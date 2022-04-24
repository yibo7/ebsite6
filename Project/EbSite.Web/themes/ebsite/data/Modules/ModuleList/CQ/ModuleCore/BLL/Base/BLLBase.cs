using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.BLL;
using EbSite.Base.Modules;
using EbSite.Base.Entity;

namespace EbSite.Modules.CQ.ModuleCore.BLL.Base
{
    abstract public class BLLBase<TYPE, KEY> : EbSite.Base.Modules.BLLBaseModules<TYPE, KEY> where TYPE : EntityBase<TYPE, KEY>, new()
    {
       
		protected static DAL.Access.SiteTools dalHelper = new DAL.Access.SiteTools(); 

        //��������������ԭϵͳ�йأ���ֱ�ӵ��� dal.������ԭ���ݲ�ʵ��
    }
}