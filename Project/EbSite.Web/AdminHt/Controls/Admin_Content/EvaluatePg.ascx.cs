using System;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;


namespace EbSite.Web.AdminHt.Controls.Admin_Content
{
    public partial class EvaluatePg : CommentListBase
    {
        
        override protected object LoadList(out int iCount)
        {
            iCount = BLL.Remark.GetCountByClassID(CID, true);
            return BLL.Remark.GetModelList("RemarkClassID= "+CID, true, pcPage.PageIndex, pcPage.PageSize);
        }

        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            BLL.Remark.Delete(int.Parse(iID.ToString()));
        }
         
       
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