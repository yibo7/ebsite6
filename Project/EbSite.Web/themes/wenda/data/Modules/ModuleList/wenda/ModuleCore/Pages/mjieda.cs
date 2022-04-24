using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.EntityAPI;
using EbSite.Modules.Wenda.ModuleCore.Entity;

namespace EbSite.Modules.Wenda.ModuleCore.Pages
{
    public class mjieda : mattractivelistBase
    {

      
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        override protected string ReWritePatchUrl
        {
            get
            {
                return string.Concat("jieda-", GetSiteID, "-", GetUID, "-{0}.ashx"); //{0} 页码
            }
        }
        override protected string SPageTitle
        {
            get
            {
                return string.Format("{0}的解盘-问答地盘", mdUser.NiName); 
            }
        }
        protected override void BindListPages(int iUserID, ref int iCount, int PageIndex, int PageSize)
        {
            if (!Equals(rpList, null))
            {
                string strsql = string.Concat("a.AnswerUserID=" , iUserID);
                rpList.DataSource = ModuleCore.BLL.Answers.Instance.GetListPagesCache(PageIndex, iPageSize, strsql,"", "a.id desc", out iCount);
                rpList.DataBind();
            }
        }
       
       
    }
}