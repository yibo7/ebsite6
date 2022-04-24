using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Modules
{
    public abstract class BasePage : EbSite.Base.ControlPage.UserControlBase
    {
        public override string Permission
        {
            get
            {
                return "";
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
                if (!Equals(GetModuleID,Guid.Empty))
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
    }
}