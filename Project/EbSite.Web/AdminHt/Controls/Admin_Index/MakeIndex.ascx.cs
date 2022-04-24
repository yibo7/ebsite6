using System;
using System.Drawing;
using EbSite.Base.Static.OneCreatManager;
using EbSite.Core;
using EbSite.Core.FSO;

//using EbSite.Core.Static.OneCreatManager;

namespace EbSite.Web.AdminHt.Controls.Admin_Index
{
    public partial class MakeIndex : Base.ControlPage.UserControlBaseSave
    {
        public override string Permission
        {
            get
            {
                return "51";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            bntSaveConfig.Click +=new EventHandler(bntSaveConfig_Click);
            cbIsIndexCache.Checked = Base.Configs.SchedulTask.ConfigsControl.Instance.IsOpenIndexCache;

            string BarcodeUrl = Server.MapPath(HostApi.MobileBarcode);
            if (Core.FSO.FObject.IsExist(BarcodeUrl, FsoMethod.File))
            {
                imgMobileIndexImg.ImageUrl = HostApi.MobileBarcode;
                
            }
            else
            {

                Core.FSO.FObject.ExistsDirectory(BarcodeUrl);
                btnMakeBarcode_Click(sender, e);
                imgMobileIndexImg.ImageUrl = HostApi.MobileBarcode;
            }
            

        }

        protected void bntSaveConfig_Click(object sender, EventArgs e)
        {
            Base.Configs.SchedulTask.ConfigsControl.Instance.IsOpenIndexCache = cbIsIndexCache.Checked;
            Base.Configs.SchedulTask.ConfigsControl.SaveConfig();
        }

        override protected string KeyColumnName
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        override protected void InitModifyCtr()
        {
            throw new NotImplementedException();
        }
        override protected void SaveModel()
        {
            string serr = IndexCreate.Instance.MakeHtml(GetSiteID);

            if (!string.IsNullOrEmpty(serr))
            {
                lbErr.Text = serr;
            }
        }

        protected void btnMakeBarcode_Click(object sender, EventArgs e)
        {
            DotNetBarcode db = new DotNetBarcode(DotNetBarcode.Types.QRCode);
            db.SaveFileType = DotNetBarcode.SaveFileTypes.Gif;
            
            string BarcodeUrl = Server.MapPath(HostApi.MobileBarcode);
            db.QRSave(string.Concat(HostApi.Domain,HostApi.MGetIndexHref()), BarcodeUrl, 3);
        }
    }
}