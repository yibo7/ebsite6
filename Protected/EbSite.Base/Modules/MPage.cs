using System.Diagnostics;
using EbSite.Base.Modules.Configs;
using EbSite.Base.Page;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using EbSite.BLL.ModulesBll;
using EbSite.Control;
using EbSite.Core;
using EbSite.Entity.Module;

namespace EbSite.Base.Modules
{

    /// <summary>
    /// 应用于模块后台管理路由页面
    /// </summary>
    public abstract class MPage : ManagePage
    {
        protected override MasterType eMasterType
        {
            get
            {
                return MasterType.Modules;
            }
        }
        virtual public int OrderID
        {
            get
            {
                return 1;
            }
        }
        /// <summary>
        /// 重写这个ID的好处是可以事先引用这个页面的路径，比如你在js中要调用，那么要事先知道这个ID，否则系统每自动生成一次，将会产生不同的ID
        /// </summary>
        virtual public Guid ModuleMenuID
        {
            get
            {
                return Guid.NewGuid();
            }
        }
        virtual public ThemeType ThemesType
        {
            get
            {
                return ThemeType.PC;
            }
        }

        protected System.Web.UI.WebControls.Repeater rpSubMenus = null;
        public Host HostApi
        {
            get
            {
                return Host.Instance;
            }
        }
        /// <summary>
        /// 获取当前模块所在的相对路径
        /// </summary>
        protected string GetCurrentModulePath
        {
            get
            {
                return EbSite.BLL.ModulesBll.Modules.Instance.GetModelPath(ModuleID);
            }
        }
        /// <summary>
        /// 获取当前模块的ID
        /// </summary>
        protected Guid ModuleID
        {
            get
            {
                if(!string.IsNullOrEmpty(Request["mid"]))
                {
                    return new Guid(Request["mid"]);
                }
                else
                {
                    Tips("出错了","找不到相应的模块数据，请确认访问路径是否正确！");
                }
                return Guid.Empty;
            }
        }
        /// <summary>
        /// 获取当前菜单的ID
        /// </summary>
        protected Guid MenuID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["muid"]))
                {
                    return new Guid(Request.QueryString["muid"]);
                }
                else
                {
                    Tips("出错了", "路由找不到相应的菜单数据，请确认访问路径是否正确！");
                }
                return Guid.Empty;
            }
        }
        public MPage() 
        {
           
            base.Load += new EventHandler(this.MPage_Load);
            this.LoadComplete += new EventHandler(MPage_LoadComplete);
            //为了在安装时反射，这里暂时去掉
            //if (!string.IsNullOrEmpty(GetModuleBaseConfigPath))
            //{
            //    if (this.ModuleBaseConfig.Instance.IsClose)
            //    {
            //        base.Tips("模块已经关闭", this.ModuleBaseConfig.Instance.ColseInfo, "");
            //    }
            //}
            
            base.MasterCacheKeyArray[0] = "MPage";
        }
        private void MPage_Load(object sender, EventArgs e)
        {
            if (phBodyControls != null)
            {
                //初始化当前页面的控件存放路径
                string strFilePath = HttpContext.Current.Request.FilePath;
                string strControlFolderName = ModuleMenu.GetControlFolderName(strFilePath);
                base.SetContolsPath(strControlFolderName);

                
            }
            
        }
        virtual protected void MPage_LoadComplete(object sender, EventArgs e)
        {
            if(ThemesType == ThemeType.PC)
            {
                AddJavaScriptInclude(string.Concat(GetCurrentModulePath, "js/comm.js"), "ebsitemodulescript");
            }
            else
            {
                AddJavaScriptInclude(string.Concat(GetCurrentModulePath, "js/commmobile.js"), "ebsitemodulescript");
            }
             
        }

        /// <summary>
        /// 重写页面载入控件
        /// </summary>
        protected override void AddControl()
        {
            //为了不用再次读取数据，直接将这个url保存在ViewState
            object ob = ViewState["sRedirectuRUL"];
            if(!Equals(ob,null))
            {
                base.LoadAControl(ob.ToString());
            }
            else
            {
                Tips("出错了","找不到定向地址！");
            }
          
        }
        protected virtual ModuleMenu GetTagsMenus
        {
            get
            {
                return new MenusForAdminer(ModuleID);
            }
        }
        virtual protected string GetTagsUrl(ModulePageInfo mp)
        {
            return mp.GetRealUrl();
        }
        virtual protected bool IsCloseTags
        {
            get
            {
                return PageType < 0;
            }
        }

        protected void SetFirstMenu()
        {
            
        }

        /// <summary>
        /// 绑定主标签-重写
        /// </summary>
        protected override void BindTopTags()
        {
            //Stopwatch test = new Stopwatch();
            //test.Start();
                #region 获取模块子菜单数据表及当前要加载的控件
                            List<ModulePageInfo> lstSubPages;
                            ModuleMenu mm = GetTagsMenus;
                            ModulePageInfo mdMenu = mm.GetEntity(MenuID);
                    
                                    string TagOrtherUrl = "";
                                    if (!Equals(mdMenu.ParentID, Guid.Empty))
                                    {
                                        lstSubPages = mm.GetSubMenu(mdMenu.ParentID);
                                        ViewState["sRedirectuRUL"] = mdMenu.FileName;
                                    }
                                    else //如果是父级分类，获取第一个子类
                                    {
                                        TagOrtherUrl = mdMenu.GetRealUrl();
                                        lstSubPages = mm.GetSubMenu(MenuID);
                                        if (lstSubPages.Count > 0)
                                            //2012-11-13 yhl 目的 不显示没有权限的tab 找到第一个正确的有权限的路径。
                                            if (IsHideMenus)
                                            {
                                                foreach (ModulePageInfo info in lstSubPages)
                                                {
                                                    if (IsHaveLimit(info.Permission))
                                                    {
                                                        ViewState["sRedirectuRUL"] = info.FileName;
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                ViewState["sRedirectuRUL"] = lstSubPages[0].FileName;
                                            }
                                    }
                #endregion
            

                if (ThemesType == ThemeType.PC)
                {
                    if (this.ucTopTags != null)
                    {
                        this.ucTopTags.Visible = IsCloseTags;
                        if (base.ucTopTags.Visible)
                        {
                            List<TagsItemInfo> list = new List<TagsItemInfo>();
                            int index = 0;
                            //对主标签的绑定
                            foreach (ModulePageInfo info in lstSubPages)
                            {
                                if (!info.IsAddToAdminMenus) continue;
                                //2012-11-13 yhl  目的 不显示没有权限的tab 
                                if (IsHideMenus)
                                {
                                    if (IsHaveLimit(info.Permission))
                                    {
                                        TagsItemInfo item = new TagsItemInfo();
                                        item.sText = info.PageName;
                                        item.TagUrl = GetTagsUrl(info); //对外开放，因为前台用户后台里的url要重写干净点 info.GetRealUrl();
                                        item.Enable = info.EnableTagLink;
                                        if (index == 0)
                                        {
                                            item.TagOrtherUrl = TagOrtherUrl;
                                        }
                                        list.Add(item);

                                        index++;
                                    }
                                }
                                else
                                {
                                    TagsItemInfo item = new TagsItemInfo();
                                    item.sText = info.PageName;
                                    item.TagUrl = GetTagsUrl(info); //对外开放，因为用户后台里的url要重写干净点 info.GetRealUrl();
                                    item.Enable = info.EnableTagLink;
                                    if (index == 0)
                                    {
                                        item.TagOrtherUrl = TagOrtherUrl;
                                    }
                                    list.Add(item);

                                    index++;
                                }
                            }
                            base.ucTopTags.Taglist = list;

                            if (lstSubPages.Count > 0)
                            {
                                base.sTitle = this.PageName;
                                base.ucTopTags.Title = this.PageName;
                            }
                        }
                    }
                }
                else
                {
                    List<ModulePageInfo> lstdata = new List<ModulePageInfo>();
                    foreach (ModulePageInfo info in lstSubPages)
                    {
                        if (!info.IsAddToAdminMenus) continue;
                        lstdata.Add(info);
                    }
                    rpSubMenus.DataSource = lstdata;
                    rpSubMenus.DataBind();
                }

            
            //Response.Write(test.ElapsedMilliseconds);
            
        }
       // /// <summary>
       // /// 获取基础配置文件路径，在用户控制面板里不使用模块，所以要重写为空
       // /// </summary>
       //virtual protected string GetModuleBaseConfigPath
       // {
       //     get
       //     {
       //         return "DataStore/Configs/Base.config";
       //     }
       // }

       // public ConfigsControl<ConfigsBaseInfo> ModuleBaseConfig
       // {
       //     get
       //     {
       //         if (!string.IsNullOrEmpty(GetModuleBaseConfigPath))
       //         {
       //             return new ConfigsControl<ConfigsBaseInfo>("..", GetModuleBaseConfigPath);
       //         }
       //         else
       //         {
       //             return null;
       //         }
                
       //     }
       // }

        abstract public string PageName { get; }

        //public virtual string PageName
        //{
        //    get
        //    {
        //        return "页面名称";
        //    }
        //}

        /// <summary>
        /// 检测当前用户是否具有某个权限ID
        /// </summary>
        /// <param name="LimitID">权限Id</param>
        /// <returns></returns>
        protected override bool IsHaveLimit(string LimitID)
        {
            if (!string.IsNullOrEmpty(LimitID))
                return HostApi.IsHaveLimit(EbSite.Base.AppStartInit.UserID, Core.Utils.StrToInt(LimitID, -1), ModuleID);
            return true;

        }
        /// <summary>
        /// 是否隐藏没有权限的菜单
        /// </summary>
        virtual protected bool IsHideMenus
        {
            get
            {
                return false;
            }
        }
    }
}

