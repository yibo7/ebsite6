
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Modules.Shop.ModuleCore.Entity;
using ListItemModel = EbSite.Base.EntityAPI.ListItemModel;

namespace EbSite.Modules.Shop.Widgets.IndexClass
{
    public partial class widget : WidgetBase
    {

        public override void LoadData()
        {

            StringDictionary settings = GetSettings();

            string cid = settings["ClassItem"];
            if (!string.IsNullOrEmpty(cid))
            {
                #region

                //string sTemp1 = "<div class=\"o_lst\">";
                //string sTemp2 = " <dl onmouseover=\"showIndex(this,'#a#')\" onmouseout=\"hideIndex(this,'#a#',event)\">";
                //string sTemp3 = " <dt><span class=\"fleft\"><a href=\"#bigurl#\">#BigClassName#</a></span><div class=\"ico all\"></div> </dt><dd>";
                //string sTemp4 = " <li><a href=\"#url#\">#SmallClassName#</a></li>";
                //string sTemp5 = "<li><div class=\"ppliline\"></div></li>";
                //string sTemp6 = "</dd></dl></div>";

                //string sTemp11 = "<div class=\"charcont\" id=\"index-#a#\" style=\"display: none\">";
                //string sTemp12 = "<ul>";
                //string sTemp13 = "  <li><a href=\"#url#\">#SmallClassName#</a></li>";
                //string sTemp14 = "</ul></div>";

                //string StrInfo = "";
                //List<Entity.NewsClass> ls = BLL.NewsClass.GetListArr("id,ClassName", "ParentID=12558", 0, "id asc", SettingInfo.Instance.GetSiteID);

                //for (int i = 0; i < ls.Count; i++)
                //{
                //    StrInfo += sTemp1;
                //    StrInfo += sTemp2.Replace("#a#", i.ToString());
                //    StrInfo += sTemp3.Replace("#bigurl#", EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.ProductClass(SettingInfo.Instance.GetSiteID, ls[i].ID)).Replace("#BigClassName#", ls[i].ClassName);
                //    List<Entity.NewsClass> lsSmall = BLL.NewsClass.GetListArr("id,classname,annex3", "ParentID=" + ls[i].ID, 0, "id asc", SettingInfo.Instance.GetSiteID);
                //    List<Entity.NewsClass> ShowLsSmall = (from x in lsSmall where x.Annex3 == "True" select x).ToList();
                //    for (int j = 0; j < ShowLsSmall.Count; j++)
                //    {
                //        StrInfo += sTemp4.Replace("#url#", EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.ProductClass(SettingInfo.Instance.GetSiteID, ShowLsSmall[j].ID))
                //                         .Replace("#SmallClassName#", ShowLsSmall[j].ClassName);
                //        if (j != ShowLsSmall.Count - 1)
                //        {
                //            StrInfo += sTemp5;
                //        }
                //    }
                //    StrInfo += sTemp6;
                //    StrInfo += sTemp11.Replace("#a#", i.ToString());
                //    StrInfo += sTemp12;
                //    List<Entity.NewsClass> HideLsSmall = (from x in lsSmall where x.Annex3 == "False" select x).ToList();
                //    foreach (var newsClass in HideLsSmall)
                //    {
                //        StrInfo += sTemp13.Replace("#url", EbSite.Modules.Shop.ModuleCore.GetLinks.Instance.ProductClass(SettingInfo.Instance.GetSiteID, newsClass.ID)).Replace("#SmallClassName#", newsClass.ClassName);
                //    }
                //    StrInfo += sTemp14;
                //}
                //this.txtBrand.Text = StrInfo;

                #endregion

                List<Entity.NewsClass> ls = BLL.NewsClass.GetListArr("id,ClassName", "id in(" + cid+")", 0, "id asc",
                                                                     SettingInfo.Instance.GetSiteID);
                this.rpList.DataSource = ls;
                this.rpList.DataBind();
            }

        }

        public void rpList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entity.NewsClass drData = (Entity.NewsClass)e.Item.DataItem;
                //提取分类ID 
                int strClassID = drData.ID;
                List<Entity.NewsClass> lsSmall = BLL.NewsClass.GetListArr("id,classname,annex3", "ParentID=" + strClassID, 0, "id asc", SettingInfo.Instance.GetSiteID);
                List<Entity.NewsClass> ShowLsSmall = (from x in lsSmall where x.Annex3 == "True" select x).ToList();
                
                Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rpSubList");

                llClassList.DataSource = ShowLsSmall;
                llClassList.DataBind();

                List<Entity.NewsClass> HideLsSmall = (from x in lsSmall where x.Annex3 == "False" select x).ToList();
                Repeater llClassList2 = (Repeater)e.Item.Controls[0].FindControl("rpSubList2");

                llClassList2.DataSource = HideLsSmall;
                llClassList2.DataBind();
                
            }

        }


        public override string Name
        {
            get { return "IndexClass"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }


    }


}