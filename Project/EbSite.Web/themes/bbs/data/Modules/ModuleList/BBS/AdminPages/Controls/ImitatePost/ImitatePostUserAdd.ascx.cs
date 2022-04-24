using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.BBS.ModuleCore.Entity;

namespace EbSite.Modules.BBS.AdminPages.Controls.ImitatePost
{
    public partial class ImitatePostUserAdd : MPUCBaseSave
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
                return new Guid("400ac069-2b3d-4807-880d-e6c9ed8c8030");
            }
        }
        override protected void InitModifyCtr()
        {
            BLL.SpaceTabsDefault.Instance.InitModifyCtr(new Guid(SID), phCtrList);
        }
        override protected void SaveModel()
        {

            int uid = int.Parse(suMainUser.UserID);
            string uName = suMainUser.UserName;
            string uNiName = suMainUser.UserNiName;

            string[] imitateuserid = suImitateUser.UserID.Split(',');
            string[] imitateusername = suImitateUser.UserName.Split(',');
            string[] imitateuserniname = suImitateUser.UserNiName.Split(',');

            for (int i = 0; i < imitateuserid.Length; i++)
            {
                int ImitateID = int.Parse(imitateuserid[i]);
                ModuleCore.Entity.imitateuser md = new imitateuser();
                md.UserID = uid;
                md.UserNiName = uNiName;
                md.ImitateUserID = ImitateID;
                md.ImitateUserName = imitateusername[i];
                md.ImitateUserRealName = imitateuserniname[i];
                ModuleCore.BLL.imitateuser.Instance.Add(md);
            }
            
        }
    }
}