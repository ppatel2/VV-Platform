using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.ServiceModel.Channels;
using VV.DataObjects;
using VV.Web.Models;
using VV.Web.DataAccess;
using VV.Proxy;
using Microsoft.Owin;

namespace VV.Web.Api
{
    public abstract class BaseApiController : ApiController
    {
        protected IBioConnectAPIProxy bioConnectAPIProxy;
        protected IDataAccess dataAccess;
        private ModelFactory _modelFactory;

        public BaseApiController(IDataAccess dataAccess, IBioConnectAPIProxy proxy)
        {
            this.dataAccess = dataAccess;
            this.bioConnectAPIProxy = proxy;
        }

        protected ModelFactory modelFactory
        {
            get
            {
                if (_modelFactory == null) _modelFactory = new ModelFactory(this.Request);
                return _modelFactory;
            }
        }

        public string ClientIP
        {
            get
            {
                return GetClientIp();
            }
        }

        private string GetClientIp(HttpRequestMessage request = null)
        {
            request = request ?? Request;
            
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            else if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            if (request.Properties.ContainsKey("MS_OwinContext"))
            {
                return ((OwinContext)request.Properties["MS_OwinContext"]).Request.RemoteIpAddress;
            }
            else
            {
                return null;
            }
        }
    }
}
