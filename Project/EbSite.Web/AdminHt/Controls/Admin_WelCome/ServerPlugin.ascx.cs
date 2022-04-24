using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_WelCome
{
    public partial class ServerPlugin : Base
    {
        public override string Permission
        {
            get
            {
                return "313";
            }
        }
        protected void chkzujian(Object Sender, EventArgs e)
        {
            string obj = zujian.Text;
            if (chkobj(obj))
            {
                serchinfo.Text = "支持" + obj;
            }
            else
            {
                serchinfo.Text = "不支持" + obj;
            }
        }
        //组件支持验证代码

        bool chkobj(string obj)
        {
            try
            {
                object meobj = Server.CreateObject(obj);
                return (true);
            }
            catch (Exception objex)
            {
                return (false);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                if (chkobj("ADODB.RecordSet"))
                {
                    serveraccess.Text = "支持";
                }
                else
                {
                    serveraccess.Text = "不支持";
                }

                if (chkobj("Scripting.FileSystemObject"))
                {
                    serverfso.Text = "支持";
                }
                else
                {
                    serverfso.Text = "不支持";
                }

                if (chkobj("CDONTS.NewMail"))
                {
                    servercdonts.Text = "支持";
                }
                else
                {
                    servercdonts.Text = "不支持";
                }


                //0.1版添加的组件验证，原有组件并未转移过来，请原谅。 
                if (chkobj("JMail.SmtpMail"))
                {
                    jmail.Text = "支持";
                }
                else
                {
                    jmail.Text = "不支持";
                }

                if (chkobj("Persits.MailSender"))
                {
                    aspemail.Text = "支持";
                }
                else
                {
                    aspemail.Text = "不支持";
                }

                if (chkobj("Geocel.Mailer"))
                {
                    geocel.Text = "支持";
                }
                else
                {
                    geocel.Text = "不支持";
                }

                if (chkobj("SmtpMail.SmtpMail.1"))
                {
                    smtpmail.Text = "支持";
                }
                else
                {
                    smtpmail.Text = "不支持";
                }

                if (chkobj("Persits.Upload.1"))
                {
                    aspup.Text = "支持";
                }
                else
                {
                    aspup.Text = "不支持";
                }



                if (chkobj("SoftArtisans.FileManager"))
                {
                    soft.Text = "支持";
                }
                else
                {
                    soft.Text = "不支持";
                }

                if (chkobj("w3.upload"))
                {
                    dimac.Text = "支持";
                }
                else
                {
                    dimac.Text = "不支持";
                }

                if (chkobj("W3Image.Image"))
                {
                    dimacimage.Text = "支持";
                }
                else
                {
                    dimacimage.Text = "不支持";
                }
            }
        }
    }
}