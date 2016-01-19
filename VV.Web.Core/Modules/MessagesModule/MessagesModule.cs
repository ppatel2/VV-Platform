using System;
using Nancy;
using Nancy.Owin;
using VV.DataObjects;
using System.Collections.Generic;
using VV.Web.DataAccess;

namespace VV.Web.Core.Modules.MessagesModule
{
    public class MessagesModule : NancyModule
    {
        public MessagesModule()
        {
            /*      Messages structure, should only return 3 at maximum and 
                        if /messages/ReadAll then return a grid view of the messages.
                <li>
                            < a href = "#" >
 
                                 < div >
 
                                     < strong > John Smith </ strong >
    
                                        < span class="pull-right text-muted">
                                        <em>Yesterday</em>
                                    </span>
                                </div>
                                <div>Lorem ipsum dolor sit amet, consectetur adipiscing elit.Pellentesque eleifend...</div>
                            </a>
                        </li>
                        <li class="divider"></li>
                        */
            Get["/pages/messages"] = _ =>
            {
                var env = Context.GetOwinEnvironment();

                if (Context.CurrentUser != null)
                {
                    var Messages = GetMessages(Context.CurrentUser.UserName);

                }
                return null;
            };
}

        private List<Messages> GetMessages(string userName)
        {
            IDataAccess da = new Web.DataAccess.DataAccess();

            List<Messages> messages = da.GetMessages(userName, 3);

            return messages;

        }
    }
}