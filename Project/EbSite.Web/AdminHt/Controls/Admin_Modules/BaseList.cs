using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Base.ControlPage;
using EbSite.BLL.ModulesBll;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Modules
{
    public abstract class BaseList : UserControlListBase
    {
        override protected string AddUrl
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
                return "1";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "1";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "1";
            }
        }
        /// <summary>
        /// 获取某个模块的菜单业务层
        /// </summary>
       virtual protected ModuleMenu MenuBll
        {
            get
            {
                if(IsHaveModule)
                {
                    return new MenusForAdminer(GetModuleID);
                }
                Tips("出错了", "找不到相应的模块数据，请确认访问路径是否正确！");
                return null;
            }
        }
        /// <summary>
        /// 获取当前菜单ID
        /// </summary>
        protected Guid GetMenuID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return new Guid(Request["id"]);
                }
                else
                {
                    Tips("出错了", "找不到相应的菜单数据，请确认访问路径是否正确！");
                }
                return Guid.Empty;
            }
        }
        /// <summary>
        /// 获取当前模块ID
        /// </summary>
        protected Guid GetModuleID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["mid"]))
                {
                    return new Guid(Request["mid"]);
                }
                return Guid.Empty;
            }
        }
        /// <summary>
        /// 是否存在当前模块
        /// </summary>
        protected bool IsHaveModule
        {
            get
            {
                return !Equals(GetModuleID, Guid.Empty);
            }
        }
        /// <summary>
        /// 获取当前模块实体
        /// </summary>
        protected ModuleInfo Model
        {
            get
            {
                ModuleInfo md = new ModuleInfo();
                if (!Equals(GetModuleID, Guid.Empty))
                {
                    return BLL.ModulesBll.Modules.Instance.GetEntity(GetModuleID);
                }
                return md;
            }
        }
        /// <summary>
        /// 获取当前模块安装路径
        /// </summary>
        protected string sModulePath
        {
            get
            {
                if (!Equals(GetModuleID, Guid.Empty))
                {
                    return BLL.ModulesBll.Modules.Instance.GetModelPath(GetModuleID);
                }
                return "";
            }
        }
        protected override string GetSplitPagePram
        {
            get
            {
                string str = "";
                if (base.PageType > -1)
                {
                    str = string.Format("t,{0}|mid,{1}", base.PageType, base.Request["mid"]);
                }
                else
                {
                    str = string.Format("mid,{0}", base.Request["mid"]);
                }
                if (base.GetSubPageType > 0)
                {
                    str = str + "&st=" + base.GetSubPageType;
                }
                return str;
            }
        }
    }
}