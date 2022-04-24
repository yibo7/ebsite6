using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modules.Framework
{
    public interface IModuleConfigDictionary
    {
        void Register(ModuleConfiguration item);
        IEnumerable<ModuleConfiguration> GetConfigs();
    }
}