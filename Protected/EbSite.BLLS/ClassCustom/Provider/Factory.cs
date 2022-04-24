using System;
using System.Collections.Generic;
using System.Data;
using EbSite.Entity;
namespace EbSite.BLL.ClassCustom.Provider
{
	/// <summary>
	/// 业务逻辑类CountData 的摘要说明。
	/// </summary>
    public abstract class Factory
	{
        public static IClassCustom ModelCtrl()
        {
            return new XMLProvider.ClassCustom("ModelCtrl");
        }
        //public static IClassCustom PageTemp()
        //{
        //    return new XMLProvider.ClassCustom("PageTemp");
        //}
        public static IClassCustom Widget()
        {
            return new XMLProvider.ClassCustom("Widget");
        }
	}
}

