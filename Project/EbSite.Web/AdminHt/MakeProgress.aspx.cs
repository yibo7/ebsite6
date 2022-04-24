using System;
using System.Threading;
//using EbSite.Core.Static.BatchCreatManager;
using EbSite.Base.Static.BatchCreatManager;
using EbSite.Pages;

namespace EbSite.Web.AdminHt
{
    public partial class MakeProgress : EbSite.Base.Page.ManagePage
    {
        protected int GetMakeType
        {
            get
            {
                if(!string.IsNullOrEmpty(Request["t"]))
                {
                    return int.Parse(Request["t"]);
                }
                return -1;
            }
        }
        /// <summary>
        /// 1列表生成成,2列表查看进度信息
        /// </summary>
        protected int mat
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["mat"]))
                {
                    return int.Parse(Request["mat"]);
                }
                return -1;
            }
        }

        public Guid ModelID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["modelid"]))
                    return new Guid(Request.QueryString["modelid"]);
                else
                     return Guid.Empty; 
                   
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {  

                if (GetMakeType>0)
                {
                    if(mat==1)
                    {
                        ProgressBase CurrentPg = MakeUtils.GetProgressObj(GetMakeType, GetSiteID,ModelID);

                        
                        CurrentPg.CurrentThread = new Thread(CurrentPg.Star);
                        CurrentPg.CurrentThread.Start();
                        
                    }
                    
                }
                

            }

        }

       
        /// <summary>
        /// 终止生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btClear_Click(object sender, EventArgs e)
        {

            ProgressBase CurrentPg =EbSite.Base.Static.BatchCreatManager.MakeUtils.GetProgressObj(GetMakeType, GetSiteID);
            if (!Equals(CurrentPg.CurrentThread,null)) CurrentPg.CurrentThread.Abort();
            CurrentPg.Dispose();
        }
        protected override void OnPreInit(EventArgs e)
        {
        }
    }
}
