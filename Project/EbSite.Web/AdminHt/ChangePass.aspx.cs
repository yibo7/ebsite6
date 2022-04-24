using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.BLL.User;

namespace EbSite.Web.AdminHt
{
    public partial class ChangePass : EbSite.Base.Page.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ucPageTags.Title = "修改密码";
            if (!IsHaveLimit("315"))//325北 305 系
            {
                Tips("没有访问权限","您访问的页面没有可用权限！");
            }
            
        }
        

        protected void OnClick(object sender, EventArgs e)
        {
            string sVUserName = UserName;
            string sOldPass = txtOldPass.Text.Trim();
            string sNewPass = txtPassWord.Text.Trim();
            string sComfirPass = txtCfPassWord.Text.Trim();
            if (!string.IsNullOrEmpty(sNewPass) && !string.IsNullOrEmpty(sComfirPass) && !string.IsNullOrEmpty(sOldPass))
            {
                if (sNewPass.Equals(sComfirPass))
                {
                    MembershipUser mu = Membership.GetUser(sVUserName);
                    sOldPass = UserIdentity.PassWordEncode(sOldPass);
                    bool ischanged = mu.ChangePassword(sOldPass, sNewPass);
                    if (!ischanged)
                    {
                        Tips("失败", "密码修改失败,请联系管理员!");
                    }
                    else
                    {
                        Tips("密码修改成功", "密码修改成功,请牢记已经修改过的密码!","");
                    }

                }
                else
                {
                    Tips("两次输入密码不相等", "请确认密码!");
                }
            }
            else
            {
                Tips("密码不能为空", "请输入新密码与确认新密码!");
            }
        }
    }
}