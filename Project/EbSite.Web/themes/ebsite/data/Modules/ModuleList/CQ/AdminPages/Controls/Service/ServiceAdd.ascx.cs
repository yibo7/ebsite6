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

namespace EbSite.Modules.CQ.AdminPages.Controls.Service
{
    public partial class ServiceAdd : MPUCBaseSave
    {
       
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("a85f9d78-adba-49e9-9765-659e33674993");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public override string Permission
        {
            get
            {
                return "2";
            }
        }
        protected override void OnBasePageLoading()
        {
            ClassID.DataTextField = "Title";
            ClassID.DataValueField = "id";
            ClassID.DataSource = ModuleCore.BLL.ServiceClass.Instance.FillList();
            ClassID.DataBind();
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
            ModuleCore.BLL.Service.Instance.InitModifyCtr(int.Parse(SID), phCtrList);

            ModuleCore.Entity.ServiceInfo md = ModuleCore.BLL.Service.Instance.GetEntity(int.Parse(SID));

            txtUserInfo.UserID = md.UserID.ToString();
            txtUserInfo.UserName = md.UserName;
            txtUserInfo.UserNiName = md.UserNiName;
        }
        override protected void SaveModel()
        {
            Base.BLL.OtherColumn cRealname = new OtherColumn("OrderID", ModuleCore.BLL.Service.Instance.GetMaxID.ToString());
            lstOtherColumn.Add(cRealname);

            

            lstOtherColumn.Add(new OtherColumn("UserID", txtUserInfo.UserID));
            lstOtherColumn.Add(new OtherColumn("UserName", txtUserInfo.UserName));
            lstOtherColumn.Add(new OtherColumn("UserNiName", txtUserInfo.UserNiName));
            //UserInfo
            ModuleCore.BLL.Service.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);

            ModuleCore.BLL.Service.Instance.UpdateFloatJsData();
            

        }

       

    }
}