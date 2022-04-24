
using System.Collections.Specialized;
using System.Web.UI.WebControls;

using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Base;

namespace EbSite.Widgets.ClassListMore
{
    public partial class widget : WidgetBase
    {
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
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                int SiteID = GetSiteID;//yhl 2012-02-14

                settings = GetSettings();
                //if (settings.ContainsKey("SiteID"))
                //{
                //    SiteID = int.Parse(settings["SiteID"]);
                //}
                
                if (settings.ContainsKey("ClassItem"))
                {
                    string sClassItem = settings["ClassItem"];

                    if (!string.IsNullOrEmpty(sClassItem))
                    {

                        if (SiteID == 0)//自动适应
                        {
                            rpSubClass.DataSource = BLL.NewsClass.GetClassInIDs(sClassItem, base.GetSiteID);
                        }
                        else
                        {
                            rpSubClass.DataSource = BLL.NewsClass.GetClassInIDs(sClassItem, SiteID);
                        }
                        
                    }
                    else
                    {
                        if (SiteID == 0)//自动适应
                        {
                            rpSubClass.DataSource = BLL.NewsClass.GetSubClass(cid, 20, base.GetSiteID);//暂时这样20

                        }
                        else
                        {
                            rpSubClass.DataSource = BLL.NewsClass.GetSubClass(cid, 20, SiteID);//暂时这样20

                        }
                    }
                }
                if (settings.ContainsKey("TemMoreList"))
                {
                    string sTem = settings["TemMoreList"];

                    sTem = base.TemBll.GetTemPath(sTem);
                    if (!string.IsNullOrEmpty(sTem))
                    {
                        
                        rpSubClass.ItemTemplate = LoadTemplate(sTem);
                    }
                }

                rpSubClass.DataBind();
                
            }

        }
        private StringDictionary settings;
        public override string Name
        {
            get { return "ClassListMore"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
        
       // private int iIndex = 1;
        public void rpSubClass_ItemBound(object sender, RepeaterItemEventArgs e)
        {

            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                //iIndex++;
                //if(iIndex==3)
                //{
                //  Literal llStyle =   (Literal)e.Item.FindControl("llStyle");

                //    llStyle.Text = "style='margin-left:9px; margin-right:9px;'";

                //    iIndex = 0;
                //}
                Entity.NewsClass drData = (Entity.NewsClass)e.Item.DataItem;
                int classid = drData.ID;
                if(settings.ContainsKey("SubClassOrContent")) 
                {
                    string sSubClassOrContent =  settings["SubClassOrContent"];

                    if (sSubClassOrContent == "1")//获取分类下的子分类列表
                    {
                        LoadSubClassCtr(e.Item.Controls[0], classid);
                    }
                    else
                    {
                       // LoadContentCtr(e.Item.Controls[0], classid);
                    }

                }
                else  //获取分类下的内容列表
                {
                   // LoadContentCtr(e.Item.Controls[0], classid);
                    
                    
                }

            }
        }

        private void LoadSubClassCtr(System.Web.UI.Control ctrl, int iClassID)
        {

            string sGetClassDataPath = string.Concat("~/", EbSite.Base.Host.Instance.CurrentSite.GetPathWidgetsWidgetList(), "/GetSubClass/widget.ascx"); ;

            EbSite.Widgets.GetSubClass.widget ucClassData = (GetSubClass.widget)Page.LoadControl(sGetClassDataPath);//"~/Widgets/GetSubClass/widget.ascx"

            

            if (settings.ContainsKey("TemSubClass"))
            {
                string sTmID = settings["TemSubClass"];

                if (!string.IsNullOrEmpty(sTmID))
                {
                    ucClassData.SetTem = sTmID;
                }
            }

            if (settings.ContainsKey("CountSubClass"))
            {
                string sCount = settings["CountSubClass"];

                if (!string.IsNullOrEmpty(sCount))
                {
                    ucClassData.SetTop = Core.Utils.StrToInt(sCount,10);
                }
            }

            if (settings.ContainsKey("OrderBySubClass"))
            {
                string sOrderBy = settings["OrderBySubClass"];

                if (!string.IsNullOrEmpty(sOrderBy))
                {
                    ucClassData.SetOrderBy = sOrderBy;
                }
            }


            ucClassData.SetClassID = iClassID;

            PlaceHolder llClassList = (PlaceHolder)ctrl.FindControl("phList");

            llClassList.Controls.Add(ucClassData);
        }

        //private void LoadContentCtr(System.Web.UI.Control ctrl,int iClassID)
        //{

        //    string sGetClassDataPath = string.Concat("~/", EbSite.Base.Host.Instance.CurrentSite.GetPathWidgetsWidgetList(), "/GetSubClass/widget.ascx"); ;

        //    GetClassDataModel ucClassData = (GetClassDataModel)Page.LoadControl(sGetClassDataPath);//"~/Widgets/GetContent/Controls/GetClassDataModel.ascx"


        //    if (settings.ContainsKey("drpType"))
        //    {
        //        string sType = settings["drpType"];

        //        if (!string.IsNullOrEmpty(sType))
        //        {
        //            ucClassData.DataModel = (Pages.Control.DataListType)int.Parse(sType);
        //        }
        //    }
        //    if (settings.ContainsKey("CountImg"))
        //    {
        //        string sType = settings["CountImg"];
        //        ucClassData.ImgTop = int.Parse(sType);
        //    }
        //    if (settings.ContainsKey("CountTitle"))
        //    {
        //        string sType = settings["CountTitle"];
        //        ucClassData.TitleTop = int.Parse(sType);
        //    }
        //    if (settings.ContainsKey("TemTitle"))
        //    {
        //        string sTem = settings["TemTitle"];
        //        sTem = base.TemBll.GetTemPath(sTem);
        //        if (!string.IsNullOrEmpty(sTem))
        //        {
        //            ucClassData.TitleTemPath = sTem;
        //        }


        //    }

        //    if (settings.ContainsKey("ListModel"))
        //    {
        //        int iListModel = int.Parse(settings["ListModel"]);
        //        ucClassData.LstModel = (ListModel)iListModel;
        //    }

        //    if (settings.ContainsKey("TemImg"))
        //    {
        //        string sTem = settings["TemImg"];
        //        sTem = base.TemBll.GetTemPath(sTem);
        //        if (!string.IsNullOrEmpty(sTem))
        //        {
        //            ucClassData.ImgTemPath = sTem;
        //        }

        //    }
        //    if (settings.ContainsKey("IsShowNum"))
        //    {
        //        string sIsShowNum = settings["IsShowNum"];
        //        if (!string.IsNullOrEmpty(sIsShowNum))
        //            ucClassData.IsShowNum = bool.Parse(sIsShowNum);

        //    }

        //    if (settings.ContainsKey("IsGetSub"))
        //    {
        //        string IsGetSub = settings["IsGetSub"];
        //        if (!string.IsNullOrEmpty(IsGetSub))
        //            ucClassData.IsGetSub = bool.Parse(IsGetSub);

        //    }


        //    ucClassData.iClassID = iClassID;

        //    //System.Web.UI.Control ctrl = e.Item.Controls[0];

        //    PlaceHolder llClassList = (PlaceHolder)ctrl.FindControl("phList");

        //    llClassList.Controls.Add(ucClassData);
        //}




    }
}