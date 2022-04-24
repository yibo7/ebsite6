using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Widgettem
{
    public partial class contenttemadd : UserControlBaseSave
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ctbTag.EndLiteral = llTagEnd;
            //ctbTag.Items = string.Format("模板名称#tg1|列表模板#tg2");
        }
        public override string Permission
        {
            get
            {
                return "116";
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
            Entity.ContentTem cm = BLL.ContentTem.Instance.GetEntity(new Guid(SID));
            txtClassTitle.Text = cm.Title;
            txtHeaderTemHtml.Text = BLL.ContentTem.Instance.GetHeaderTemHtmlByID(cm.id);
            txtListTemHtml.Text = BLL.ContentTem.Instance.GetListemHtmlByID(cm.id);
        }

        override protected void SaveModel()
        {
           
            if(string.IsNullOrEmpty(SID))
            {
                Entity.ContentTem cm = new ContentTem();
                cm.id = Guid.NewGuid();
                cm.Title = txtClassTitle.Text;
                BLL.ContentTem.Instance.AddTem(cm, txtHeaderTemHtml.Text, txtListTemHtml.Text);
            }
            else
            {
                Entity.ContentTem cm = BLL.ContentTem.Instance.GetEntity(new Guid(SID));
                cm.Title = txtClassTitle.Text;
                BLL.ContentTem.Instance.UpdateTem(cm,txtHeaderTemHtml.Text,txtListTemHtml.Text);
            }
        }
    }
}