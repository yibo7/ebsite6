using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;
using EbSite.Modules.Wenda.ModuleCore.Entity;

namespace EbSite.Modules.Wenda.AdminPages.Controls.Experts
{
    public partial class AddExperts : MPUCBaseSave
    {
        public override string Permission
        {
            get
            {
                return "27";
            }
        }
        public override string PageName
        {
            get
            {
                return "添加专家";
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
                return new Guid("4491705b-75a4-4512-9195-674c72864d7c");
            }
        }
        override protected void InitModifyCtr()
        {
            ModuleCore.BLL.ExpertsControl.Instance.InitModifyCtr(int.Parse(SID), phCtrList);

            ModuleCore.Entity.ExpertsInfo md = ModuleCore.BLL.ExpertsControl.Instance.GetEntity(int.Parse(SID));

            txtUserInfo.UserID = md.UserID.ToString();
            txtUserInfo.UserName = md.UserName;
            txtUserInfo.UserNiName = md.UserNiName;

            if (md.IsAudit > 0)
            {
                this.rdoYES.Checked = true;
                this.rdoNo.Checked = false;
            }
            else
            {
                this.rdoNo.Checked = true;
                this.rdoYES.Checked = false;
            }
        }


        override protected void SaveModel()
        {
           
            ModuleCore.Entity.ExpertsInfo md;
            if (!string.IsNullOrEmpty(SID))
            {
                md = ModuleCore.BLL.ExpertsControl.Instance.GetEntity(int.Parse(SID));
            }
            else
            {
                md = new ExpertsInfo(); 

            }
            md.Area = this.Area.Text;
            md.Field = this.Field.Text;
            md.UserID =int.Parse( txtUserInfo.UserID);
            md.UserName = txtUserInfo.UserName;
            md.UserNiName = txtUserInfo.UserNiName;
            md.IsAudit = this.rdoYES.Checked ? 1 : 0;
            md.Brand = this.Brand.Text;
            md.JianJie = this.JianJie.Text;
            md.Postition = this.Postition.Text;
            if (!string.IsNullOrEmpty(SID))
            {
                md.id = Core.Utils.StrToInt(SID);
                ModuleCore.BLL.ExpertsControl.Instance.Update(md);
            }
            else
            {
                ModuleCore.BLL.ExpertsControl.Instance.Add(md);
            }
        }

      
    }
}