using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.Supplier
{
    public partial class SuppliersEdit : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "供货商添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "6";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }
        override protected void InitModifyCtr()
        {
            ModuleCore.BLL.Supplier.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {
            if (string.IsNullOrEmpty(SID))
            {
                ModuleCore.BLL.Supplier.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
            }
            else
            {
                EbSite.Base.BLL.OtherColumn column = new Base.BLL.OtherColumn("id", SID);
                lstOtherColumn.Add(column);
                ModuleCore.BLL.Supplier.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
            }
            base.ShowTipsPop("操作成功");
        }
    }
}