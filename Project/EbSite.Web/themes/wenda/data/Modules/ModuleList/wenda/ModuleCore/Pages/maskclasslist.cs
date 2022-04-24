using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Modules.Wenda.ModuleCore.DAL.MySQL;

namespace EbSite.Modules.Wenda.ModuleCore.Pages
{
    public class maskclasslist : EbSite.Base.Page.BasePage
    {
        #region 控件定义

        protected EbSite.ControlData.RepeaterIndex AskClassList;
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.Title = "全球汽车品牌维修问题解答汇总_专家一对一为您服务_北迈汽配网";

            //base.SeoKeyWord = "问答，问答平台，维修问答，问答中心";
            //base.SeoDes = "北迈问答，全球汽车品牌维修问题解答汇总，从品牌和配件分类来查找配件，专家一对一为您服务的汽车问答平台。";
            string GetFromIds = AskClassList.ClassIDs;//用逗号分开
            if (!string.IsNullOrEmpty(GetFromIds))
            {
                this.AskClassList.DataSource = EbSite.BLL.NewsClass.GetListArr("id in("+GetFromIds+")", 0, SettingInfo.Instance.GetSiteID);
                this.AskClassList.DataBind();
            }
        }
        public void AskClassList_ItemBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                EbSite.Entity.NewsClass drData = (EbSite.Entity.NewsClass)e.Item.DataItem;
                if (!Equals(drData, null))
                {
                    int strClassID = drData.ID;
                    Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rpSubList");
                    string sqlWhere =string.Format(" eb_newsclass.siteid={0} and eb_newsclass.ParentID={1}" ,SettingInfo.Instance.GetSiteID, strClassID);
                    List<BNewsClass> ls = ModuleCore.BLL.Answers.Instance.BNews_GetListArray(0, sqlWhere, "");//"ID,ClassName,HtmlName,SiteID", sqlWhere, 0, "", 1);
                    llClassList.DataSource = ls;
                    llClassList.DataBind();
                }
            }
        }
    }
   
   
}
