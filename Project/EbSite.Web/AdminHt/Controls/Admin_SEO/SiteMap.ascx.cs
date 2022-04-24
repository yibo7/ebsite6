using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.ContentSet;
using EbSite.Base.ControlPage;
using EbSite.Core.FSO;

namespace EbSite.Web.AdminHt.Controls.Admin_SEO
{
    public partial class SiteMap : UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "278";
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
            throw new NotImplementedException();
        }
        override protected void SaveModel()
        {

            ConfigsControl.Instance.MapPl = int.Parse(txtMapPl.Text);
            ConfigsControl.Instance.MapSl = int.Parse(txtMapSl.Text);
            ConfigsControl.SaveConfig();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtMapPl.Text = ConfigsControl.Instance.MapPl.ToString();
                txtMapSl.Text = ConfigsControl.Instance.MapSl.ToString();
                string sPath = Server.MapPath(IISPath + "robots.txt");
                if (Core.FSO.FObject.IsExist(sPath, FsoMethod.File))
                {
                    txtRobots.Text = Core.FSO.FObject.ReadFile(sPath);
                }
                else
                {
                    txtRobots.Text = "网站不存在robots.txt文件";
                }
                

            }
        }

        protected void btnMake_Click(object sender, EventArgs e)
        {
            EbSite.BLL.SiteMap sm = new BLL.SiteMap();
            sm.Save();

        }

        protected void btnSaveRobots_Click(object sender, EventArgs e)
        {
            string sPath = Server.MapPath(IISPath + "robots.txt");
            if (Core.FSO.FObject.IsExist(sPath, FsoMethod.File))
            {
               string sContent =  txtRobots.Text;

                FObject.WriteFileUtf8(sPath, sContent);

            }
             

        }
    }
}