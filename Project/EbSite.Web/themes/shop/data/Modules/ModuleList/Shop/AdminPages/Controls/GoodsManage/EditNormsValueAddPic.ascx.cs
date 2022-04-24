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
    public partial class EditNormsValueAddPic : MPUCBaseSave
	{

        public override string PageName
        {
            get
            {
                return "添加规格值（图片）";
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
            ModuleCore.BLL.TypeRelationProduct.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {
            ModuleCore.Entity.NormsValue md = new NormsValue();
            md.NormsValueName = NormsValueName.Text;
            md.OrderID = 1;
            md.NormID = TypeNameValueID;
            md.NormsIco = fileUpLoad.CtrValue;
            ModuleCore.BLL.NormsValue.Instance.Add(md);

        }
	}
}