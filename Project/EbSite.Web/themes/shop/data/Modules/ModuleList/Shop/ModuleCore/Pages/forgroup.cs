using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using EbSite.Base.Page;
using EbSite.Modules.Shop.ModuleCore.Cart;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    public class forgroup : BasePageM
    {

        protected global::System.Web.UI.WebControls.Button btnSave;
        protected global::System.Web.UI.WebControls.TextBox txtMobile;
        protected global::System.Web.UI.WebControls.TextBox txtEmail;
        protected global::System.Web.UI.WebControls.TextBox txtPrice;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "求团购";
            btnSave.Click += new EventHandler(btnSave_Click);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string ProductID = Request.QueryString["pid"];
            ModuleCore.Entity.requestgroup md = new requestgroup();
            md.Mobile = this.txtMobile.Text.Trim();
            md.Email = this.txtEmail.Text.Trim();
            md.RequestPrice = Convert.ToDecimal(this.txtPrice.Text.Trim());
            md.ProductID = EbSite.Core.Utils.StrToInt(ProductID, 0);
            md.AddDateTime = DateTime.Now;
            md.UserID = base.UserID;
            md.UserName = base.UserNiName;
            md.IsNotice = 0;
            int key = ModuleCore.BLL.requestgroup.Instance.Add(md);
            if (key > 0)
            {
                txtMobile.Text = "";
                txtEmail.Text = "";
                txtPrice.Text = "";
                Response.Write("<script>alert('添写成功！')</script>");
            }

        }
        #region 解决重写url后，保持postback地址不改变的问题

        //// <summary>
        ///  重写默认的HtmlTextWriter方法，修改form标记中的value属性，使其值为重写的URL而不是真实URL。
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (writer is System.Web.UI.Html32TextWriter)
            {
                writer = new FormFixerHtml32TextWriter(writer.InnerWriter);
            }
            else
            {
                writer = new FormFixerHtmlTextWriter(writer.InnerWriter);
            }

            base.Render(writer);
        }
        #endregion

    }
}