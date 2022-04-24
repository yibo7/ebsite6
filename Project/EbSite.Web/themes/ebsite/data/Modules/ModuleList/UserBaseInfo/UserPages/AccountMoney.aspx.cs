using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.UserPages
{
    public partial class AccountMoney : MPageForUer
    {
        override public int OrderID
        {
            get
            {
                return 6;
            }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("c65f0059-b345-4c0b-a437-37363f2fa4e9");
            }
        }
        public override string PageName
        {
            get
            {
               
                return "预付款管理";
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
            else if (PageType == 3) //收藏 分类
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