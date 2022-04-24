using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modules.Framework
{
    public class ModuleConfigContainer
    {
        static ModuleConfigContainer()

           {

              Instance = new ModuleConfigDictionary();

          }

         internal static IModuleConfigDictionary Instance { get; set; }
        
        public static void Register(ModuleConfiguration item)
          {

             Instance.Register(item);

          }
        

         public static IEnumerable<ModuleConfiguration> GetConfig()
         {

             return Instance.GetConfigs();

         }
    }
}