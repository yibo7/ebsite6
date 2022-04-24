using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.CQ.AdminPages.Controls.CustomWord
{
    public partial class  Add : MPUCBaseSave
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("41388e6b-f5df-4520-8a61-58f85978462c");
            }
        }

        public override string Permission
        {
            get
            {
                return "10";
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
            ModuleCore.Entity.CustomWord md = ModuleCore.BLL.CustomWord.Instance.GetEntity(int.Parse(SID));
            this.ServiceName.Text = md.CommonlyInfo;
            this.OrderID.Text = md.OrderID.ToString();
        }
        override protected void SaveModel()
        {
            if (string.IsNullOrEmpty(SID))
            {
                ModuleCore.Entity.CustomWord md = new ModuleCore.Entity.CustomWord();
                md.OpDate = DateTime.Now;
                //  md.UserId = base.UserID;
                md.CommonlyInfo = this.ServiceName.Text.Trim();
                md.OrderID = Convert.ToInt32(this.OrderID.Text.Trim());
                ModuleCore.BLL.CustomWord.Instance.Add(md);
            }
            else
            {
                ModuleCore.Entity.CustomWord md = ModuleCore.BLL.CustomWord.Instance.GetEntity(int.Parse(SID));
                md.CommonlyInfo = this.ServiceName.Text.Trim();
                md.OrderID = Convert.ToInt32(this.OrderID.Text.Trim());
                ModuleCore.BLL.CustomWord.Instance.Update(md);
            }
        }

    }
}