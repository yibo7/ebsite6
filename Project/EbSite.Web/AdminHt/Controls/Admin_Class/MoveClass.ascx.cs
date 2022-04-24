using System;

namespace EbSite.Web.AdminHt.Controls.Admin_Class
{
    public partial class MoveClass : EbSite.Base.ControlPage.UserControlBaseSave
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
                return "57";
            }
        }
        private void BindData()
        {
            lbsSourceclass.DataTextField = "classname";
            lbsSourceclass.DataValueField = "id";
            lbsSourceclass.DataSource = BLL.NewsClass.GetContentClassesTree(5000,base.GetSiteID);
            lbsSourceclass.DataBind();

            lbsTarget.DataTextField = "classname";
            lbsTarget.DataValueField = "id";
            lbsTarget.DataSource = BLL.NewsClass.GetContentClassesTree(5000,base.GetSiteID);
            lbsTarget.DataBind();

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
            if (lbsSourceclass.SelectedValue == lbsTarget.SelectedValue)
            {
                base.TipsAlert("您所要移动的分类与目标分类相同，无法移动！");
                return;
            }

            if(string.IsNullOrEmpty(lbsSourceclass.SelectedValue)||string.IsNullOrEmpty(lbsTarget.SelectedValue))
            {
                base.TipsAlert("请选择好源分类与目标分类！");
                return;
            }

          

            int iSoureClassID = int.Parse(lbsSourceclass.SelectedValue);
            int iTargetClassID = int.Parse(lbsTarget.SelectedValue);

             //验证是否 同一模型 2014-2-27 YHL
            if (EbSite.BLL.ClassConfigs.Instance.GetClassModelID(iSoureClassID) != EbSite.BLL.ClassConfigs.Instance.GetClassModelID(iTargetClassID))
            {
                base.TipsAlert("请选择同一模型下的分类！");
                return;
            }
            bool IsToSub = (Equals(movetype.SelectedValue, "1"));
            BLL.NewsClass.MoveClass(iSoureClassID, iTargetClassID, IsToSub, base.GetSiteID);

            BindData();

        }
       
    }
}