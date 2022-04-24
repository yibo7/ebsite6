using EbSite.Base.Entity;

namespace EbSite.Base.Modules
{
    using EbSite.Base.BLL;
    using System;

    [Serializable]
    public abstract class BLLBaseModules<TYPE, KEY> : BllBase<TYPE, KEY> where TYPE : EntityBase<TYPE, KEY>, new()
    {
        protected BLLBaseModules()
        {

        }
        public Host HostApi
        {
            get
            {
               return Host.Instance;
            }
        }
        

    }
}

