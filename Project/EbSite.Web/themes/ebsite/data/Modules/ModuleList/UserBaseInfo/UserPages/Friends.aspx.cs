using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.UserPages
{
    public partial class Friends : MPageForUer
    {
        override public int OrderID
        {
            get
            {
                return 7;
            }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("470ba0af-6b6d-4636-9d27-3f39c139562f");
            }
        }
    
        public override string PageName
        {
            get
            {
                return "我的好友";
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