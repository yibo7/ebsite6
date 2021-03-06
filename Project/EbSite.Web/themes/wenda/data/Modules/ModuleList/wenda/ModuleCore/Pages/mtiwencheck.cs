using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.EntityAPI;
using EbSite.Modules.Wenda.ModuleCore.Entity;

namespace EbSite.Modules.Wenda.ModuleCore.Pages
{
    public class mtiwencheck : mattractivelistBase
    {

      
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        override protected string ReWritePatchUrl
        {
            get
            {
                return string.Concat("tiwencheck-", GetSiteID, "-", GetUID, "-{0}.ashx"); //{0} 页码
            }
        }
        override protected string SPageTitle
        {
            get
            {
                return string.Format("{0}的提问审核中-问答地盘", mdUser.NiName); ;
            }
        }
        protected override void BindListPages(int iUserID, ref int iCount, int PageIndex, int PageSize)
        {
            if (EbSite.Base.Host.Instance.UserID == iUserID) 
            {
                if (!Equals(rpList, null))
                {
                    string strsql = string.Concat("isauditing=false and userid =", iUserID); //查 全部 没有通过审核
                    rpList.DataSource = Base.AppStartInit.NewsContentInstDefault.GetListPages(PageIndex, PageSize, strsql, out iCount,
                                                                            false, GetSiteID);

                    rpList.DataBind();
                }
            }
        }
       
       
    }
}