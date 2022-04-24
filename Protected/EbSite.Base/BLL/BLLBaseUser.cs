using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Data.User.Interface;

namespace EbSite.Base.BLL
{
    [Serializable]
    public abstract class BLLBaseUser<TYPE, KEY> : Base<TYPE, KEY>
    {
        protected IDataProviderUser dal;

        protected BLLBaseUser()
        {
            this.dal = DbProviderUser.GetInstance();
            
        }
    }

    ///// <summary>
    ///// 本系统所有业务层都要继承此基类
    ///// </summary>
    ///// <typeparam name="TYPE"></typeparam>
    ///// <typeparam name="KEY"></typeparam>
    //[Serializable]
    //public abstract class BLLBaseCms<TYPE, KEY> : BllBase<TYPE, KEY>
    //{
    //    protected Data.Interface.IDataProviderCms dal = Data.Interface.DbProviderCms.GetInstance();
    //}
}
