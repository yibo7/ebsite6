using System;
using System.Web;
using EbSite.Base.Entity;
using EbSite.Core.FSO;

namespace EbSite.Modules.BBS.ModuleCore.BLL
{
    //以下只作xml操作数据演示

    #region xml操作演示业务类
        public class WebSiteXmlDemo : EbSite.Base.Datastore.XMLProviderBase<WebSiteXmlInfo>
        {
            public static readonly WebSiteXmlDemo Instance = new WebSiteXmlDemo();
            /// <summary>
            /// 重写菜单的保存路径-绝对
            /// </summary>
            public override string SavePath
            {
                get
                {
                    return HttpContext.Current.Server.MapPath(SettingInfo.Instance.GetBaseConfig.Instance.ModulePath + "datastore/WebSiteInfo/");
                }
            }
            private WebSiteXmlDemo()
            {


                if (!FObject.IsExist(SavePath, FsoMethod.Folder))
                {
                    FObject.Create(SavePath, FsoMethod.Folder);
                }
            }
        }
    #endregion
    

    #region xml操作演示实体类

    /// <summary>
    /// 实体类Website 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class WebSiteXmlInfo : XmlEntityBase<Guid>
    {

        private string _webname;
        private string _url;
        private string _weblog;
        private bool _isauditing;

        /// <summary>
        /// 网站名称
        /// </summary>
        public string WebName
        {
            set { _webname = value; }
            get { return _webname; }
        }
        /// <summary>
        /// 连接地址 不带http://
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 上传的logo文件相对路径
        /// </summary>
        public string WebLog
        {
            set { _weblog = value; }
            get { return _weblog; }
        }
        /// <summary>
        /// 是否已经通过审核
        /// </summary>
        public bool IsAuditing
        {
            set { _isauditing = value; }
            get { return _isauditing; }
        }

    }

    #endregion

}