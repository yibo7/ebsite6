
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.BLL.GetLink;
using EbSite.Entity;

namespace EbSite.Widgets.ClassList
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            bool isCurClassFirst = false;
            StringDictionary settings = GetSettings();
            string TemPath = string.Empty;
            //int SiteID = base.GetSiteID;//yhl 2012-02-14
            if (settings.ContainsKey("ClassItem"))
            {
                string sType = settings["ClassItem"];

                if (!string.IsNullOrEmpty(sType))
                {
                    ClassShowIDs = sType;
                }
            }

            if (settings.ContainsKey("tem"))
            {
                TemPath = base.TemBll.GetTemPath(settings["tem"]);
            }
            if (settings.ContainsKey("CurClassFirst"))
            {
                string sIsCurrent = settings["CurClassFirst"];
                if (!string.IsNullOrEmpty(sIsCurrent))
                    isCurClassFirst = bool.Parse(sIsCurrent);

            }
            //if (settings.ContainsKey("SiteID"))
            //{
            //    SiteID = int.Parse(settings["SiteID"]);
            //}
            
            if (!string.IsNullOrEmpty(ClassShowIDs.Trim()))
            {

                string[] IDs = ClassShowIDs.Split(',');
                if (IDs.Length > 0)
                {
                    List<EbSite.Entity.NewsClass> lst;
                    if (IDs[0] == "0")
                    {

                        Entity.NewsClass mdIndex = new NewsClass();
                        mdIndex.ID = 0;
                        mdIndex.ClassName = settings["indextxt"];
                        //string sUrl = HrefFactory.GetHtmlInstance(GetSiteID).GetMainIndexHref();
                        string sUrl =LinkOrther.Instance.GetHtmlInstance(GetSiteID).GetMainIndexHref();
                        if (!sUrl.StartsWith("/"))
                            sUrl = string.Concat("/", sUrl);
                        mdIndex.OutLike = sUrl;
                       
                        lst = BLL.NewsClass.GetClassInIDs(ClassShowIDs, mdIndex, base.GetSiteID);
                        
                    }
                    else
                    {
                       
                        lst = BLL.NewsClass.GetClassInIDs(ClassShowIDs, base.GetSiteID);
                       
                    }

                    List<EbSite.Entity.NewsClass> nlst=new List<NewsClass>();
                    for (int i = 0; i < IDs.Length; i++)
                    {
                        int id = EbSite.Core.Utils.StrToInt(IDs[i], 0);
                        IEnumerable<Entity.NewsClass> lstdd = (from nclass in lst where nclass.ID == id select nclass);
                        if (lstdd.Count() > 0)
                        {
                            EbSite.Entity.NewsClass md = lstdd.First();
                            //if(lstdd.First())
                            //EbSite.Entity.NewsClass md = (from nclass in lst where nclass.ID == id select nclass).ToList()[0];
                            nlst.Add(md);
                        }
                        
                    }
                    if (isCurClassFirst)
                    {
                        List<Entity.NewsClass> nls1 = (from i in nlst where i.ID != cid select i).ToList();
                        Entity.NewsClass ModelFirst = (from i in nlst where i.ID == cid select i).ToList()[0];
                        lst = nls1;
                        lst.Insert(0, ModelFirst);
                        rpSubClass.DataSource = lst;
                    }
                    else
                    {
                        rpSubClass.DataSource = nlst;
                    }
                    if (!string.IsNullOrEmpty(TemPath))
                        rpSubClass.ItemTemplate = LoadTemplate(TemPath);

                    rpSubClass.DataBind();

                }

                //BindIndexLink();
            }
            //else
            //{
            //    llIndexLink.Text = "您还没为此部件选择任何分类!";
            //}



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


        //public void BindIndexLink()
        //{
        //    string[] aItems = ClassShowIDs.Split(',');
        //    if (Core.Strings.Validate.InArray("0", aItems))// aItems.Contains("0")
        //    {
        //        llIndexLink.Text = string.Concat("<li class=", GetCurrentClass(-1), "><a class='", GetCurrentClass(-1, "menucurrent"),"' href=", Base.AppStartInit.IISPath, "><span>首页</span></a></li>");
        //    }

        //}

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
            get { return "ClassList"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}