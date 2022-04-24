using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace
{
    public partial class DefaultTabAdd : MPUCBaseSave
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Layout.DataTextField = "LayoutName";
                Layout.DataValueField = "FileName";
                Layout.DataSource = EbSite.BLL.LayoutPane.Instance.FillList();
                Layout.DataBind();

                UserGroupID.AppendDataBoundItems = true;
                UserGroupID.Items.Insert(0, new ListItem("所有用户", "0"));
                UserGroupID.DataTextField = "groupname";
                UserGroupID.DataValueField = "id";
                UserGroupID.DataSource = EbSite.BLL.User.UserGroupProfile.UserGroupProfiles;
                UserGroupID.DataBind();
                

                
                
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
                return "id";
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("67eb0f9d-f9e2-4867-9d9d-737e98ad587c");
            }
        }
        override protected void InitModifyCtr()
        {
            BLL.SpaceTabsDefault.Instance.InitModifyCtr(new Guid(SID), phCtrList);
        }
        override protected void SaveModel()
        {
            //Base.BLL.OtherColumn cRealname = new OtherColumn("UserID", "0");
            //lstOtherColumn.Add(cRealname);
            BLL.SpaceTabsDefault.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
            base.ShowTipsPop("保存成功");
        }
    }
}