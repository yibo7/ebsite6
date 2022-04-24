using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.AdminPages.Controls.GoodsManage
{
    public partial class EditAttributeValuesAdd : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "添加属性值";
            }
        }
        public override string Permission
        {
            get
            {
                return "35";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }

        private int TypeNameValueID
        {
            get
            {
                return Core.Utils.StrToInt(Request.QueryString["pid"], 0);
            }
        }

        override protected void InitModifyCtr()
        {
            ModuleCore.BLL.TypeNameValues.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {
            List<OtherColumn> ls = new List<OtherColumn>();
            OtherColumn c = new OtherColumn("TypeNameValueID", TypeNameValueID.ToString());
            ls.Add(c);
            c = new OtherColumn("OrderID", "1");
            ls.Add(c);
            ModuleCore.BLL.TypeNameValues.Instance.SaveEntityFromCtr(phCtrList, ls);

        }
    }
}