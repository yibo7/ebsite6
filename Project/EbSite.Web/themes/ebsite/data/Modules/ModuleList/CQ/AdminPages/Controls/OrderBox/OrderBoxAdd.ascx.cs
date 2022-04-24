using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages.Controls.OrderBox
{
    public partial class OrderBoxAdd : MPUCBaseSave
    {
       
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("3054004f-c741-4c35-9e4a-893bf7f2d53a");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //DefaultParentClassID.Visible = false;
        }
        public override string Permission
        {
            get
            {
                return "12";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
            ModuleCore.BLL.OrderBox.Instance.InitModifyCtr(int.Parse(SID), phCtrList);
        }
        override protected void SaveModel()
        {
            //Base.BLL.OtherColumn cRealname = new OtherColumn("OrderID", ModuleCore.BLL.OrderBox.Instance.GetMaxID.ToString());
            //lstOtherColumn.Add(cRealname);

            ModuleCore.BLL.OrderBox.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
        }

        
    }
}