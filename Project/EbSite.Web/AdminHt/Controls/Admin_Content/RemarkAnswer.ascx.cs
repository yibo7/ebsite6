using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Core;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Content
{
    public partial class RemarkAnswer : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "126";
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

             EbSite.Entity.Remark   md = EbSite.BLL.Remark.GetModel(Convert.ToInt32(SID));
            this.txtWt.Text = md.Body;
            txtCt.Text = md.Quote;

        }

        override protected void SaveModel()
        {
            if(!string.IsNullOrEmpty(txtCt.Text.Trim()))
            {

                EbSite.Entity.Remark md = EbSite.BLL.Remark.GetModel(Convert.ToInt32(SID));
                md.IsAsked = true;//标记已经有回复
               
                md.Quote = this.txtCt.Text.Trim();

                md.DateAskTime = DateTime.Now;
                if (!string.IsNullOrEmpty(md.Quote))
                {
                    BLL.Remark.Update(md);
                    base.TipsAlert("回复成功！");
                }
               
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}