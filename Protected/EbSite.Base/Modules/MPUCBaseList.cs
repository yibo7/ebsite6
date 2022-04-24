using EbSite.Base.ControlPage;
using EbSite.Control;

namespace EbSite.Base.Modules
{
    using EbSite.Base.Page;
    using System;

    public abstract class MPUCBaseList : UserControlListBase
    {
        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }

        protected string GetPageUrl(string menuid)
        {
            return string.Format("{0}?muid={1}&mid={2}", this.GetPageName, menuid, this.ModuleID);
        }

        override protected string GetAddUrl
        {
            get
            {
                if (!Equals(MenuAddID, Guid.Empty))
                {
                    return string.Format("{0}?muid={1}&mid={2}", this.GetPageName, this.MenuAddID, this.ModuleID);
                }
                else
                {
                    return string.Concat(GetUrl, "&", AddUrl);
                }
            }
        }
        override protected string GetMofifyUrl(object id)
        {
            if (MenuAddID != Guid.Empty)
            {
                return string.Format("{0}?muid={1}&mid={2}&id={3}", this.GetPageName, this.MenuAddID, this.ModuleID, id);
            }
            else
            {
                return base.GetMofifyUrl(id);
            }
            
        }

        /// <summary>
        /// 获取当前模块的ID
        /// </summary>
        protected Guid ModuleID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["mid"])) 
                {
                    return new Guid(Request["mid"]);
                }
                else
                {
                    Tips("出错了", "列表页找不到相应的模块数据，请确认访问路径是否正确！");
                }
                return Guid.Empty;
            }
        }
        /// <summary>
        /// 获取当前模块的安装目录
        /// </summary>
        protected string GetModulePath
        {
            get
            {
               return HostApi.GetModulePath(ModuleID);
            }
        }
        /// <summary>
        /// 获取当前菜单的ID
        /// </summary>
        protected Guid MenuID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["muid"]))
                {
                    return new Guid(Request["muid"]);
                }
                else
                {
                    Tips("出错了", "列表页找不到相应的菜单数据，请确认访问路径是否正确！");
                }
                return Guid.Empty;
            }
        }
        protected override string GetSplitPagePram
        {
            get
            {
                string str = "";
                if (base.PageType > -1)
                {
                    str = string.Format("t={0}", base.PageType);
                }
                else
                {
                    str = string.Format("mid,{0}|muid,{1}", base.Request["mid"], base.Request["muid"]);
                }
                if (base.GetSubPageType > 0)
                {
                    str = str + "&st=" + base.GetSubPageType;
                }
                return str;
            }
        }
        override protected  string GetUrl
        {
            get
            {
                return string.Format("{0}?muid={1}&mid={2}", this.GetPageName, this.MenuID, this.ModuleID);
            }
        }

        //protected override void AddHelpBntToToolBar()
        //{
        //    //添加帮助按钮
        //    ToolBarItem item = new ToolBarItem();
        //    item.Text = "帮助";
        //    item.Img = base.IISPath + "images/menus/help.png";
        //    item.IsRight = true;
        //    item.OnClientClick = string.Format("OpenDialog_Iframe('{0}SystemManage/Admin_Modules.aspx?t=15&mid={1}&id={2}','查看帮助',600,300);", base.IISPath, ModuleID, MenuID);
        //    item.IsPostBack = false;
        //    this.ucToolBar.Items.Add(item);
        //}
        /// <summary>
        /// 检测当前用户是否具有某个权限ID
        /// </summary>
        /// <param name="LimitID">权限Id</param>
        /// <returns></returns>
       override protected bool IsHaveLimit(string LimitID)
        {
            if (!string.IsNullOrEmpty(LimitID))
                return HostApi.IsHaveLimit(EbSite.Base.AppStartInit.UserID, Core.Utils.StrToInt(LimitID, -1), ModuleID);
            return true;
            
        }
    }
}

