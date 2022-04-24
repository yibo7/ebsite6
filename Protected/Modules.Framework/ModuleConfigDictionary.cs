using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modules.Framework
{
    public class ModuleConfigDictionary : IModuleConfigDictionary

        {

         private readonly Dictionary<string, ModuleConfiguration>  _configurations = new Dictionary<string, ModuleConfiguration>();

  

          public IEnumerable<ModuleConfiguration> GetConfigs()

           {

            return _configurations.Values.AsEnumerable();

        }

   

          public void Register(ModuleConfiguration item)

         {

             if(_configurations.ContainsKey(item.ModuleName))

             {

                 _configurations[item.ModuleName] = item;

           }

            else

             {

                _configurations.Add(item.ModuleName, item);

            }

       }

     }
}