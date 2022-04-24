using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages.Controls.Service
{
    public partial class ServiceClassAdd : MPUCBaseSave
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("821e4073-9dfd-41df-9b53-358cae866a81");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public override string Permission
        {
            get
            {
                return "16";
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
            ModuleCore.BLL.ServiceClass.Instance.InitModifyCtr(int.Parse(SID), phCtrList);
        }
        
        override protected void SaveModel()
        {
            Base.BLL.OtherColumn cRealname = new OtherColumn("OrderID", ModuleCore.BLL.OrderBox.Instance.GetMaxID.ToString());
            lstOtherColumn.Add(cRealname);

            ModuleCore.BLL.ServiceClass.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);

            ModuleCore.BLL.ServiceClass.Instance.UpdateFloatJsData();
        }

    }
}