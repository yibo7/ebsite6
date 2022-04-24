using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.UserPages
{
    public partial class InviteUser : MPageForUer
    {
        override public int OrderID
        {
            get
            {
                return 2;
            }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("47b5303c-40cf-4c20-b2db-ec1dd13c198c");
            }
        }

        public override string PageName
        {
            get
            {
                return "邀请好友";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void AddControl()
        {
            if (PageType == 0) //添加收藏
            {
                base.LoadAControl("Add.ascx");
            }
            else if (PageType == 1)//添加收藏分类
            {
                base.LoadAControl("ClassAdd.ascx");
            }
             else if (PageType == 2)//添加收藏
            {
                base.LoadAControl("List.ascx");
            }
            else if(PageType==3) //收藏 分类
            {
                base.LoadAControl("ClassList.ascx");
            }

            else
            {
                base.AddControl();
            }
        }
    }
}