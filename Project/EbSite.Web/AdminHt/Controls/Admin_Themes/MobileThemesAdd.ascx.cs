using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.Core.FSO;

namespace EbSite.Web.AdminHt.Controls.Admin_Themes
{
    public partial class MobileThemesAdd : UserControlBaseSave
    {
        protected override string KeyColumnName
        {
            get { throw new NotImplementedException(); }
        }
        protected override void InitModifyCtr()
        {
            BLL.ThemesMobile ThemesMobile = new ThemesMobile();
            Entity.Themes md = ThemesMobile.GetEntity(new Guid(SID));
            //ThemesName.Text = md.ThemesName;
            ThemePath.Text = md.ThemePath;
            FullPath.Text = md.FullPath;
            AddDate.Text = md.AddDate.ToString();
            //drpSites.SelectedValue = md.SiteID;
        }
        protected override void SaveModel()
        {
            string oldpath = "";
            BLL.ThemesMobile ThemesPC = new ThemesMobile();
            Entity.Themes md = ThemesPC.GetEntity(new Guid(SID));
            oldpath = md.FullPath;
            //md.SiteID = drpSites.SelectedValue;
            //md.ThemesName = this.ThemesName.Text;
            md.ThemePath = this.ThemePath.Text;
            md.FullPath = string.Concat("/themesm/" , md.ThemePath ,"/");
            md.IndexUrl = md.FullPath + "pages/index.aspx";
            md.SmallImg = md.FullPath + "SmallImg.jpg";
            md.BigImg = md.FullPath + "BigImg.jpg";
            ThemesPC.Add(md);
            //修改cp_ebsite/configs.config文件
            string filepath = string.Concat(Server.MapPath(oldpath), "configs.config");
            EbSite.Core.FSO.FObject.WriteFile(filepath, this.ThemesName.Text, false);
            //themes/cp_ebsite文件的名称
            string OPath = Server.MapPath(oldpath);
            string NPath = Server.MapPath("/themesm/" + this.ThemePath.Text + "/");

            if (oldpath == "/themesm/" + md.ThemePath + "/")
            {
                //文件夹的名称没有改变时不用改名
            }
            else
            {
                EbSite.Core.FSO.FObject.CopyDirectory(OPath, NPath);// Core.FSO.FObject.Move(OPath, NPath, FsoMethod.Folder);
                if (Core.FSO.FObject.IsExist(NPath, FsoMethod.Folder))
                {
                    Core.FSO.FObject.Delete(OPath, FsoMethod.Folder);
                }
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //drpSites.DataTextField = "SiteName";
            //drpSites.DataValueField = "id";
            List<Entity.Sites> ls = BLL.Sites.Instance.FillList();

            Entity.Sites md = new Entity.Sites();
            md.SiteName = "适用全站";
            md.id = 0;
            ls.Add(md);

            //drpSites.DataSource = ls;
            //drpSites.DataBind();
            //if (Equals(SID, null))
            //{
            //    drpSites.SelectedValue = base.GetSiteID.ToString();
            //}
        }
    }
}