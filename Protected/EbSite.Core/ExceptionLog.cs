//using System;
//using System.Data;
//using System.IO;
//using System.Web;
//using stCommon.FSO;
//using stCommon.XML;
//using stdata.LogProvider;

//namespace EbSite.Core
//{
//    public class ExceptionLog
//    {
//        #region 构造函数
//        /// <summary>
//        /// 构造函数，使用默认的日志名称
//        /// </summary>
//        public ExceptionLog()
//        {
//            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".xml";
//            this._logFolderPath = GetFullPath("/ExceptionLog");
//            this._logFilePath = string.Concat(this._logFolderPath, "/", fileName);
//        }
//        /// <summary>
//        /// 用于用户线程传入的HttpContext
//        /// </summary>
//        public HttpContext contex;

//        public string GetFullPath(string str)
//        {
//            if (contex == null)
//            {
//                return HttpContext.Current.Server.MapPath(str);
//            }
//            else
//            {
//                return contex.Server.MapPath(str);
//            }

//        }

//        /// <summary>
//        /// 指定日志的名称
//        /// </summary>
//        /// <param name="logFilePath">日志文件的相对路径</param>
//        public ExceptionLog(string logFilePath)
//        {
//            this._logFilePath = GetFullPath(logFilePath);
//            FileInfo f = new FileInfo(this._logFilePath);
//            this._logFolderPath = f.DirectoryName;
//        }

//        #endregion

//        //Private Field
//        private string _logFilePath = string.Empty; // 日志文件的存放路径
//        private string _logFolderPath = string.Empty; // 日志文件所在文件夹的路径
//        private bool _IsEnabled = true;			// 是否允许日志记录

//        #region Public Property
//        /// <summary>
//        /// 
//        /// </summary>
//        public DataTable this[string a]
//        {
//            get
//            {
//                return null;
//            }
//        }

//        /// <summary>
//        /// 存放当前日志文件的文件夹绝对路径
//        /// </summary>
//        public string logFolderPath
//        {
//            get { return _logFolderPath; }
//        }

//        /// <summary>
//        /// 当前日志文件的绝对路径
//        /// </summary>
//        public string logFilePath
//        {
//            get { return _logFilePath; }
//        }

//        /// <summary>
//        /// 判断是否存在当前日志文件
//        /// </summary>
//        public bool IsLogExist
//        {
//            get
//            {
//                return FObject.IsExist(this._logFilePath, FsoMethod.File);
//            }
//        }

//        /// <summary>
//        /// 是否允许日志记录
//        /// </summary>
//        public bool IsEnabled
//        {
//            get { return _IsEnabled; }
//            set { _IsEnabled = value; }
//        }
//        #endregion


//        #region Public Method
//        /// <summary>
//        /// 创建当前日志文件
//        /// </summary>
//        public void CreateLog()
//        {
//            if (!this.IsEnabled) return;

//            if (!this.IsLogExist)//是否已经存在
//            {
//                OperateXml oXml = new OperateXml(this._logFilePath);

//                oXml.CreateXml("logInfo");
//            }
//        }


//        /// <summary>
//        /// 将日志信息写入日志文件中
//        /// </summary>
//        /// <param name="Title">日志标题</param>
//        /// <param name="UserID">操作人ID</param>
//        /// <param name="type">日志记录类型</param>
//        public void Write(string Title, string UserID, LogType type)
//        {
//            if (!this.IsEnabled) return;

//            try
//            {
//                OperateXml oxml = new OperateXml();
//                oxml.filePath = this._logFilePath;
//                oxml.xPath = "logInfo";

//                DataTable dt = new DataTable();
//                DataRow dr;
//                dt.Columns.Add("@ID");
//                dt.Columns.Add("@UserID");
//                dt.Columns.Add("@UserIP");
//                dt.Columns.Add("@Addtime");
//                dt.Columns.Add("@LogType");
//                dt.Columns.Add("Title");
//                dt.Columns.Add("Message");

//                dr = dt.NewRow();
//                dr["@ID"] = Guid.NewGuid().ToString();
//                dr["@UserID"] = UserID;
//                dr["@UserIP"] = System.Web.HttpContext.Current.Request.UserHostAddress;
//                dr["@Addtime"] = DateTime.Now.ToString();
//                dr["@LogType"] = type;
//                dr["Title"] = Title;
//                dr["Message"] = "";
//                dt.Rows.Add(dr);

//                oxml.CreateNode("log", dt);
//            }
//            catch (System.IO.DirectoryNotFoundException)
//            {
//                throw new Exception("日志源“" + this._logFilePath + "”不存在，请用 CreateLog 先创建");
//            }
//            catch (System.IO.FileNotFoundException)
//            {
//                throw new Exception("日志源“" + this._logFilePath + "”不存在，请用 CreateLog 先创建");
//            }
//        }


