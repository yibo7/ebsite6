using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace
{
    public partial class ThemesClassAdd : MPUCBaseSave
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("9e758659-8d99-48af-aefb-56beef996922");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
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
                return "2";
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
            BLL.SpaceThemeClass.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {
            Base.BLL.OtherColumn cRealname = new OtherColumn("addtime", DateTime.Now.ToString());
            lstOtherColumn.Add(cRealname);
            BLL.SpaceThemeClass.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
            base.ShowTipsPop("保存成功");
        }
    }
}