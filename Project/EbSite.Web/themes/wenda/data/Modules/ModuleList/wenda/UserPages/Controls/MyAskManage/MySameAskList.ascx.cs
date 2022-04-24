using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.Wenda.ModuleCore.Entity;

namespace EbSite.Modules.Wenda.UserPages.Controls.MyAskManage
{
    public partial class MySameAskList : MPUCBaseListForUserRp
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("82c4442b-770c-4ac9-b7cb-0df6405896ef");
            }
        }
        public override string PageName
        {
            get
            {
                return "我的同问";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        //public override bool IsCloseTagsTitle
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}
        public override int OrderID
        {
            get
            {
                return 2;
            }
        }

        protected string GetModifyUrl
        {
            get
            {
                return "?box=1&t=0&id=";
            }
        }

        protected int iLoadCount = 0;
        override protected object LoadList(out int iCount)
        {
            string strsql = " userid =" + base.UserID;
            string nstr = "";
            List<ModuleCore.Entity.SameQuestion> lsSQ = ModuleCore.BLL.SameQuestion.Instance.GetListArray(0, strsql, "");
            if (lsSQ.Count > 0)
            {
                foreach (SameQuestion i in lsSQ)
                {
                    nstr += i.Cid + ",";
                }
                if (nstr.Length > 0)
                    nstr = nstr.Remove(nstr.Length - 1, 1);
            }
            string nstrsql = "";
            if (string.IsNullOrEmpty(nstr))
            {
                nstrsql = "id=0";
            }
            else
            {
                nstrsql = "id in(" + nstr + ")";
            }

            List<Entity.NewsContent> ls = Base.AppStartInit.NewsContentInstDefault.GetListPages(pcPage.PageIndex, iPageSize, nstrsql, out iCount, 2);
            iLoadCount = iCount;
            return ls;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            Base.AppStartInit.NewsContentInstDefault.Delete(int.Parse(iID.ToString()),GetSiteID);
        }
    }
}