using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Wenda.UserPages
{
    public partial class MyAskManage : MPageForUer
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("b8db356c-9000-4e9a-8aaa-c508bc80c309");
            }
        }
        public override string PageName
        {
            get
            {
                return "问答管理";
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
            else if (PageType == 2)
            {
                base.LoadAControl("MyAskList.ascx");
            }
            else
            {
                base.AddControl();
            }
        }

    }
}