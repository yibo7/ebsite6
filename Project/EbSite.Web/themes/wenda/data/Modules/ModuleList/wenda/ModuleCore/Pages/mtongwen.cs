using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.EntityAPI;
using EbSite.Modules.Wenda.ModuleCore.Entity;

namespace EbSite.Modules.Wenda.ModuleCore.Pages
{
    public class mtongwen : mattractivelistBase
    {

      
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        override protected string ReWritePatchUrl
        {
            get
            {
                return string.Concat("tongwen-", GetSiteID, "-", GetUID, "-{0}.ashx"); //{0} 页码
            }
        }
        override protected string SPageTitle
        {
            get
            {
                return string.Format("{0}的同问-问答地盘", mdUser.NiName); ;
            }
        }
        protected override void BindListPages(int iUserID, ref int iCount, int PageIndex, int PageSize)
        {
            if (!Equals(rpList, null))
            {
                string strsql = string.Concat(" userid =", iUserID);
                string nstr = "";
                List<ModuleCore.Entity.SameQuestion> lsSQ = ModuleCore.BLL.SameQuestion.Instance.GetListArray(0, strsql, "");
                if (lsSQ.Count > 0)
                {
                    foreach (SameQuestion i in lsSQ)
                    {
                        nstr += i.Cid + ",";
                    }
                    if (nstr.Length > 0)
                        nstr = nstr.Remove(nstr.Length - 1, 1);
                }
                string nstrsql = "";
                if (string.IsNullOrEmpty(nstr))
                {
                    nstrsql = "id=0";
                }
                else
                {
                    nstrsql = "id in(" + nstr + ")";
                }

                List<EbSite.Entity.NewsContent> ls = Base.AppStartInit.NewsContentInstDefault.GetListPages(PageIndex, iPageSize, nstrsql, out iCount, GetSiteID);
                rpList.DataSource = ls; 
                rpList.DataBind();
            }
        }
       
       
    }
}