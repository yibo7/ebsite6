﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.UserPages
{
    public partial class MFavorite : MPageForUerMobile
    {
        
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("aca406b7-8998-4396-8c9a-a1a881286aa0");
            }
        }
        public override string PageName
        {
            get
            {
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
            else if (PageType == 3) //收藏 分类
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