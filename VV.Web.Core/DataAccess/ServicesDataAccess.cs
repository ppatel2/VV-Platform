using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Web;

namespace VV.Web.Core.DataAccess
{
     public class ServicesDataAccess
     {

          public Dictionary<string, string> Services { get; set; }

          public ServicesDataAccess()
          {
               Services = GetServices();
          }

          private Dictionary<string, string> GetServices()
          {
               var result = new Dictionary<string, string>();
               List<string> services = new List<string>{ "BiometricServiceHost", "BiometricServiceApiHost", "BiostarSdkHost", "BiometricDeviceService", "BioConnectApiHost" };

               foreach (var service in services)
               {
                    result.Add(service, GetStatus(service));
               }
               return result;
          }

          private string GetStatus(string service)
          {
               try
               {

                    ServiceController sc = new ServiceController(service);

                    switch (sc.Status)
                    {
                         case ServiceControllerStatus.Running:
                              return "Running";
                         case ServiceControllerStatus.Stopped:
                              return "Stopped";
                         case ServiceControllerStatus.Paused:
                              return "Paused";
                         case ServiceControllerStatus.StopPending:
                              return "Stopping";
                         case ServiceControllerStatus.StartPending:
                              return "Starting";
                         default:
                              return "Status Changing";
                    }
               }
               catch (Exception ae)
               {
                    return "Not Found!!!";
               }

          }

          public string StartService(string service)
          {
               try
               {
                    ServiceController sc = new ServiceController(service);

                    if (sc.Status == ServiceControllerStatus.Stopped)
                    {
                         sc.Start();
                         return "Start Command sent!";
                    }
                    return "Service is not stopped!";
               }
               catch (Exception ae)
               {
                    return "Failed!!! Please check Event Viewer.";
               }
          }

          public string StopService(string service)
          {
               try
               {
                    ServiceController sc = new ServiceController(service);

                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                         sc.Stop();
                         return "Stop Command sent!";
                    }
                    return "Service is not running!";
               }
               catch (Exception ae)
               {
                    return "Failed!!! Please check Event Viewer.";
               }
          }

     }
}