using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.BLL;
using EbSite.Base.Modules;
using EbSite.Base.Entity;

namespace EbSite.Modules.Wenda.ModuleCore.BLL.Base
{
    abstract public class BLLBase<TYPE, KEY> : EbSite.Base.Modules.BLLBaseModules<TYPE, KEY> where TYPE : EntityBase<TYPE, KEY>, new()
    {
       
        protected static DALInterface.IDataProvider dalHelper
        {
            get
            {
               return DAL.DataProfile.DalFactory.DalProvider;
            }
        }

        //如果处理的数据与原系统有关，可直接调用 dal.来处理原数据层实体
    }
}