using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;

namespace EbSite.Web.AdminHt.Controls.Admin_Themes
{
    abstract public class BasePage : UserControlListBase
    {
        abstract public ThemesBase ThemeBll { get; }
        
        /// <summary>
        /// 模块ID
        /// </summary>
        virtual protected Guid ModuleID
        {
            get
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        /// 菜单 ID
        /// </summary>
        protected virtual Guid MenuID
        {
            get
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        /// 菜单名称
        /// </summary>
        virtual protected string MenuName
        {
            get
            {
                return "";
            }
        }

        public override string Permission
        {
            get
            {
                return "93";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "-1";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "97";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "93";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }


        override protected object LoadList(out int iCount)
        {
            List<Entity.Themes> ls= ThemeBll.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount);
            return ls;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;

            return null;
        }
        override protected void Delete(object iID)
        {

            ThemeBll.Delete(new Guid(iID.ToString()));

        }
        protected Control.TextBox txtOne = new Control.TextBox();
        protected override void BindToolBar()
        {
            base.BindToolBar(true, false, true, true, false);
           
            string ModuleMarketUrl = base.HostApi.GetModuleUrlForAdmin(ModuleID, MenuID);
               if(ModuleMarketUrl.Equals(EbSite.Base.Host.Instance.GetTipsUrl(6)))
                   ModuleMarketUrl = EbSite.Base.Host.Instance.GetTipsUrl(7);
               ucToolBar.AddDialog(ModuleMarketUrl, MenuName, IISPath + "images/menus/Doc-Previous.gif");

            ucToolBar.AddBnt("导出皮肤", IISPath + "images/menus/Doc-Next.gif", "putout");
            ucToolBar.AddBnt("刷新皮肤数据", IISPath + "images/menus/Doc-Next.gif", "refesh", "如果上传了新皮肤，那么要点这里刷新皮肤数据才会加载到这里来!");
            ucToolBar.AddLine();

            txtOne.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtOne);

            base.ShowCustomSearch("查询");
            ucToolBar.AddLine();


        }
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                //case "save":
                //    string sThemeId = Request.Form["rbIsUsed"];

                //    if (!string.IsNullOrEmpty(sThemeId))
                //    {

                //        ThemeBll.SetUsed(new Guid(sThemeId));
                //        base.gdList_Bind();
                //    }

                //    break;
                case "down":
                    break;
                case "putout":
                    break;
                case "refesh":
                    ThemeBll.InitThemes();
                   
                    base.gdList_Bind();
                    break;
            }


        }
        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (Equals(e.CommandName, "CopyData"))
            {
                Guid id = new Guid(e.CommandArgument.ToString());
                ThemeBll.CopyData(id);
                base.gdList_Bind();
            }
            //else if (Equals(e.CommandName, "MakeImg"))
            //{
            //    Guid id = new Guid(e.CommandArgument.ToString());
            //    ThemeBll.MakeThemeImg(id);
            //    base.gdList_Bind();
            //}
           
        }

    }
}