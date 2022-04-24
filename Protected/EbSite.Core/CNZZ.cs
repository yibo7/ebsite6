//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Net;
//using System.Text;
//using System.Web;
//using System.Web.Security;
//using EbSite.Core.FSO;

//namespace EbSite.Core
//{

//    public class CNZZ
//    {
        
//        static private string GetCnzzPath
//        {
//            get
//            {

//                return HttpContext.Current.Server.MapPath(string.Concat(Base.AppStartInit.IISPath, "cnzz.txt"));
//            }
//        }
//        static public bool IsHaveID
//        {
//            get
//            {
//                return Core.FSO.FObject.IsExist(GetCnzzPath, FsoMethod.File);
//            }
//        }

//        static private string _GetCnzzID = null;
//        static private string GetCnzzID
//        {
//            get
//            {
//                if (_GetCnzzID == null)
//                {
//                    if (IsHaveID)
//                    {
//                        string sInfo = Core.FSO.FObject.ReadFile(GetCnzzPath);
//                        string[] strArray = sInfo.Split(new char[] { '@' });

//                        _GetCnzzID =  strArray[0];
//                    }
//                    _GetCnzzID =  "";
                    
//                }

//                return _GetCnzzID;

//            }
//        }
//        static public string GetCnzzPass
//        {
//            get
//            {
//                if (IsHaveID)
//                {
//                    string sInfo = Core.FSO.FObject.ReadFile(GetCnzzPath);
//                    string[] strArray = sInfo.Split(new char[] { '@' });

//                    return strArray[1];
//                }
//                return "";

//            }
//        }
//        static public string InfoUrl
//        {
//            get
//            {
//                return string.Format("http://wss.cnzz.com/user/companion/92hi_login.php?site_id={0}&password={1}", GetCnzzID, GetCnzzPass);
//            }
//        }

//        static public void DeleteCnzzId()
//        {
//            if (Core.FSO.FObject.IsExist(GetCnzzPath, FsoMethod.File))
//            {
//                FObject.Delete(GetCnzzPath,FsoMethod.File);
//            }
//        }

//        static public void CreateCnzzId()
//        {

//            string host = HttpContext.Current.Request.Url.Host;
//            string str2 = FormsAuthentication.HashPasswordForStoringInConfigFile(host + "A9jkLUxm", "MD5").ToLower();
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://wss.cnzz.com/user/companion/92hi.php?domain=" + host + "&key=" + str2);
//            Stream responseStream = ((HttpWebResponse)request.GetResponse()).GetResponseStream();
//            responseStream.ReadTimeout = 100;
//            StreamReader reader = new StreamReader(responseStream);
//            string str4 = reader.ReadToEnd().Trim();
//            reader.Close();
//            if (str4.IndexOf("@") == -1)
//            {
//                Core.Strings.cJavascripts.MessageShowBack("帐号创建不成功");
//            }
//            else
//            {
//                //string[] strArray = str4.Split(new char[] { '@' });

//                //string CnzzUsername = strArray[0];
//                //string CnzzPassword = strArray[1];

//                Core.FSO.FObject.WriteFile(GetCnzzPath, str4);

//            }
//        }
//        static public string GetJs()
//        {

//            return string.Format("<span  style='display:none' ><script src='http://pw.cnzz.com/c.php?id={0}&l=2' language='JavaScript' charset='utf-8'></script></span>", GetCnzzID);
//        }
//    }
    

//}
