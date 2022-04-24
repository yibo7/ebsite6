using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.SysConfigs;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.BLL.GetLink;

//using EbSite.BLL.GetLink;

namespace EbSite.Web.AdminHt.Controls.Admin_Configs
{
    public partial class Safe : UserControlBaseSave
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
            ConfigsControl.Instance.WebServiceRequestModel = int.Parse(rblRequestModel.SelectedValue);
            //ConfigsControl.Instance.WebServiceIPS = txtIPS.Text;
            if (!string.IsNullOrEmpty(ConfigsControl.Instance.WebServiceIPS))
            {

                string[] aItem = ConfigsControl.Instance.WebServiceIPS.Split('\n');
                List<string> lst = new List<string>();
                foreach (string s in aItem)
                {
                    string sv = s.Replace("\r", "").Trim();
                    lst.Add(sv);

                }
                ConfigsControl.Instance.WebServiceIPList = lst;
                
            }
            List<string> lstNoCheck = new List<string>();
            foreach (ListItem li in lblUserleva1.Items)
            {
                if (li.Selected)
                {
                    lstNoCheck.Add(li.Value);
                }
            }
            ConfigsControl.Instance.UserlevaNoCheck = lstNoCheck;

            List<string> lstUpload = new List<string>();
            foreach (ListItem li in lblUserleva2.Items)
            {
                if (li.Selected)
                {
                    lstUpload.Add(li.Value);
                }
            }
            ConfigsControl.Instance.UserlevaUpload = lstUpload;
            //ConfigsControl.Instance.WebServiceSafeCode = txtWebServiceSafeCode.Text;
            ConfigsControl.Instance.PassType = (PassWordType)int.Parse(this.rblPassType.SelectedValue);
            ConfigsControl.Instance.EncryptionKey = txtPassKey.Text;

            ConfigsControl.Instance.IsOpenAppLog = this.cbIsOpenAppLog.Checked;
            ConfigsControl.Instance.IsOpenAdminLoginLog = this.IsOpenAdminLoginLog.Checked;
            ConfigsControl.Instance.IsOpen404Log = cbIsOpen404Log.Checked;

            ConfigsControl.Instance.IsOpenSafeCoder = this.cbIsOpenSafeCoder.Checked;
            ConfigsControl.Instance.IsOpenSafeCoder_PL = this.cbIsOpenSafeCoder_PL.Checked;

            ConfigsControl.Instance.AuditingContent = this.cbAuditingContent.Checked;
            ConfigsControl.Instance.AuditingComment = this.cbAuditingComment.Checked;

            ConfigsControl.Instance.AdminPath = this.txtAdminPath.Text.Trim();
            ConfigsControl.Instance.ErrLoginNum = int.Parse(this.txtErrLoginNum.Text);

            ConfigsControl.Instance.IsEndDataBaseStr = cbIsEndDataBaseStr.Checked;
            ConfigsControl.Instance.PostTimeOut = int.Parse(txtPostTimeOut.Text);
            

            ConfigsControl.SaveConfig();


            bool IsEndDataBaseStr = bool.Parse(ViewState["IsEndDataBaseStr"].ToString());
            string EncryptionKey = ViewState["EncryptionKey"].ToString();

            if (!IsEndDataBaseStr.Equals(ConfigsControl.Instance.IsEndDataBaseStr) || !EncryptionKey.Equals(ConfigsControl.Instance.EncryptionKey))
            {

                UpdateDataConn(ConfigsControl.Instance.IsEndDataBaseStr, ConfigsControl.Instance.EncryptionKey);

                if (!EncryptionKey.Equals(ConfigsControl.Instance.EncryptionKey))
                {
                    //先退出
                    BLL.User.UserIdentity.SignOutAdmin();
                    EbSite.BLL.User.UserIdentity.SignOutUser();
                    Response.Redirect("syslogin.aspx");
                }

            }


