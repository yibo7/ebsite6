
using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.BLL.GetLink;
using EbSite.BLL.Space;
using EbSite.Control;

namespace EbSite.Base.Page
{

    public class MPForSpace : BasePage
    {
        #region 原来

        protected PlaceHolder LayoutPanes;
        /// <summary>
        /// 当前用户ID，可以是登录的用户也可以是指定访问的用户
        /// </summary>
        protected int CurrentUserID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
                {
                    return int.Parse(Request.QueryString["uid"]);
                }
                else
                {
                    return UserID;
                }
            }
        }
        /// <summary>
        /// 当前访问是不是自己
        /// </summary>
        protected bool IsMyPlace
        {
            get
            {
                if (Request.QueryString["v"] == "1") //一览模式
                    return false;
                return Request.QueryString["uid"] == UserID.ToString();
            }
        }
        /// <summary>
        /// 是否存在当前空间
        /// </summary>
        private bool IsExistsPlace
        {
            get
            {
                return EbSite.BLL.SpaceSetting.Instance.Exists(CurrentUserID);
            }
        }
        /// <summary>
        /// 获取预览皮肤的ID,如果大于0将以此为当前皮肤
        /// </summary>
        private int PreviewThemeID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["themeid"]))
                {
                    int.Parse(Request.QueryString["themeid"]);
                }
                return 0;
            }
        }
        /// <summary>
        /// 获取当前空间皮肤所在目录路径 
        /// </summary>
        protected string GetCurrentThemePath
        {
            get
            {
                if (PreviewThemeID == 0)
                {
                    return string.Concat(IISPath, "Home/themes/", CurrentUser.SpaceThemePath, "/");
                }
                else  //预览皮肤,还没实现
                {
                    return string.Concat(IISPath, "Home/themes/", CurrentUser.SpaceThemePath, "/");
                }

            }
        }
        /// <summary>
        /// 当前用户实例，可以是登录的用户也可以是指定访问的用户
        /// </summary>
        protected EntityAPI.MembershipUserEb CurrentUser
        {
            get
            {
                Base.EntityAPI.MembershipUserEb md = EbSite.BLL.User.MembershipUserEb.Instance.GetEntity(CurrentUserID); //Host.Instance.EBMembershipInstance.Users_GetEntity(CurrentUserID);
                if (md != null)
                {
                    return md;
                }
                else
                {
                    Tips("出错了", "找不到此用户!");
                    return null;
                }

            }
        }

        public MPForSpace()
        {
            base.Load += new EventHandler(this.ManagePage_Load);
            base.LoadComplete += new EventHandler(ManagePage_LoadComplete);
        }
        private void LoadLayoutpane(string layoutname)
        {
            if (!string.IsNullOrEmpty(layoutname))
            {
                string ctrPath = string.Concat(IISPath, "home/layoutpanes/", layoutname, ".ascx");
                LayoutPanes.Controls.Add(LoadControl(ctrPath));
            }
            else //加载默认版式
            {
                LayoutPanes.Controls.Add(LoadControl(string.Concat(IISPath, "home/layoutpanes/level_35_65.ascx")));
            }
        }
        private int GetSubTabID
        {
            get
            {
                if(!string.IsNullOrEmpty(Request.QueryString["t"]))
                {
                   return EbSite.BLL.SpaceTabs.Instance.GetTabIDFormMark(CurrentTabID, Request.QueryString["t"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        private Guid GetModuleID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mid"]))
                {
                    return new Guid(Request.QueryString["mid"]);
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }
        /// <summary>
        /// 是否访问二级标签，并载入模块里的自定义控件
        /// </summary>
        private bool IsViewModuleCtr
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["t"]) && !string.IsNullOrEmpty(Request.QueryString["mid"]))
                    return true;
                return false;

            }
        }
        /// <summary>
        /// LOAD事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        virtual protected void ManagePage_Load(object sender, EventArgs e)
        {

            if (!IsExistsPlace)
            {

                if (IsMyPlace) //自己访问的自己
                {
                    //如果不存在空间,指定到创建空间页面

                    Response.Redirect(EbSite.BLL.MenusForUser.Instance.GetSpaceSettingUrl);
                }
                else //访问别人空间
                {
                    Tips("出错了", "当前用户还没有创建空间！");
                }
            }
            else
            {
                //载入版式
                string sLayout = string.Empty;
                if (!IsViewModuleCtr)
                {
                    sLayout = EbSite.BLL.SpaceTabs.Instance.GetLayoutName(CurrentTabID);
                }
                else
                {
                    sLayout = EbSite.BLL.SpaceTabs.Instance.GetLayoutName(GetSubTabID);
                }
                    

                LoadLayoutpane(sLayout);
                //if (!string.IsNullOrEmpty(sLayout))
                //{
                //    string ctrPath = string.Concat(IISPath, "home/layoutpanes/", sLayout, ".ascx");
                //    LayoutPanes.Controls.Add(LoadControl(ctrPath));
                //}
                //else //加载默认版式
                //{
                //    LayoutPanes.Controls.Add(LoadControl(string.Concat(IISPath, "home/layoutpanes/level_35_65.ascx")));
                //}

                //加载部件
                int ThisTabID = 0;
                if(!IsViewModuleCtr)
                {
                    ThisTabID = CurrentTabID;
                }
                else
                {
                    ThisTabID = GetSubTabID;
                }
                List<EbSite.Entity.SpaceTabWidget> lstThisUserWidGets = EbSite.BLL.SpaceTabWidget.Instance.GetListWidgets(CurrentUserID, ThisTabID);
                ;
                HtmlGenericControl DefaultWidgets = (HtmlGenericControl)LayoutPanes.Controls[0].FindControl("DefaultWidgets");
                //载入模块控件 
                if (GetModuleID != Guid.Empty)
                {
                    string sPath = EbSite.BLL.ModulesBll.Modules.Instance.GetModelPath(GetModuleID);
                    if (DefaultWidgets != null)
                        DefaultWidgets.Controls.Add(LoadControl(string.Concat(sPath, "ForHome", Request["t"], ".ascx")));
                }

                    if (lstThisUserWidGets.Count > 0)
                    {
                        
                        foreach (EbSite.Entity.SpaceTabWidget entity in lstThisUserWidGets)
                        {
                            WidgetMoveForHome wdWidget = new WidgetMoveForHome();
                            wdWidget.WidgetID = entity.WidgetID;
                            wdWidget.CtrID = entity.id.ToString();
                            wdWidget.IsManager = IsMyPlace;
                            if (!string.IsNullOrEmpty(entity.LayoutPane) && !"DefaultWidgets".Equals(entity.LayoutPane))
                            {
                                HtmlGenericControl WgPanne = (HtmlGenericControl)LayoutPanes.Controls[0].FindControl(entity.LayoutPane);
                                if (WgPanne != null)
                                    WgPanne.Controls.Add(wdWidget);
                                    //DefaultWidgets = WgPanne;
                            }
                            else
                            {
                                if (DefaultWidgets != null)
                                {
                                    DefaultWidgets.Controls.Add(wdWidget);
                                }
                                else
                                {
                                    Tips("出错了", "当前版式没找到默认部件输出控件:" + entity.LayoutPane);
                                }
                            }

                            
                        }
                    }
                   
                
                  
                
            }

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

                AddJavaScriptInclude(string.Concat(Base.AppStartInit.IISPath, "home/js/homecomm.js"));
                //不需要引用这个,否则会有错乱
                //AddStylesheetInclude(string.Concat(Base.AppStartInit.IISPath, "js/plugin/easywidgets/css.css"));
                //AddJavaScriptInclude(string.Concat(Base.AppStartInit.IISPath, "js/plugin/easywidgets/js.js"));


                EbSite.Entity.SpaceSetting md = EbSite.BLL.SpaceSetting.Instance.GetEntityByUserID(CurrentUserID);
                if (md != null)
                {
                    HomeTitle = md.Title;
                    HomeDemo = md.Description;
                    //_CurrentTabID = md.DefaultTabID;
                    //暂时不启用空间地址重写
                    //if (!string.IsNullOrEmpty(md.ReWriteName))
                    //{
                    //    HomeUrl = HrefFactory.GetInstance(GetSiteID).UhomeRw.Replace(".ashx", string.Format("/{0}/", md.ReWriteName));
                    //}
                    //else
                    //{
                    //    HomeUrl = string.Concat(HrefFactory.GetInstance(GetSiteID).UhomeRw, "?uid=", CurrentUserID);
                    //}
                    HomeUrl = EbSite.Base.Host.Instance.GetUserSiteUrl(CurrentUserID);// string.Concat(HrefFactory.GetInstance(GetSiteID).UhomeRw, "?uid=", CurrentUserID);
                    HomeUrl = string.Concat(EbSite.Base.AppStartInit.DomainName, HomeUrl);

                    //LoginUrl = HrefFactory.GetInstance(GetSiteID).LoginRw;
                    //RegUrl = HrefFactory.GetInstance(GetSiteID).RegRw;
                    //UccUrl = HrefFactory.GetInstance(GetSiteID).UccIndexRw;


                    LoginUrl = Base.PageLink.GetBaseLinks.Get(GetSiteID).LoginRw;
                    RegUrl = Base.PageLink.GetBaseLinks.Get(GetSiteID).RegRw;
                    UccUrl = Base.PageLink.GetBaseLinks.Get(GetSiteID).UccIndexRw;

                }
                else
                {
                    Tips("出错了", "空间不存在!");
                }

                Page.Title = HomeTitle;
            }
        }
        protected override void InitStyle()
        {
            if (!string.IsNullOrEmpty(GetCurrentThemePath))
            {
                AddStylesheetInclude(string.Concat(IISPath, "themes/base.css"));
                AddStylesheetInclude(string.Concat(IISPath, "Home/themes/base.css"));
                AddStylesheetInclude(string.Concat(GetCurrentThemePath, "css.css"));
                //目前公共部件边框只供个人空间使用，以后主站实现可视化模板再做考虑
                AddStylesheetInclude(string.Concat(IISPath, "themeswidgets/publicbox.css"));

            }
        }


        //virtual protected void LoadMaster()
        //{
        //    if (!IsExistsPlace)
        //    {

        //        if (IsMyPlace) //自己访问的自己
        //        {
        //            //如果不存在空间,指定到创建空间页面

        //            Response.Redirect(EbSite.BLL.MenusForUser.Instance.GetSpaceSettingUrl);
        //        }
        //        else //访问别人空间
        //        {
        //            Tips("出错了", "当前用户还没有创建空间！");
        //        }
        //    }
        //    else
        //    {
        //        MasterPageFile = string.Concat(GetCurrentThemePath, "UhomeTem.Master");
        //    }


        //}

        //protected override void OnPreInit(EventArgs e)
        //{

        //    LoadMaster();
        //    base.OnPreInit(e);
        //}


        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
        }
        #endregion
        protected string HomeTitle;
        protected string HomeDemo;
        protected string HomeUrl;
        protected string LoginUrl;
        protected string RegUrl;
        protected string UccUrl;
        private int _CurrentTabID = 1;
        protected int CurrentTabID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["tab"]))
                {
                    return int.Parse(Request.QueryString["tab"]);
                }
                else
                {
                    return _CurrentTabID;
                }
            }
        }

        
        
    }

    
}
