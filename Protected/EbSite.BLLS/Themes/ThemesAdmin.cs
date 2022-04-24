using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base;
using EbSite.Base.Configs.ContentSet;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
    public class ThemesAdmin : ThemesBase
    {
        override protected ThemeType eThemeType
        {
            get { return ThemeType.ADMIN; }
        }
        override public string ThemesVpath
        {
            get
            {
                return string.Concat(AppStartInit.AdminPath, "themes");
            }
        }
        public override string FilePathName
        {
            get
            {
                //return "/adminht/themes/";
                return string.Concat(IISPath,AppStartInit.AdminPath, "themes");
            }
        }
        
        //public static readonly ThemesAdmin Instance = new ThemesAdmin();
        override protected void UpdateConfigs(string ThemePath)
        {
            //ConfigsControl.Instance.AdminStyle = ThemePath;
            //ConfigsControl.SaveConfig();

            CurrentSite.AdminTheme = ThemePath;
            EbSite.BLL.Sites.Instance.Update(CurrentSite);

            string sTemPath = HttpContext.Current.Server.MapPath(string.Concat(AppStartInit.AdminPath, "/makeimgtem.htm"));
            if (Core.FSO.FObject.IsExist(sTemPath, FsoMethod.File))
            {
                string sTem = FObject.ReadFile(sTemPath);
                sTem = sTem.Replace("{皮肤目录}", ThemePath);
                FObject.WriteFile(sTemPath, sTem);

            }
        }
        override public  void CopyData(Guid ThemeID)
        {
            //不需要复制功能。
        }
        //override public void MakeThemeImg(Guid ThemeID)
        //{
        //    //Entity.Themes Theme = GetEntity(ThemeID);

        //    //string sSavePath = HttpContext.Current.Server.MapPath(Theme.BigImg);

        //    //string sUrl = "http://localhost:8088/makeimgtem.htm"
        //    //;//string.Concat(EbSite.Base.Host.Instance.Domain,"/",Core.AplicationGlobal.AdminPath, "/makeimgtem.htm");

        //    //MakeThemeImg(sSavePath, sUrl);
        //}
        /// <summary>
        /// 重写数据的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/Themes/Admin/"));
            }
        }

    }
}
