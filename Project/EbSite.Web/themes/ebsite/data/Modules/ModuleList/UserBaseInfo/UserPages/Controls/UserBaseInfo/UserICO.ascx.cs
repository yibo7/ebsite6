using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.BLL.User;
using EbSite.Core;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.UserBaseInfo
{
    public partial class UserICO : MPUCBaseSaveForUser
    {
        public string FlashParam = "";
        public override string PageName
        {
            get
            {
                return "修改头像";
            }
        }
        //public override string TipsText
        //{
        //    get
        //    {
        //        return "修改密码!";

        //    }
        //}
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
        public override int OrderID
        {
            get
            {
                return 2;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                FlashParam = string.Concat(Base.AppStartInit.IISPath, "flash/common/camera.swf?appid=", Utils.MD5(string.Concat(Base.AppStartInit.UserName , Base.AppStartInit.UserPass ,Base.AppStartInit.UserID , Base.Host.Instance.OnlineID)), "&input=",
                    DES.Encode(string.Concat(EbSite.Base.AppStartInit.UserID,",", Base.Host.Instance.OnlineID), Base.Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey),
                    "&ucapi=",Utils.GetRootUrl(Base.AppStartInit.IISPath),"ajaxget/avatar.ashx");
                
                #region
                //if (Base.Configs.ConformConfig.ConfigsControl.Instance.WebType < 1)
                //{
                //    FlashParam = string.Concat(Base.AppStartInit.IISPath, "flash/common/camera.swf?nt=1&inajax=1&appid=1&input=",
                //    DES.Encode(EbSite.Base.AppStartInit.UserID.ToString(),
                //    Base.Configs.SysConfigs.ConfigsControl.Instance.Passwordkey),
                //    "&ucapi=",
                //    Utils.GetRootUrl(Base.AppStartInit.IISPath),//Utils.UrlEncode(Utils.GetRootUrl(Base.AppStartInit.IISPath)), 
                //    "ajaxget/avatar.ashx");
                //}
                //else
                //{
                //    //discuz nt 的头像上传办法
                //    FlashParam = string.Concat(Base.Configs.ConformConfig.ConfigsControl.Instance.WebUrl, "/images/common/camera.swf?nt=1&inajax=1&appid=",
                //        Utils.MD5(UserName.Trim() + Core.AplicationGlobal.UserPass.Trim() + UserID + Core.AplicationGlobal.OnlineID),
                //        "&input=", DES.Encode(UserID + "," + Core.AplicationGlobal.OnlineID, Base.Configs.ConformConfig.ConfigsControl.Instance.PassKey),
                //        "&ucapi=", Utils.UrlEncode(string.Concat(Base.Configs.ConformConfig.ConfigsControl.Instance.WebUrl, "/tools/ajax.aspx")));
                //}

                #endregion
               
            }

        }
        /// <summary>
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "2";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("af371bdd-a674-4077-a9ed-e2896fb4c857");
            }
        }
       
        override protected void InitModifyCtr()
        {

            EbSite.BLL.SpaceSetting.Instance.InitModifyCtr(SID, phCtrList);
        }
        override protected void SaveModel()
        {

            base.ShowTipsPop("设置完成");
        }
    }
}