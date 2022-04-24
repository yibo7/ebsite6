using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
    public class ContentTem: EbSite.Base.Datastore.XMLProviderBase<Entity.ContentTem>
    {
        public static readonly ContentTem Instance = new ContentTem();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                string p = string.Concat("themes\\", EbSite.Base.Host.Instance.CurrentSite.PageTheme, "\\data\\AdminContentTem\\setupdata\\");
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, p);
            }
        }
        public  string SavePathFile
        {
            get
            {
                string p = string.Concat("themes\\", EbSite.Base.Host.Instance.CurrentSite.PageTheme, "\\data\\AdminContentTem\\temfiledata");
                return System.IO.Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, p);
            }
        }
        public string UrlFile
        {
            get
            {
                return string.Concat(IISPath,"themes/", EbSite.Base.Host.Instance.CurrentSite.PageTheme, "/data/AdminContentTem/temfiledata/");
            }
        }
        public string GetHeaderTemUrlByID(Guid ID)
        {
            return string.Concat(UrlFile, "header", ID, ".ascx");
        }
        public string GetListemUrlByID(Guid ID)
        {
            return string.Concat(UrlFile, "list", ID, ".ascx");
        }
        public string GetHeaderTemPathByID(Guid ID)
        {
            return string.Concat(SavePathFile, "\\header", ID,".ascx");
        }
        public string GetListemPathByID(Guid ID)
        {
            return string.Concat(SavePathFile, "\\list", ID, ".ascx");
        }
        public string GetHeaderTemHtmlByID(Guid ID)
        {
            return Core.FSO.FObject.ReadFile(GetHeaderTemPathByID(ID));
        }
        public string GetListemHtmlByID(Guid ID)
        {
            return Core.FSO.FObject.ReadFile(GetListemPathByID(ID));
        }
        public void AddTem(Entity.ContentTem md, string HeaerTemHtml, string ListTemHtml)
        {
            //md.HeaderTemPath = GetHeaderTemPathByID(md.id);
            //md.ListTemPath = GetListemPathByID(md.id);
            base.Add(md);

            Core.FSO.FObject.WriteFile(GetHeaderTemPathByID(md.id), HeaerTemHtml);
            Core.FSO.FObject.WriteFile(GetListemPathByID(md.id), ListTemHtml);
        }
        public void UpdateTem(Entity.ContentTem md,string HeaerTemHtml,string ListTemHtml)
        {
            base.Update(md);
            Core.FSO.FObject.WriteFile(GetHeaderTemPathByID(md.id), HeaerTemHtml);
            Core.FSO.FObject.WriteFile(GetListemPathByID(md.id), ListTemHtml);
        }
        public void DeleteCtrTem(Guid ID)
        {
            base.Delete(ID);
        }
        private ContentTem()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
    }
}
