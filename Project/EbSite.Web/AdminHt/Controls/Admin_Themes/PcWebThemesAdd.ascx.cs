using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Datastore;
using EbSite.BLL;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Themes
{
    public partial class PcWebThemesAdd : UserControlBaseSave
    {
        protected override string KeyColumnName
        {
            get { throw new NotImplementedException(); }
        }
        protected override void InitModifyCtr()
        {
            BLL.ThemesPC ThemesPC = new ThemesPC();
            Entity.Themes md = ThemesPC.GetEntity(new Guid(SID));
            //ThemesName.Text = md.ThemePath;
            ThemePath.Text = md.ThemePath;
            FullPath.Text = md.FullPath;
            //AddDate.Text = md.AddDate.ToString();
            //drpSites.SelectedValue = md.SiteID;
        }
        protected override void SaveModel()
        {
            string oldpath = "";
            BLL.ThemesPC ThemesPC = new ThemesPC();
            Entity.Themes md = ThemesPC.GetEntity(new Guid(SID));
            oldpath = md.FullPath;
            //md.ThemesName = this.ThemesName.Text;
            md.ThemePath = this.ThemePath.Text;
            md.FullPath = "/themes/" + md.ThemePath + "/";
            md.IndexUrl = md.FullPath + "pages/index.aspx";
            md.SmallImg = md.FullPath + "SmallImg.jpg";
            md.BigImg = md.FullPath + "BigImg.jpg";
            //md.SiteID = drpSites.SelectedValue;
            ThemesPC.Add(md);
            //修改cp_ebsite/configs.config文件
            //string filepath = string.Concat(Server.MapPath(oldpath), "configs.config");
            //EbSite.Core.FSO.FObject.WriteFile(filepath, this.ThemePath.Text, false); 
            //themes/cp_ebsite文件的名称

            if (oldpath == "/themes/" + md.ThemePath + "/")
            {
                //文件夹的名称没有改变时不用改名
            }
            else
            {
                string OPath = Server.MapPath(oldpath);
                string NPath = Server.MapPath("/themes/" + this.ThemePath.Text + "/");
                EbSite.Core.FSO.FObject.CopyDirectory(OPath, NPath);
                    // Core.FSO.FObject.Move(OPath, NPath, FsoMethod.Folder);
                if (Core.FSO.FObject.IsExist(NPath, FsoMethod.Folder))
                {
                    Core.FSO.FObject.Delete(OPath, FsoMethod.Folder);
                }
            }

            TempFactory.GetInstance(md.ThemePath).ResetNoInCurrent();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //drpSites.DataTextField = "SiteName";
            //drpSites.DataValueField = "id";
            //List<Entity.Sites> ls = BLL.Sites.Instance.FillList();
            //Entity.Sites md = new Entity.Sites();
            //md.SiteName = "适用全站";
            //md.id = 0;
            //ls.Add(md);

            //drpSites.DataSource = ls;
            //drpSites.DataBind();
            //if (Equals(SID, null))
            //{
            //    drpSites.SelectedValue = base.GetSiteID.ToString();
            //}
        }
    }
}