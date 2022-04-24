using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.AdminPages
{
    public partial class AskOperate : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("5F51D71F-C91C-42A9-B6D4-BA0DC5913B94");
            }
        }
        public override string PageName
        {
            get
            {
                return "问答管理";
            }
        }

        protected override bool IsHideMenus
        {
            get
            {
                return true;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
           
            if (PageType == 4)
            {
                base.LoadAControl("ConfigAdd.ascx");
            }
            else if (PageType == 5)
            {
                base.LoadAControl("ConfigShow.ascx");
            }
            else if (PageType == 6)
            {
                base.LoadAControl("UserHelpAdd.ascx");
            }
            else if (PageType == 7)
            {
                base.LoadAControl("UserHelpShow.ascx");
            }
            else if (PageType == 8)
            {
                base.LoadAControl("AnswerAdd.ascx");
            }
            else if (PageType == 9)
            {
                base.LoadAControl("AnswerShow.ascx");
            }
            else if (PageType == 10)
            {
                base.LoadAControl("CommentAdd.ascx");
            }
            else if (PageType == 11)
            {
                base.LoadAControl("CommentShow.ascx");
            }
            else if (PageType==12)
            {
                base.LoadAControl("AddExperts.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}