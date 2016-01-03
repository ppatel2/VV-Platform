using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace VV.Web.Core.DataAccess
{
     public class ConfigDataAccess
     {

          public Dictionary<string,string> ApplicationSettings { get; set; }
          public XmlDocument ConfigurationFile { get; set; } 

          public ConfigurationSection Services { get; set; }

          public ConfigDataAccess()
          {
               this.ApplicationSettings = ParseConfigFile();
               this.Services = ParseConfigFile("system.serviceModel");
               this.ConfigurationFile = ParseConfigFileToXml();

          }

          private XmlDocument ParseConfigFileToXml()
          {
               var xmlDoc = new XmlDocument();
               xmlDoc.Load(PathToConfigFile());
               return xmlDoc;
          }

          private ConfigurationSection ParseConfigFile(string sectionName)
          {
               var config = LoadConfigFile();
               return config.GetSection("system.serviceModel");
          }

          private Dictionary<string, string> ParseConfigFile()
          {
               Configuration config = LoadConfigFile();
               Dictionary<string, string> results = new Dictionary<string, string>();
               foreach (KeyValueConfigurationElement item in config.AppSettings.Settings)
               {
                    results.Add(item.Key, item.Value.ToString());
               }
               return results;
          }

          private static Configuration LoadConfigFile()
          {
               string filePath = PathToConfigFile();
               ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
               configMap.ExeConfigFilename = filePath; //base.PathToConfig;
               return ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
          }

          private static string PathToConfigFile()
          {
               var path = ConfigurationManager.AppSettings.AllKeys.Contains("VV.Configuration.Path") ? ConfigurationManager.AppSettings["VV.Configuration.Path"] : @"C:\Program Files (x86)\VV Systems\Service";
               return path + @"VV.Service.exe.config";
          }

          public string SaveConfigFile()
          {
               try
               {
                    this.ConfigurationFile.Save(PathToConfigFile());
                    return "Saved Successfully!!";
               }
               catch (Exception ex)
               {
                    return ex.Message;
               }
          }

     }
}