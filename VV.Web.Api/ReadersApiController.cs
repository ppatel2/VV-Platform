using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VV.DataObjects;
using VV.Web.DataAccess;
using VV.Web.Models;
using VV.Proxy;
using System.Security.Claims;

namespace VV.Web.Api
{
    [Authorize]
    [RoutePrefix("api/v1/readers")]
    public class ReadersApiController : BaseApiController
    {
        bool isDigitusEnabled;
        const int PAGE_SIZE = 50;

        public ReadersApiController(IDataAccess dataAccess, IBioConnectAPIProxy proxy):base(dataAccess, proxy)
        {
            isDigitusEnabled = bioConnectAPIProxy.GetDigitusStatus();
        }

        /// <summary>
        /// Start synchronization process for online devices
        /// </summary>
        /// <param name="location">location filter, exact match</param>
        /// <response code="202">Accepted</response>
        /// <response code="500">Internal Server Error</response>
        [Route("synchronize")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ResponseType(typeof(string))]
        public IHttpActionResult SyncReaders([FromUri]string location = null)
        {
            try
            {
                ClaimsPrincipal user = Request.GetRequestContext().Principal as ClaimsPrincipal;
                Claim username = user.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault();
                bioConnectAPIProxy.SyncReaders(username.Value, ClientIP, location);

                return Content(System.Net.HttpStatusCode.Accepted, String.Format("Synchronization in progress for {0} devices", location == null ? "all" : location));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get list of readers
        /// </summary>
        /// <param name="isonline">online status filter</param>
        /// <param name="location">location filter, exact match, case insensitive</param>
        /// <param name="ipaddress">ipaddress filter, partial match</param>
        /// <param name="page">page number</param>
        /// <param name="pagesize">page size</param>
        /// <returns></returns>
        /// <response code="200">Ok</response>
        /// <response code="500">Internal Server Error</response>
        [Route("suprema", Name ="SupremaReaders")]
        [HttpGet]
        [ResponseType(typeof(List<ReadersModel>))]
        public IHttpActionResult Get([FromUri]bool? isonline = null, [FromUri]string location = null, [FromUri]string ipaddress = null, [FromUri] int page = 0, [FromUri] int pagesize = PAGE_SIZE)
        {
            try
            {
                List<ReadersStubDataObject> readersStubDOList = dataAccess.GetReadersStubs("");
                if(isonline != null)
                {
                    readersStubDOList = readersStubDOList.Where(x => x.Online == isonline).ToList();
                }
                if(location != null)
                {
                    readersStubDOList = readersStubDOList.Where(x => String.Equals(x.Location, location, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                if(ipaddress != null)
                {
                    readersStubDOList = readersStubDOList.Where(x => x.IPAddress.Contains(ipaddress)).ToList();
                }

                var result = readersStubDOList.Select(x => modelFactory.Create(x));

                int totalcount = result.Count();
                int pagecount = totalcount > 0 ? (int)Math.Ceiling(totalcount / (double)pagesize) : 0;

                result = result.Skip(page * pagesize)
                               .Take(pagesize);

                var response = Request.CreateResponse(result);

                return new OkActionResultWithPagingHeaders("SupremaReaders", response, page, pagesize, pagecount, totalcount);
                //return Ok(readersStubDOList.Select(x => modelFactory.Create(x)));
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get reader with matching device ID
        /// </summary>
        /// <param name="deviceId"></param>
        /// <response code="200">Ok</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Route("suprema/{deviceId}", Name = "SupremaReader")]
        [HttpGet]
        [ResponseType(typeof(ReadersModel))]
        public IHttpActionResult Get(long deviceId)
        {
            try
            {
                ReadersDataObject readerDO = dataAccess.GetReaderDetailsByDeviceID(deviceId);
                if (readerDO == null) return NotFound();
                return Ok(modelFactory.Create(readerDO));
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get system digitus status
        /// </summary>
        /// <returns></returns>
        [Route("digitus")]
        [HttpGet]
        [ResponseType(typeof(DigitusStatusModel))]
        public IHttpActionResult GetStatus()
        {
            try
            {
                DigitusStatusModel model = new DigitusStatusModel
                {
                    IsEnabled = isDigitusEnabled
                };
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get list of current digitus connections
        /// </summary>
        /// <returns></returns>
        [Route("digitus/connections")]
        [HttpGet]
        [ResponseType(typeof(List<DigitusConnectionModel>))]
        public IHttpActionResult GetConnections()
        {
            try
            {
                if (!isDigitusEnabled) return new ForbiddenActionResult(Request.CreateResponse());

                return Ok(bioConnectAPIProxy.GetDigitusConnections().Select(x => modelFactory.Create(x)));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get list of device groups
        /// </summary>
        /// <returns></returns>
        [Route("digitus/devicegroups")]
        [HttpGet]
        [ResponseType(typeof(List<DigitusDeviceGroupModel>))]
        public IHttpActionResult GetDeviceGroups()
        {
            try
            {
                if (!isDigitusEnabled) return new ForbiddenActionResult(Request.CreateResponse());

                return Ok(bioConnectAPIProxy.GetDigitusDeviceGroups().Select(x => modelFactory.Create(x)));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get list of bus controllers
        /// </summary>
        /// <param name="devicegroupguid">Device Group Guid filter</param>
        /// <returns></returns>
        [Route("digitus/bus")]
        [HttpGet]
        [ResponseType(typeof(List<DigitusControllerModel>))]
        public IHttpActionResult GetBusControllers([FromUri]string devicegroupguid = null)
        {
            try
            {
                if (!isDigitusEnabled) return new ForbiddenActionResult(Request.CreateResponse());

                if (!String.IsNullOrWhiteSpace(devicegroupguid))
                {
                    Guid tmp;
                    if (!Guid.TryParse(devicegroupguid, out tmp)) return BadRequest("error parsing provided device group guid");
                }

                return Ok(bioConnectAPIProxy.GetDigitusBusControllers(devicegroupguid));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get list of sentry controllers
        /// </summary>
        /// <param name="devicegroupguid">Device Group Guid filter</param>
        /// <returns></returns>
        [Route("digitus/sentry")]
        [HttpGet]
        [ResponseType(typeof(List<DigitusControllerModel>))]
        public IHttpActionResult GetSentryControllers([FromUri]string devicegroupguid = null)
        {
            try
            {
                if (!isDigitusEnabled) return new ForbiddenActionResult(Request.CreateResponse());

                if (!String.IsNullOrWhiteSpace(devicegroupguid))
                {
                    Guid tmp;
                    if (!Guid.TryParse(devicegroupguid, out tmp)) return BadRequest("error parsing device group guid");
                }

                return Ok(bioConnectAPIProxy.GetDigitusSentryControllers(devicegroupguid));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get list of bus controller nodes
        /// </summary>
        /// <param name="controllerguid">Controller Guid filter</param>
        /// <returns></returns>
        [Route("digitus/bus/{controllerguid}/nodes")]
        [HttpGet]
        [ResponseType(typeof(List<DigitusControllerNodeModel>))]
        public IHttpActionResult GetControllerNodes(string controllerguid)
        {
            try
            {
                if (!isDigitusEnabled) return new ForbiddenActionResult(Request.CreateResponse());

                Guid tmp;
                if (!Guid.TryParse(controllerguid, out tmp)) return BadRequest("error parsing controller guid");

                return Ok(bioConnectAPIProxy.GetDigitusBusControllerNodes(controllerguid).Select(x => modelFactory.Create(x)));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get list of enlines
        /// </summary>
        /// <param name="controllerguid">Controller Guid filter</param>
        /// <returns></returns>
        [Route("digitus/enlines")]
        [HttpGet]
        [ResponseType(typeof(List<DigitusEnlineModel>))]
        public IHttpActionResult GetEnlines([FromUri]string controllerguid = null)
        {
            try
            {
                if (!isDigitusEnabled) return new ForbiddenActionResult(Request.CreateResponse());

                if (!String.IsNullOrWhiteSpace(controllerguid))
                {
                    Guid tmp;
                    if (!Guid.TryParse(controllerguid, out tmp)) return BadRequest("error parsing controller guid");
                }

                return Ok(bioConnectAPIProxy.GetDigitusBusEnlines(controllerguid).Select(x => modelFactory.Create(x)));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get list of devices
        /// </summary>
        /// <param name="controllerguid">Controller Guid filter</param>
        /// <param name="buscontrollernode">Controller Node filter</param>
        /// <param name="devicegroupguid">Device Group Guid filter</param>
        /// <returns></returns>
        [Route("digitus/devices")]
        [HttpGet]
        [ResponseType(typeof(List<DigitusDeviceModel>))]
        public IHttpActionResult GetDevices([FromUri]string controllerguid = null, [FromUri] int buscontrollernode = 0, [FromUri]string devicegroupguid = null)
        {
            try
            {
                if (!isDigitusEnabled) return new ForbiddenActionResult(Request.CreateResponse());

                if (!String.IsNullOrWhiteSpace(controllerguid))
                {
                    Guid tmp;
                    if (!Guid.TryParse(controllerguid, out tmp)) return BadRequest("error parsing controller guid");
                }

                if (!String.IsNullOrWhiteSpace(devicegroupguid))
                {
                    Guid tmp;
                    if (!Guid.TryParse(devicegroupguid, out tmp)) return BadRequest("error parsing device group guid");
                }

                return Ok(bioConnectAPIProxy.GetDigitusDevices(controllerguid, buscontrollernode, devicegroupguid).Select(x => modelFactory.Create(x)));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get list of device schedules
        /// </summary>
        /// <returns></returns>
        [Route("digitus/deviceschedules")]
        [HttpGet]
        [ResponseType(typeof(List<DigitusDeviceScheduleModel>))]
        public IHttpActionResult GetDeviceSchedules()
        {
            try
            {
                if (!isDigitusEnabled) return new ForbiddenActionResult(Request.CreateResponse());

                List<DigitusDeviceScheduleModel> list = bioConnectAPIProxy.GetDigitusDeviceSchedules().Select(x => modelFactory.Create(x)).ToList();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get list of timebands
        /// </summary>
        /// <returns></returns>
        [Route("digitus/timebands")]
        [HttpGet]
        [ResponseType(typeof(List<DigitusTimebandModel>))]
        public IHttpActionResult GetTimebands()
        {
            try
            {
                if (!isDigitusEnabled) return new ForbiddenActionResult(Request.CreateResponse());

                return Ok(bioConnectAPIProxy.GetDigitusTimebands().Select(x => modelFactory.Create(x)));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get list of events
        /// </summary>
        /// <returns></returns>
        [Route("digitus/events")]
        [HttpGet]
        [ResponseType(typeof(List<DigitusEventModel>))]
        public IHttpActionResult GetEvents()
        {
            try
            {
                if (!isDigitusEnabled) return new ForbiddenActionResult(Request.CreateResponse());

                return Ok(bioConnectAPIProxy.GetDigitusEvents().Select(x => modelFactory.Create(x)));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get list of alarms
        /// </summary>
        /// <returns></returns>
        [Route("digitus/alarms")]
        [HttpGet]
        [ResponseType(typeof(List<DigitusAlarmModel>))]
        public IHttpActionResult GetAlarms()
        {
            try
            {
                if (!isDigitusEnabled) return new ForbiddenActionResult(Request.CreateResponse());

                return Ok(bioConnectAPIProxy.GetDigitusAlarms().Select(x => modelFactory.Create(x)));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
