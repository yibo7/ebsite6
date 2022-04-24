using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Core.FSO;

namespace EbSite.Base.LuceneUtils.FieldConfig
{
  
    public class CreateBLL : EbSite.Base.Datastore.XMLProviderBaseInt<CreateEntity>
    {
        //public static readonly BLL Instance = new BLL();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                if (!Equals(HttpContext.Current, null))
                {
                    return
                        HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/Lucene/Site", SiteID,
                            "/FieldConfig/"));
                }
                else
                {
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Concat("datastore\\Lucene\\Site", SiteID,"\\FieldConfig\\"));
                }
                
            }
        }

        private int SiteID = 1;
        public CreateBLL(int _SiteID)
        {
            SiteID = _SiteID;
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
    }
}
