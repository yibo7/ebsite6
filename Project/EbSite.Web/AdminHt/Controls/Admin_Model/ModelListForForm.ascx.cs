using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.BLL.GetLink;
using EbSite.BLL.ModelBll;

namespace EbSite.Web.AdminHt.Controls.Admin_Model
{
    public partial class ModelListForForm : ModelListBase<StringDictionary>
    {
        #region 权限
        public override string Permission
        {
            get
            {
                return "271";
            }
        }
        /// <summary>
        /// 添加权限的标识
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "271";
            }
        }
        /// <summary>
        /// 删除权限的标识
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "271";
            }
        }
        /// <summary>
        /// 修改权限的标识
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "271";
            }
        }

        #endregion
        public override ModelBase<StringDictionary> bllModel
        {
            get
            {
                return new FormModel(GetSiteID);
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=7";
            }
        }
        protected string GetFormPageUrl(object id)
        {
            //return string.Concat(EbSite.Base.Host.Instance.Domain,BLL.GetLink.HrefFactory.GetReWriteInstance(GetSiteID).GetFormUrl(id.ToString()));
            return string.Concat(EbSite.Base.Host.Instance.Domain, LinkOrther.Instance.GetReWriteInstance(GetSiteID).GetFormUrl(id.ToString()));
        }
       override protected string GetOrderUrl(object id)
        {
            return string.Concat("?mt=3&t=3&id=", id);
        }
       protected string GetEditFiledUrl(object id)
       {
           return string.Concat("?mt=3&t=5&id=", id);
       }
    }
}