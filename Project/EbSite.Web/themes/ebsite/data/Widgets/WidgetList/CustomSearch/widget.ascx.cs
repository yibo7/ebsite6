using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.BLL.GetLink;

namespace EbSite.Widgets.CustomSearch
{
    public partial class widget : WidgetBase
    {
        private StringDictionary settings;
        public override void LoadData()
        {
            if (!base.IsPostBack)
            {
                
                string sTem = "";
                 settings = GetSettings();
                if (settings.ContainsKey("Tem"))
                {
                    sTem = settings["Tem"];

                }
                sTem = base.TemBll.GetTemPath(sTem);
                if (!string.IsNullOrEmpty(sTem))
                {
                    
                    rpData.ItemTemplate = LoadTemplate(sTem);
                }
                  action = settings["SoPage"];
                  if (string.IsNullOrEmpty(action))
                      action = Base.PageLink.GetBaseLinks.Get(GetSiteID).CustomSearchRw;
                      //action = HrefFactory.GetInstance(GetSiteID).CustomSearchRw;

                  method = settings["Method"];
                  onSubmit = settings["OnSubmit"];
                  target = settings["Target"];
;
                    SubMitType = settings["SubmitType"];
                    SubMitTextOrImgUrl = settings["SubMitTextOrImgUrl"];
                    if (Equals(SubMitType, "image"))
                    {
                        SubMitTextOrImgUrl = string.Format("src=\"{0}\" ", SubMitTextOrImgUrl); 
                    }
                    else
                    {
                        SubMitTextOrImgUrl = string.Format("value=\"{0}\" ", string.IsNullOrEmpty(SubMitTextOrImgUrl)?"搜索":SubMitTextOrImgUrl); 
                    }

                DataBind();

            }
        }
       protected string FormID = "fm" + Core.Strings.GetString.RandomNUM(5);
       protected string action = "";
       protected string method = "";
       protected string onSubmit = "";
       protected string target = "";
       protected string SubMitTextOrImgUrl = "";
       protected string SubMitType = "submit";
       
        

        private void DataBind()
        {
            
            if (!Equals(settings, null))
            {
                DataTable dt = GetSettingsTable();
                List<FormModel> lst = new List<FormModel>();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FormModel fm = new FormModel();

                        fm.Title = dr["FormName"].ToString();
                        string sCtrID = dr["ModelCtrlID"].ToString();
                        string sColumnName = dr["SearchFiled"].ToString();
                        fm.Control = GetCtrHtml(sCtrID, sColumnName);

                        lst.Add(fm);
                    }
                }

                rpData.DataSource = lst;
                rpData.DataBind();
            }
            

        }
        private string GetCtrHtml(string sCtrID,string sColumnName)
        {
            if (string.IsNullOrEmpty(sCtrID)) return "";
            string sHtml = "";
            string sUrl = string.Format("{0}/CustomPages/GetCtrHtml.aspx?id={1}", Base.AppStartInit.IISPath, sCtrID);
            sHtml = Core.Utils.GetData(sUrl);

            sHtml = Core.Strings.GetString.CutMiddleStr(sHtml, "<!--开始-->", "<!--结束-->");
            string sRegex = "name=\".*?\"";
            sHtml = Core.Strings.GetString.RegexReplace(sHtml, sRegex, string.Format("name = \"{0}\"", sColumnName));               
            return sHtml;
        }
        /// <summary>
        /// 返回部件数据构成所需要列格式
        /// </summary>
        /// <returns></returns>
        public override List<string> InitColumns()
        {
            List<string> lst = new List<string>();
            lst.Add("TableName");
            lst.Add("FormName");
            lst.Add("ModelCtrlID");
            lst.Add("SearchFiled");
            lst.Add("Where");
            lst.Add("DataType");
            lst.Add("AndOr");
            
            return lst;
        }
        public override string Name
        {
            get { return "CustomSearch"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }
        
    }
    public class FormModel
    {
        private string _Title;
        private string _Control;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }
        public string Control
        {
            get
            {
                return _Control;
            }
            set
            {
                _Control = value;
            }
        }
    }
}