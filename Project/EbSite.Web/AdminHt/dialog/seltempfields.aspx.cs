using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Page;

namespace EbSite.Web.AdminHt.dialog
{
    public partial class seltempfileds : EbSite.Base.Page.ManagePage
    {
        protected override MasterType eMasterType
        {
            get
            {
                return MasterType.Mini;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.SetContolsPath("dialog");
        }

        protected override void AddControl()
        {
            if (PageType == 0)//部件
            {
                base.LoadAControl("WidgetData.ascx");
            }
            else if (PageType == 1)//分类字段
            {
                base.LoadAControl("ClassField.ascx");
            }
            else if (PageType == 2)//内容字段
            {
                base.LoadAControl("ContentField.ascx");
            }
            else if (PageType == 3)//专题字段
            {
                base.LoadAControl("SpecialField.ascx");
            }
            else if (PageType == 4)//用户字段
            {
                base.LoadAControl("UserField.ascx");
            }
            else if (PageType == 5)//常用变量
            {
                base.LoadAControl("Commonly.ascx");
            } 
            else if (PageType == 6)//函数
            {
                base.LoadAControl("Function.ascx");
            }
            else if (PageType == 7)//连接
            {
                base.LoadAControl("ConnectData.ascx");
            }
            else if (PageType == 8)//inclue代码
            {
                base.LoadAControl("InclueCode.ascx");
            }
            else
            {
                base.LoadAControl("");
            }

        }
    }
}