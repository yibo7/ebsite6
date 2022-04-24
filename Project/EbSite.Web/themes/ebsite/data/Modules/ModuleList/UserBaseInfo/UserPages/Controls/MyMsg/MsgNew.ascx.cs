using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.BLL;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.MyMsg
{
    public partial class MsgNew : MPUCBaseListForUserRp
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("67024109-4035-47eb-8f9e-e154aff35def");
            }
        }
        public override string PageName
        {
            get
            {
                return "新消息";
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


        public override int OrderID
        {
            get
            {
                return 1;
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

           return EbSite.BLL.Msg.GetListPages(pcPage.PageIndex, pcPage.PageSize, UserID,true, "", out iCount);
        

        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        protected override void Deletes(string IDs)
        {
            EbSite.BLL.Msg.DeleteInIDs(IDs);
        }
        override protected void Delete(object iID)
        {
            EbSite.BLL.Msg.DeleteMsg(int.Parse(iID.ToString()), base.UserID);
        }
        
        #region 工具栏的初始化

        override protected void BindToolBar()
        {

            base.BindToolBar(true,false);
            //ucToolBar.AddLine();


        }
        #endregion

        #region 工具栏事件扩展

        //protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        //{
        //    base.ucToolBar_ItemClick(source, e);
        //    switch (e.ItemTag)
        //    {
        //        case "good":
        //            break;
        //    }
        //}

        #endregion
    }
}