using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
    public class PsCompany :EbSite.Base.Datastore.XMLProviderBaseInt<Entity.PsCompany>
    {
       public static readonly PsCompany Instance = new PsCompany();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/peisong/company/"));
            }
        }
        public string GetNamesByIDs(string ids)
        {
            List<Entity.PsCompany> lst = base.FillList();
            string [] li =  ids.Split(',');

            List<Entity.PsCompany> ltem = (from g in lst where li.Contains(g.id.ToString()) select g).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in ltem)
            {
                sb.Append(item.CompanyName);
                sb.Append(",");
            }
            if (sb.Length > 1)
                sb.Remove(sb.Length - 1, 1);
            return sb.ToString();

        }
        private PsCompany()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
    }
}
