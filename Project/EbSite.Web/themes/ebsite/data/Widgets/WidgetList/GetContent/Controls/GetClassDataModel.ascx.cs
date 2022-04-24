using System;
namespace EbSite.Pages.Control
{
    public partial class GetClassDataModel : System.Web.UI.UserControl
    {
        
        private int _iClassID = -1;
        public int iClassID
        {
            get
            {
                return _iClassID;
            }
            set
            {
                _iClassID = value;
            }
        }
        private int _ImgTop = 3;
        public int ImgTop
        {
            get
            {
                return _ImgTop;
            }
            set
            {
                _ImgTop = value;
            }
        }

        private int _TitleTop = 10;
        public int TitleTop
        {
            get
            {
                return _TitleTop;
            }
            set
            {
                _TitleTop = value;
            }
        }

        public DataListType _DataModel;

        public DataListType DataModel
        {
            get
            {
                return _DataModel;
            }
            set
            {
                _DataModel = value;
            }
        }

        public ListModel _LstModel;

        public ListModel LstModel
        {
            get
            {
                return _LstModel;
            }
            set
            {
                _LstModel = value;
            }
        }

        public string _TitleTemPath;

        public string TitleTemPath
        {
            get
            {
                return _TitleTemPath;
            }
            set
            {
                _TitleTemPath = value;
            }
        }
        public string _ImgTemPath;

        public string ImgTemPath
        {
            get
            {
                return _ImgTemPath;
            }
            set
            {
                _ImgTemPath = value;
            }
        }

        public bool _IsShowNum = false;
        /// <summary>
        /// 是否显示序号
        /// </summary>
        public bool IsShowNum
        {
            get
            {
                return _IsShowNum;
            }
            set
            {
                _IsShowNum = value;
            }
        }

        private bool _IsGetSub = false;
        /// <summary>
        /// 是否调用子分类下的数据
        /// </summary>
        public bool IsGetSub
        {
            get
            {
                return _IsGetSub;
            }
            set
            {
                _IsGetSub = value;
            }
        }
        //private bool _IsImg = false;
        ///// <summary>
        ///// 是否只查询图片内容
        ///// </summary>
        //public bool IsImg
        //{
        //    get
        //    {
        //        return _IsImg;
        //    }
        //    set
        //    {
        //        _IsImg = value;
        //    }
        //}
        public int SiteID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               
                //string sGetClassDataPath = string.Concat("~/", EbSite.BLL.ThemesPC.Instance.GetCurrentUsedTheme.GetPathWidgetsWidgetList(), "/GetContent/Controls/GetClassData.ascx"); 

                string sGetClassDataPath = string.Concat("~/", EbSite.Base.Host.Instance.GetSite(SiteID).GetPathWidgetsWidgetList(), "/GetContent/Controls/GetClassData.ascx"); ;

