using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages
{
    public partial class OrderBox : MPage
    {
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("4838f178-0860-4b51-be61-a258e5990731");
            }
        }
        public override string PageName
        {
            get
            {
                return "下单流程";
            }
        }
        //Stopwatch test = new Stopwatch();
        protected void Page_Load(object sender, EventArgs e)
        {

            //test.Start();
            //this.PreRenderComplete += new EventHandler(dLoad);
        }
        //protected void dLoad(object sender, EventArgs e)
        //{
        //    Response.Write(test.ElapsedMilliseconds);
        //}
        protected override bool IsHideMenus
        {
            get
            {
                return true;
            }
        }

        protected override void AddControl()
        {
            if (PageType == 0)//添加
            {
                base.LoadAControl("OrderBoxAdd.ascx");
            }
            else if (PageType == 1) //显示
            {
                base.LoadAControl("ServiceAdd.ascx");
            }
            else if (PageType == 2)
            {
                base.LoadAControl("CustomWordAdd.ascx");
            }
            else if (PageType == 3)
            {
                base.LoadAControl("ServiceClassAdd.ascx");
            }
            else if (PageType == 4)
            {
                base.LoadAControl("PluginsAdd.ascx");
            }
            else if (PageType == 5)
            {
                base.LoadAControl("ChatList.ascx");
            }
            else if (PageType == 6)
            {
                base.LoadAControl("Chathistorys.ascx");
            }
            else if (PageType == 7)
            {
                base.LoadAControl("CustomItemAdd.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}