using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;
using EbSite.Entity;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.Favorite
{
    /// <summary>
    /// 添加一个收藏记录时，可以修改内容标题
    /// </summary>
    public partial class ClassAdd : MPUCBaseSaveForUser
    {
        public override string Permission
        {
            get
            {
                return "3";
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("ce3670a8-c31b-4913-bb26-1214717f5df5");
            }
        }
        public override string PageName
        {
            get
            {

                return "添加分类";
            }
        }
       
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return false;
            }
        }
        public override int OrderID
        {
            get
            {
                return 4;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //绑定收藏分类列表
            //drpClassName.DataSource = EbSite.BLL.
        }
        ///// <summary>
        ///// 此权限ID不为空，将要求用户登录后才能访问此页面
        ///// </summary>
        //public override string Permission
        //{
        //    get
        //    {
        //        return "1";
        //    }
        //}
        
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
            if (!string.IsNullOrEmpty(SID))
            {
                EbSite.Entity.FavoriteClass md = EbSite.BLL.FavoriteClass.GetModel(int.Parse(SID));
                this.ClassName.Text = md.ClassName;
            }

        }
        override protected void SaveModel()
        {
            if (string.IsNullOrEmpty(SID))
            {
                EbSite.Entity.FavoriteClass md = new FavoriteClass();
                md.ClassName = ClassName.Text.Trim();
                md.UserName = base.UserName;
                md.UserID = base.UserID;
                md.UserNiName = base.UserNiname;
                EbSite.BLL.FavoriteClass.Add(md);
                base.ShowTipsPop("添加成功");
            }
            else
            {
                EbSite.Entity.FavoriteClass md = EbSite.BLL.FavoriteClass.GetModel(int.Parse(SID));
                md.ClassName = ClassName.Text.Trim();
                md.UserName = base.UserName;
                md.UserID = base.UserID;
                md.UserNiName = base.UserNiname;
                md.ID = int.Parse(SID);
                EbSite.BLL.FavoriteClass.Update(md);
                base.ShowTipsPop("修改成功");
            }
            //string strurl = EbSite.Base.Host.Instance.GetModuleUrl(new Guid("a9156956-8f57-4bce-b011-4f8107fcbb41"), new Guid("cfa7c5d9-db68-4182-aec9-84d10b9f61f8"));


        }
    }
}