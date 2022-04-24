
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using EbSite.Control;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.WinBox
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                string sTem = "";
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("Tem"))
                {
                    sTem = settings["Tem"];

                }

                sTem = base.TemBll.GetTemPath(sTem);
                if (!string.IsNullOrEmpty(sTem))
                {
                    
                    rpData.ItemTemplate = LoadTemplate(sTem);
                }
                
                string sT;
                if (settings.ContainsKey("Type"))
                {
                    sT = settings["Type"];
                    IsImg = (sT == "1");
                }
                if (settings.ContainsKey("Group"))
                {
                    sT = settings["Group"];
                    IsShowAllLink = (sT == "1");

                }
                if (settings.ContainsKey("HrefModel"))
                {
                    sT = settings["HrefModel"];
                    if (!string.IsNullOrEmpty(sT))
                        HrefModel = (WinBoxLinkModel)int.Parse(sT);
                }
                if (settings.ContainsKey("WindowsTitle"))
                {
                    WindowsName = settings["WindowsTitle"];
                   ;
                }
                if (settings.ContainsKey("IsFull"))
                {
                    if (!string.IsNullOrEmpty(settings["IsFull"]))
                    {
                        IsFull = bool.Parse(settings["IsFull"]);
                    }
                }
                if (settings.ContainsKey("Width"))
                {
                    if (!string.IsNullOrEmpty(settings["Width"]))
                    {
                        iWidth = int.Parse(settings["Width"]);
                    }
                }
                if (settings.ContainsKey("Height"))
                {
                    if (!string.IsNullOrEmpty(settings["Height"]))
                    {
                        iHeight = int.Parse(settings["Height"]);
                    }
                }
               
                GroupName = Core.Strings.GetString.RandomNUM(5);
                DataBind();
            }
        }
        private void DataBind()
        {
            DataTable dt = GetSettingsTable();
            if(IsShowAllLink)
            {
                
                rpData.DataSource = dt;
                rpData.DataBind();
            }
            else
            {
                if(dt.Rows.Count>0)
                {
                    StringBuilder sbImgList = new StringBuilder();

                    foreach (DataRow dataRow in dt.Rows)
                    {
                        string su = dataRow["url"].ToString();
                        sbImgList.Append(su);
                        sbImgList.Append("|");
                    }
                    if (sbImgList.Length > 1) sbImgList.Remove(sbImgList.Length-1, 1);

                    DataRow dr = dt.Rows[0];

                    string sTitle = dr["title"].ToString();
                    string sUrl = dr["url"].ToString();
                    string sUrlPic = dr["UrlPic"].ToString();
                    EbSite.Control.WinBox wb = GetAWinBox(sTitle, sUrl, sUrlPic, sbImgList.ToString());
                    plOneItem.Controls.Add(wb);
                }
                
            }
            
        }
        /// <summary>
        /// 返回部件数据构成所需要列格式
        /// </summary>
        /// <returns></returns>
        public override List<string> InitColumns()
        {
            List<string> lst = new List<string>();
            lst.Add("Title");
            lst.Add("Url");
            lst.Add("UrlPic");

            return lst;
        }
        public override string Name
        {
            get { return "WinBox"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }

        private int iWidth = 0;
        private int iHeight = 0;
        private bool IsFull;
        /// <summary>
        /// 是否图片,否则页面
        /// </summary>
        private bool IsImg;
        /// <summary>
        /// 是否显示所有连接
        /// </summary>
        private bool IsShowAllLink;
        /// <summary>
        /// 连接模式 1文本连接,2图片连接,3按钮连接
        /// </summary>
        private  WinBoxLinkModel HrefModel;
        /// <summary>
        /// 组名称
        /// </summary>
        private string GroupName = "GroupName";

        private string WindowsName = "";
        private EbSite.Control.WinBox GetAWinBox(string Title,string Url,string HrefImg,string ImgList)
        {
            EbSite.Control.WinBox wb = new Control.WinBox();
            wb.Href = Url;
            wb.Title = string.IsNullOrEmpty(WindowsName) ? Title : WindowsName;
            wb.Text = Title;
            wb.IsFull = IsFull;
            wb.GroupName = GroupName;
            wb.LinkModel = HrefModel;
            wb.IsImg = IsImg;
            wb.HrefImg = HrefImg;

            wb.Width = iWidth;
            wb.Height = iHeight;
            
            if (!string.IsNullOrEmpty(ImgList))
                wb.ImgList = ImgList;

            return wb;
        }
        protected void rpData_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                DataRowView drData = (DataRowView) e.Item.DataItem;
                string sTitle = drData["Title"].ToString();
                string sUrl = drData["Url"].ToString();
                string sUrlPic = drData["UrlPic"].ToString();
                Panel pl = (Panel)e.Item.FindControl("plItem");

                EbSite.Control.WinBox wb = GetAWinBox(sTitle, sUrl, sUrlPic,"");

                pl.Controls.Add(wb);
            }
        }

        
        
    }
}