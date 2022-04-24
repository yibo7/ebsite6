using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Core.FSO;

namespace EbSite.Web.AdminHt.Controls.Admin_Tem
{
    public partial class StyleList : BaseList
    {
        public override string Permission
        {
            get
            {
                return "239";
            }
        }
        public override string PermissionModifyID
        {
            get
            {
                return "240";
            }
        }
        protected override string AddUrl
        {
            get
            {
                return "";
            }
        }
        protected override object LoadList(out int iCount)
        {
            string url = string.Concat(IISPath, TemBll.ThemesFolder, "/", TemBll._ThemeName, "/css");
            string urlPath = Server.MapPath(url);
            string[] arr = System.IO.Directory.GetFiles(urlPath, "*.css");
            iCount = arr.Count();
            List<SylteNames> ls = new List<SylteNames>();
            if (iCount > 0)
            {
                foreach (string li in arr)
                {
                    SylteNames md = new SylteNames();
                    md.Name = System.IO.Path.GetFileName(li);

                    md.UrlPath = url + "/" + md.Name;
                    ls.Add(md);

                }
            }
            return ls;
        }
        protected override object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        protected override void Delete(object ID)
        {
            throw new NotImplementedException();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Base.Host.Instance.CurrentSite.PageTheme != null)
                //{
                //    thememName.InnerHtml = "当前操作模板所在样式:<font color=red>" + Base.Host.Instance.CurrentSite.PageTheme + "</font>";
                //}


            }
        }

    }
    public class SylteNames
    {
        public string Name { get; set; }
        public string UrlPath { get; set; }
    }
}