using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Base.Page;

namespace EbSite.Modules.UserBaseInfo.AdminPages
{
    public partial class Splace : MPage
    {
        protected override MasterType eMasterType
        {
            get
            {
                if (PageType == 8|| PageType == 3 || PageType == 2 || PageType == 7)
                    return MasterType.Mini; 
                return MasterType.Modules;
            }
        }
        
        override public int OrderID
        {
            get
            {
                return 1;
            }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("629719d5-76f2-49f5-a2db-1a998e7672fd");
            }
        }
        public override string PageName
        {
            get
            {
                return "空间站点管理";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void AddControl()
        {
            if (PageType == 0) //
            {
                base.LoadAControl("ThemesAdd.ascx");
            }
            else if (PageType == 1) //
            {
                base.LoadAControl("ThemesClassAdd.ascx");
            }
            else if (PageType == 2) //
            {
                base.LoadAControl("EditeMaster.ascx");
            }
            else if (PageType == 3) //
            {
                base.LoadAControl("EditeCss.ascx");
            }
            else if (PageType == 4) //
            {
                base.LoadAControl("DefaultTabAdd.ascx");
            }
            else if (PageType == 5) //
            {
                base.LoadAControl("LayoutPaneAdd.ascx");
            }
            else if (PageType == 6) //
            {
                base.LoadAControl("WidgetAdd.ascx");
            }
            else if (PageType == 7) //
            {
                base.LoadAControl("InitTabWidgets.ascx");
            }
            else if (PageType == 8)//修改空间版式
            {
                base.LoadAControl("EditeLayoutPane.ascx");
            }
            else if(PageType==9)//边框样式的添加
            {
                base.LoadAControl("WidgetBoxStyleAdd.ascx");
            }
            else
            {
                base.AddControl();
            }
        }
    }
}