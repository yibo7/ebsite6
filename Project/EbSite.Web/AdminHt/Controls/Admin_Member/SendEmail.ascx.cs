using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EbSite.Base.ControlPage;
using EbSite.BLL.Email;

namespace EbSite.Web.AdminHt.Controls.Admin_Member
{
    public partial class SendEmail : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void rdoSendTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rdoSendTo.SelectedValue=="1") //用户组
            {
                txtReceiverUserList.Visible = false;
                cbReceiverGroupList.Visible = true;

                cbReceiverGroupList.DataSource = Roles.GetAllRoles();
                cbReceiverGroupList.DataBind();
            }
            else  //一个用户
            {
                txtReceiverUserList.Visible = true;
                cbReceiverGroupList.Visible = false;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            List<string> lst = new List<string>();
            if(rdoSendTo.SelectedValue=="1") //用户组
            {
                foreach (ListItem li in cbReceiverGroupList.Items)
                {
                    if(li.Selected)
                    {
                        lst.Add(li.Value);
                    }
                }

                EmailBLL.SendEmailOfGroupsList(lst,this.txtEmailTitle.Text,this.ebMailContent.Text);
            }
            else
            {
                string EmailList = this.txtReceiverUserList.Text.Trim();

                if(EmailList.IndexOf(",")>0)
                {
                    string[] al = EmailList.Split(',');

                    foreach (string s in al)
                    {
                        lst.Add(s);
                    }
                }
                else
                {
                    lst.Add(EmailList);
                }
                if (rdoSendTo.SelectedValue == "0") 
                {
                    EmailBLL.SendEmailOfUserList(lst, this.txtEmailTitle.Text, this.ebMailContent.Text);
                }
                else
                {
                    EmailBLL.SendEmailOfEmailList(lst, this.txtEmailTitle.Text, this.ebMailContent.Text);
                }
                
                
            }
            
        }
    }
}