using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;

namespace Modules.Framework
{
    public class ModuleLoader
    {

        public static List<ModuleAttribute> Modules = new List<ModuleAttribute>();

        public static void Initialize(string folder = "~/Modules")
         {
             Modules.Clear();
             LoadAssemblies(HostingEnvironment.MapPath(folder));

             //LoadConfig(folder);

         }
          // private static void LoadConfig(string folder, string defaultConfigName="*.config")
          // {

          //     var directory = new DirectoryInfo(HostingEnvironment.MapPath(folder));

          //     var configFiles = directory.GetFiles(defaultConfigName, SearchOption.AllDirectories).ToList();

          //      if (configFiles.Count == 0) return;
     

          //   foreach (var configFile in configFiles.OrderBy(s => s.Name))
          //   {

          //       ModuleConfigContainer.Register(new ModuleConfiguration(configFile.FullName));

          //  }

          //}

         private static void LoadAssemblies(string folder)

         {

             var directory = new DirectoryInfo(folder);

               List<FileInfo> binFiles = directory.GetFiles("*.dll", SearchOption.AllDirectories).ToList();

               if (binFiles.Count == 0) return;

   

             foreach (FileInfo plug in binFiles)

              {

                  //running in full trust

                   //************

                  //if (GetCurrentTrustLevel() != AspNetHostingPermissionLevel.Unrestricted)

                   //set in web.config, probing to plugin\temp and copy all to that folder

                 //************************

                 var shadowCopyPlugFolder = new DirectoryInfo(AppDomain.CurrentDomain.DynamicDirectory);

                 var shadowCopiedPlug = new FileInfo(Path.Combine(shadowCopyPlugFolder.FullName, plug.Name));
                  


                   File.Copy(plug.FullName, shadowCopiedPlug.FullName, true); //TODO: Exception handling here...

                   var shadowCopiedAssembly = Assembly.Load(AssemblyName.GetAssemblyName(shadowCopiedPlug.FullName));
                   ModuleAttribute sea = null;
                   foreach (Module m in shadowCopiedAssembly.GetModules())
                  {
                      foreach (Type t in m.FindTypes(Module.FilterTypeName, "*")) //采用过滤器进行类名过滤
                      {
                          if (t.Name == "SettingInfo")
                          {
                              
                              foreach (object arr in t.GetCustomAttributes(typeof(ModuleAttribute), true))
                              {
                                  sea = (ModuleAttribute)arr;
                                 
                                  break; //目前一个类库只支持一个
                              }

                               
                              //SettingBase ist = Activator.CreateInstance(t) as SettingBase;

                              //if (!Equals(ist, null))
                              //{
                                  //IniParser iniParser = new IniParser(string.Concat(AppDomain.CurrentDomain.BaseDirectory, @"\conf.ini"));
                                  //ist.Init();
                              //}
                              //else
                              //{
                              //    Debug.Print("载入模块配置出错！");
                              //}
                          }
                          
                      }
                  }

                   if (!Equals(sea, null))
                   { 
                       
                       BuildManager.AddReferencedAssembly(shadowCopiedAssembly);
                       //载入视图，否则会找不到视图
                       BoC.Web.Mvc.PrecompiledViews.ApplicationPartRegistry.Register(shadowCopiedAssembly);
                         
                       Modules.Add(sea);

                       SettingBase ist = shadowCopiedAssembly.CreateInstance("SettingInfo") as SettingBase;
                     

                   }
                   

              }

          }

    
   

      }
    
}