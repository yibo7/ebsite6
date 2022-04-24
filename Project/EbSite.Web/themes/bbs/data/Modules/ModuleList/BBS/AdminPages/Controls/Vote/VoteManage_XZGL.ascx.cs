using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.AdminPages.Controls.Vote
{
    public partial class VoteManage_XZGL : MPUCBaseList
    {
        protected string bigId;
        public override string Permission
        {
            get
            {
                return "2";
            }
        }
        override protected string AddUrl
        {
            get
            {
               return "t=3";
                //return "Vote.aspx?t=3&mid="+ModuleID+"&bigId="+bigId;
            }
        }
        public string TagCls
        {
            get
            {
                return Request["cls"];
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=4";
            }
        }

        override protected object LoadList(out int iCount)
        {
            bigId = Convert.ToString(Request.QueryString["id"]);
            return ModuleCore.BLL.toupiao.Instance.GetListPagesByBigId(pcPage.PageIndex, pcPage.PageSize, out iCount, UserName, bigId);            
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.toupiao.Instance.Delete(long.Parse(iID.ToString()));
        }

          
    }
}