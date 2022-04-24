using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Base.BLL
{
    [Serializable]
    public abstract class BllBase<TYPE, KEY> : Base<TYPE, KEY>
    {
        protected Data.Interface.IDataProviderCms dal;

        protected BllBase()
        {
            this.dal = Data.Interface.DbProviderCms.GetInstance();
            
        }
    }

}
