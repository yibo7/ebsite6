using System;
using System.Collections.Generic;

using System.Web;
using EbSite.Base.Entity;
using EbSite.Base.Modules;


namespace EbSite.Modules.UserBaseInfo.ModuleCore.BLL.Base
{
    abstract public class BLLBase<TYPE, KEY> : BLLBaseModules<TYPE, KEY> where TYPE : EntityBase<TYPE, KEY>, new()
    {
        //protected static DALInterface.IDataProvider dalHelper = new DAL.SqlServer.DataProvider();
    }
}