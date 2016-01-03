using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Globalization;
using VV.DataObjects;
using VV.Web.DataAccess;
using VV.Web.Models;
using VV.Proxy;
using VV.Web.Server;
using VV.Web.Server.DataModels;
using Marvin.JsonPatch;
using System.Net;
using System.Web.Http.Routing;

namespace VV.Web.Api
{
    [Authorize]
    [RoutePrefix("api/v1/users")]
    public class UsersApiController : BaseApiController
    {
        const int PAGE_SIZE = 50;

        EnrollmentServer enrollmentServer;
        public UsersApiController(IDataAccess dataAccess, IBioConnectAPIProxy proxy) : base(dataAccess, proxy)
        {
            enrollmentServer = new EnrollmentServer(proxy);
        }

        /// <summary>
        /// Get list of users
        /// </summary>
        /// <param name="name">name filter, partial match, case insensitive</param>
        /// <param name="isactive">active status filter</param>
        /// <param name="page">page number</param>
        /// <param name="pagesize">page size</param>
        /// <returns></returns>
        /// <security></security>
        /// <response code="200">Ok</response>
        /// <response code="500">Internal Server Error</response>
        [Route("", Name ="Users")]
        [HttpGet]
        [ResponseType(typeof(List<UsersModel>))]
        public IHttpActionResult Get([FromUri] string name = null, [FromUri] bool? isactive = null, [FromUri] int page = 0, [FromUri] int pagesize = PAGE_SIZE)
        {
            try
            {
                List<UsersDataObject> userDOList = dataAccess.GetUserList("");
                if(name != null)
                {
                    userDOList = userDOList.Where(x => CultureInfo.CurrentCulture.CompareInfo.IndexOf(x.Name,name,CompareOptions.IgnoreCase) >= 0).ToList();
                }
                if(isactive != null)
                {
                    userDOList = userDOList.Where(x => x.IsActive == isactive).ToList();
                }

                var result = userDOList.Select(x => modelFactory.Create(x));

                int totalcount = result.Count();
                int pagecount = totalcount > 0 ? (int)Math.Ceiling(totalcount / (double)pagesize) : 0;

                result = result.Skip(page * pagesize)
                               .Take(pagesize);

                var response = Request.CreateResponse(result);

                return new OkActionResultWithPagingHeaders("Users", response, page, pagesize, pagecount, totalcount);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get user with matching External ID
        /// </summary>
        /// <param name="externalId">User External ID</param>
        /// <response code="200">Ok</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Route("{externalId}", Name = "User")]
        [HttpGet]
        [ResponseType(typeof(UsersModel))]
        public IHttpActionResult Get(string externalId)
        {
            try
            {
                UsersDataObject userDO = dataAccess.GetUserByExternalID(externalId);
                if (userDO == null) return NotFound();
                return Ok(modelFactory.Create(userDO));
            }
            catch
            {
                return InternalServerError();
            }
        }


        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="model">User Model</param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [Route("")]
        [Authorize(Roles ="Admin")]
        [HttpPost]
        [ResponseType(typeof(UsersModel))]
        public IHttpActionResult Post([FromBody]UsersModel model)
        {
            try
            {
                int id = dataAccess.InsertUser(model.ExternalID, model.Name, false);
                if (id == -1) return BadRequest("Error saving user");

                UsersDataObject userDO = dataAccess.GetUserByID(id);

                return CreatedAtRoute<UsersModel>("User", new { id = id }, modelFactory.Create(userDO));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// start synchronization process of ACM users
        /// </summary>
        /// <param name="changesSince">Starting datetime of sync process, format yyyy-MM-dd HH:mm:ss</param>
        /// <response code = "202">Accepted</response >
        /// <response code="500">Internal Server Error</response>
        [Route("synchronize")]
        [Authorize(Roles ="Admin")]
        [HttpPost]
        [ResponseType(typeof(string))]
        public IHttpActionResult SyncUsers(DateTime changesSince)
        {
            try
            {
                ClaimsPrincipal user = Request.GetRequestContext().Principal as ClaimsPrincipal;
                Claim username = user.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault();
                bioConnectAPIProxy.SyncUsers(changesSince, username.Value, ClientIP);
                return Content(System.Net.HttpStatusCode.Accepted, String.Format("Synchronization in process for users since {0}", changesSince));
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Patch a user
        /// </summary>
        /// <param name="externalId">User External ID</param>
        /// <param name="userModelPatchDoc">
        /// op:replace 
        /// path:name 
        /// value:notnullorempty</param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Route("{externalId}")]
        [Authorize(Roles = "Admin")]
        [HttpPatch]
        [ResponseType(typeof(UsersModel))]
        public IHttpActionResult Patch(string externalId, [FromBody]Marvin.JsonPatch.JsonPatchDocument<UsersModel> userModelPatchDoc)
        {
            try
            {
                UsersDataObject userDO = dataAccess.GetUserByExternalID(externalId);
                if (userDO == null) return NotFound();

                UsersModel m = modelFactory.Create(userDO);

                if (userModelPatchDoc.Operations.Any(x => x.OperationType != Marvin.JsonPatch.Operations.OperationType.Replace
                                                                 || !(x.path == "name")
                                                                 || String.IsNullOrEmpty(x.value.ToString())))
                {
                    return BadRequest("Patch only support op:replace path:name value:notnullorempty");
                }

                userModelPatchDoc.ApplyTo(m);

                userDO = modelFactory.Parse(m);

                dataAccess.UpdateUser(userDO);

                return Ok(m);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="externalId">User External ID</param>
        /// <response code="204">No Content</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Route("{externalId}")]
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IHttpActionResult Delete(string externalId)
        {
            try
            {
                UsersDataObject userDO = dataAccess.GetUserByExternalID(externalId);
                if (userDO == null) return NotFound();

                dataAccess.DeleteUserByExternalID(externalId);
                return new NoContentActionResult(Request.CreateResponse());
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Register user with login credentials
        /// </summary>
        /// <param name="externalId">User External ID</param>
        /// <param name="model">User Register Model</param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Route("{externalId}/register")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IHttpActionResult Register(string externalId, [FromBody] UsersRegisterModel model)
        {
            try
            {
                UsersDataObject usersDO = dataAccess.GetUserByExternalID(externalId);
                if (usersDO == null) return NotFound();

                //var principal = Thread.CurrentPrincipal;
                ClaimsPrincipal user = Request.GetRequestContext().Principal as ClaimsPrincipal;
                if (!user.HasClaim(x => x.Type == ClaimTypes.Name)) return BadRequest("Invalid authentication, please request another access token");

                Claim username = user.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault();
                Proxy.BioConnectAPI.SecurityTokenDto authorizedToken = bioConnectAPIProxy.RetrieveSecurityTokenByUsername(username.Value);
                if (authorizedToken == null) return BadRequest("Invalid authentication, please request another access token");


                Proxy.BioConnectAPI.SecurityTokenDto newToken = new Proxy.BioConnectAPI.SecurityTokenDto
                {
                    Password = model.Password,
                    UserName = model.UserName,
                    UserID = usersDO.Id,
                    Level = model.Role,
                    Locations = new string[] { "Default" }
                };

                bioConnectAPIProxy.SaveSecurityToken(newToken, authorizedToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Start the process to enroll user's finger templates
        /// </summary>
        /// <param name="externalId">User External ID</param>
        /// <param name="model">User Enroll Model</param>
        /// <response code="202">Accepted</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Route("{externalId}/enroll")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ResponseType(typeof(string))]
        public IHttpActionResult Enroll(string externalId, [FromBody] UsersEnrollModel model)
        {
            try
            {
                UsersDataObject usersDO = dataAccess.GetUserByExternalID(externalId);
                if (usersDO == null) return NotFound();

                ClaimsPrincipal user = Request.GetRequestContext().Principal as ClaimsPrincipal;
                if (!user.HasClaim(x => x.Type == ClaimTypes.Name)) return BadRequest("Invalid authentication, please request another access token");

                Claim username = user.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault();
                Proxy.BioConnectAPI.SecurityTokenDto authorizedToken = bioConnectAPIProxy.RetrieveSecurityTokenByUsername(username.Value);
                if(authorizedToken == null) return BadRequest("Invalid authentication, please request another access token");          

                EnrollDataModel dataModel = new EnrollDataModel
                {
                    readerID = model.deviceID,
                    userDO = usersDO,
                    enrollQuality = model.enrollQuality,
                    fingerIndex = model.fingerIndex,
                    callbackUrl = model.callbackUrl,
                    authorizedToken = authorizedToken
                };

                enrollmentServer.Enqueue(dataModel);
                return Content(System.Net.HttpStatusCode.Accepted, String.Format("Starting enrollment process for user: {0}", externalId));
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get list of cards associated with user
        /// </summary>
        /// <param name="externalId">User External ID</param>
        /// <response code="200">Ok</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Route("{externalId}/cards")]
        [HttpGet]
        [ResponseType(typeof(List<CardsModel>))]
        public IHttpActionResult GetCards(string externalId)
        {
            try
            {
                UsersDataObject userDO = dataAccess.GetUserByExternalID(externalId);
                if (userDO == null) return NotFound();

                return Ok(userDO.Cards.Select(x => modelFactory.Create(externalId, x)));
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get card detail
        /// </summary>
        /// <param name="externalId">User External ID</param>
        /// <param name="cardExternalId">Card External ID</param>
        /// <response code="200">Ok</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Route("{externalId}/cards/{cardExternalId}", Name = "Card")]
        [HttpGet]
        [ResponseType(typeof(CardsModel))]
        public IHttpActionResult GetCards(string externalId, string cardExternalId)
        {
            try
            {
                UsersDataObject userDO = dataAccess.GetUserByExternalID(externalId);
                if (userDO == null) return NotFound();

                CardDataObject cardDO = userDO.Cards.Where(x => x.ExternalId == cardExternalId).FirstOrDefault();
                if (cardDO == null) return NotFound();

                return Ok(modelFactory.Create(externalId, cardDO));
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Add new card to user
        /// </summary>
        /// <param name="externalId">User External ID</param>
        /// <param name="model">Cards Model</param>
        /// <response code="200">Ok</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Route("{externalId}/cards")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ResponseType(typeof(CardsModel))]
        public IHttpActionResult PostCards(string externalId, [FromBody] CardsModel model)
        {
            try
            {
                UsersDataObject userDO = dataAccess.GetUserByExternalID(externalId);
                if (userDO == null) return NotFound();

                CardDataObject c = modelFactory.Parse(model);

                dataAccess.InsertUserCard(c.ExternalId, c.BadgeNumber, c.IsActive, c.PIN, userDO.Id);

                userDO = dataAccess.GetUserByExternalID(externalId);
                CardDataObject cardDO = userDO.Cards.Where(x => x.ExternalId == model.ExternalId).FirstOrDefault();
                if (cardDO == null) return NotFound();

                return CreatedAtRoute<CardsModel>("Cards", new { externalId = externalId, cardExternalId = cardDO.ExternalId }, modelFactory.Create(externalId, cardDO));
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Patch a card
        /// </summary>
        /// <param name="externalId">User External ID</param>
        /// <param name="cardExternalId">Card External ID</param>
        /// <param name="cardsModelPatchDoc">
        /// op:replace 
        /// path:badgenumber
        ///     |isactive
        ///     |pin|priority
        ///     |isbypass
        ///     |facilitycode
        /// value:notnullorempty
        /// </param>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Route("{externalId}/cards/{cardExternalId}")]
        [Authorize(Roles = "Admin")]
        [HttpPatch]
        [ResponseType(typeof(CardsModel))]
        public IHttpActionResult PatchCard(string externalId, string cardExternalId, [FromBody] JsonPatchDocument<CardsModel> cardsModelPatchDoc)
        {
            try
            {
                UsersDataObject userDO = dataAccess.GetUserByExternalID(externalId);
                if (userDO == null) return NotFound();

                CardDataObject cardDO = userDO.Cards.Where(x => x.ExternalId == cardExternalId).FirstOrDefault();
                if (cardDO == null) return NotFound();

                CardsModel m = modelFactory.Create(externalId, cardDO);

                if (cardsModelPatchDoc.Operations.Any(x => x.OperationType != Marvin.JsonPatch.Operations.OperationType.Replace
                                                                 || !(x.path == "badgenumber" || x.path == "isactive" || x.path == "pin" || x.path == "priority" || x.path == "isbypass" || x.path == "facilitycode")
                                                                 || String.IsNullOrEmpty(x.value.ToString())))
                {
                    return BadRequest("Patch only support op:replace path:badgenumber|isactive|pin value:notnullorempty");
                }

                cardsModelPatchDoc.ApplyTo(m);

                cardDO = modelFactory.Parse(m);

                dataAccess.UpdateCard(cardDO);

                return Ok(m);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Delete a card
        /// </summary>
        /// <param name="externalId">User External ID</param>
        /// <param name="cardExternalId">Card External ID</param>
        /// <response code="204">No Content</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Route("{externalId}/cards/{cardExternalId}")]
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [ResponseType(null)]
        public IHttpActionResult DeleteCard(string externalId, string cardExternalId)
        {
            try
            {
                UsersDataObject userDO = dataAccess.GetUserByExternalID(externalId);
                if (userDO == null) return NotFound();

                CardDataObject cardDO = userDO.Cards.Where(x => x.ExternalId == cardExternalId).FirstOrDefault();
                if (cardDO == null) return NotFound();

                dataAccess.DeleteCardByExternalID(cardExternalId);

                return new NoContentActionResult(Request.CreateResponse());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
