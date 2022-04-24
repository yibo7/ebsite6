using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Entity;

namespace EbSite.Widgets.ClassTreeDh
{
    public partial class widget : WidgetBase
    {


        //public int SiteID = GetSiteID;//yhl 2012-02-14
        private bool isCurrent = false;
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {


                int iTop = 100;
                string TemPath = "";


                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("txtCount"))
                {
                    iTop = int.Parse(settings["txtCount"]);

                }

                if (settings.ContainsKey("txtTem"))
                {
                    TemPath = settings["txtTem"];
                }
                if (settings.ContainsKey("IsCurrent"))
                {
                    string sIsCurrent = settings["IsCurrent"];
                    if (!string.IsNullOrEmpty(sIsCurrent))
                        isCurrent = bool.Parse(sIsCurrent);

                }

                int iPid = 0;

                //0表示父ID随参数变动，-1表示除一级分类外始终使用当前分类的父ID
                if (settings.ContainsKey("txtPid"))
                {
                    iPid = int.Parse(settings["txtPid"]);
                }
                if (iPid == 0)
                {
                    iPid = cid;
                }
                else if (iPid == -1)
                {
                    int pcid = BLL.NewsClass.GetModelByCache(cid).ParentID;

                    if (pcid >= 0)
                    {
                        iPid = pcid;
                    }
                    else
                    {
                        iPid = cid;
                    }

                }
                else if (iPid == -2)//启用固定分类
                {
                    //string cid = settings["ClassItem"];
                }

                List<Entity.NewsClass> lst = new List<NewsClass>();
                if (iPid == -2) //启用固定分类
                {
                    string cid = settings["ClassItem"];
                    if (!string.IsNullOrEmpty(cid))
                        lst = BLL.NewsClass.GetListArr("id,ClassName", "id in(" + cid + ")", 0, "id asc", GetSiteID);
                }
                else
                {
                    lst = BLL.NewsClass.GetSubClass(iPid, iTop, GetSiteID);
                }
                if (isCurrent)
                {
                    //yhl 2013-11-12 这时 要把当前分类 排到第一位
                    if (lst.Count > 0)
                    {
                        List<Entity.NewsClass> nls1 = (from i in lst where i.ID != cid select i).ToList();
                        Entity.NewsClass ModelFirst = (from i in lst where i.ID == cid select i).ToList()[0];
                        lst = nls1;
                        lst.Insert(0, ModelFirst);
                        rpAllClass.DataSource = lst;
                    }
                }
                else
                {
                    rpAllClass.DataSource = lst;
                }

                TemPath = base.TemBll.GetTemPath(TemPath);
                if (!string.IsNullOrEmpty(TemPath))
                {

                    rpAllClass.ItemTemplate = LoadTemplate(TemPath);
                }
                rpAllClass.DataBind();

            }
        }

        public override string Name
        {
            get { return "ClassTreeDh"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }


        //////////////////////////////////////
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


        public string GetCurrentClass(object ob)
        {

            string sCss = "";

            if (!Equals(ob, null))
            {
                int ID = int.Parse(ob.ToString());

                if (ID == cid)
                {
                    sCss = "onClassTree";
                }
            }

            return sCss;
        }

        public void rpAll_ItemBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Entity.NewsClass drData = (Entity.NewsClass)e.Item.DataItem;
                int classid = drData.ID;

                //2013-11-12 YHL 也可以 只查询 当前分类的子分类
                if (isCurrent)
                {
                    if (classid == cid)
                    {
                        List<Entity.NewsClass> lst;
                        int SiteID = GetSiteID;
                        if (SiteID == 0)//自动适应
                        {
                            lst = BLL.NewsClass.GetSubClass(classid, 100, base.GetSiteID);
                        }
                        else
                        {
                            lst = BLL.NewsClass.GetSubClass(classid, 100, SiteID);
                        }


                        if (!Equals(lst, null) && lst.Count > 0) //如果当前分类没有对应的子类信息,隐藏当前分类
                        {

                            Repeater repeater = (Repeater)e.Item.FindControl("rpSubList");
                            if (repeater != null)
                            {
                                repeater.DataSource = lst;
                                repeater.DataBind();

                            }

                        }
                        else
                        {
                            //HtmlGenericControl listTile = (HtmlGenericControl)e.Item.FindControl("listTitle");
                            //if (listTile != null) listTile.Visible = false;

                        }
                    }
                }
                else
                {
                    List<Entity.NewsClass> lst;
                    int SiteID = GetSiteID;
                    if (SiteID == 0)//自动适应
                    {
                        lst = BLL.NewsClass.GetSubClass(classid, 100, base.GetSiteID);
                    }
                    else
                    {
                        lst = BLL.NewsClass.GetSubClass(classid, 100, SiteID);
                    }


                    if (!Equals(lst, null) && lst.Count > 0) //如果当前分类没有对应的子类信息,隐藏当前分类
                    {

                        Repeater repeater = (Repeater)e.Item.FindControl("rpSubList");
                        if (repeater != null)
                        {
                            repeater.DataSource = lst;
                            repeater.DataBind();

                        }

                    }
                    else
                    {
                        //HtmlGenericControl listTile = (HtmlGenericControl)e.Item.FindControl("listTitle");
                        //if (listTile != null) listTile.Visible = false;

                    }
                }


            }
        }
    }
}