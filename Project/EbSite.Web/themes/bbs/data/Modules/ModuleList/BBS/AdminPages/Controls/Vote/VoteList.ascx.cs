using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Control;


namespace EbSite.Modules.BBS.AdminPages.Controls.Vote
{
    public partial class VoteList : MPUCBaseList
    {
        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        public override string PageName
        {
            get
            {
                return "所有投票";
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("9843a8c8-35a4-4bfa-b2a3-809c88389514");
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
        public override string Permission
        {
            get
            {
                return "1";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=2";
            }
        }
        public string TagCls
        {
            get
            {
                return Request["cls"];
            }
        }


        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.toupiaobt.Instance.GetListPagesByGkuName(pcPage.PageIndex, pcPage.PageSize, out iCount, UserName);            
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
           
        }
        protected void gdList_DataBound(object sender, EventArgs e)
        {
            for (int i = 0; i < gdList.Rows.Count; i++)
            {
                string type = (gdList.Rows[i].FindControl("lbtype") as Label).Text;
                if (string.Equals(type, "已结束"))
                {
                    (gdList.Rows[i].FindControl("WinBox8") as EasyuiDialog).Visible = false;
                    (gdList.Rows[i].FindControl("lbtp") as Label).Visible = true;
                }
                else
                {
                    (gdList.Rows[i].FindControl("WinBox8") as EasyuiDialog).Visible = true;
                    (gdList.Rows[i].FindControl("lbtp") as Label).Visible = false;
                }
            }
        }
    }
}