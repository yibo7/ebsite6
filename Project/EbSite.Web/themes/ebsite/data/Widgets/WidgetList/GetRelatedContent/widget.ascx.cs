using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Base.Static;

namespace EbSite.Widgets.GetRelatedContent
{
    public partial class widget : WidgetBase
    {
        override public string CacheKey
        {
            get
            {
                return ContentID.ToString();
            }
        } 

        /// <summary>
        /// 要查询的字段，可由用户后台设置
        /// </summary>
        //protected string Fields = "id,newstitle,ClassName,addtime,classid,HtmlName";
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                
                
                    int iTop = 10;
                    int SiteID = GetSiteID;
                    string TemPath = "";
                    bool IsSmallImg = false;
                    bool IsRandAll = false;
                    int CacheType = 0;
                    StringDictionary settings = GetSettings();
                    if (settings.ContainsKey("txtCount"))
                    {
                        iTop = int.Parse(settings["txtCount"]);

                    }

                    if (settings.ContainsKey("txtTem"))
                    {
                        TemPath = settings["txtTem"];
                    }
                    if (settings.ContainsKey("IsSmallImg"))
                    {
                        IsSmallImg = bool.Parse(settings["IsSmallImg"]);
                    }

                    if (settings.ContainsKey("IsRandAll"))
                    {
                        IsRandAll =   bool.Parse(settings["IsRandAll"]);
                    }


                    if (settings.ContainsKey("CacheType"))
                    {
                        CacheType = int.Parse(settings["CacheType"]);
                    }

                        int iParentID = ClassId;
                    if (IsRandAll)
                    {
                        iParentID = 0;
                    }

                    NewsContentSplitTable NewsContentInst;// = EbSite.Base.AppStartInit.GetNewsContentInst(ParentID);

                    if (iParentID > 0)
                    {
                        NewsContentInst = EbSite.Base.AppStartInit.GetNewsContentInst(iParentID);
                    }
                    else
                    {
                        NewsContentInst = EbSite.Base.AppStartInit.NewsContentInstDefault;
                    }

                    List<Entity.NewsContent> lstData;// = NewsContentInst.Get_Related(IsSmallImg, iTop, iParentID, SiteID);

                    if (CacheType>0)
                    {
                        double cachetime = 0;
                        ETimeSpanModel esm = ETimeSpanModel.FZ;

                        switch (CacheType)
                        {
                            case 1:
                                cachetime = 1;
                                esm = ETimeSpanModel.FZ;
                                break;
                            case 2:
                                cachetime = 15;
                                esm = ETimeSpanModel.FZ;
                                break;
                            case 3:
                                cachetime = 30;
                                esm = ETimeSpanModel.FZ;
                                break;
                            case 4:
                                cachetime = 1;
                                esm = ETimeSpanModel.XS;
                                break;
                            case 5:
                                cachetime = 3;
                                esm = ETimeSpanModel.XS;
                                break;
                            case 6:
                                cachetime = 5;
                                esm = ETimeSpanModel.XS;
                                break;
                            case 7:
                                cachetime = 1;
                                esm = ETimeSpanModel.T;
                                break;
                            case 8:
                                cachetime = 2;
                                esm = ETimeSpanModel.T;
                                break;
                            case 9:
                                cachetime = 3;
                                esm = ETimeSpanModel.T;
                                break;
                        }

                        string cachekey = string.Concat("GetRandContent", DataID,"c", iParentID,"a", ContentID);
                        lstData = EbSite.Base.Host.CacheApp.GetCacheItem<List<Entity.NewsContent>>(cachekey, "widget");
                        if (Equals(lstData, null))
                        {
                            lstData = NewsContentInst.Get_Related(IsSmallImg, iTop, iParentID, SiteID, ContentID);
                            if(!Equals(lstData,null)&& lstData.Count>0)
                                EbSite.Base.Host.CacheApp.AddCacheItem(cachekey, lstData, cachetime, esm, "widget");
                        }
                    }
                    else
                    {
                        lstData = NewsContentInst.Get_Related(IsSmallImg, iTop, iParentID, SiteID, ContentID);
                    }
                    rpRelateContent.DataSource = lstData;// NewsContentInst.Get_Related(IsSmallImg, iTop, iParentID, SiteID);
                    TemPath = base.TemBll.GetTemPath(TemPath);
                    if (!string.IsNullOrEmpty(TemPath))
                    {
                        rpRelateContent.ItemTemplate = LoadTemplate(TemPath);
                    }
                    rpRelateContent.DataBind();
                }
                
                
            
        }

        public override string Name
        {
            get { return "GetRelatedContent"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }


        protected long ContentID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return long.Parse(Request["id"]);
                }
                return 0;
            }
        }


        protected int ClassId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return int.Parse(Request["cid"]);
                }
                return 0;
            }
        }

        

        //private NewsContentSplitTable NewsContentInst
        //{
        //    get
        //    {
        //        return EbSite.Base.AppStartInit.GetNewsContentInst(ParentID);
        //    }
        //}
    }
}