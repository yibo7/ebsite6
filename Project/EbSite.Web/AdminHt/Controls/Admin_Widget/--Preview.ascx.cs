using System;
using System.IO;
using System.Xml;
using EbSite.Base.ControlPage;
namespace EbSite.Web.AdminHt.Controls.Admin_Widget
{
    public partial class Preview : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "122";
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
            wdPreview.WidgetID = new Guid(SID);
        }
        override protected void SaveModel()
        {
        }

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    string id = Request.QueryString["id"];

        //    if (!string.IsNullOrEmpty(id))
        //    {
        //        wdPreview.WidgetID = new Guid(id);
        //    }
        //}

    }
}