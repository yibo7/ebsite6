using System;

namespace EbSite.Web.AdminHt.Controls.Admin_Class
{
    public partial class MergeClassMore : EbSite.Base.ControlPage.UserControlBaseSave
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        public override string Permission
        {
            get
            {
                return "58";
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

        }
        
        override protected void SaveModel()
        {
            string sSID = drpSoure.Value;
            string sTID = drpTarget.Value;

            if (!string.IsNullOrEmpty(sSID) && !string.IsNullOrEmpty(sTID))
            {
                int iSid = int.Parse(sSID);

                int iTid = int.Parse(sTID);

                //验证是否 同一模型 2014-2-27 YHL
                if (EbSite.BLL.ClassConfigs.Instance.GetClassModelID(iSid) != EbSite.BLL.ClassConfigs.Instance.GetClassModelID(iTid))
                {
                    base.TipsAlert("请选择同一模型下的分类！");
                    return;
                }


                string sTClassName = BLL.NewsClass.GetModel(iTid).ClassName;

                BLL.NewsClass.MergeClass(iSid, iTid, sTClassName, base.GetSiteID, "NewsContent");

                Response.Redirect(Request.RawUrl);
            }
        }
    }
}