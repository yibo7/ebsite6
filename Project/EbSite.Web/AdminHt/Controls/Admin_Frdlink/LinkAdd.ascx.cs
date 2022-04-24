using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Frdlink
{
    public partial class LinkAdd : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "309";
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
            BLL.outlinks.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {

            lstOtherColumn.Add(new OtherColumn("AddTime", DateTime.Now.ToString()));
            lstOtherColumn.Add(new OtherColumn("SiteID",GetSiteID.ToString()));
            lstOtherColumn.Add(new OtherColumn("IsAuditing", "true"));
            if (!string.IsNullOrEmpty(LogoUrl.CtrValue))
            {
                lstOtherColumn.Add(new OtherColumn("IsHaveLogo", "true"));
                
            }
            else
            {
                lstOtherColumn.Add(new OtherColumn("IsHaveLogo", "false"));
            }



            BLL.outlinks.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);


        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {


            }
        }
    }
}