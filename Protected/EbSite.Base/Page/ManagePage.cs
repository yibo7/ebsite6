
using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.SysConfigs;
using EbSite.BLL;
using EbSite.Control;

namespace EbSite.Base.Page
{
    public enum MasterType
    {
        Custom=1,
        Mini=2,
        Modules=3
    }

    public class ManagePage : BasePage
    {

        private string _sTitle;
        protected internal int AdminGroudid;
        protected PlaceHolder phBodyControls;
        protected CustomTagsBase ucTopTags = null;
        protected Notes ntTips = null;
        /// <summary>
        /// 与用户权限相关的处理
        /// </summary>
        protected AdminPrincipal apAdmin;
        public ManagePage()
        {
            base.Load += new EventHandler(this.ManagePage_Load);
            base.LoadComplete += new EventHandler(ManagePage_LoadComplete);
        }
        protected virtual bool IsHaveLimit(string LimitID)
        {
            //AdminPrincipal user = AdminPrincipal.ValidateLogin(UserName);
            if (apAdmin != null)
            {
                if (!string.IsNullOrEmpty(LimitID) && apAdmin.HasPermissionID(int.Parse(LimitID)))
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// LOAD事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       virtual protected void ManagePage_Load(object sender, EventArgs e)
        {
            //验证当前用户是否已经登录(帐号+密码),如果还未登录，跳转到登录页面
            CheckCurrentUserIsLogin();
            apAdmin = AppStartInit.CheckAdmin();
             

        }
       /// <summary>
       /// LOAD事件处理
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
       virtual protected void ManagePage_LoadComplete(object sender, EventArgs e)
       {
           if (!Page.IsCallback)
           {
               //AddJavaScriptInclude(string.Concat(AppStartInit.AdminPath, "js/admin.js"));
           }
       }
         protected  void InitJavaScript()
        {
            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/js/modernizr.min.js"));
            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/js/jquery.min.js"));

            AddJavaScriptInclude(string.Concat(IISPath, "js/jquery.js"));
            AddJavaScriptInclude(string.Concat(IISPath, "js/bootstrap/5/js/bootstrap.bundle.min.js"));
            AddJavaScriptInclude(string.Concat(IISPath, "js/init.js"));
            AddJavaScriptInclude(string.Concat(IISPath, "js/inc.js"));
            AddJavaScriptInclude(string.Concat(IISPath, "js/comm.js"));
            AddJavaScriptInclude(string.Concat(IISPath, "js/customctr.js"));

            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/js/bootstrap.min.js"));
            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/js/detect.js"));
            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/js/fastclick.js"));
            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/js/jquery.slimscroll.js"));
            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/js/jquery.blockUI.js"));

            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/js/waves.js"));
            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/js/wow.min.js"));
            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/js/jquery.nicescroll.js"));

            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/js/jquery.scrollTo.min.js"));
            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/plugins/peity/jquery.peity.min.js"));
            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/plugins/waypoints/lib/jquery.waypoints.js"));
            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/plugins/counterup/jquery.counterup.min.js"));

            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/js/jquery.core.js"));
            ////AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/js/jquery.app.js"));

            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/plugins/bootstrap-table/dist/bootstrap-table.min.js"));
            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/pages/jquery.bs-table.js"));
            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/plugins/notifyjs/dist/notify.min.js"));
            //AddJavaScriptInclude(string.Concat(AdminPath, "themes/Ubold/plugins/notifications/notify-metro.js"));

            AddJavaScriptInclude(string.Concat(IISPath, "js/plugin/jquery.cookie.js"));
            AddJavaScriptInclude(string.Concat(IISPath, "js/customctr.js"));
            AddJavaScriptInclude(string.Concat(IISPath, "js/json2.js"));
            AddJavaScriptInclude(string.Concat(AdminPath, "js/admin.js?v=1.1"));


        }
        /// <summary>
        /// PC版
        /// </summary>
        protected override void AddHeaderPram()
       {
            //if (!string.IsNullOrEmpty(SeoTitle))
            //{
            //    Page.Title = string.Concat(SeoTitle, " - Powered by EbSite");
            //}
            Page.Title = string.Concat(SiteName,"-后台管理 ");
            //SeoKeyWord = string.Concat(SeoKeyWord, "   EbSite商业正式版");
            if (!string.IsNullOrEmpty(SeoKeyWord))
           {
               SetMeta("keywords", SeoKeyWord);
           }
           if (!string.IsNullOrEmpty(SeoDes))
           {
               SetMeta("Description", SeoDes);
           }
           string ThemePath = Host.Instance.ThemePath;
           //添加皮肤样式,可重写,如前台与后台
           int enableJsCompression = ConfigsControl.Instance.EnableJsCompression;

           InitJavaScript();

           InitStyle();
            

           HtmlMeta encode = new HtmlMeta();
           encode.HttpEquiv = "Content-Type";
           encode.Content = "text/html; charset=utf-8";
           Page.Header.Controls.Add(encode);
           if (InitOrtherJavaScript.Length > 0)
           {
               foreach (string sJsPath in InitOrtherJavaScript)
               {
                   AddJavaScriptInclude(sJsPath);
               }
           }

           if (GetSiteID > 0)
           {
               HtmlGenericControl sc = new HtmlGenericControl("script");
               sc.Attributes["type"] = "text/javascript";
               sc.InnerHtml = string.Concat("inisite(", GetSiteID, ",'", ThemePath, "');");
               Page.Header.Controls.Add(sc);
           }
       }

        protected override void InitStyle()
        {
            //AddStylesheetInclude(string.Concat(AppStartInit.AdminPath, "themes/Ubold/css/bootstrap.min.css"));
            //AddStylesheetInclude(string.Concat(AppStartInit.AdminPath, "themes/Ubold/css/core.css"));
            //AddStylesheetInclude(string.Concat(AppStartInit.AdminPath, "themes/Ubold/css/components.css"));
            //AddStylesheetInclude(string.Concat(AppStartInit.AdminPath, "themes/Ubold/css/icons.css"));
            //AddStylesheetInclude(string.Concat(AppStartInit.AdminPath, "themes/Ubold/css/pages.css"));
            //AddStylesheetInclude(string.Concat(AppStartInit.AdminPath, "themes/Ubold/css/responsive.css"));

            //添加全局样式
            AddStylesheetInclude(string.Concat(IISPath, "js/bootstrap/5/css/bootstrap.min.css"));
            if (!string.IsNullOrEmpty(CurrentSite.AdminTheme))
            {
                //AddStylesheetInclude(string.Concat(AppStartInit.AdminPath, "themes/base.css"));
                AddStylesheetInclude(string.Concat(AppStartInit.AdminPath, "themes/", CurrentSite.AdminTheme, "/css.css"));
            }
        }
        /// <summary>
        /// 向页面载入一个控件
        /// </summary>
        protected virtual void AddControl()
        {
            if (this.phBodyControls != null)
            {

                EbSite.Entity.Menus entity = EbSite.BLL.Menus.Instance.GetEntity(this.GetSubMenuID);
                this.LoadAControl(entity.CtrPath);
            }
        }

        protected virtual void BindTopTags()
        {
            //有点慢，暂时屏蔽
            //if (this.ucTopTags != null)
            //{
            //    if (PageType > -1)  //子页面上关闭主标签
            //    {
            //        this.ucTopTags.Visible = false;
            //    }
            //    if (this.ucTopTags.Visible)
            //    {
            //        //获取当前父菜单下的子菜单列表
            //        List<EbSite.Entity.Menus> menusByUser = EbSite.BLL.Menus.Instance.GetMenusByParentID(this.GetParentMenuID);
            //        List<TagsItemInfo> listSubMenus = new List<TagsItemInfo>();
            //        foreach (EbSite.Entity.Menus menus in menusByUser)
            //        {
            //            TagsItemInfo item = new TagsItemInfo();
            //            item.sText = menus.MenuNameResource;
            //            item.TagUrl = menus.Url;
            //            listSubMenus.Add(item);
            //        }
            //        this.ucTopTags.Taglist = listSubMenus;
            //        //设置当前标题名称
            //        if (!object.Equals(this.GetSubMenuID, Guid.Empty))
            //        {
            //            EbSite.Entity.Menus entity = EbSite.BLL.Menus.Instance.GetEntity(this.GetSubMenuID);
            //            this.sTitle = entity.MenuNameResource;
            //            this.ucTopTags.Title = entity.MenuNameResource;
            //        }
            //    }
            //}


            
        }

        protected bool IsCloseLeft = false;
        virtual protected bool IsCheckLogin
        {
            get { return true; }
        }

        /// <summary>
        /// 是否登录后才能访问,目前只为用户后台用，因为管理后台是一定要登录的
        /// </summary>
        //protected bool IsCheckLogin = true;
        ///// <summary>
        ///// 自定义母板页 相对地址 ,目前只应用于用户前台模块
        ///// </summary>
        virtual protected MasterType eMasterType
        {
            get
            {
                return MasterType.Custom;
            }
        }
        protected void LoadAControl(string CtrName)
        {
            EbSite.Base.ControlPage.CtrBase uc = base.LoadControl(string.Concat(this.GetControlsPath , "/" , CtrName)) as ControlPage.CtrBase;
            if (uc!=null)
            {
                this.phBodyControls.Controls.Add(uc);
                if (this.ntTips != null && !string.IsNullOrEmpty(uc.TipsText))
                {
                    this.ntTips.Text = uc.TipsText;
                    this.ntTips.Visible = true;
                }
                if (this.ucTopTags!=null)
                {
                    this.ucTopTags.IsCloseTagsItem = uc.IsCloseTagsItem;
                    if(uc.IsCloseTagsTitle)
                    {
                        this.ucTopTags.Title = "";
                    }
                }
                IsCloseLeft = uc.IsCloseLeft;
                //当前页面访问权限不为空时，要求用户登录后才能访问
                //IsCheckLogin = !string.IsNullOrEmpty(uc.Permission);
                 
                    
            }
            else
            {
                Tips("出错了","控件的转换为null");
            }
            
        }
        /// <summary>
        /// 这个要放在 LoadMaster() 之后，将读取Master中的一些共用控件
        /// </summary>
       virtual protected void InitMasterCtr()
        {
            this.ntTips = (Notes)base.Master.FindControl("ntTips");
            
        }
        virtual protected void LoadMaster()
        {
            if (eMasterType == MasterType.Custom)
            {
                MasterPageFile = string.Concat(AdminPath, "PagesCustom.Master");
            }
            else if (eMasterType == MasterType.Mini)
            {
                MasterPageFile = string.Concat(AdminPath, "PagesCustomMini.Master");
            }
            else if (eMasterType == MasterType.Modules)
            {
                MasterPageFile = string.Concat(AdminPath, "PagesModules.Master");
            }
            //这个控件与用户管理页的tag控件不一样，所以不能放到InitMasterCtr中
            this.ucTopTags = (CustomTags)base.Master.FindControl("ucPageTags");

        }

        protected override void OnPreInit(EventArgs e)
        {

            LoadMaster();
            InitMasterCtr();
            base.OnPreInit(e);
        }

        protected void SetContolsPath(string sPath)
        {
            this.ContolsPath = sPath;
             
            this.BindTopTags();
            this.AddControl();
        }
        ///// <summary>
        ///// 关闭
        ///// </summary>
        //protected void TagCloseVisible()
        //{
        //    this.ucTopTags.Visible = false;
        //}

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
        }
        private string _sContolsPath;
        protected string ContolsPath
        {
            get
            {
                return this._sContolsPath;
            }
            set
            {
                this._sContolsPath = value;
            }
        }

        protected int CurrentAdtion
        {
            get
            {
                if (!string.IsNullOrEmpty(base.Request["mat"]))
                {
                    return int.Parse(base.Request["mat"]);
                }
                return 0;
            }
        }

        protected string GetControlsPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ContolsPath))
                {
                    throw new Exception("控件路径不能为空");
                }
                return ("controls/" + this.ContolsPath);
            }
        }

        protected Guid GetSubMenuID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["msid"]))
                {
                    return new Guid(Request["msid"]);
                }
                return Guid.Empty;
            }
        }
        protected Guid GetParentMenuID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["mpid"]))
                {
                    return new Guid(Request["mpid"]);
                }
                return Guid.Empty;
            }
        }
        /// <summary>
        /// 获取页面类别,t为空的情况下一般为列表页面，其他添加、修改，显示页面一般都要带着一个t参
        /// </summary>
        protected int PageType
        {
            get
            {
                if (!string.IsNullOrEmpty(base.Request["t"]))
                {
                    //this.TagCloseVisible();
                    return int.Parse(base.Request["t"]);
                }
                return -1;
            }
        }

        protected string sTitle
        {
            get
            {
                return this._sTitle;
            }
            set
            {
                this._sTitle = value;
            }
        }
    }

    
}
