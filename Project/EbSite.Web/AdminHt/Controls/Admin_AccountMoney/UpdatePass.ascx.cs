using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL.User;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_AccountMoney
{
    public partial class UpdatePass : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "262";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }

        /// <summary>
        /// 可用余额
        /// </summary>
        public string UserMoney
        {
            get
            {
                string imoney = Request.QueryString["um"];
                return imoney;
            }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get
            {
                string uname = "";

                if (Uid > 0)
                {
                    uname = EbSite.Base.Host.Instance.GetUserUserName(Uid);
                }
                return uname;
            }
        }

        protected int Uid
        {
            get
            {
                int iUID = 0;
                if (!string.IsNullOrEmpty(Request.QueryString["uid"]))
                {
                    iUID = Convert.ToInt32(Request.QueryString["uid"]);
                }
                return iUID;
            }
        }
        override protected void InitModifyCtr()
        {
        }
        override protected void SaveModel()
        {
            string sNewPass = txtPassWord.Text.Trim();
            string sComfirPass = txtCfPassWord.Text.Trim();

            if (!string.IsNullOrEmpty(sNewPass) && !string.IsNullOrEmpty(sComfirPass))
            {
                if (sNewPass.Equals(sComfirPass))
                {
                    Entity.PayPass payModel = BLL.PayPass.Instance.GetEntity(Uid);


                    if (!Equals(payModel, null))
                    {
                        sNewPass = UserIdentity.PassWordEncode(sNewPass);
                        payModel.Pass = sNewPass;
                        payModel.Update();
                        TipsAlert("修改成功。");
                    }
                    else
                    {
                        base.TipsAlert("密码修改失败,请联系管理员!");
                    }
                }
                else
                {
                    TipsAlert("两次输入密码不相等,请确认密码!");
                }
            }
            else
            {
                TipsAlert("密码不能为空,请输入新密码与确认新密码!");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lbUName.Text = UserName;

            }
        }
    }
}