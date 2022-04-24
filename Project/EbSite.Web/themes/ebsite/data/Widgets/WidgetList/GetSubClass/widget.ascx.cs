
using System;
using System.Collections.Specialized;

using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.GetSubClass
{
    public partial class widget : WidgetBase
    {
        private int GetClassID
        {
            get
            {
               
                if(!string.IsNullOrEmpty(Request["cid"]))
                {
                    return int.Parse(Request["cid"]);
                }
                return 0;
            }
        }
        #region 由ClassListMore部件直接调用
        private int _SetClassID = 0;
        public int SetClassID
        {
            set
            {
                _SetClassID = value;
            }
        }
        private int _SetTop = 10;
        public int SetTop
        {
            set
            {
                _SetTop = value;
            }
        }

        private string _SetOrderBy = "z";
        public string SetOrderBy
        {
            set
            {
                _SetOrderBy = value;
            }
        }
        private string _SetTem = "";
        /// <summary>
        /// 由ClassListMore部件直接调用
        /// </summary>
        public string SetTem
        {
            set
            {
                _SetTem = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_SetClassID > 0)
                {
                    _SetTem = base.TemBll.GetTemPath(_SetTem);
                    if (!string.IsNullOrEmpty(_SetTem))
                    {
                       
                        rpSubClass.ItemTemplate = LoadTemplate(_SetTem);
                    }
                    BindDataList(GetSiteID, _SetClassID, _SetTop, _SetOrderBy);
                    rpSubClass.DataBind();
                }
                
            }
        }

        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                
                if(_SetClassID==0)
                {
                    StringDictionary settings = GetSettings();
                    if (settings.ContainsKey("ClassItem"))
                    {
                        int SiteID = GetSiteID;// int.Parse(settings["SiteID"]);
                        string pid = settings["ClassItem"];
                        string gettype = settings["drpType"];
                        string sTop = settings["Top"];
                        string IsSetID = settings["IsSetID"];

                        if (!string.IsNullOrEmpty(IsSetID) && IsSetID=="1")
                        {
                            rpSubClass.DataSource = BLL.NewsClass.GetSubClass(pid, Core.Utils.StrToInt(sTop, 60), GetSiteID);
                        }
                        else if (!string.IsNullOrEmpty(pid) && !string.IsNullOrEmpty(gettype))
                        {
                            int ParentID = int.Parse(pid);
                            int iTop = int.Parse(sTop);
                            if (ParentID == 0) //自动适应
                            {
                                int ic =  EbSite.BLL.NewsClass.GetCount(GetClassID, GetSiteID);
                                if (ic>0)
                                    ParentID = GetClassID;
                                else
                                {
                                    ParentID = BLL.NewsClass.GetModelByCache(GetClassID).ParentID;
                                }
                            }

                            BindDataList(SiteID, ParentID, iTop, gettype);
                            //if (SiteID == 0)
                            //{
                            //    rpSubClass.DataSource = BLL.NewsClass.GetSubClass(ParentID, iTop, gettype, GetSiteID);
                            //}
                            //else
                            //{
                            //    rpSubClass.DataSource = BLL.NewsClass.GetSubClass(ParentID, iTop, gettype, SiteID);
                            //}
                        }
                    }

                    if (settings.ContainsKey("tem"))
                    {
                        string sTem = settings["tem"];
                        sTem = base.TemBll.GetTemPath(sTem);
                        if (!string.IsNullOrEmpty(sTem))
                        {
                            rpSubClass.ItemTemplate = LoadTemplate(sTem);
                        }
                    }
                    rpSubClass.DataBind();
                }
               

               
                
            }
        }
        private void BindDataList(int SiteID, int ParentID, int iTop, string gettype)
        {
            if (SiteID == 0)
            {
                rpSubClass.DataSource = BLL.NewsClass.GetSubClass(ParentID, iTop, gettype, GetSiteID);
            }
            else
            {
               
                rpSubClass.DataSource = BLL.NewsClass.GetSubClass(ParentID, iTop, gettype, SiteID);
            }
        }
        public override string Name
        {
            get { return "GetSubClass"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
    }
}