using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.UserPages.Controls.MyAskManage
{
    public partial class MyAnswerList : MPUCBaseListForUserRp
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("3e9e5479-1579-4eb8-a594-d0583501ca71");
            }
        }
        //public override string TipsText
        //{
        //    get
        //    {
        //        return "在这里显示您好所申请的友情连接列表，您可以查看通过状态!";
        //    }
        //}
        public override string PageName
        {
            get
            {
                return "我的回答";
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
                return 3;
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
            string strsql = "AnswerUserID=" + base.UserID;
            List<EbSite.Modules.Wenda.ModuleCore.Entity.Answers> ls = EbSite.Modules.Wenda.ModuleCore.BLL.Answers.Instance.GetListPages(pcPage.PageIndex, iPageSize, strsql, "id desc", out iCount);
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