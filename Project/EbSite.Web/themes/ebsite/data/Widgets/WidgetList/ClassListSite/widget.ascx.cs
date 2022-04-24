using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.BLL.GetLink;
using EbSite.Entity;

namespace EbSite.Widgets.ClassListSite
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {

            //StringDictionary settings = GetSettings();
            //string TemPath = string.Empty;
            //if (settings.ContainsKey("ClassItem"))
            //{
            //    string sType = settings["ClassItem"];

            //    if (!string.IsNullOrEmpty(sType))
            //    {
            //        ClassShowIDs = sType;
            //    }
            //}

            //if (settings.ContainsKey("tem"))
            //{
            //    TemPath = BLL.Ctrtem.TemList.GetTemPath(settings["tem"]);
            //}

            //if (!string.IsNullOrEmpty(ClassShowIDs.Trim()))
            //{

            //    string[] IDs = ClassShowIDs.Split(',');
            //    if (IDs.Length > 0)
            //    {
            //        List<EbSite.Entity.NewsClass> lst;
            //        if (IDs[0] == "0")
            //        {

            //            Entity.NewsClass mdIndex = new NewsClass();
            //            mdIndex.ID = 0;
            //            mdIndex.ClassName = "首页";//settings["indextxt"];
            //            string sUrl = HrefFactory.GetHtmlInstance(GetSiteID).GetMainIndexHref();
            //            if (!sUrl.StartsWith("/"))
            //                sUrl = string.Concat("/", sUrl);
            //            mdIndex.OutLike = sUrl;
            //            lst = BLL.NewsClass.GetClassInIDs(ClassShowIDs, mdIndex, base.GetSiteID);
            //        }
            //        else
            //        {
            //            lst = BLL.NewsClass.GetClassInIDs(ClassShowIDs, base.GetSiteID);
            //        }


            //        rpSubClass.DataSource = lst;

            //        if (!string.IsNullOrEmpty(TemPath))
            //            rpSubClass.ItemTemplate = LoadTemplate(TemPath);

            //        rpSubClass.DataBind();
            //    }


            //  }
            int SiteID = GetSiteID;
            StringDictionary settings = GetSettings();
            string TemPath = string.Empty;
            if (settings.ContainsKey("tem"))
            {
                TemPath = base.TemBll.GetTemPath(settings["tem"]);
            }
            //if (settings.ContainsKey("SiteID"))
            //{
            //    SiteID = int.Parse(settings["SiteID"]);
            //}
            List<EbSite.Entity.NewsClass> lst;
            Entity.NewsClass mdIndex = new NewsClass();
            mdIndex.ID = 0;
            mdIndex.ClassName = "首页";//settings["indextxt"];
            if (SiteID == 0)
            {
                //string sUrl = HrefFactory.GetHtmlInstance(GetSiteID).GetMainIndexHref();
                string sUrl = LinkOrther.Instance.GetHtmlInstance(GetSiteID).GetMainIndexHref();
                if (!sUrl.StartsWith("/"))
                    sUrl = string.Concat("/", sUrl);
                mdIndex.OutLike = sUrl;
                lst = BLL.NewsClass.GetParentClass(0, mdIndex, base.GetSiteID);
            }
            else
            {
                //string sUrl = HrefFactory.GetHtmlInstance(SiteID).GetMainIndexHref();
                string sUrl = LinkOrther.Instance.GetHtmlInstance(SiteID).GetMainIndexHref();
                if (!sUrl.StartsWith("/"))
                    sUrl = string.Concat("/", sUrl);
                mdIndex.OutLike = sUrl;
                lst = BLL.NewsClass.GetParentClass(0, mdIndex, SiteID);
            }

            rpSubClass.DataSource = lst;
            if (!string.IsNullOrEmpty(TemPath))
                rpSubClass.ItemTemplate = LoadTemplate(TemPath);

            rpSubClass.DataBind();
        }

        protected int cid
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return int.Parse(Request["cid"]);
                }
                return -1;
            }
        }

        public string _ClassShowIDs = string.Empty;

        public string ClassShowIDs
        {
            get
            {
                return _ClassShowIDs;
            }
            set
            {
                _ClassShowIDs = value;
            }
        }




        public string GetCurrentClass(object ob)
        {

            return GetCurrentClass(ob, "menucurrent");
        }
        public string GetCurrentClass(object ob, string sCurrentClassName)
        {

            string sCss = "";

            if (!Equals(ob, null))
            {
                int ID = int.Parse(ob.ToString());

                if (ID == cid) //先判断当前分类ID
                {
                    sCss = sCurrentClassName;
                }
                else
                {
                    if (ID > 0)  //如果同一个页面有两个导航，那么子类的正常显示，父类的将调用父ID
                    {
                        EbSite.Entity.NewsClass mdCurrent = BLL.NewsClass.GetModelByCache(cid);

                        if (mdCurrent.ParentID > 0)
                        {
                            if (mdCurrent.ParentID == ID) //先判断当前分类ID
                            {
                                sCss = sCurrentClassName;
                            }
                        }

                    }

                }
            }

            return sCss;
        }
        public override string Name
        {
            get { return "ClassListSite"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}