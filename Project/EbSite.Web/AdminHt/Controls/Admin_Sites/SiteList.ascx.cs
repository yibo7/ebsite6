using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL.GetLink;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Sites
{
    public partial class SiteList : UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "317";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "163";
            }
        }
        /// <summary>
        /// 添加数据的权限ID
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "163";
            }
        }
        /// <summary>
        /// 修改数据权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "163";
            }
        }
        #endregion

        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }

        protected string MGetHref(object siteid, int iType)
        {
            string sUrl = "";
            int iSiteID = int.Parse(siteid.ToString());
            if (iType == 0) //首页
            {
                sUrl = LinkMobile.Instance(iSiteID).GetIndexHref();
            }
            else //分类
            {
                sUrl = LinkMobile.Instance(iSiteID).GetClassHref();

            }
            //if (!sUrl.StartsWith("/"))
            //    sUrl = string.Concat("/", sUrl);
            return sUrl;
        }

        protected string GetHref(object siteid,int iType)
        {
            string sUrl = "";
            int iSiteID = int.Parse(siteid.ToString());
            if(iType==0)
            {
                //sUrl =  HrefFactory.GetAspxInstance(iSiteID).GetMainIndexHref();

                sUrl = LinkOrther.Instance.GetAspxInstance(iSiteID).GetMainIndexHref();
            }
            else 
            {
                //sUrl = HrefFactory.GetHtmlInstance(iSiteID).GetMainIndexHref();
                sUrl = LinkOrther.Instance.GetHtmlInstance(iSiteID).GetMainIndexHref();
                
            }
            if (!sUrl.StartsWith("/"))
                sUrl = string.Concat("/", sUrl);
            return sUrl;

        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            var data = BLL.Sites.Instance.GetTree_pic(10000);
            
            return data;

            //Entity.Sites temp = new Sites() {IsSys = false,
            //OrderID = 0,ParentID=1,SiteName = "a" };

            //List<Entity.Sites> siteses = BLL.Sites.Instance.GetListArray(0,"","");
            //iCount = siteses.Count;
            //return siteses;
        }
        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            if (int.Parse(iID.ToString()) == 1)
            {
                base.TipsAlert("根节点不能删除");
                return;
            }


            //-----判断 如果有子接点，全部删除-----//
            List<Sites> allSite = BLL.Sites.Instance.FillList();
            List<int> delIDs = new List<int>();
            foreach (var item in allSite)
            {
                //判断当前选择的节点是否有子节点
                if (item.ParentID == int.Parse(iID.ToString()))
                {
                    delIDs.Add(item.id);
                }
            }
            //通过查找，如果查到子节点，就全删除
            if(delIDs.Count>0)
            {
                //base.TipsAlert(message);
                foreach (var item in delIDs)
                {
                    BLL.Sites.Instance.DeleteSite(item);
                }
            }
            else
            {
                Sites st = BLL.Sites.Instance.GetEntity(int.Parse(iID.ToString()));
                if (null != st) BLL.Sites.Instance.DeleteSite(int.Parse(iID.ToString()));
            }
            //这里，要判断系统中，是否用了删了的节点，如果用了，将其改为默认的
        }

        protected override void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (object.Equals(e.CommandName, "SetMainSite"))
            {
                int siteid = int.Parse(e.CommandArgument.ToString());
                Entity.Sites mdMain = BLL.Sites.Instance.GetEntityForMain;
                Entity.Sites mdThis = BLL.Sites.Instance.GetEntity(siteid);

                mdMain.id = siteid;
                mdMain.ParentID = mdThis.ParentID;
                mdMain.OrderID = mdThis.OrderID;
                mdMain.IsNoSys = true;
                mdMain.SiteFolder = mdThis.SiteFolder;
                BLL.Sites.Instance.Update(mdMain);

               
                mdThis.id = 1;
                mdThis.ParentID = 0;
                mdThis.OrderID = 0;
                mdThis.IsNoSys = false;
                mdThis.SiteFolder = "";
                BLL.Sites.Instance.Update(mdThis);
                EbSite.BLL.NewsClass.SetSubSiteToMainUpdateSiteID(1, siteid);

                //重新启动网站
                EbSite.Base.Host.CacheApp.Clear(); // EbSite.Core.CacheManager.RemoveAllCache();
                base.Response.Redirect(base.Request.RawUrl);
            }
        }

  
    }
}