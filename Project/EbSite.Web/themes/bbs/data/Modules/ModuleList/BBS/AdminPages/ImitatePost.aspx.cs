using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
namespace EbSite.Modules.BBS.AdminPages
{
    public partial class ImitatePost : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("fb9b578d-2571-40d3-8c9a-53a00461eb52");
            }
        }
        public override string PageName
        {
            get
            {
                return "模块发帖";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 0)//添加
            {
                base.LoadAControl("ImitatePostUserAdd.ascx");
            }
            else
            {
                //ImitatePostUserAdd.ascx
                base.AddControl();
            }
        }
    }
}