
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using EbSite.BLL;
using EbSite.BLL.User;
using EbSite.Core;

namespace EbSite.Base.ControlPage
{
    abstract public class UserControlBase : CtrBase
    {
       
        #region 属性

        //override public string MasterPagePath
        //{
        //    get
        //    {
        //        return "";
        //    }
        //}
        /// <summary>
        /// 菜单ID，只适用于模块,有时在开发模块时就要指定菜单ID，所以重写里可以指定
        /// 生成菜单时将以此ID生成，这样您就可以在某些地方写死模块页面的连接
        /// </summary>
        virtual public Guid ModuleMenuID
        {
            get
            {
                return Guid.Empty;
            }
        }
        /// <summary>
        /// 是否开启Tag连接
        /// </summary>
        virtual public bool EnableTagLink
        {
            get
            {
                return true;
            }
        }
        override public string TipsText
        {
            get
            {
                return "";
            }
        }
        override public bool IsCloseLeft 
        { 
            get
            {
                return false;
            }
        }

        override public bool IsCloseTagsTitle
        {
            get
            {
                return false;
            }
        }
        override public bool IsCloseTagsItem
        {
            get
            {
                return false;
            }
        }

        protected string GetMenuLink(int iType)
        {
            string sUrl = "";

            switch (iType)
            {
                case 0: //内容列表页
                    //sUrl ="Admin_Content.aspx?mpid=1b108482-32a5-4145-a093-cabe2d74231e&msid=817e382f-e0e5-4512-acad-c2964de6d914";
                    sUrl = "Admin_Content.aspx?t=1";
                    break;
                case 1: //添加内容页
                    sUrl = "Admin_Content.aspx?t=4";
                    break;
                case 2:  //分类列表页
                    sUrl = "admin_Class.aspx?t=1";
                    break;
                case 3: //添加分类页
                    sUrl = "Admin_Class.aspx?t=0";
                    break;
                case 4: //专题列表页
                    sUrl = "Admin_Special.aspx?t=1";
                    break;
                case 5: //专题添加页
                    sUrl = "Admin_Special.aspx?t=0";
                    break;
            }

            return sUrl;
        }
        protected string sRawUrl
        {
            get
            {
                return Request.RawUrl;
            }
        }
        /// <summary>
        /// 当 GetMat 下还有子页面时可以通过PageType判别不同的页面
        /// </summary>
        protected int PageType
        {
            get
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["t"]))
                {
                    
                    return int.Parse(HttpContext.Current.Request["t"]);
                }
                return -1;
            }
        }
        protected string IISPath
        {
            get
            {
                return Base.AppStartInit.IISPath;
            }
        }
        protected string UserName = UserIdentity.GetUserName;
        protected string UserNiname = UserIdentity.GetUserNiName;
        protected int UserID = UserIdentity.GetUserID;
      
        protected string GroupName = "0";
        protected string GroupID = "0";
       
        #endregion

        /// <summary>
        /// 获取当前用户所在的用户组，或以是多个
        /// </summary>
        protected string[] UserGroups
        {
            get
            {
                return Roles.GetRolesForUser(UserName);
            }
        }
        public UserControlBase()
        {
            this.Load += new EventHandler(BasePage_Load);
            
        }
        private void BasePage_Load(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(this.Permission))
            {
                //先判断用户是否已经登录，如果没登录并且this.Permission不为空，则要求用户先登录
                if(UserID<1)
                {
                    CheckCurrentUserIsLogin();
                }
                if (!IsHaveLimit(this.Permission))
                {
                    
                    this.Tips("出错了", "您没有权限执行此操作，请与管理员联系！", "");
                }
            }
            //else
            //{
            //    this.Tips("出错了", "您没有权限执行此操作，请与管理员联系！", "");
            //}
            if(!string.IsNullOrEmpty(PageName))
                this.Page.Title = string.Concat(Host.Instance.CurrentSite.SiteName, " ", PageName);// PageName;
        }
        virtual protected void OutPutWord()
        {

        }
        virtual protected void OutPutExcel()
        {

        }
        virtual protected void OutPutExcel_Click(object sender, EventArgs e)
        {
            OutPutExcel();
        }
        virtual protected void OutPutWord_Click(object sender, EventArgs e)
        {
            OutPutWord();
        }
        protected void Tips(string Title, string Info)
        {
            string sUrl = "";
            if (!Equals(Request.UrlReferrer, null))
                sUrl = Request.UrlReferrer.ToString();
            AppStartInit.TipsPageRender(Title, Info, sUrl);
        }
        public void Tips(string Tips)
        {
            HttpContext.Current.Response.Redirect(HostApi.GetTips(Tips));
        }
        protected void Tips(string Title, string Info, string Url)
        {
            AppStartInit.TipsPageRender(Title, Info, Url);
        }
        protected void TipsAlert(string msg)
        {
            Core.Strings.cJavascripts.MessageShowBack(msg);
        }
        //protected void ColseGreyBox(bool isrefesh)
        //{
        //    Utils.RunClientJs(this,"ColseGreyBox()");
           
        //}
        protected void ShowTipsPop(string  sMsg)
        {
            Utils.RunClientJs(this,"showpop(\"" + sMsg + "\")");
           
        }
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="MkName"></param>
        public void InsertLog(string Name, string MkName)
        {
            HostApi.InsertLog(Name, MkName);
        }
        /// <summary>
        /// 检测当前用户是否具有某个权限ID
        /// </summary>
        /// <param name="LimitID">权限Id,暂时用字符串型,原本 int</param>
        /// <returns></returns>
        protected virtual bool IsHaveLimit(string LimitID)
        {
            AdminPrincipal user = AdminPrincipal.ValidateLogin(UserName);
            if (user!=null)
            {
                if (!string.IsNullOrEmpty(LimitID) && user.HasPermissionID(int.Parse(LimitID)))
                {
                    return true;
                }
            }
            
            return false;
        }

        



        #region 配合模块使用
        public virtual bool IsAddToAdminMenus
        {
            get
            {
                return false;
            }
        }

        public virtual int OrderID
        {
            get
            {
                return 0;
            }
        }

        public virtual string PageName
        {
            get
            {
                return "";
            }
        }
        public Host HostApi
        {
            get
            {
                return Host.Instance;
            }
        }
        #endregion
    }
}
