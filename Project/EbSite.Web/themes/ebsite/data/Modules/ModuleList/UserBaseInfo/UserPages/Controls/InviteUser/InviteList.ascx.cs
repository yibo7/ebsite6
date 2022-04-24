using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Base.Plugin;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.InviteUser
{
    public partial class InviteList : MPUCBaseListForUserRp
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
             if(!IsPostBack)
             {
                 if(string.IsNullOrEmpty(GetApiName))
                 {
                     IUserLoginApi[] lst = Collectors.UseIUserLoginApiCollector.AllProviders;
                     if (lst.Length > 0)
                     {

                         Response.Redirect(string.Concat(Request.RawUrl, "?api=", lst[0].ApiName));
                     }
                     else
                     {
                         Tips("您还没有配置第三方登录插件", "您还没有配置第三方登录插件,请安装第三方登录插件！");
                     }
                 }

             }
             pcPage.OtherPram = string.Format("api,{0}", GetApiName);
        }
        public override string TipsText
        {
            get
            {
                return "每邀请成功1位好友，获得1次抽奖机会（查看奖品），满10位还能兑换10Q币";

            }
        }
        //override public bool IsCloseTagsTitle
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}
        protected string GetApiName
        {
            get
            {
                return Request["api"];
                //return "QQ";
            }
        }

        protected string GetToken
        {
            get
            {
                if(!string.IsNullOrEmpty(GetApiName))
                {
                    EbSite.Entity.TheThirdLoginCode model = EbSite.BLL.TheThirdLoginCode.Instance.GetEntity(base.UserID.ToString(), GetApiName.ToLower());
                    if (model != null && !string.IsNullOrEmpty(model.tokencode))
                    {
                        return model.tokencode;
                    }
                }
                
                return "";
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("a93f2113-e421-4250-ab13-e83f8134d798");
            }
        }
        public override string PageName
        {
            get
            {
                return "邀请好友";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "13";
            }
        }

        public override bool IsCloseTagsItem
        {
            get
            {
                return true;
            }
        }
        

        public int iLoadCount = 0;
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            if(!string.IsNullOrEmpty(GetApiName))
            {
                string sToken = GetToken;
                EbSite.Base.Plugin.IUserLoginApi thirdAPI = Factory.GetLoginApi(GetApiName);
                if (!string.IsNullOrEmpty(sToken))
                {

                    int pageCount = 24;
                    int pageIndex = this.pcPage.PageIndex;
                    this.litRegUrl.Text = "http://www.beimai.com/9195-1-0c.ashx?inviteID=" + base.UserID;
                    if (!string.IsNullOrEmpty(GetApiName) && !string.IsNullOrEmpty(sToken))
                    {

                        List<Base.EntityAPI.MembershipUserEb> modelList = thirdAPI.GetIdollist(sToken, pageCount, pageIndex -1, out iCount);
                        if (modelList != null && modelList.Count > 0)
                        {
                            this.DataListMyFriend.DataSource = modelList;
                            this.DataListMyFriend.DataBind();
                        }
                    }
                    this.hdPath.Value = EbSite.Base.Host.Instance.GetModulePath(new Guid("8961c5b2-43f2-4298-8145-f0965aff70a0")) + "/css";

                    phIsBind.Visible = true;
                    phNoBind.Visible = false;
                    
                }
                else
                {
                    phIsBind.Visible = false;
                    phNoBind.Visible = true;
                    ntShowInfo.Text = string.Format("你尚未设置[{0}]账号，绑定后你可以用该帐号登录本站", thirdAPI.ShowName);
                    btnToBind.Text = string.Format("   现在去绑定{0}帐号   ", thirdAPI.ShowName);
                   
                }
                return Collectors.UseIUserLoginApiCollector.AllProviders;

            }
            return null;
            
        }
        protected void btnToBind_Click(object sender, EventArgs e)
        {
            EbSite.Base.Host.Instance.BindLogin(GetApiName,Request.RawUrl);
        }
        
        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
      
        override protected void Delete(object iID)
        {
          
           
        }
        protected string GetCss(object apiname)
        {
            string s = "";
            if (apiname.Equals(GetApiName))
            {
                s = "class=\"current_nav\"";
            }
            return s;
        }

        protected void btnSendWeibo_Click(object sender, EventArgs e)
        {
            EbSite.Base.Plugin.IUserLoginApi thirdAPI = Factory.GetLoginApi(GetApiName);
            thirdAPI.SendMsg(this.txtWeiboMsg.Text + "  " + this.litRegUrl.Text, GetToken);
        }
    }
}