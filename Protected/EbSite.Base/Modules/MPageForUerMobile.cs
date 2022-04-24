using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using EbSite.Base.Page;
using EbSite.BLL.ModulesBll;
using EbSite.Control;
using EbSite.Entity.Module;

namespace EbSite.Base.Modules
{
    public abstract class MPageForUerMobile : MPageForUerBase
    {
        
        public override ThemeType ThemesType
        {
            get
            {
                return ThemeType.MOBILE;
            }
        }
        /// <summary>
        /// 获取菜单业务
        /// </summary>
        protected override ModuleMenu GetTagsMenus
        {
            get
            {
                return new MenusForUser(ModuleID);
            }
        }

        override protected void LoadMaster()
        {
            //找不到当前用户组所属的母板页时，使用默认的母板页
            //多用户组机制下，只取第一个
            MasterPageFile = CurrentSite.GetCurrentDefualtUcMasterMobile();
            rpSubMenus = base.Master.FindControl("rpSubMenus") as System.Web.UI.WebControls.Repeater;
            
            
            
        }
        /// <summary>
        /// LOAD事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        override protected void ManagePage_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// LOAD事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        override protected void ManagePage_LoadComplete(object sender, EventArgs e)
        {
           
            if (IsCheckLogin)
            {
                MCheckCurrentUserIsLogin();
            }
               
        }
        protected override void InitStyle()
        {
            base.MobileInitStyle();
            

        }
        protected override void AddHeaderPram()
        {
            base.MobileAddHeaderPram();

        }
        override protected string GetTagsUrl(ModulePageInfo mp)
        {
            return string.Format("?mukey={0}", mp.id);
        }

        

      
       
        

    }

    
}
