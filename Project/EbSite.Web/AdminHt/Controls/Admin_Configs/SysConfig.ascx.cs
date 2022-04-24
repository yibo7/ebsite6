using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.BLL.GetLink;

using EbSite.BLL.GetLink;
using EbSite.Base.EntityAPI;
using EbSite.Base.Extension.Manager;
using EbSite.Base.Plugin;

namespace EbSite.Web.AdminHt.Controls.Admin_Configs
{
    public partial class SysConfig : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "148";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
            throw new NotImplementedException();
        }
        override protected void SaveModel()
        {
            this.SaveConfig();
        }


        protected void initConfig()
        {
           
            this.txtsMapPath.Text = ConfigsControl.Instance.sMapPath;
            this.txtsLocalhost.Text = ConfigsControl.Instance.DomainName;
            this.txtUplaodPath.Text = ConfigsControl.Instance.UploadPath;

            this.txtUplaodPath.Text = ConfigsControl.Instance.UploadPath;

            this.txtCopyright.CtrValue = ConfigsControl.Instance.Copyright;
            //this.txtAdminPath.Text = ConfigsControl.Instance.AdminPath;
            //this.txtErrLoginNum.Text = ConfigsControl.Instance.ErrLoginNum.ToString();
            this.txtUserPath.Text = ConfigsControl.Instance.UserPath;
            this.txtCookieDomain.Text = ConfigsControl.Instance.CookieDomain;
            this.rbIsCookieOrSession.SelectedValue = ConfigsControl.Instance.IsUpdateHisCookieOrSession.ToString();
            //this.cbAuditingContent.Checked = ConfigsControl.Instance.AuditingContent;
            //this.cbAuditingComment.Checked = ConfigsControl.Instance.AuditingComment;

            //this.cbIsOpenSafeCoder.Checked = ConfigsControl.Instance.IsOpenSafeCoder;
            //this.cbIsOpenSafeCoder_PL.Checked = ConfigsControl.Instance.IsOpenSafeCoder_PL;

            
            //this.cbIsOpenAppLog.Checked = ConfigsControl.Instance.IsOpenAppLog;
            //this.IsOpenAdminLoginLog.Checked = ConfigsControl.Instance.IsOpenAdminLoginLog;
            //cbIsOpen404Log.Checked = ConfigsControl.Instance.IsOpen404Log;
            this.txtIISPath.Text = ConfigsControl.Instance.IISPath;
            this.txtHitsUpdateTimeLength.Text = ConfigsControl.Instance.HitsUpdateTimeLength.ToString();
            this.txtLoginExpires.Text = ConfigsControl.Instance.LoginExpires.ToString();

            //this.rblCacheModel.SelectedValue = ConfigsControl.Instance.CacheModel.ToString();

            this.ddlCulture.SelectedValue = ConfigsControl.Instance.Culture;
            this.cbIsOpenSql.Checked = ConfigsControl.Instance.IsOpenSql;
            cbDelModuleAndFile.Checked = ConfigsControl.Instance.DelModuleAndFile;
            //txtPassKey.Text = ConfigsControl.Instance.EncryptionKey;

            cbIsErrFriend.Checked = ConfigsControl.Instance.IsErrFriend;
            
            cbIsOpenGzip.Checked = ConfigsControl.Instance.EnableHttpCompression;
            rblEnableCssCompression.SelectedValue = ConfigsControl.Instance.EnableCssCompression.ToString();
            rblEnableJsCompression.SelectedValue = ConfigsControl.Instance.EnableJsCompression.ToString();
            cbIsCacheJsCss.Checked = ConfigsControl.Instance.IsCacheJsCss;

            cblIsOpenUserHome.Checked = ConfigsControl.Instance.IsOpenUserHome;

            cbIsOpenFileServer.Checked = ConfigsControl.Instance.IsOpenFileServer;
            txtFileServerUrl.Text = ConfigsControl.Instance.FileServerUrl;

            List<ManagedExtension> lstRz1 = PluginManager.Instance.GetPluginInfoByType("ISearchEngine", 1);

            drpSearchEngine.DataTextField = "Description";
            drpSearchEngine.DataValueField = "Name";
            drpSearchEngine.DataSource = lstRz1;
            drpSearchEngine.DataBind();

            drpSearchEngine.SelectedValue = ConfigsControl.Instance.GetSearchEngineType(GetSiteID);

            //cbIsEndDataBaseStr.Checked = ConfigsControl.Instance.IsEndDataBaseStr;


            List<ManagedExtension> lstRz2 = PluginManager.Instance.GetPluginInfoByType("IIPToArea", 1);
            drpIpToArea.DataTextField = "Description";
            drpIpToArea.DataValueField = "Name";
            drpIpToArea.DataSource = lstRz2;
            drpIpToArea.DataBind();

            drpIpToArea.SelectedValue = ConfigsControl.Instance.IpToAreaPluginName;


            List<ManagedExtension> lstRz3 = PluginManager.Instance.GetPluginInfoByType("IDelivery", 1);
            drpKuaiDi.DataTextField = "Description";
            drpKuaiDi.DataValueField = "Name";
            drpKuaiDi.DataSource = lstRz3;
            drpKuaiDi.DataBind();
            drpKuaiDi.SelectedValue = ConfigsControl.Instance.KuaiDiPluginName;

            //ViewState["IsEndDataBaseStr"] = cbIsEndDataBaseStr.Checked;


            List<ManagedExtension> lstRz4 = PluginManager.Instance.GetPluginInfoByType("ICache", 1);
            drpCacheBll.DataTextField = "Description";
            drpCacheBll.DataValueField = "Name";
            drpCacheBll.DataSource = lstRz4;
            drpCacheBll.DataBind();
            drpCacheBll.SelectedValue = ConfigsControl.Instance.CacheBll;


            //List<ManagedExtension> lstRz5 = PluginManager.Instance.GetPluginInfoByType("IEmailManager", 1);
            //drpEmailSendPlugin.DataTextField = "Description";
            //drpEmailSendPlugin.DataValueField = "Name";
            //drpEmailSendPlugin.DataSource = lstRz5;
            //drpEmailSendPlugin.DataBind();
            //drpEmailSendPlugin.SelectedValue = ConfigsControl.Instance.EmailSendPlugin;


            List<ManagedExtension> lstRz6 = PluginManager.Instance.GetPluginInfoByType("IMobileSend", 1);
            drpMobileMsgSendPlugin.DataTextField = "Description";
            drpMobileMsgSendPlugin.DataValueField = "Name";
            drpMobileMsgSendPlugin.DataSource = lstRz6;
            drpMobileMsgSendPlugin.DataBind();
            drpMobileMsgSendPlugin.SelectedValue = ConfigsControl.Instance.MobileMsgSendPlugin;

            

            cbIsMobileRedirect.Checked = ConfigsControl.Instance.IsMobileRedirect;

            IsAutoUpdateDomain.Checked = ConfigsControl.Instance.IsAutoUpdateDomain;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                var path = Server.MapPath(string.Format("{0}App_GlobalResources/", Base.AppStartInit.IISPath));
                foreach (var file in Directory.GetFiles(path, "lang.*.resx"))
                {
                    var index = file.LastIndexOf(Path.DirectorySeparatorChar) + 1;
                    var filename = file.Substring(index);
                    filename = filename.Replace("lang.", string.Empty).Replace(".resx", string.Empty);
                    var info = CultureInfo.GetCultureInfoByIetfLanguageTag(filename);
                    ddlCulture.Items.Add(new ListItem(info.NativeName, filename));
                }

                this.initConfig();

            }
        }

        protected void SaveConfig()
        {

            ConfigsControl.Instance.UploadPath = this.txtUplaodPath.Text.Trim();
            ConfigsControl.Instance.Copyright = this.txtCopyright.CtrValue;
            //ConfigsControl.Instance.AdminPath = this.txtAdminPath.Text.Trim();
            //ConfigsControl.Instance.ErrLoginNum = int.Parse(this.txtErrLoginNum.Text);
            ConfigsControl.Instance.UserPath = this.txtUserPath.Text.Trim();
            ConfigsControl.Instance.CookieDomain = this.txtCookieDomain.Text.Trim();
            ConfigsControl.Instance.IsUpdateHisCookieOrSession = int.Parse(this.rbIsCookieOrSession.SelectedValue);
            //ConfigsControl.Instance.AuditingContent = this.cbAuditingContent.Checked;
            //ConfigsControl.Instance.AuditingComment = this.cbAuditingComment.Checked;
            //ConfigsControl.Instance.IsOpenSafeCoder = this.cbIsOpenSafeCoder.Checked;
            //ConfigsControl.Instance.IsOpenSafeCoder_PL = this.cbIsOpenSafeCoder_PL.Checked;

            
            ConfigsControl.Instance.IISPath = this.txtIISPath.Text;
            //ConfigsControl.Instance.IsOpenAppLog = this.cbIsOpenAppLog.Checked;
            //ConfigsControl.Instance.IsOpenAdminLoginLog = this.IsOpenAdminLoginLog.Checked;
            //ConfigsControl.Instance.IsOpen404Log = cbIsOpen404Log.Checked;
            ConfigsControl.Instance.HitsUpdateTimeLength = int.Parse(this.txtHitsUpdateTimeLength.Text);
            ConfigsControl.Instance.LoginExpires = int.Parse(this.txtLoginExpires.Text.Trim());
            
            ConfigsControl.Instance.DomainName = this.txtsLocalhost.Text;
            
            ConfigsControl.Instance.sMapPath = this.txtsMapPath.Text;

            ConfigsControl.Instance.Culture = this.ddlCulture.SelectedValue;
            ConfigsControl.Instance.IsOpenSql = this.cbIsOpenSql.Checked;

            ConfigsControl.Instance.IsErrFriend = cbIsErrFriend.Checked;
            ConfigsControl.Instance.DelModuleAndFile = cbDelModuleAndFile.Checked;
            //ConfigsControl.Instance.EncryptionKey = txtPassKey.Text;
            

            ConfigsControl.Instance.EnableHttpCompression = cbIsOpenGzip.Checked;
            ConfigsControl.Instance.EnableCssCompression = int.Parse(rblEnableCssCompression.SelectedValue);
            ConfigsControl.Instance.EnableJsCompression = int.Parse(rblEnableJsCompression.SelectedValue);
            ConfigsControl.Instance.IsCacheJsCss = cbIsCacheJsCss.Checked;

            ListItemSimple md = new ListItemSimple(drpSearchEngine.SelectedValue, GetSiteID.ToString());
            ConfigsControl.Instance.AddSearchEngine(md);


            //ConfigsControl.Instance.IsEndDataBaseStr = cbIsEndDataBaseStr.Checked;

            ConfigsControl.Instance.IpToAreaPluginName = drpIpToArea.SelectedValue;

            ConfigsControl.Instance.IsOpenUserHome = cblIsOpenUserHome.Checked;

            ConfigsControl.Instance.KuaiDiPluginName = drpKuaiDi.SelectedValue;

            ConfigsControl.Instance.CacheBll = drpCacheBll.SelectedValue;

            //ConfigsControl.Instance.EmailSendPlugin = drpEmailSendPlugin.SelectedValue;
            ConfigsControl.Instance.MobileMsgSendPlugin = drpMobileMsgSendPlugin.SelectedValue;

            ConfigsControl.Instance.IsMobileRedirect = cbIsMobileRedirect.Checked ;

            ConfigsControl.Instance.IsAutoUpdateDomain = IsAutoUpdateDomain.Checked;

            ConfigsControl.Instance.IsOpenFileServer = cbIsOpenFileServer.Checked;
            ConfigsControl.Instance.FileServerUrl = txtFileServerUrl.Text;
            //ConfigsControl.Instance.CacheModel = int.Parse(this.rblCacheModel.SelectedValue);

            //模块重写目录 和 手机目录或子域 不能相同
            if (Base.Configs.ContentSet.ConfigsControl.Instance.MPath.Trim()+"/" == ConfigsControl.Instance.UserPath.Trim())
            {
                base.TipsAlert("模块重写目录和手机目录或子域不能相同！");
            }
            else
            {
                ConfigsControl.SaveConfig();
                Core.Utils.AppRestart();
                //EbSite.Base.Host.Instance.Init(); 
                //EbSite.Base.Host.CacheApp.Clear(); 
            }
        }

        protected void btnTestMobileMsg_Click(object sender, EventArgs e)
        {
            string sNumber = txtMobileNumber.Text.Trim();

            Base.Host.Instance.SendMobileMsg("这是来自ebsite的测试短信,发送时间:"+DateTime.Now, sNumber,UserNiname);
        }
    }
}