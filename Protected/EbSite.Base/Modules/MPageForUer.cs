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
    public abstract class MPageForUer : MPageForUerBase
    {
        public override ThemeType ThemesType
        {
            get
            {
                return ThemeType.PC;
            }
        }
        //protected System.Web.UI.HtmlControls.HtmlTableCell tbLeft;
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
        //private bool GetIsOpenBox
        //{
        //    get
        //    {
        //        string sIs = Request["box"];
        //        return (sIs == "1");
        //    }
        //}
        /// <summary>
        /// 自定义母板页 相对地址 ,目前只应用于用户前台模块
        /// </summary>
        virtual protected string MasterPagePath
        {
            get
            {
                return string.Empty;
            }
        }
        override protected void LoadMaster()
        {
             

            if (string.IsNullOrEmpty(MasterPagePath))
            {
                //找不到当前用户组所属的母板页时，使用默认的母板页
                //多用户组机制下，只取第一个
                MasterPageFile = CurrentSite.GetCurrentDefualtUcMaster();
            }
            else //自定义
            {
                MasterPageFile = string.Concat(this.GetCurrentModulePath, MasterPagePath);
            }

            this.ucTopTags = (CustomTagsBase)base.Master.FindControl("ctdTags");
            //this.tbLeft = (System.Web.UI.HtmlControls.HtmlTableCell)base.Master.FindControl("tbLeft");
            
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
            //if (this.tbLeft != null)
            //{
            //    this.tbLeft.Visible = !base.IsCloseLeft;
            //}

            if (IsCheckLogin)
            {
                //验证当前用户是否已经登录(帐号+密码),如果还未登录，跳转到登录页面
                CheckCurrentUserIsLogin();
                
            }
               
        }

        protected override void AddHeaderPram()
        {
            base.AddHeaderPramPC();//跨过后台样式
        }

        protected override void InitStyle()
        {
            //添加全局样式
            AddStylesheetInclude(string.Concat(IISPath, "themes/base.css"));
            string sCss = "default";

            if (!string.IsNullOrEmpty(HostApi.MainSite.PageTheme))
            {
                sCss = HostApi.MainSite.PageTheme;
            }
            AddStylesheetInclude(string.Concat(Base.AppStartInit.IISPath, "themes/", sCss, "/css/index.css"));

            //加载模块样式表及js
            //if (!string.IsNullOrEmpty(GetModuleBaseConfigPath))
            //{
            //    AddStylesheetInclude(string.Concat(GetCurrentModulePath, "css/index.css"));
            //}
            //AddStylesheetInclude(string.Concat(GetCurrentModulePath, "css/index.css"));

        }
        //protected override void AddHeaderPram()
        //{
        //    base.AddHeaderPram();

        //}
        override protected string GetTagsUrl(ModulePageInfo mp)
        {
            return string.Format("?mukey={0}", mp.id);
        }

      
        override protected void InitMasterCtr()
        {
            this.ntTips = (Notes)base.Master.FindControl("ntTips");
        }

        
       

    }

    
}
