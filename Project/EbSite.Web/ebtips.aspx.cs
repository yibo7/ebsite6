using System;
using System.Web;

namespace EbSite.Web
{
    public partial class ebtips : EbSite.Base.Page.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request["info"]))
            {
                base.Title = "操作提示";
                lbInfo.Text = Core.Utils.CleanInput(Request["info"]);
            }
            else
            {
                string sID = Request["id"];

            if(!string.IsNullOrEmpty(sID)&&Core.Utils.IsNumeric(sID))
            {
               Entity.ErrInfo md =   EbSite.BLL.ErrInfo.Instance.GetEntity(int.Parse(sID));

                base.Title = md.Title;
                lbInfo.Text = md.ErrMsg;
                md.ErrCount += 1;
                EbSite.BLL.ErrInfo.Instance.Update(md);
            }
            }

           

            
        }


        
    }
}
