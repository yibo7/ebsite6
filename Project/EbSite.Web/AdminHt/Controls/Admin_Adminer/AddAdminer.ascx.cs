using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.Core;

namespace EbSite.Web.AdminHt.Controls.Admin_Adminer
{
    public partial class AddAdminer : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "181";
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

            string username = txtUserName.Text.Trim();
            string password = PassWord.Text.Trim();
            string cfpassword = CfPassWord.Text.Trim();
            string email = Email.Text.Trim();
            //AplicationGlobal.RegUser(username, password, cfpassword, email, true, -1);
            string Ip = EbSite.Core.Utils.GetClientIP();
            EbSite.Base.Host.Instance.RegUser(username, password, cfpassword, email, true, -1, true, Ip,"后台添加管理员时注册");
            

        }

        //protected void btnAddUser_Click(object sender, EventArgs e)
        //{
        //    string username = UserName.Text.Trim();
        //    string password = PassWord.Text.Trim();
        //    string cfpassword = CfPassWord.Text.Trim();
        //    string email = Email.Text.Trim();
        //    AplicationGlobal.RegUser(username, password, cfpassword, email,true,-1);
        //    Response.Redirect(Request.RawUrl);
        //}

    }
}