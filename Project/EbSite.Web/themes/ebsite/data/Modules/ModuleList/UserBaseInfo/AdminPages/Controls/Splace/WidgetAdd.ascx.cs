using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace
{
    public partial class WidgetAdd : MPUCBaseSave
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("8870375d-20f5-4104-bf3d-73f6808b3f09");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ThemeClassID.DataTextField = "classname";
                ThemeClassID.DataValueField = "id";
                ThemeClassID.DataSource = EbSite.BLL.SpaceThemeClass.Instance.GetListArray("");
                ThemeClassID.DataBind();


                txtID.DataTextField = "title";
                txtID.DataValueField = "DataID";
                txtID.DataSource = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetList();
                txtID.DataBind();

                ImgUrl.SaveFolder = string.Concat(IISPath, "home/UploadFile");

            }
        }
        public override string Permission
        {
            get
            {
                return "8";
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
            BLL.HomeWidget.Instance.InitModifyCtr(new Guid(SID), phCtrList);
            Entity.HomeWidgetInfo md = BLL.HomeWidget.Instance.GetEntity(new Guid(SID));
            txtID.SelectedValue = md.id.ToString();
            txtID.Enabled = false;
        }
        override protected void SaveModel()
        {
           

            Base.BLL.OtherColumn cRealname = new OtherColumn("id", txtID.SelectedValue);
            lstOtherColumn.Add(cRealname);

            BLL.HomeWidget.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
            base.ShowTipsPop("保存成功");
        }
    }
}