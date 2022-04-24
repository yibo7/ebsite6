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
using EbSite.BLL.User;
using EbSite.Core;

namespace EbSite.Web.AdminHt.Controls.Admin_Member
{
    public partial class AddMember : UserControlBaseSave
    {

        public override string Permission
        {
            get
            {
                return "76";
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
            //AplicationGlobal.RegUser(username, password, cfpassword, email, false, -1);  

            string sIP = Core.Utils.GetClientIP();

            EbSite.Base.Host.Instance.RegUser(username, password, cfpassword, email, false, -1, true, sIP,"后台直接添加用户");


        }

        //protected void Page_Load(object sender, EventArgs e)
        //{
            
        //}

        //protected void btnAddUser_Click(object sender, EventArgs e)
        //{
        //    string username = UserName.Text.Trim();
        //    string password = PassWord.Text.Trim();
        //    string cfpassword = CfPassWord.Text.Trim();
        //    string email = Email.Text.Trim();
        //    AplicationGlobal.RegUser(username, password, cfpassword, email,false,-1);  
        //    Response.Redirect(Request.RawUrl);

            

        //}
    }
}