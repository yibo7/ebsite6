using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Xml.Linq;

namespace Modules.Framework
{
   public class ModuleConfiguration

       {

          public ModuleConfiguration(string filePath)

           {

              try

              {

                   var doc = XDocument.Load(filePath);

                   var root = XElement.Parse(doc.ToString());

  

                  if (!root.HasElements) return;

  

                  var module = from e in root.Descendants("module")

                               //where e.Attribute("name").Value == "xxxx"

                               select e;

   

                 if (!module.Any()) return;

  

                  ModuleName = module.FirstOrDefault().Attribute("name").Value;

  

                  var menus = from e in module.FirstOrDefault().Descendants("menu")

                              select e;

   

                  if (!menus.Any()) return;

   

              var menuitems = menus.Select(xElement => new MainMenuItemModel

                                                               {

                                                                   Id = xElement.Attribute("id").Value,

                                                                    Text = xElement.Attribute("text").Value,

                                                                   ActionName = xElement.Attribute("action").Value,

                                                                    ControllerName = xElement.Attribute("controller").Value

                                                                }).ToList();

  

                  MainMenuItems = menuitems;

             }

             catch

             {

                 //TODO: logging

              }

          }

         public string ModuleName { get; set; }

         public IEnumerable<MainMenuItemModel> MainMenuItems { get; set; }

     }
}