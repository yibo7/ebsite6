using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Core.FSO;

namespace EbSite.Modules.CQ.ModuleCore.BLL
{
    public class CustomWord : EbSite.Base.Datastore.XMLProviderBaseInt<ModuleCore.Entity.CustomWord>
    {
        public static readonly CustomWord Instance = new CustomWord();
        /// <summary>
        /// 重写数据的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                string mpath = EbSite.Base.Host.Instance.GetModulePath(new Guid("b456beef-6b3e-4caf-b282-fd17fc4c8684"));

                return HttpContext.Current.Server.MapPath(string.Concat("~/" + mpath, "/datastore/CustomWord/"));
            }
        }
        private CustomWord()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
        /// <summary>
        /// 生成 常用语句
        /// </summary>
        public void MarkHtml()
        {

            string sPath = HttpContext.Current.Server.MapPath("../dialog/customword/index.html");
            List<ModuleCore.Entity.CustomWord> lst = ModuleCore.BLL.CustomWord.Instance.FillList();
            List<ModuleCore.Entity.CustomWord> nlst = (from i in lst orderby i.OrderID ascending select i).ToList();

            if (nlst.Count > 0)
            {
                StringBuilder sb = new StringBuilder("<div class=\"custtomword\"> <ul>");
                foreach (ModuleCore.Entity.CustomWord info in nlst)
                {
                    sb.AppendFormat(" <li>{0}</li>", info.CommonlyInfo);
                }
                sb.Append("</ul></div>");
                Core.FSO.FObject.WriteFileUtf8(sPath, sb.ToString());
            }


        }
    }
}