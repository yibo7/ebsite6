using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.FloorSet
{
    public partial class MobileDesignFloor : MPUCBaseSave
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("86d17e6e-af5f-4111-a6a7-8ed8f445ebdd");
            }
        }
        public override string PageName
        {
            get
            {
                return "Mobile设计楼层";
            }
        }
        public override string Permission
        {
            get
            {
                return "96";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int FloorId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    return EbSite.Core.Utils.StrToInt(Request.QueryString["id"], 0);
                }
                return 0;
            }
        }
        override protected void InitModifyCtr()
        {


        }


        override protected void SaveModel()
        {


        }
    }
}