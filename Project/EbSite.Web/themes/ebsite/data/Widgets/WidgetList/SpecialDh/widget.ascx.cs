
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.SpecialDh
{
    public partial class widget : WidgetBase
    {
        protected int sid
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["sid"]))
                {
                    return int.Parse(Request["sid"]);
                }
                return -1;
            }
        }
        /// <summary>
        /// 分类的ID
        /// </summary>
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
        protected int ContentId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return int.Parse(Request["id"]);
                }
                return -1;
            }
        }
        public override void LoadData()
        {
            if (!IsPostBack)
            {
              
                StringDictionary settings = GetSettings();
                //if (settings.ContainsKey("SiteID"))
                //{
                //    SiteID = int.Parse(settings["SiteID"]);
                //}
                if (settings.ContainsKey("SpecialItem"))
                {
                    string sType = settings["SpecialItem"];
                     
                    int iDataType =Core.Utils.StrToInt(settings["DataType"],0);//数据类型，0所有,1有图片的专题,2有专题介绍的专题,3有图片且有专题介绍的专题,4有归属文章的专题
                    int iOrderBy = Core.Utils.StrToInt(settings["OrderBy"],0);//排序方式,0最新添加越靠前,1排序ID越大越靠前,2排序ID越大越靠后

                    int iTop = 100;
                    if (settings.ContainsKey("count"))
                    {
                        iTop = Core.Utils.StrToInt(settings["count"],0);
                    }

                    if (!string.IsNullOrEmpty(sType))
                    {
                        if (sType.Trim() == "0")//全部
                        {
                            rpSubSpecial.DataSource = BLL.SpecialClass.GetListArr(0,iDataType, iOrderBy, GetSiteID);

                        }
                        else if (sType.Trim() == "-2")//自动适应内容ID
                        {
                            if(ContentId>0)
                             rpSubSpecial.DataSource = BLL.SpecialClass.GetListByContentId(ContentId, cid, iDataType, iOrderBy, iTop,GetSiteID);
                        }
                        else if (sType.Trim() == "-1")//自动适应分类ID //把所有专题都属于这个分类的给查出来 RelateClassIDs
                        {
                            rpSubSpecial.DataSource = BLL.SpecialClass.GetListInAutoClassId(cid, iDataType, iOrderBy, iTop, GetSiteID);
                        }
                        else   //选择
                        {
                            rpSubSpecial.DataSource = BLL.SpecialClass.GetListInIDs(sType, iDataType, iOrderBy, GetSiteID);
                        }
                        
                    }
                }
                 

                if (settings.ContainsKey("tem"))
                {
                    string sTem = settings["tem"];
                    sTem = base.TemBll.GetTemPath(sTem);
                    if (!string.IsNullOrEmpty(sTem))
                    {
                        
                        rpSubSpecial.ItemTemplate = LoadTemplate(sTem);
                    }
                }
                rpSubSpecial.DataBind();


            }
        }

        public string GetCurrentClass(object ob)
        {

            string sCss = "";

            if (!Equals(ob, null))
            {
                int ID = int.Parse(ob.ToString());

                if (ID == sid)
                {
                    sCss = "spcurrent";
                }
            }

            return sCss;
        }
        public override string Name
        {
            get { return "SpecialDh"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}