//        /// <summary>
//        /// 将日志信息写入日志文件中
//        /// </summary>
//        /// <param name="Title">日志标题</param>
//        /// <param name="UserIP">操作人的IP地址</param>
//        /// <param name="UserID">操作人ID</param>
//        /// <param name="type">日志记录类型</param>
//        public void Write(string Title, string UserIP, string UserID, LogType type)
//        {
//            if (!this.IsEnabled) return;

//            try
//            {
//                OperateXml oxml = new OperateXml();
//                oxml.filePath = this._logFilePath;
//                oxml.xPath = "logInfo";

//                DataTable dt = new DataTable();
//                DataRow dr;
//                dt.Columns.Add("@ID");
//                dt.Columns.Add("@UserID");
//                dt.Columns.Add("@UserIP");
//                dt.Columns.Add("@Addtime");
//                dt.Columns.Add("@LogType");
//                dt.Columns.Add("Title");
//                dt.Columns.Add("Message");

//                dr = dt.NewRow();
//                dr["@ID"] = Guid.NewGuid().ToString();
//                dr["@UserID"] = UserID;
//                dr["@UserIP"] = UserIP;
//                dr["@Addtime"] = DateTime.Now.ToString();
//                dr["@LogType"] = type;
//                dr["Title"] = Title;
//                dr["Message"] = "";
//                dt.Rows.Add(dr);

//                oxml.CreateNode("log", dt);
//            }
//            catch (System.IO.DirectoryNotFoundException)
//            {
//                throw new Exception("日志源“" + this._logFilePath + "”不存在，请用 CreateLog 先创建");
//            }
//            catch (System.IO.FileNotFoundException)
//            {
//                throw new Exception("日志源“" + this._logFilePath + "”不存在，请用 CreateLog 先创建");
//            }
//        }

//        /// <summary>
//        /// 将日志信息写入日志文件中
//        /// </summary>
//        /// <param name="Title">日志标题</param>
//        /// <param name="Message">日志详细文本</param>
//        /// <param name="UserIP">操作人的IP地址</param>
//        /// <param name="UserID">操作人ID</param>
//        /// <param name="type">日志记录类型</param>
//        public void Write(string Title, string Message, string UserIP, string UserID, LogType type)
//        {
//            if (!this.IsEnabled) return;

//            try
//            {
//                OperateXml oxml = new OperateXml();
//                oxml.filePath = this._logFilePath;
//                oxml.xPath = "logInfo";

//                DataTable dt = new DataTable();
//                DataRow dr;
//                dt.Columns.Add("@ID");
//                dt.Columns.Add("@UserID");
//                dt.Columns.Add("@UserIP");
//                dt.Columns.Add("@Addtime");
//                dt.Columns.Add("@LogType");
//                dt.Columns.Add("Title");
//                dt.Columns.Add("Message");

//                dr = dt.NewRow();
//                dr["@ID"] = Guid.NewGuid().ToString();
//                dr["@UserID"] = UserID;
//                dr["@UserIP"] = UserIP;
//                dr["@Addtime"] = DateTime.Now.ToString();
//                dr["@LogType"] = type;
//                dr["Title"] = Title;

//                dr["Message"] = stCommon.Strings.cConvert.convertXmlString(Message);
//                dt.Rows.Add(dr);

//                oxml.CreateNode("log", dt);
//            }
//            catch (System.IO.DirectoryNotFoundException)
//            {
//                throw new Exception("日志源“" + this._logFilePath + "”不存在，请用 CreateLog 先创建");
//            }
//            catch (System.IO.FileNotFoundException)
//            {
//                throw new Exception("日志源“" + this._logFilePath + "”不存在，请用 CreateLog 先创建");
//            }
//            SendReport(Title, Message);
//        }
//        private void SendReport(string sTitle, string msg)
//        {
//            msg = msg + ",具体请查看日志文件";
//            sTitle = "一家发生错误了时间:" + DateTime.Now.ToString();
//            //SendMail mail = new SendMail("369913836@qq.com", "cqs263@163.com", msg, sTitle, "cqs82313333");
//            //mail.Send();
//        }
//        //private void SendCompleted(SendCompletedEventHandler tg)
//        //{

//        //}
//        /// <summary>
//        /// 从当前日志文件中删除指定的日志信息
//        /// </summary>
//        /// <param name="LogID"></param>
//        public void Remove(string LogID)
//        {
//        }

//        /// <summary>
//        /// 移除指定的日志
//        /// </summary>
//        public void RemoveAll()
//        {
//            FObject.Delete(this._logFilePath, FsoMethod.File);
//        }
//        #endregion
//    }
//}
