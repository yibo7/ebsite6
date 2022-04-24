using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.ModuleCore.BLL
{
    public class Barcode : EbSite.Base.Datastore.XMLProviderBase<BarcodeInfo>
    {
        public static readonly Barcode Instance = new Barcode();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(VoteSaveUrl);
            }
        }

        private readonly string VoteSaveUrl = string.Concat(SettingInfo.Instance.GetBaseConfig.Instance.ModulePath, "DataStore/BarcodeInfo/");
        private Barcode()
        {

            string sPath = HttpContext.Current.Server.MapPath(VoteSaveUrl);
            if(!FObject.IsExist(sPath,FsoMethod.Folder))
            {
                FObject.Create(sPath,FsoMethod.Folder);
            }
        }
        
        public void SaveQR(PlaceHolder ph, List<EbSite.Base.BLL.OtherColumn> lstOtherColumn,string Content,string SavePath,int iLen)
        {
            base.SaveEntityFromCtr(ph, lstOtherColumn);

            string sContent = Content;

            string sSavePath = HttpContext.Current.Server.MapPath(SavePath);

            int iSize = iLen;

            DotNetBarcode db = new DotNetBarcode(DotNetBarcode.Types.QRCode);
            db.SaveFileType = DotNetBarcode.SaveFileTypes.Gif;
            db.QRSave(sContent, sSavePath, iSize);
            
        }
        public void DeleteQR(Guid ID)
        {
           
            BarcodeInfo md = GetEntity(ID);
            string sSavePath = HttpContext.Current.Server.MapPath(md.SavePath);
            if (FObject.IsExist(sSavePath,FsoMethod.File))
            Core.FSO.FObject.Delete(sSavePath,FsoMethod.File);
            base.Delete(ID);


        }
        

    }
}