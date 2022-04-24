using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.UserPages
{
    public partial class Favorite : MPageForUer
    {
        override public int OrderID
        {
            get
            {
                return 4;
            }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("a9156956-8f57-4bce-b011-4f8107fcbb41");
            }
        }
        public override string PageName
        {
            get
            {
                // return SettingInfo.Instance.GetSysConfig.Instance.FavoriteName;
                return "收藏夹";
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
            else if (PageType == 4) //收藏 分类
            {
                base.LoadAControl("ClassShow.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}