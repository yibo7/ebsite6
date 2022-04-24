using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;

namespace EbSite.Modules.UserBaseInfo.AdminPages.Controls.Splace
{
    public partial class EditeMaster : MPUCBaseSave
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("ae9b3d05-0dbc-440d-a6d7-159ec640b5ba");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string fn = Request.QueryString["fn"];
            string fUrl = HttpContext.Current.Server.MapPath(IISPath+"home/themes/" + fn + "/uhome.aspx");
            txtMaster.Text = EbSite.Core.FSO.FObject.ReadFile(fUrl);
        }
        //public override string Permission
        //{
        //    get
        //    {
        //        return "2";
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
            //string fn = Request.QueryString["fn"];
            //string fUrl = HttpContext.Current.Server.MapPath("/home/themes/" + fn + "uhome.aspx");
            //txtMaster.Text = EbSite.Core.FSO.FObject.ReadFile(fUrl);
            ////ModuleCore.BLL.WebSite.Instance.InitModifyCtr(new Guid(SID), phCtrList);
        }
        override protected void SaveModel()
        {
            string fn = Request.QueryString["fn"];
            string fUrl = HttpContext.Current.Server.MapPath(IISPath+"home/themes/" + fn + "/uhome.aspx");
            EbSite.Core.FSO.FObject.WriteFile(fUrl, this.txtMaster.Text);
            base.ShowTipsPop("编辑成功");
            //Base.BLL.OtherColumn cRealname = new OtherColumn("IsAuditing", "true");
            //lstOtherColumn.Add(cRealname);
            //ModuleCore.BLL.WebSite.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);
            //base.ShowTipsPop("添加成功");
        }
    }
}