using System;
using System.Collections.Generic;
using EbSite.Base.Configs.EmailSend;
using EbSite.Base.ControlPage;
using EbSite.BLL.Email;
using EbSite.Base.Plugin;
using EbSite.Base.Extension.Manager;

namespace EbSite.Web.AdminHt.Controls.Admin_Configs
{
    public partial class EmailConfig : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "157";
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
            ConfigsControl.Instance.emailfrom = this.emailfrom.Text;
            ConfigsControl.Instance.emailuserName = this.emailuserName.Text;
            ConfigsControl.Instance.emailuserpwd = this.emailuserpwd.Text;
            //ConfigsControl.Instance.emaildll = this.emaildll.Text;
            ConfigsControl.Instance.smtpserver = this.smtpserver.Text;

            ConfigsControl.Instance.SynNum = int.Parse(this.SynNum.Text);
            ConfigsControl.Instance.iTimeSpan = int.Parse(iTimeSpan.Text);
            ConfigsControl.Instance.Port = int.Parse(txtPort.Text);
            ConfigsControl.Instance.EnableSsl = cbIsOpenSSL.Checked;
            ConfigsControl.SaveConfig();

            EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.EmailSendPlugin = drpEmailSendPlugin.SelectedValue;
            EbSite.Base.Configs.SysConfigs.ConfigsControl.SaveConfig();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.emailfrom.Text = ConfigsControl.Instance.emailfrom;
                this.emailuserName.Text = ConfigsControl.Instance.emailuserName;
                this.emailuserpwd.Text = ConfigsControl.Instance.emailuserpwd;
                smtpserver.Text = ConfigsControl.Instance.smtpserver;
                //this.emaildll.Text = ConfigsControl.Instance.emaildll;
                this.SynNum.Text = ConfigsControl.Instance.SynNum.ToString();
                this.iTimeSpan.Text = ConfigsControl.Instance.iTimeSpan.ToString();
                txtPort.Text = ConfigsControl.Instance.Port.ToString();
                cbIsOpenSSL.Checked = ConfigsControl.Instance.EnableSsl;

                List<ManagedExtension> lstRz5 = PluginManager.Instance.GetPluginInfoByType("IEmailManager", 1);
                drpEmailSendPlugin.DataTextField = "Description";
                drpEmailSendPlugin.DataValueField = "Name";
                drpEmailSendPlugin.DataSource = lstRz5;
                drpEmailSendPlugin.DataBind();
                drpEmailSendPlugin.SelectedValue = EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.EmailSendPlugin;
            }
        }

        protected void btnTestEmail_Click(object sender, EventArgs e)
        {
            IEmailManager[] lst = Collectors.UseIEmailManagerCollector.AllProviders;
            if (lst.Length > 0)
            {
                string sContent = "欢迎使用EbSite网站管理系统，恭喜，您在EbSite的邮件设置成功，更多请访问我们的网站 <a href='http://www.ebsite.net'>http://www.ebsite.net</a>！";
                EmailBLL.SendEmail(txtTestEmail.Text.Trim(), "这是一份来自EbSite的测试邮件！", sContent);
            }
            else
            {
                Tips("找不到Email处理程序", "还没有安装Email发送插件，或者已经安装但没启用！");
            }
           
        }

        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    ConfigsControl.Instance.emailfrom = this.emailfrom.Text;
        //    ConfigsControl.Instance.emailuserName = this.emailuserName.Text;
        //    ConfigsControl.Instance.emailuserpwd = this.emailuserpwd.Text;
        //    ConfigsControl.Instance.emaildll = this.emaildll.Text;
        //    ConfigsControl.Instance.smtpserver = this.smtpserver.Text;

        //    ConfigsControl.Instance.SynNum = int.Parse(this.SynNum.Text);
        //    ConfigsControl.Instance.iTimeSpan = int.Parse(iTimeSpan.Text);
            
        //    ConfigsControl.SaveConfig();

        //}
    }
}