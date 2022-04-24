using System;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;


namespace EbSite.Web.AdminHt.Controls.Admin_Content
{
    public partial class CommentList : CommentListBase
    {
         
        
        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (Equals(e.CommandName, "ShowModel"))
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("Admin_Content.aspx?t=11&cid=" + id);

            }
            


        }
       
    }
}