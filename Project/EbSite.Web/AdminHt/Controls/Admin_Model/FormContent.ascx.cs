using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.BLL.GetLink;
using EbSite.BLL.ModelBll;
using EbSite.Entity;
using System.Data;

namespace EbSite.Web.AdminHt.Controls.Admin_Model
{
    public partial class FormContent : UserControlListBase
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
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }
      
        /// <summary>
        /// 获取表单模型ID
        /// </summary>
        private Guid ModelID
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

        private CusttomFiledsBLL<StringDictionary> CFB
        {
            get
            {
                return EbSite.BLL.ModelBll.CusstomFileds.HrefFactory.GetInstance(ModelID, ModelType.BDMX,GetSiteID);
            }
        }
        protected string GetFormPageUrl(object id)
        {
            //return string.Concat(EbSite.Base.Host.Instance.Domain, BLL.GetLink.HrefFactory.GetReWriteInstance(GetSiteID).GetFormUrl(ModelID.ToString()), "?id=", id);
            return string.Concat(EbSite.Base.Host.Instance.Domain, LinkOrther.Instance.GetReWriteInstance(GetSiteID).GetFormUrl(ModelID.ToString()), "?id=", id);
        }

        protected string GetDelUrl(object id)
        {
            return string.Format("?delid={0}&mid={1}&t={2}", id, ModelID,Request["t"]);
        }
        override protected object LoadList(out int iCount)
        {
            if (!string.IsNullOrEmpty(Request["delid"]))
            {
                Guid id = new Guid(Request["delid"]);
                CFB.Delete(id);
            }

            iCount = 0;
            CusttomFiledsBLLForm cfb = new CusttomFiledsBLLForm(ModelID,EbSite.Base.Host.Instance.GetSiteID);
           
            return cfb.GetDataTable(gdList);

           // return null;
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {

            CFB.Delete(int.Parse(iID.ToString()));

        }
        
    }
}