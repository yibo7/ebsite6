
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Web;
using EbSite.Base;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Data.Interface;
using Newtonsoft.Json.Linq;

namespace EbSite.Widgets.JsonList
{
    public partial class widget : WidgetBase
    {
        public override void LoadData()
        {

            if (!base.IsPostBack)
            { 
                string TemPath = ""; 
                StringDictionary settings = GetSettings();
                 
                if (settings.ContainsKey("txtTem"))
                {

                    TemPath = settings["txtTem"];
                }
                string sUrl = settings["txtJsonUrl"];
                if (!string.IsNullOrEmpty(sUrl))
                {
                    if (!string.IsNullOrEmpty(Pram))
                        sUrl = string.Concat(sUrl, "?", Pram);
                        Encoding ed = Encoding.UTF8;
                    if (settings["PostGet"] == "1")
                        ed = Encoding.GetEncoding("gb2312");
                    string sJson =LoadURLString(sUrl, ed, settings["PostGet"]);
                    JArray dataList = JArray.Parse(sJson);
                    rpDataList.DataSource = dataList;
                    TemPath = base.TemBll.GetTemPath(TemPath);
                    if (!string.IsNullOrEmpty(TemPath))
                    {

                        rpDataList.ItemTemplate = LoadTemplate(TemPath);
                    }
                    rpDataList.DataBind();
                }
              
                
            }
        }
        private   string LoadURLString(string url,  Encoding ed,string GetPost)
        { 
            //string sUrl = HttpUtility.UrlEncode(url); 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            
            request.Method = GetPost; 
            //request.Headers.Add("Cache-Control: no-cache");   
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
          
            StreamReader reader = new StreamReader(response.GetResponseStream(), ed);
            return reader.ReadToEnd();
        }
        public override string Name
        {
            get { return "JsonList"; }
        }

        public override bool IsEditable
        {
            get { return true; }
        }

         
        
    }
}