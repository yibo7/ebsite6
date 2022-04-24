using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.UserPages
{
    public partial class MyMsg : MPageForUer
    {
        override public int OrderID
        {
            get
            {
                return 8;
            }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("4cd1ac15-54b3-4364-985f-590a824f2ed5");
            }
        }
    
        public override string PageName
        {
            get
            {
                return "我的消息";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        ///// <summary>
        ///// 这样可以让页面不用登录也可以访问，如果你有页面不用受权，可以设置这个为false
        ///// </summary>
        //override protected bool IsCheckLogin
        //{
        //    get { return false; }
        //}

    }
}