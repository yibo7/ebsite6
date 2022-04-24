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
using Amib.Threading;
using EbSite.Base;
using EbSite.Base.ControlPage;
using EbSite.BLL.Email;

namespace EbSite.Web.AdminHt.Controls.Admin_Member
{
    public partial class SendMessage : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void rdoSendTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoSendTo.SelectedValue == "1") //用户组
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
            string sMsg = txtMsg.Text.Trim();
            if (!string.IsNullOrEmpty(sMsg))
            {
                if (rdoSendTo.SelectedValue == "1") //用户组
                {
                    List<string> lst = new List<string>();
                    foreach (ListItem li in cbReceiverGroupList.Items)
                    {
                        if (li.Selected)
                        {
                            lst.Add(li.Value);
                        }
                    }

                    foreach (var GroupName in lst)
                    {

                        string[] UsersOfGroup = Roles.GetUsersInRole(GroupName);

                        foreach (string sUserName in UsersOfGroup)
                        {
                            var us = BLL.User.MembershipUserEb.Instance.GetEntity(sUserName);
                            HostApi.SendMobileMsgToPool(us.MobileNumber, sMsg);
                        }

                    }

                }
                else
                {
                    string NumberList = this.txtReceiverUserList.Text.Trim();

                    if (!string.IsNullOrEmpty(NumberList))
                    {
                        string[] aNumberOrUserName = Core.Strings.GetString.GetArrByWrap(NumberList);

                        if (rdoSendTo.SelectedValue == "0") //用户
                        {
                            foreach (var username in aNumberOrUserName)
                            {
                                var us = BLL.User.MembershipUserEb.Instance.GetEntity(username);
                                HostApi.SendMobileMsgToPool(us.MobileNumber, sMsg);
                            }

                        }
                        else //手机号
                        {
                            foreach (var sMobileNumber in aNumberOrUserName)
                            {
                                HostApi.SendMobileMsgToPool(sMobileNumber, sMsg);
                            }
                        }
                    }

                }
            }
            else
            {
                TipsAlert("短信内容不能为空！");
            }
            

        }


    }
}