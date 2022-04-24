using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.BLL;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.RelateContent
{
    public partial class widget : WidgetBase
    {
        /// <summary>
        /// 要查询的字段，可由用户后台设置
        /// </summary>
        protected string Fields = "id,newstitle,ClassName,addtime,classid,HtmlName,ContentInfo,smallpic";
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                
                if(ContentID>0)
                {
                    int iTop = 10;
                    int SiteID = GetSiteID;
                    


                    StringDictionary settings = GetSettings();
                    if (settings.ContainsKey("txtCount"))
                    {
                        iTop = int.Parse(settings["txtCount"]);

                    }
                    
                    if (settings.ContainsKey("txtTem"))
                    {
                        string TemId = settings["txtTem"];
                        string TemPath = base.TemBll.GetTemPath(TemId);
                        
                        if (!string.IsNullOrEmpty(TemPath))
                        {
                            rpRelateContent.ItemTemplate = LoadTemplate(TemPath);
                            //AppStartInit.InfoLog.InfoFormat("载入模板完毕，模板ID：{0},模板路径：{1}", TemId,TemPath);
                        }
                    }

                    rpRelateContent.DataSource = NewsContentInst.GetTagRelate(iTop, ContentID,"", SiteID);
                    rpRelateContent.DataBind();
                }
                
                
            }
        }

        public override string Name
        {
            get { return "RelateContent"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }


        protected int ContentID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return int.Parse(Request["id"]);
                }
                return 0;
            }
        }
        protected int ClassID
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

        private NewsContentSplitTable NewsContentInst
        {
            get
            {
                return EbSite.Base.AppStartInit.GetNewsContentInst(ClassID);
            }
        }
    }
}