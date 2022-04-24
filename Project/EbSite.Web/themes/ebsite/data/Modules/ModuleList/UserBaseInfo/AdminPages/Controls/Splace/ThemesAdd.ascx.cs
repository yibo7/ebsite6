using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace
{
    public partial class ThemesAdd : MPUCBaseSave
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("cce36be9-d39c-42ae-8ee9-5548e99802ad");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTheme();
                ThemeClassID.DataTextField = "classname";
                ThemeClassID.DataValueField = "id";
                ThemeClassID.DataSource = EbSite.BLL.SpaceThemeClass.Instance.GetListArray("");
                ThemeClassID.DataBind();

                //UserGroupID.AppendDataBoundItems = true;
                //UserGroupID.Items.Insert(0, new ListItem("所有用户", "0"));
                //UserGroupID.DataTextField = "groupname";
                //UserGroupID.DataValueField = "id";
                //UserGroupID.DataSource = EbSite.BLL.User.UserGroupProfile.UserGroupProfiles;
                //UserGroupID.DataBind();

            }
        }
        protected void BindTheme()
        {
            if (string.IsNullOrEmpty(SID))
            {
                CopyThemeID.DataTextField = "ThemeName";
                CopyThemeID.DataValueField = "ThemePath";
                CopyThemeID.DataSource = EbSite.BLL.SpaceThemes.Instance.GetListArray("");
                CopyThemeID.DataBind();
            }
        }
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
        override protected void InitModifyCtr()
        {
            BLL.SpaceThemes.Instance.InitModifyCtr(SID, phCtrList);
         
            DivCopy.Visible = false;
            CopyThemeID.Enabled = false;
            ThemePath.Enabled = false;
        }
        override protected void SaveModel()
        {
            if (string.IsNullOrEmpty(SID))
            {

                #region 生成新的皮肤文件夹 把复制的皮肤文件Copy ThemePath.text 中
                //创建新的文件夹
                string url = HttpContext.Current.Server.MapPath(IISPath + "home/themes/" + this.ThemePath.Text);

                #region 检测此文件夹是否存在
                bool key = EbSite.Core.FSO.FObject.IsExist(url, FsoMethod.Folder);
                #endregion
                if (key)
                {
                    base.Tips("出错了", "已经存在" + this.ThemePath.Text + "这个皮肤");
                }
                else
                {

                    EbSite.Core.FSO.FObject.Create(url, FsoMethod.Folder);
                    //复制文件夹
                    string oldFile = HttpContext.Current.Server.MapPath(IISPath + "home/themes/" + this.CopyThemeID.SelectedValue);
                    //CopyThemeID          
                    EbSite.Core.FSO.FObject.CopyDirectory(oldFile, url);

                    EbSite.Entity.SpaceThemes md = new SpaceThemes();
                    md.ThemeName = ThemeName.Text;
                    md.ThemePath = ThemePath.Text;
                    md.Author = Author.Text;
                    md.UserID = UserID;
                    md.AddTime = DateTime.Now;
                    md.ThemeClassID = int.Parse(ThemeClassID.CtrValue);
                   // md.UserGroupID = UserGroupID.SelectedIndex;

                    BLL.SpaceThemes.Instance.Add(md);
                    base.ShowTipsPop("保存成功");

                }
                #endregion
            }
            else
            {
                EbSite.Entity.SpaceThemes md = BLL.SpaceThemes.Instance.GetEntity(Convert.ToInt16(SID));
                md.ThemeName = ThemeName.Text;            
                md.Author = Author.Text;
                md.UserID = UserID;
                md.AddTime = DateTime.Now;
                md.ThemeClassID = int.Parse(ThemeClassID.CtrValue);
                //md.UserGroupID = UserGroupID.SelectedIndex;

                BLL.SpaceThemes.Instance.Update(md);
                base.ShowTipsPop("修改成功");
            }
           
        }
    }
}