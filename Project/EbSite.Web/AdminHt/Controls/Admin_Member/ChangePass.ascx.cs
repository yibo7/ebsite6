using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Member
{
    public partial class ChangePass : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "315";//北326 系307
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



        }

        override protected void SaveModel()
        {
            string sVUserName = UName;

            string sNewPass = PassWord.Text.Trim();
            string sComfirPass = CfPassWord.Text.Trim();
            if (!string.IsNullOrEmpty(sNewPass) && !string.IsNullOrEmpty(sComfirPass) )
            {
                if (sNewPass.Equals(sComfirPass))
                {
                    bool ischanged = EbSite.BLL.User.MembershipUserEb.Instance.ChangeUserPass(sVUserName, sNewPass);
                    if (!ischanged)
                    {
                        Tips("失败", "密码修改失败,请联系管理员!");
                    }
                    else
                    {
                        Tips("密码修改成功", "密码修改成功,请牢记已经修改过的密码!", "");
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
        public string UName
        {
            get { return Request.QueryString["u"]; }
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}