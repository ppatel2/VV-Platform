using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using VV.Utilities;

namespace VV.Web.Engine
{
     class Program
     {
          static void Main(string[] args)
          {
               StartOptions startOptions = new StartOptions();
               startOptions.Urls.Add("http://+:8090");

               try
               {
                    using (WebApp.Start<Startup>(startOptions))
                    {
                         Logger.Log.InfoFormat("Started host!!!");
                         Console.ReadKey();
                         Logger.Log.Debug("SHUT DOWN!");

                    }

               }
               catch (Exception ex)
               {
                    Logger.LogException(ex, "Crashed!");

               }
               Console.Read();
          }
     }
}