                GetClassData gcd;
                System.Web.UI.Control ctrls;
                string ListNumSytle = "list_one";
                if (IsShowNum) ListNumSytle = "NoList";
                if (LstModel == ListModel.ImgTitle)  //左边图片右边标题版式
                {
                    string sTable = "<table style=\"width:100%\" cellpadding=0 cellspacing=0><tr><td style=\"width:32%; vertical-align:top;padding-top:5px;\"> ";
                    ctrls = Page.ParseControl(sTable);
                    phList.Controls.Add(ctrls);
                    //gcd = (GetClassData)Page.LoadControl(sGetClassDataPath);
                    gcd = (GetClassData)Page.LoadControl(sGetClassDataPath);
                    gcd.DataModel = DataModel;
                    gcd.iTop = ImgTop;
                    //gcd.iImgTop = ImgTop;
                    gcd.SiteID = SiteID;
                   
                    gcd.iClassID = iClassID;

                    if (!string.IsNullOrEmpty(ImgTemPath))
                    {
                        gcd.MyTemPath = TitleTemPath;
                    }
                    else
                    {
                        gcd.MyTemPath = "defaulttem/imgtitle.ascx";
                    }
                    gcd.IsHaveImg = true;
                    phList.Controls.Add(gcd);

                    sTable = string.Concat("</td><td style=\"width:68%\"><ul class=\"", ListNumSytle, "\">");
                    ctrls = Page.ParseControl(sTable);
                    phList.Controls.Add(ctrls);

                    gcd = (GetClassData)Page.LoadControl(sGetClassDataPath);
                    gcd.DataModel = DataModel;
                    gcd.iTop = TitleTop;
                   // gcd.iTitleTop = TitleTop;

                    gcd.iClassID = iClassID;

                    gcd.IsGetSub = IsGetSub;

                    if (!string.IsNullOrEmpty(TitleTemPath))
                    {
                        gcd.MyTemPath = TitleTemPath;
                    }
                    else
                    {
                        gcd.MyTemPath = "defaulttem/title.ascx";
                    }
                    phList.Controls.Add(gcd);

                    sTable = "</ul></td></tr></table>";
                    ctrls = Page.ParseControl(sTable);
                    phList.Controls.Add(ctrls);

                }
                else if (LstModel == ListModel.TitleImg)//左边标题右边图片版式
                {
                    string sTable = string.Concat("<table style=\"width:100%\" cellpadding=0 cellspacing=0><tr><td style=\"width:68%; vertical-align:top;\"><ul class=\"", ListNumSytle, "\">");
                    ctrls = Page.ParseControl(sTable);
                    phList.Controls.Add(ctrls);

                    gcd = (GetClassData)Page.LoadControl(sGetClassDataPath);
                    gcd.DataModel = DataModel;
                   gcd.iTop = TitleTop;
                  //  gcd.iTitleTop = TitleTop;

                    gcd.iClassID = iClassID;
                    gcd.IsGetSub = IsGetSub;
                    gcd.SiteID = SiteID;

                    if (!string.IsNullOrEmpty(TitleTemPath))
                    {
                        gcd.MyTemPath = TitleTemPath;
                    }
                    else
                    {
                        gcd.MyTemPath = "defaulttem/title.ascx";
                    }
                    phList.Controls.Add(gcd);

                    sTable = "</ul></td><td style=\"width:32%;vertical-align:top;padding-top:5px;\">";
                    ctrls = Page.ParseControl(sTable);
                    phList.Controls.Add(ctrls);

                    gcd = (GetClassData)Page.LoadControl(sGetClassDataPath);
                    gcd.DataModel = DataModel;
                   gcd.iTop = ImgTop;
                    //gcd.iImgTop = ImgTop;

                    gcd.iClassID = iClassID;
                    gcd.IsGetSub = IsGetSub;
                    gcd.IsHaveImg = true;
                    if (!string.IsNullOrEmpty(ImgTemPath))
                    {
                        gcd.MyTemPath = ImgTemPath;
                    }
                    else
                    {
                        gcd.MyTemPath = "defaulttem/imgtitle.ascx";
                    }
                    phList.Controls.Add(gcd);
                    sTable = "</td></tr></table>";
                    ctrls = Page.ParseControl(sTable);
                    phList.Controls.Add(ctrls);
                }
                else if (LstModel == ListModel.ListImg)//只查询有图片的内容
                {
                    string sTable = string.Concat("<ul >");
                    ctrls = Page.ParseControl(sTable);
                    phList.Controls.Add(ctrls);

                    gcd = (GetClassData)Page.LoadControl(sGetClassDataPath);
                    gcd.DataModel = DataModel;
                    gcd.iTop = ImgTop;
                     // gcd.iImgTop = ImgTop;
                    gcd.SiteID = SiteID;

                    gcd.iClassID = iClassID;
                    gcd.IsGetSub = IsGetSub;
                    gcd.IsHaveImg = true;

                    if (!string.IsNullOrEmpty(ImgTemPath))
                    {
                        gcd.MyTemPath = ImgTemPath;
                    }
                    else
                    {
                        gcd.MyTemPath = "defaulttem/imgtitle.ascx";
                    }
                    phList.Controls.Add(gcd);

                    sTable = "</ul>";
                    ctrls = Page.ParseControl(sTable);
                    phList.Controls.Add(ctrls);
                }
                else //只列标题版式
                {

                    //string sTable = string.Concat("<ul class=\"", ListNumSytle, "\">");
                    //ctrls = Page.ParseControl(sTable);
                    //phList.Controls.Add(ctrls);

                    gcd = (GetClassData)Page.LoadControl(sGetClassDataPath);
                    gcd.DataModel = DataModel;
                    gcd.iTop = TitleTop;
                    gcd.SiteID = SiteID;
                   // gcd.iTitleTop = TitleTop;

                    gcd.iClassID = iClassID;
                    gcd.IsGetSub = IsGetSub;

                    if (!string.IsNullOrEmpty(TitleTemPath))
                    {
                        gcd.MyTemPath = TitleTemPath;
                    }
                    phList.Controls.Add(gcd);

                    //sTable = "</ul>";
                    //ctrls = Page.ParseControl(sTable);
                    //phList.Controls.Add(ctrls);
                }

            }
        }

        

    }
    
    public enum ListModel
    {
        /// <summary>
        /// 只列表标题
        /// </summary>
        ListTile = 1,
        /// <summary>
        /// 左栏图片右栏标题
        /// </summary>
        ImgTitle = 2,
        /// <summary>
        /// 左栏标题右栏图片
        /// </summary>
        TitleImg = 3,
        /// <summary>
        /// 只列图片-只查询有图片的内容
        /// </summary>
        ListImg = 4
    }
    
    
}