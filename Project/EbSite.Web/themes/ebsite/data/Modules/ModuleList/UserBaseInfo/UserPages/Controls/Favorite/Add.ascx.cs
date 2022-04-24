using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Entity;

namespace EbSite.Modules.UserBaseInfo.UserPages.Controls.Favorite
{
    public partial class Add : MPUCBaseSaveForUser
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("cfa7c5d9-db68-4182-aec9-84d10b9f61f7");
            }
        }
        public override string PageName
        {
            get
            {
                //  return "添加到" + SettingInfo.Instance.GetSysConfig.Instance.FavoriteName;
                return "添加收藏夹";
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
                return 2;
            }
        }

        /// <summary>
        /// 添加内容id
        /// </summary>
        protected int CtentID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["cid"]))
                {
                    return int.Parse(Request.QueryString["cid"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定收藏分类列表
                BindDrop();
                if (string.IsNullOrEmpty(SID))
                {
                    Entity.NewsContent md = EbSite.Base.AppStartInit.GetNewsContentInst(CtentID).GetModel(CtentID, GetSiteID);
                    if (!Equals(md, null))
                    {
                        this.txtTitle.Text = md.NewsTitle;
                    }
                }


            }
        }

        protected void BindDrop()
        {
            drpClassName.DataTextField = "ClassName";
            drpClassName.DataValueField = "id";
            drpClassName.DataSource = EbSite.BLL.FavoriteClass.GetListArr(0, "UserID=" + base.UserID, "id desc");
            drpClassName.DataBind();
        }
        /// <summary>
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "9";
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
            Entity.Favorite md = BLL.Favorite.GetModel(int.Parse(SID));
            txtTitle.Text = md.Title;
            drpClassName.SelectedValue = md.ClassID.ToString();


        }
        /// <summary>
        /// 要添加的Url
        /// </summary>
        protected string GetLinkUrl
        {
            get
            {
                return Request.QueryString["url"];
            }
        }
        override protected void SaveModel()
        {
            #region 先要检测有没有加过
            if (string.IsNullOrEmpty(SID))
            {


                List<EbSite.Entity.Favorite> ls = EbSite.BLL.Favorite.GetListArr(0,"userid=" + base.UserID +
                                                                                 " and LinkUrl='" + GetLinkUrl+"'", "id desc");
                if (ls.Count > 0)
                {
                    TipsAlert("您已经添加过此记录");
                }
                else
                {
                    Entity.Favorite md = new Entity.Favorite();
                    md.Title = txtTitle.Text.ToString();
                    md.ContentID = CtentID;
                    md.FavType = 0; //0为内容 
                    md.AddDateTime = DateTime.Now;
                    md.UserID = base.UserID;
                    md.UserNiName = base.UserNiname;
                    md.UserName = base.UserName;
                    md.ClassID = int.Parse(drpClassName.SelectedValue);
                    md.LinkUrl = GetLinkUrl;
                    BLL.Favorite.Add(md);

                    //转到列表页面
                   string strurl = EbSite.Base.Host.Instance.GetModuleUrl(new Guid("a9156956-8f57-4bce-b011-4f8107fcbb41"), new Guid("cfa7c5d9-db68-4182-aec9-84d10b9f61f8"));
                   Response.Redirect(strurl);


                }
            }

            #endregion

            if (!string.IsNullOrEmpty(SID))
            {
                Entity.Favorite md = BLL.Favorite.GetModel(int.Parse(SID));
                md.ClassID =int.Parse(drpClassName.SelectedValue);
                md.Title = txtTitle.Text.ToString();
                BLL.Favorite.Update(md);
                      
            }


        }

        protected void btnAddClass_Click(object sender, EventArgs e)
        {
            //添加分类
            EbSite.Entity.FavoriteClass md = new FavoriteClass();
            md.ClassName = txtClassName.Text.Trim();
            md.UserName = base.UserName;
            md.UserID = base.UserID;
            md.UserNiName = base.UserNiname;
            EbSite.BLL.FavoriteClass.Add(md);
            BindDrop();
            base.ShowTipsPop("添加成功");

        }


    }
}