            EbSite.Base.Host.CacheApp.Clear();// EbSite.Core.CacheManager.RemoveAllCache();


        }
        /// <summary>
        /// 加密或解密数据库连接串
        /// </summary>
        /// <param name="IsEndDataBaseStr">后台设置的是否加密数据库连接串配置</param>
        private void UpdateDataConn(bool IsEndDataBaseStr, string deskey)
        {
            
            if (IsEndDataBaseStr)
            {

                string datastrcms =
                    Core.DES.Encode(
                        EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCms, deskey);
                string datastrcmswrite =
                    Core.DES.Encode(
                        EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCmsWrite, deskey);


                string datastruser =
                    Core.DES.Encode(
                        EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysUser, deskey);
                string datastruserwrite =
                    Core.DES.Encode(
                        EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysUserWrite, deskey);


                if (!string.IsNullOrEmpty(datastrcms) && !string.IsNullOrEmpty(datastruser) && !string.IsNullOrEmpty(datastrcmswrite) && !string.IsNullOrEmpty(datastruserwrite))
                {
                    EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCms = datastrcms;
                    EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysUser =datastruser;
                    EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCmsWrite = datastrcmswrite;
                    EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysUserWrite = datastruserwrite;
                }
                Base.Configs.BaseCinfigs.ConfigsControl.SaveConfig();

            }
            else
            {
                string datastrcms =
                    Core.DES.Decode(
                        EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCms, deskey);
                string datastrcmswrite =
                    Core.DES.Decode(
                        EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCmsWrite, deskey);

                string datastruser =
                    Core.DES.Decode(
                        EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysUser, deskey);
                string datastruserwrite =
                    Core.DES.Decode(
                        EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysUserWrite, deskey);

                if (!string.IsNullOrEmpty(datastrcms) && !string.IsNullOrEmpty(datastruser))
                {
                    EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCms = datastrcms;
                    EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysUser = datastruser;

                    EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysCmsWrite = datastrcmswrite;
                    EbSite.Base.Configs.BaseCinfigs.ConfigsControl.Instance.ConnectionStringSysUserWrite = datastruserwrite;
                }

                Base.Configs.BaseCinfigs.ConfigsControl.SaveConfig();
            }
        }
       
        protected void initConfig()
        {
            rblRequestModel.SelectedValue = ConfigsControl.Instance.WebServiceRequestModel.ToString();
            foreach (ListItem li in lblUserleva1.Items)
            {
                if(ConfigsControl.Instance.UserlevaNoCheck.Contains(li.Value))
                {
                    li.Selected = true;
                }
            }
            foreach (ListItem li in lblUserleva2.Items)
            {
                if (ConfigsControl.Instance.UserlevaUpload.Contains(li.Value))
                {
                    li.Selected = true;
                }
            }

            //txtWebServiceSafeCode.Text = ConfigsControl.Instance.WebServiceSafeCode;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                lblUserleva1.DataTextField = "LevelName";
                lblUserleva1.DataValueField = "id";
                lblUserleva1.DataSource = EbSite.BLL.UserLevel.Instance.GetListArray("");
                lblUserleva1.DataBind();
                

                lblUserleva2.DataTextField = "LevelName";
                lblUserleva2.DataValueField = "id";
                lblUserleva2.DataSource = EbSite.BLL.UserLevel.Instance.GetListArray("");
                lblUserleva2.DataBind();
                this.rblPassType.SelectedValue = ((int)ConfigsControl.Instance.PassType).ToString();
                txtPassKey.Text = ConfigsControl.Instance.EncryptionKey;

                this.cbIsOpenAppLog.Checked = ConfigsControl.Instance.IsOpenAppLog;
                this.IsOpenAdminLoginLog.Checked = ConfigsControl.Instance.IsOpenAdminLoginLog;
                cbIsOpen404Log.Checked = ConfigsControl.Instance.IsOpen404Log;

                this.cbIsOpenSafeCoder.Checked = ConfigsControl.Instance.IsOpenSafeCoder;
                this.cbIsOpenSafeCoder_PL.Checked = ConfigsControl.Instance.IsOpenSafeCoder_PL;

                this.cbAuditingContent.Checked = ConfigsControl.Instance.AuditingContent;
                this.cbAuditingComment.Checked = ConfigsControl.Instance.AuditingComment;

                this.txtAdminPath.Text = ConfigsControl.Instance.AdminPath;
                this.txtErrLoginNum.Text = ConfigsControl.Instance.ErrLoginNum.ToString();

                cbIsEndDataBaseStr.Checked = ConfigsControl.Instance.IsEndDataBaseStr;

                txtPostTimeOut.Text = ConfigsControl.Instance.PostTimeOut.ToString();

                ViewState["IsEndDataBaseStr"] = cbIsEndDataBaseStr.Checked;


                ViewState["EncryptionKey"] = ConfigsControl.Instance.EncryptionKey;

                this.initConfig();
                
            }
        }

        protected void rblRequestModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(rblRequestModel.SelectedValue=="3")
            //{
            //    txtIPS.Visible = true;
            //}
            //else
            //{
            //    txtIPS.Visible = false;
            //}
        }

       
    }
}