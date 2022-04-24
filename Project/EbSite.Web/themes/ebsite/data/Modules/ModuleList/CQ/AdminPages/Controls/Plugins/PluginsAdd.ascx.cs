using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.AdminPages.Controls.Plugins
{
    public partial class PluginsAdd : MPUCBaseSave
    {
       
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("72695a84-dd8e-4e27-9277-a90e6d74add6");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public override string Permission
        {
            get
            {
                return "14";
            }
        }
        protected override void OnBasePageLoading()
        {
          
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
            ModuleCore.BLL.ChatPlugin.Instance.InitModifyCtr(int.Parse(SID), phCtrList);

            //ModuleCore.Entity.ChatPlugin md = ModuleCore.BLL.ChatPlugin.Instance.GetEntity(int.Parse(SID));

            //txtUserInfo.UserID = md.UserID.ToString();
            //txtUserInfo.UserName = md.UserName;
            //txtUserInfo.UserNiName = md.UserNiName;
        }
        override protected void SaveModel()
        {
            //Base.BLL.OtherColumn cRealname = new OtherColumn("OrderID", ModuleCore.BLL.Service.Instance.GetMaxID.ToString());
            //lstOtherColumn.Add(cRealname);

            

            //lstOtherColumn.Add(new OtherColumn("UserID", txtUserInfo.UserID));
            //lstOtherColumn.Add(new OtherColumn("UserName", txtUserInfo.UserName));
            //lstOtherColumn.Add(new OtherColumn("UserNiName", txtUserInfo.UserNiName));
            //UserInfo
            ModuleCore.BLL.ChatPlugin.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
            ModuleCore.BLL.ChatPlugin.Instance.BuilderJs();
            

        }

       

    }
}