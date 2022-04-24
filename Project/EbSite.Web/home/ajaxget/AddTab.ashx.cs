using System;
using System.Collections.Generic;
using System.Web;
using EbSite.Entity;

namespace EbSite.Web.home.ajaxget
{
    /// <summary>
    /// Summary description for AddTab
    /// </summary>
    public class AddTab : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            
                if (!string.IsNullOrEmpty(context.Request.QueryString["c"])) //分类名称
                {
                    string sClassName = context.Request.QueryString["c"];
                    if (!string.IsNullOrEmpty(context.Request.QueryString["tid"])) //分类ID
                    {
                        int TabID = int.Parse(context.Request.QueryString["tid"]);
                        if (!string.IsNullOrEmpty(context.Request.QueryString["sub"])) //添加子分类
                        {
                            Entity.SpaceTabs md = new SpaceTabs();
                            md.UserID = EbSite.Base.AppStartInit.UserID;
                            md.TabName = sClassName;
                            md.ParentID = TabID;
                            EbSite.BLL.SpaceTabs.Instance.Add(md);
                        }
                        else
                        {

                            Entity.SpaceTabs md = new SpaceTabs(TabID);
                            md.TabName = sClassName;
                            md.Save();
                        }

                    }
                    else
                    {

                        Entity.SpaceTabs md = new SpaceTabs();
                        md.UserID = EbSite.Base.AppStartInit.UserID;
                        md.TabName = sClassName;
                        EbSite.BLL.SpaceTabs.Instance.Add(md);
                    }

                    context.Response.Write("ok");
                }
                else if (!string.IsNullOrEmpty(context.Request.QueryString["del"]) && !string.IsNullOrEmpty(context.Request.QueryString["tid"])) //排序菜单
                {
                    EbSite.BLL.SpaceTabs.Instance.Delete(Core.Utils.StrToInt(context.Request.QueryString["tid"],0));
                    context.Response.Write("ok");
                }
                else if (!string.IsNullOrEmpty(context.Request.QueryString["sort"])) //排序菜单
                {
                    EbSite.BLL.SpaceTabs.Instance.UpdateOrders(EbSite.Base.AppStartInit.UserID, context.Request.QueryString["sort"]);
                    context.Response.Write("ok");

                }
            
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}