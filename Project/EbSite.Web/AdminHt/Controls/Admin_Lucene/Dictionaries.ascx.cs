using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Lucene
{
    public partial class Dictionaries : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "304";
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

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {


            }
        }
    }
}