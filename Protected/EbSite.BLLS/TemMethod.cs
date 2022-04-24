using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Base.Entity;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
    /// <summary>
    /// 为模板提供公共方法调用库
    /// </summary>
    public class TemMethod : Base.Datastore.XMLProviderBase<TemMethodInfo>
    {
       public static readonly TemMethod Instance = new TemMethod();
        ///// <summary>
        ///// 重写菜单的保存路径-绝对
        ///// </summary>
        //public override string SavePath
        //{
        //    get
        //    {
        //        return HttpContext.Current.Server.MapPath();
        //    }
        //}
       private TemMethod()
        {
            string sPath = HttpContext.Current.Server.MapPath("/datastore/TemMethodInfo/");
            if(!FObject.IsExist(sPath,FsoMethod.Folder))
            {
                FObject.Create(sPath,FsoMethod.Folder);
            }
        }
    }
    public class TemMethodInfo : XmlEntityBase<Guid>
    {
        public string Title { get; set; }
        public string GetCode { get; set; }
        public string Author { get; set; }
        public string Demo { get; set; }
    }
}
