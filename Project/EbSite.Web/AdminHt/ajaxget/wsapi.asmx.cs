using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using EbSite.BLL;
using EbSite.Base.Json;
using EbSite.Entity;
using EbSite.Web.AdminHt.ajaxget.WsapiHelp;
using EbSite.Base;

namespace EbSite.Web.AdminHt.ajaxget
{
    /// <summary>
    /// Summary description for wsapi
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class wsapi : System.Web.Services.WebService
    {
        
        [WebMethod]
        public JsonResponse SaveUserToGroup(int gid,string u)
        {
            int GroupId = gid;
            if (GroupId > 0)
            {
                EbSite.BLL.User.MembershipUserEb.Instance.UpdateUserGroupId(u, GroupId);
            }

            EbSite.Base.Host.CacheApp.Clear();

            return new JsonResponse { Message = "用户组保存成功", Success = true };
        }
        [WebMethod]
        public JsonResponse ChangeSite(int siteid)
        {
            //Core.Utils.WriteCookie("adminsiteid", siteid.ToString());
            AppStartInit.ChangeSite(siteid.ToString());
            return new JsonResponse { Message = "站点切换成功", Success = true };
        }
        [WebMethod]
         public JsonResponse DelFastMenus(string id)
        {

            EbSite.BLL.FastMenu.Instance.Delete(int.Parse(id));
            //BindFastMenus();
            return new JsonResponse() { Message = "数据删除成功", Success = true };
        }
        [WebMethod]
        public JsonResponse DelAreaPrice(int id)
        {
            BLL.PsAreaPrice.Instance.Delete(id);

            return new JsonResponse{Message = "删除成功",Success = true};
        }

        #region  关于专题列表式专题的操作

        [WebMethod]
        public JsonResponse DelSPClass(int cid, int sid)
        {
            EbSite.BLL.SpecialClass.Delete(cid, sid);
            return new JsonResponse { Message = "删除成功", Data = cid.ToString(), Success = true };
        }

        [WebMethod]
        public JsonResponse CopySPClass(int cid,int sid)
        {
            Entity.SpecialClass md = BLL.SpecialClass.GetCopySpecial(cid,sid);
            string sUrl = string.Format("Admin_Special.aspx?t=0&id={0}", md.id);
            return new JsonResponse { Message = "复制成功", Data = sUrl, Success = true };
        }

        [WebMethod]
        public ClassInfo GetSpecialManageSel(int cid,int sid)
        {
            ClassInfo mdClassInfo = new ClassInfo();
            if (cid > 0)
            {
                Entity.SpecialClass md = BLL.SpecialClass.GetModel(cid);
                if (!Equals(md, null))
                {
                    string url = EbSite.Base.Host.Instance.GetSpecialHref(cid, 1); //前台页面路径
                    int contentCount = EbSite.BLL.SpecialNews.GetCount(cid);
                    int childClassCount = EbSite.BLL.SpecialClass.GetSubCount(cid, sid);
                    string ctUrl = "Admin_Content.aspx?t=1&sid=" + cid; //查看内容路径
                    string UrlCode = string.Format("<a href=\"<%=EbSite.Base.Host.Instance.GetSpecialHref({0},1)%>\" >{1}</a>", cid, md.SpecialName);
                    mdClassInfo.id = cid;
                    mdClassInfo.ClassName = md.SpecialName;
                    mdClassInfo.Url = url;
                    mdClassInfo.CtCount = contentCount;
                    mdClassInfo.ChildCount = childClassCount;
                    mdClassInfo.CtUrl = ctUrl;
                    mdClassInfo.UrlCode = UrlCode;
                    mdClassInfo.UrlEdit = string.Format("Admin_Special.aspx?t=0&id={0}", md.id);


                }

            }


            return mdClassInfo;
        }
        #endregion
        #region  关于分类列表式专题的操作
        [WebMethod]
        public JsonResponse MakeClassHtml(int cid, int sid)
        {
            Base.Static.BatchCreatManager.WebClass wcHtml = new Base.Static.BatchCreatManager.WebClass(sid);
            wcHtml.MakeOneClass(cid);
            return new JsonResponse { Message = "删除成功", Data = cid.ToString(), Success = true };
        }

        [WebMethod]
        public JsonResponse DelClass(int cid, int sid)
        {
            EbSite.BLL.NewsClass.Delete(cid, sid);
            return new JsonResponse { Message = "删除成功", Data = cid.ToString(), Success = true };
        }

        [WebMethod]
        public JsonResponse CopyClass(int cid)
        {
            Entity.NewsClass md = BLL.NewsClass.GetCopyClass(cid);
            string sUrl = string.Format("Admin_Class.aspx?t=0&id={0}&pid={1}", md.ID, md.ParentID);
            return new JsonResponse { Message = "复制成功", Data = sUrl, Success = true };
        }

        [WebMethod]
        public ClassInfo GetClassManageSel(int cid)
        {
            ClassInfo mdClassInfo = new ClassInfo();
            //StringBuilder sb = new StringBuilder("[");
            if (cid > 0)
            {
                Entity.NewsClass md = BLL.NewsClass.GetModel(cid);
                if (!Equals(md, null))
                {
                    string url = EbSite.Base.Host.Instance.GetClassHref(cid, md.HtmlName, 1); //前台页面路径
                    //YHL 2014-2-11
                    NewsContentSplitTable NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(md.ID);

                    int contentCount = NewsContentInst.GetCount("classid=" + md.ID, md.SiteID); // 查看内容 总数
                    int childClassCount = EbSite.BLL.NewsClass.GetCount(md.ID, md.SiteID); //子分类的个数
                    string ctUrl = "Admin_Content.aspx?t=1&cid=" + cid; //查看内容路径



                    string UrlCode = string.Format("<a href=\"<%=EbSite.Base.Host.Instance.GetClassHref({0},1)%>\" >{1}</a>", md.ID, md.ClassName);


                    mdClassInfo.id = md.ID;
                    mdClassInfo.ClassName = md.ClassName;
                    mdClassInfo.Url = url;
                    mdClassInfo.CtCount = contentCount;
                    mdClassInfo.ChildCount = childClassCount;
                    mdClassInfo.CtUrl = ctUrl;
                    mdClassInfo.UrlCode = UrlCode;
                    mdClassInfo.UrlEdit = string.Format("Admin_Class.aspx?t=0&id={0}&pid={1}", md.ID, md.ParentID);


                }

            }


            return mdClassInfo;
        }
        #endregion


        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public Dictionary<string, int> GetSpiderCount(int spid)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("d", EbSite.BLL.spiderlog.Instance.GetLogCount(spid, 1));
            dic.Add("l", EbSite.BLL.spiderlog.Instance.GetLogCount(spid, 2));
            dic.Add("w", EbSite.BLL.spiderlog.Instance.GetLogCount(spid, 3));
            dic.Add("m", EbSite.BLL.spiderlog.Instance.GetLogCount(spid, 4));
            return dic;
        }
        [WebMethod(EnableSession = true)]
        [SoapHeader("SecurityKey")]
        public List<VititTimeModel> GetVititTime(int it)
        {
            List<VititTimeModel> lst = new List<VititTimeModel>();

             List<Entity.ListItemModel> d = BLL.spiderlog.Instance.GetVisitTime(it);
            string sLastName = string.Empty;
            List<Entity.ListItemModel> tem = new List<ListItemModel>();
            VititTimeModel temData = new VititTimeModel();
            foreach (var li in d)
            {
                if (!string.IsNullOrEmpty(sLastName))
                {
                    if (!sLastName.Equals(li.ID))
                    {
                        temData.SpiderName = sLastName;
                        temData.Data = tem;
                        lst.Add(temData);
                        tem = new List<ListItemModel>();
                        temData = new VititTimeModel();
                    }
                }
                tem.Add(li);
                sLastName = li.ID;
            }
            //补全24小时时间点
            foreach (var mdL in lst)
            {
                for (int i = 0; i < 23; i++)
                {
                    var o = mdL.Data.SingleOrDefault(dd => dd.Text == i.ToString());

                    if (Equals(o, null))
                    {
                        mdL.Data.Insert(i, new ListItemModel(mdL.SpiderName, i.ToString(), "0"));
                    }
                }
                 
            }

            return lst;
        }

        

    }


    public class VititTimeModel
    {
        public string SpiderName { get; set; }
        public List<Entity.ListItemModel> Data { get; set; }
    }
}


