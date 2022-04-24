using System;
using System.Collections.Generic;
using System.Text;

namespace EbSite.Base.BLL
{
    /// <summary>
    /// 所有二次开发模块业务层都要继承此基类
    /// </summary>
    /// <typeparam name="TYPE"></typeparam>
    /// <typeparam name="KEY"></typeparam>
    [Serializable]
    public abstract class BLLBaseModules<TYPE, KEY> : BllBase<TYPE, KEY>
    {
        //protected Data.Interface.IDataProviderOA dal = Data.Interface.DataProviderOA.GetInstance();
    }
}
