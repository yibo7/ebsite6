//using System;
//using System.IO;
//using System.Text;
//using System.Threading;
//using System.Web;
//using System.Xml;
//using EbSite.Core.FSO;

//namespace EbSite.Core
//{

//    public class ServerInfo
//    {
//        public string Info { get; set; }
//        private string sPath
//        {
//            get
//            {
//                return HttpContext.Current.Server.MapPath(string.Concat(Base.Host.Instance.IISPath, "ConfigsFile/", "ServerInfo.txt"));
//            }
//        }
//        public ServerInfo()
//        {
            
//            if (FSO.FObject.IsExist(sPath, FsoMethod.File))
//            {
//                try
//                {
//                    string json = Core.FSO.FObject.ReadFile(sPath);
//                    Info = Core.Utils.JsonToObj<string>(json);
//                }
//                catch (Exception)
//                {


//                }
//            }

//            //开一个线程，获取服务器上的新闻
//            GetServerInfo gs = new GetServerInfo();
//            gs.SavePath = sPath;
//            Thread td = new Thread(gs.GetInfo);
//            td.Start();
//        }

        

//        public class GetServerInfo
//        {
//            public string SavePath { get; set; }

//            public void  GetInfo()
//            {
//                string sifp = string.Format("{0}/Api/Service.svc/ServerInfo", EbSite.Base.AppStartInit.OfficialsUrl);
//                try
//                {

//                    string Inf = Core.WebUtility.LoadURLStringUTF8(sifp);
//                    FSO.FObject.WriteFile(SavePath, Inf);
//                }
//                catch (Exception e)
//                {


//                }
//            }
//        }
//    }

//    public class UpdateNew
//    {

       

//        public EbSite.Entity.VersionInfo VersionModel; 

//        public bool IsUpdate{ get; set;}
//        /// <summary>
//        /// 检测是否有新版
//        /// </summary>
//         public bool CheckVersion()
//        {
            
//            if (!Utils.IsConnectedInternet()) return false; //如果没有连网，返回false

//            //客户端应用程序最近一次更新日期与服务器端升级程序的最近一次更新日期进行比较。 

//            //获得已下载文档的最近一次更新日期 
//            Version CilVrs = new Version(Utils.GetAssemblyVersion());
//            Version ServerVrs = new Version("1.0.0");
//            string sPath = HttpContext.Current.Server.MapPath(string.Concat(Base.Host.Instance.IISPath, "ConfigsFile/", "NewVersion.txt"));
            
//            if(FSO.FObject.IsExist(sPath,FsoMethod.File))
//            {
//                try
//                {
//                    string sNewVersion = Core.FSO.FObject.ReadFile(sPath);
//                    VersionModel = Core.Utils.JsonToObj<Entity.VersionInfo>(sNewVersion);
//                    ServerVrs = new Version(VersionModel.Version);

//                    IsUpdate = VersionModel.IsUpdate;
//                }
//                catch (Exception)
//                {


//                }
               
                
//            }
//            //开一个线程，获取服务器上的版本
//            string sWebUrl = Core.Strings.GetString.GetSite();
//            string sIP = Core.Utils.GetClientIP();
//            GetSVersion gs = new GetSVersion();
//            gs.WebUrl = sWebUrl;
//            gs.SavePath = sPath;
//            gs.IP = sIP;
//            Thread td = new Thread(gs.GetServerVersion);
//            td.Start();
//            return ServerVrs > CilVrs;
            
           
//        }



        
//    }

//    public class GetSVersion
//    {
//        private string _sWebUrl = "";
//        private string _sSavePath = "";
//        private string _sIP = "";
//        public string WebUrl
//        {
//            get
//            {
//                return _sWebUrl;
//            }
//            set
//            {
//                _sWebUrl = value;
//            }
//        }
//        public string SavePath
//        {
//            get
//            {
//                return _sSavePath;
//            }
//            set
//            {
//                _sSavePath = value;
//            }
//        }
//        public string IP
//        {
//            get
//            {
//                return _sIP;
//            }
//            set
//            {
//                _sIP = value;
//            }
//        }
//        public  void GetServerVersion()
//        {
//            string sServerVersion = "1.0.0";
//            string AutoUpdaterFileName = string.Format("{0}/Api/Service.svc/GetVersion?ip={1}&dm={2}", EbSite.Base.AppStartInit.OfficialsUrl, IP, WebUrl);
//            try
//            {

//                sServerVersion = Core.WebUtility.LoadURLStringUTF8(AutoUpdaterFileName);
//                FSO.FObject.WriteFile(SavePath, sServerVersion);
//            }
//            catch (Exception e)
//            {


//            }
//        }

//    }
//}
