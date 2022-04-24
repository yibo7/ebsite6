using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.ContentSet;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_SEO
{
    public partial class PageCode : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "279";
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
            throw new NotImplementedException();
        }
        override protected void SaveModel()
        {
            ConfigsControl.Instance.PageSizeClass = int.Parse(txtPageSizeClass.Text.Trim());
            ConfigsControl.Instance.PageSizeSpecail = int.Parse(txtPageSizeSpecial.Text.Trim());
            ConfigsControl.Instance.PageSizeTagList = int.Parse(txtPageSizeTag.Text.Trim());
            ConfigsControl.Instance.PageSizeTagValue = int.Parse(txtPageSizeTagValue.Text.Trim());

            
            
            ConfigsControl.SaveConfig();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtPageSizeClass.Text = ConfigsControl.Instance.PageSizeClass.ToString();
                txtPageSizeSpecial.Text = ConfigsControl.Instance.PageSizeSpecail.ToString();
                txtPageSizeTag.Text = ConfigsControl.Instance.PageSizeTagList.ToString();
                txtPageSizeTagValue.Text = ConfigsControl.Instance.PageSizeTagValue.ToString();



            }
        }
    }
}