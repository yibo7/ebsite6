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
    public partial class DesignFloor : MPUCBaseSave
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("a4de7dee-4d12-4738-ada0-f8b27960811f");
            }
        }
        public override string PageName
        {
            get
            {
                return "设计楼层";
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