using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.EntityAPI;
using EbSite.Modules.Wenda.ModuleCore.Entity;

namespace EbSite.Modules.Wenda.ModuleCore.Pages
{
   abstract public class mattractivelistBase : EbSite.Base.Page.BasePage
    {

        protected global::EbSite.Control.Repeater rpList;
        protected global::EbSite.Control.PagesContrl pgCtr;
        public MembershipUserEb mdUser;
        public ModuleCore.Entity.UserHelp mdTotal;
        public int PageIndex
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["p"]))
                    return Convert.ToInt32(Request.QueryString["p"]);
                else
                    return 1;
            }
        }
       
        protected int iSearchCount = 0;
        protected int iPageSize
        {
            get
            {
                if (!Equals(pgCtr, null) && pgCtr.PageSize > 0)
                {
                    return pgCtr.PageSize;
                }
                else
                {
                    return Base.Configs.ContentSet.ConfigsControl.Instance.PageSizeClass;
                }

            }

        }
       protected int GetUID
       {
           get
           {
               int iUserID = 0;
               if (!string.IsNullOrEmpty(Request["uid"]))
               {
                    iUserID = int.Parse(Request["uid"]);
               }
               return iUserID;
           }
       
       }
       public mattractivelistBase()
        {
            base.Load += new EventHandler(this.mattractivelistBase_Load);
        }
       protected void mattractivelistBase_Load(object sender, EventArgs e)
        {
            if (GetUID>0)
            {
                int iUserID = GetUID;
                
                mdUser = EbSite.Base.Host.Instance.EBMembershipInstance.Users_GetEntity(iUserID);
                if(!Equals(mdUser,null))
                {
                    mdTotal = ModuleCore.BLL.UserHelp.Instance.GetEntityByUserID(iUserID);
                    if (Equals(mdTotal,null))
                        mdTotal = new UserHelp();
                    binddata(iUserID);

                }
                else
                {
                    mdUser = new MembershipUserEb();
                    mdUser.NiName = "已经删除用户";
                }
                
            }
        }
        abstract protected string ReWritePatchUrl { get; }
        abstract protected string SPageTitle { get; }
        protected abstract void BindListPages(int iUserID, ref int iCount, int PageIndex, int PageSize);
        private void binddata(int uid)
        {
            
            BindListPages(uid, ref iSearchCount, pgCtr.PageIndex, iPageSize);
            //if (!Equals(rpList,null))
            //{
            //    string strsql = string.Concat(" userid =", uid);
            //    rpList.DataSource = GetListPages(pgCtr.PageIndex, iPageSize, out iSearchCount);// Base.AppStartInit.NewsContentInstDefault.GetListPages(pgCtr.PageIndex, iPageSize, strsql, out iSearchCount, GetSiteID); 
            //    Title = SPageTitle;// string.Format("{0}的提问-问答地盘", mdUser.NiName);
            //    rpList.DataBind();
            //}
            
            if (!Equals(pgCtr, null))
            {

                //这有点不好理解,以重构
                pgCtr.ReWritePatchUrl = ReWritePatchUrl;// string.Concat("attractivelist-", GetSiteID, "-", uid, "-{0}.ashx"); //{0} 页码
                pgCtr.AllCount = iSearchCount;
                pgCtr.PageSize = iPageSize;
                //pgCtr.OtherPram = string.Format("cid,{0}", GetClassID);
                pgCtr.CurrentClass = "CurrentPageCoder";
                pgCtr.ParentClass = "PagesClass";
            }
            Title = SPageTitle;
        }
       
    }
}