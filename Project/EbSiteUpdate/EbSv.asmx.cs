using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using EbSite.Core.FSO;

namespace EbSiteUpdate
{
    /// <summary>
    /// Summary description for EbSv
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EbSv : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet GetPlubins(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            RecordCount = 0;
            return null;
        }
        /// <summary>
        /// 获取模块列表 ,ID,Title,Version,AuthorUrl,Author,FMoney
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="strWhere"></param>
        /// <param name="oderby"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet GetModules(int PageIndex, int PageSize, string strWhere, string oderby, out int RecordCount)
        {
            RecordCount = 0;
            return null;
        }
        [WebMethod]
        public string GetLastVersion(string sIp,string sWebUrl)
        {
            if (!string.IsNullOrEmpty(sIp) && !string.IsNullOrEmpty(sWebUrl))
            {
                string sPath = Server.MapPath("sites.txt");
                string sInfo = string.Format("IP:{0};域名:{1}\n\t", sIp, sWebUrl);
                FObject.WriteFile(sPath, sInfo, true);
                string sPathVersion = Server.MapPath("Version.txt");
                string sVersion = FObject.ReadFile(sPathVersion);
                return sVersion;
            }
            else
            {
                return "1.0.0";
            }
        }

    }
}
