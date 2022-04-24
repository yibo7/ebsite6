using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.UserPages
{
    public partial class Chat : MPageForUer
    {
        override public int OrderID
        {
            get
            {
                return 9;
            }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("eb1e11de-5307-469d-b350-4035c4621dae");
            }
        }
    
        public override string PageName
        {
            get
            {
                return "即时聊天";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        ///// <summary>
        ///// 这样可以让页面不用登录也可以访问，如果你有页面不用受权，可以设置这个为false
        ///// </summary>
        override protected bool IsCheckLogin
        {
            get { return false; }
        }

    }
}