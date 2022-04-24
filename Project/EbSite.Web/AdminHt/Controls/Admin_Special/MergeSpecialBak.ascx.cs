using System;

namespace EbSite.Web.AdminHt.Controls.Admin_Special
{
    public partial class MergeSpecialBak : EbSite.Base.ControlPage.UserControlBaseSave
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }
        public override string Permission
        {
            get
            {
                return "70";
            }
        }
        private void BindData()
        {
            drpSoure.DataTextField = "specialname";
            drpSoure.DataValueField = "id";
            drpSoure.DataSource = BLL.SpecialClass.GetTree(5000, GetSiteID);
            drpSoure.DataBind();

            drpTarget.DataTextField = "specialname";
            drpTarget.DataValueField = "id";
            drpTarget.DataSource = BLL.SpecialClass.GetTree(5000, GetSiteID);
            drpTarget.DataBind();

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

        }

        override protected void SaveModel()
        {
            string sSID = drpSoure.SelectedValue;
            string sTID = drpTarget.SelectedValue;

            if (!string.IsNullOrEmpty(sSID) && !string.IsNullOrEmpty(sTID))
            {
                int iSid = int.Parse(sSID);

                int iTid = int.Parse(sTID);

                BLL.SpecialClass.MergeSpecail(iSid, iTid, base.GetSiteID);
            }
        }
    }
}