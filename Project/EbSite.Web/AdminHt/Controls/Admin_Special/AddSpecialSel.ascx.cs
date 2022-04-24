using System;
using System.Text;
using System.Web.UI.WebControls;
using EbSite.BLL;

namespace EbSite.Web.AdminHt.Controls.Admin_Special
{
    public partial class AddSpecialSel : EbSite.Base.ControlPage.UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "67";
            }
        }
      
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        
        override protected void SaveModel()
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
        }
      


    }
}