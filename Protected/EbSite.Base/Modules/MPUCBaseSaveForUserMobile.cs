
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

using EbSite.Base.Page;
using System;
namespace EbSite.Base.Modules
{

    public abstract class MPUCBaseSaveForUserMobile : MPUCBaseSaveForUser
    {

        new  protected LinkButton bntSave;
        protected MPUCBaseSaveForUserMobile()
        {
            this.Load += new EventHandler(BMPUCBaseSaveForUserMobile_Load);
        }

        private void BMPUCBaseSaveForUserMobile_Load(object sender, EventArgs e)
        {

            if (!Equals(bntSave, null))
            {
                if (!Page.IsPostBack)
                {
                    string sText = string.IsNullOrEmpty(bntSave.Text) ? " 保 存 " : bntSave.Text;
                    bntSave.Text = string.Format("<div style=\"width:100%;\"    class=\"button btngreen2 btnbig\"   >{0}</div>", sText);
                }
               
                
                bntSave.Click += new EventHandler(bntSave_Click);

            }
        }

    }
}

