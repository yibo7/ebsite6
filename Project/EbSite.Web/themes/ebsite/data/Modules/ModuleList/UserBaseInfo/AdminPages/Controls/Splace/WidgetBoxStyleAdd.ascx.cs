using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace
{
    public partial class WidgetBoxStyleAdd : MPUCBaseSave
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("55f4ad36-b218-4f90-8d2c-247ad295741a");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                //yhl 2012-01-04 给注释
                //CopyThemeID.AppendDataBoundItems = true;
                //CopyThemeID.Items.Insert(0, new ListItem("所有皮肤", "0"));
                //CopyThemeID.DataTextField = "ThemeName";
                //CopyThemeID.DataValueField = "id";
                //CopyThemeID.DataSource = EbSite.BLL.SpaceThemes.Instance.GetListArray("");
                //CopyThemeID.DataBind();

                //StyleClass.AppendDataBoundItems = true;//0代表EbSite，1代表个空间
                //StyleClass.Items.Insert(0, new ListItem("EbSite", "0"));
                //StyleClass.Items.Insert(1, new ListItem("个人空间", "1"));
                //StyleClass.DataBind();
            }
        }
        public override string Permission
        {
            get
            {
                return "11";
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
            BLL.WidgetBoxStyle.Instance.InitModifyCtr(new Guid(SID), phCtrList);
            //yhl 2012-01-04 给注释
            //EbSite.Entity.WidgetBoxStyle md = EbSite.BLL.WidgetBoxStyle.Instance.GetEntity(new Guid(SID));
            //CopyThemeID.SelectedIndex = md.ThemeID;
            //StyleClass.SelectedIndex = md.StyleClass;
        }
        protected override void SaveModel()
        {
            //yhl 2012-01-04 给注释
            //Base.BLL.OtherColumn cRealname = new OtherColumn("ThemeID", CopyThemeID.SelectedValue);
            //lstOtherColumn.Add(cRealname);
            //cRealname = new OtherColumn("StyleClass", StyleClass.SelectedValue);
            //lstOtherColumn.Add(cRealname);

            Base.BLL.OtherColumn cRealname =  new OtherColumn("StyleColorPram", StyleColorPram.Text);
            lstOtherColumn.Add(cRealname);

            cRealname = new OtherColumn("CustomDropDownListPram", CustomDropDownListPram.Text);
            lstOtherColumn.Add(cRealname);

            BLL.WidgetBoxStyle.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
            base.ShowTipsPop("保存成功");
        }
    }
}