using System;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Widget
{
    public partial class ClassAdd : EbSite.Base.ControlPage.UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "180";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {  
               
            }
        }
        override protected void InitModifyCtr()
        {
            ClassCustom md = BLL.ClassCustom.Provider.Factory.Widget().Select(new Guid(SID));

            txtTile.Text = md.Title;
            txtDescription.Text = md.Description;

        }
        override protected void SaveModel()
        {           
           Entity.ClassCustom md = new ClassCustom();

            md.Title = txtTile.Text;
            md.Description = txtDescription.Text;
            md.AddDate = DateTime.Now;
            if(string.IsNullOrEmpty(SID))
            {
                BLL.ClassCustom.Provider.Factory.Widget().Insert(md);
            }
            else
            {
                md.ID = new Guid(SID);
                BLL.ClassCustom.Provider.Factory.Widget().Update(md);
            }
            
            //base.ColseGreyBox(true);
        }       
    }
}