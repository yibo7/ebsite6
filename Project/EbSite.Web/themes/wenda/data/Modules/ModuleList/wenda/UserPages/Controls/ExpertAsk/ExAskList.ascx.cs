using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.Wenda.ModuleCore.Entity;

namespace EbSite.Modules.Wenda.UserPages.Controls.ExpertAsk
{
    public partial class ExAskList : MPUCBaseListForUserRp
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("dde53680-706b-4707-9e62-aac066d3de13");
            }
        }
        public override string PageName
        {
            get
            {
                return "我的答疑";
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
        public override bool IsCloseTagsTitle
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
            string strsql = " State=0 and userid =" + base.UserID;

            List<ModuleCore.Entity.expertAsk> lsit = ModuleCore.BLL.expertAsk.Instance.GetListPages(pcPage.PageIndex, iPageSize, strsql, "id desc", out iCount);

            if (lsit != null && lsit.Count > 0)
            {
                this.startLab.Text = string.Concat(" 还有【", iCount, "】个 问题 等待您 的回答。");
                this.divMsg.Visible = false;
            }
            else
            {
                this.divMsg.Visible = true;
            }
            return lsit;
        }

        public string GetAskAress(string id, string state)
        {
            string str = "";
            if (state == "0")
            {
                str = string.Concat("<a target='_blank' href='/wenda/", id, "content.ashx'>去回答</a>");
            }
            else
            {
                str = string.Concat("<a target='_blank' href='/wenda/", id, "content.ashx'>查看</a>");
            }
            return str;

        }
        override protected object SearchList(out int iCount)
        {
            string istate = ucToolBar.GetItemVal(drDQ);

            string strsql = string.Concat(" State=",istate," and userid =", base.UserID);

            List<ModuleCore.Entity.expertAsk> lsit = ModuleCore.BLL.expertAsk.Instance.GetListPages(pcPage.PageIndex, iPageSize, strsql, "id desc", out iCount);

            if (istate == "0" && lsit != null && lsit.Count > 0)
            {
                this.startLab.Text = string.Concat(" 还有【", iCount, "】个 问题 等待您 的回答。");
            }
            if (lsit != null && lsit.Count > 0)
            {
                this.divMsg.Visible = false;
            }
            else
            {
                this.divMsg.Visible = true;
            }
            return lsit;
        }
        //override protected string BulderSearchWhere(bool IsValueEmpytNoSearch)
        //{
        //    return SqlWhere;
        //}
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.expertAsk.Instance.Delete(int.Parse(iID.ToString()));
        }

       
     
        #region 工具栏的初始化
        protected EbSite.Control.DropDownList drDQ = new EbSite.Control.DropDownList();
        protected System.Web.UI.WebControls.Label startLab = new Label();
        override protected void BindToolBar()
        {
            base.BindToolBar(true, true);
            drDQ.ID = "drDQ";
            ListItem liIt = new ListItem("未回答", "0");
            drDQ.Items.Add(liIt);
            liIt = new ListItem("已回答", "1");
            drDQ.Items.Add(liIt);
            ucToolBar.AddCtr(drDQ);

            
            ucToolBar.AddBnt("查询", string.Concat(IISPath, "images/Menus/Search.gif"), "search");
            ucToolBar.AddLine();
            startLab.ID = "startLab";
            startLab.Attributes.Add("style","color:red;");
            ucToolBar.AddCtr(startLab);
        }
        #endregion
    }
}