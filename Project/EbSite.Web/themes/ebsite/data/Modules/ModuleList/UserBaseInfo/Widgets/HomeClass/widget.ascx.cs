
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Modules.UserBaseInfo.Widgets.HomeClass
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("delvalue"))
                {
                    string sType = settings["delvalue"];
                    int TabID = 0;
                    if(sType=="0") //自动适应
                    {
                        TabID = cid;
                    }
                    else
                    {
                        TabID = Core.Utils.StrToInt(sType, 0);
                    }
                    rpParentClass.DataSource = EbSite.BLL.SpaceTabs.Instance.GetSubTabs(uid, TabID);
                    rpParentClass.DataBind();
                }

                
        }
        /// <summary>
        /// 当前访问是不是自己
        /// </summary>
        protected bool IsMyPlace
        {
            get
            {
                if (Request.QueryString["v"] == "1") //一览模式
                    return false;
                return Request.QueryString["uid"] == EbSite.Base.AppStartInit.UserID.ToString();
            }
        }
        protected string GetManageLink(object id, object TabName)
        {
            if (IsMyPlace)
            {
                return string.Concat("onmouseover=\"TipsClickClose(this,'<div class=modifytab><div title=", TabName,
                                 " onclick=AddSpaceTab(this,", id, ")> 修 改 </div><div onclick=DeleteTab(", id,
                                 ")> 删 除 </div><div onclick=AddSpaceTabSub(this,", id,
                                 ")> 添加(子) </div></div>')\"");
            }
            else
            {
                return string.Empty;
            }

        }
        public void rpAll_ItemBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Entity.SpaceTabs drData = (Entity.SpaceTabs)e.Item.DataItem;
                int classid = drData.id;
                List<Entity.SpaceTabs> lst = EbSite.BLL.SpaceTabs.Instance.GetSubTabs(uid, classid);
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
        protected string GetUrl(object id)
        {
            return string.Concat("?uid=", uid, "&tab=", id);
        }
        protected int uid
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["uid"]))
                {
                    return int.Parse(Request["uid"]);
                }
                return -1;
            }
        }
        protected int cid
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["tab"]))
                {
                    return int.Parse(Request["tab"]);
                }
                return -1;
            }
        }
        
        public override string Name
        {
            get { return "HomeClass"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}