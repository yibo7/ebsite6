using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Modules.BBS.AdminPages.Controls.PostManage
{
    public partial class ListDels : MPUCBaseList
    {
        private int ClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return int.Parse(Request["cid"]);
                }
                return 0;
            }
        }
        public override string PageName
        {
            get
            {
                return "已经删除";
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
        /// <summary>
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "1";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "1";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "1";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "1";
            }
        }

        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("385e01b9-223d-4ad4-8ca1-9e4212ac392e");
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }
        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.TopicReplies.Instance.GetListPages(pcPage.PageIndex, iPageSize, "DeleteFlag=1", "", out iCount, ClassID);
        }
       
        override protected object SearchList(out int iCount)
        {
            string skey = ucToolBar.GetItemVal(txtkeyword);
            return ModuleCore.BLL.TopicReplies.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, string.Format("ReplyContent like '%{0}%'", skey), "", out iCount, ClassID);
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.TopicReplies.Instance.Delete(int.Parse(iID.ToString()), ClassID);
        }
        #region  工具栏的初始化
        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.TextBox txtkeyword = new TextBox();
        override protected void BindToolBar()
        {
            base.BindToolBar(true, false, true, true, true);
            ucToolBar.AddLine();
            LbName.ID = "LbName";
            LbName.Text = "回帖内容:";
            ucToolBar.AddCtr(LbName);
            txtkeyword.ID = "keyword";
            txtkeyword.Attributes.Add("style", "width:200px");
            ucToolBar.AddCtr(txtkeyword);
            base.ShowCustomSearch("查询");
        }
        #endregion
        protected override void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (object.Equals(e.CommandName, "HYModel"))
            {
                int iD = int.Parse(e.CommandArgument.ToString());
                ModuleCore.BLL.TopicReplies.Instance.SetPostToHY(iD, ClassID);
                base.Response.Redirect(base.Request.RawUrl);
            }
        }
        
    }
}