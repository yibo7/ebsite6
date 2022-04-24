using System;
using System.Web;
using EbSite.Base.Entity;
using EbSite.Core.FSO;

namespace EbSite.Modules.BBS.ModuleCore.BLL
{
    //����ֻ��xml����������ʾ

    #region xml������ʾҵ����
        public class WebSiteXmlDemo : EbSite.Base.Datastore.XMLProviderBase<WebSiteXmlInfo>
        {
            public static readonly WebSiteXmlDemo Instance = new WebSiteXmlDemo();
            /// <summary>
            /// ��д�˵��ı���·��-����
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
    

    #region xml������ʾʵ����

    /// <summary>
    /// ʵ����Website ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class WebSiteXmlInfo : XmlEntityBase<Guid>
    {

        private string _webname;
        private string _url;
        private string _weblog;
        private bool _isauditing;

        /// <summary>
        /// ��վ����
        /// </summary>
        public string WebName
        {
            set { _webname = value; }
            get { return _webname; }
        }
        /// <summary>
        /// ���ӵ�ַ ����http://
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// �ϴ���logo�ļ����·��
        /// </summary>
        public string WebLog
        {
            set { _weblog = value; }
            get { return _weblog; }
        }
        /// <summary>
        /// �Ƿ��Ѿ�ͨ�����
        /// </summary>
        public bool IsAuditing
        {
            set { _isauditing = value; }
            get { return _isauditing; }
        }

    }

    #endregion

}