using System;

namespace EbSite.Web.AdminHt.Controls.Admin_Special
{
    public partial class MoveSpecial : EbSite.Base.ControlPage.UserControlBaseSave
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                //BindData();
                
            }
        }
        public override string Permission
        {
            get
            {
                return "69";
            }
        }
        //private void BindData()
        //{
        //    lbsSourceclass.DataTextField = "specialname";
        //    lbsSourceclass.DataValueField = "id";
        //    lbsSourceclass.DataSource = BLL.SpecialClass.GetTree(5000, GetSiteID);
        //    lbsSourceclass.DataBind();

        //    lbsTarget.DataTextField = "specialname";
        //    lbsTarget.DataValueField = "id";
        //    lbsTarget.DataSource = BLL.SpecialClass.GetTree(5000,base.GetSiteID);
        //    lbsTarget.DataBind();

        //}
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
            string sSID = drpSoure.Value;
            string sTID = drpTarget.Value;
            if (sSID == sTID)
            {
                base.TipsAlert("您所要移动的分类与目标分类相同，无法移动！");
                return;
            }

            if (string.IsNullOrEmpty(sSID) || string.IsNullOrEmpty(sTID))
            {
                base.TipsAlert("请选择好源分类与目标分类！");
                return;
            }

            int iSoureClassID = int.Parse(sSID);
            int iTargetClassID = int.Parse(sTID);
            bool IsToSub = (Equals(movetype.SelectedValue, "1"));
            BLL.SpecialClass.SpecialClassMove(iSoureClassID, iTargetClassID, IsToSub, base.GetSiteID);

            Response.Redirect(Request.RawUrl);

        }
    }
}