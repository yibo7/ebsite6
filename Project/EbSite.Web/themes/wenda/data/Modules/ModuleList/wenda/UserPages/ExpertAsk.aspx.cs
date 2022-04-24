using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.UserPages
{
    public partial class ExpertAsk : MPageForUer
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("90578fcd-0254-4d01-a8a1-e9dd6a64fdea");
            }
        }
        public override string PageName
        {
            get
            {
                return "专家答疑";
            }
        }
        ///// <summary>
        ///// 自定义模板页，目前只能应用于路由,不能应用于单独页面
        ///// </summary>
        //protected override string MasterPagePath
        //{
        //    get
        //    {
        //        return "Ask.Master";
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void AddControl()
        {
            if (PageType == 0) //
            {
                base.LoadAControl("MyAskAdd.ascx");

            }
            else
            {
                base.AddControl();
            }
        }
    }
}