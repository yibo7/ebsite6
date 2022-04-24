using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.EntityAPI;
using EbSite.Modules.Wenda.ModuleCore.Entity;

namespace EbSite.Modules.Wenda.ModuleCore.Pages
{
    public class mtmyasked : mattractivelistBase
    {

      
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        override protected string ReWritePatchUrl
        {
            get
            {
                return string.Concat("myasked-", GetSiteID, "-", GetUID, "-{0}.ashx"); //{0} 页码
            }
        }
        override protected string SPageTitle
        {
            get
            {
                return string.Format("向{0}发起请求的问题-问答地盘", mdUser.NiName); ;
            }
        }
        protected override void BindListPages(int iUserID, ref int iCount, int PageIndex, int PageSize)
        {
            if (EbSite.Base.Host.Instance.UserID == iUserID) 
            {
                if (!Equals(rpList, null))
                {
                   
                    string strsql = string.Concat(" userid =", iUserID); 
                    List<ModuleCore.Entity.expertAsk> lsit = ModuleCore.BLL.expertAsk.Instance.GetListPages(PageIndex, iPageSize, strsql, "id desc", out iCount);
                    string strwhere = "";
                    foreach (expertAsk expertAsk in lsit)
                    {
                        strwhere += expertAsk.Qid + ",";
                    }
                    if (strwhere.Length > 0)
                    {
                        strwhere = strwhere.Remove(strwhere.Length - 1, 1);
                        strwhere = "id in(" + strwhere + ")";
                    }
                    else
                    {
                        strwhere = "id=0";
                    }

                    List<EbSite.Entity.NewsContent> ls = Base.AppStartInit.NewsContentInstDefault.GetListPages(PageIndex, iPageSize, strwhere, out iCount, GetSiteID);
                    rpList.DataSource = ls;// Base.AppStartInit.NewsContentInstDefault.GetListPages(PageIndex, PageSize, strsql, out iCount, GetSiteID);
                    rpList.DataBind();
                }
            }
        }
       
       
    }
}