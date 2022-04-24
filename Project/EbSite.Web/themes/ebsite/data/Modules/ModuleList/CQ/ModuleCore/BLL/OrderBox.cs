using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Core;
using EbSite.Core.FSO;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.ModuleCore.BLL
{
    public class OrderBox : EbSite.Base.Datastore.XMLProviderBaseInt<OrderBoxInfo>
    {
        public static readonly OrderBox Instance = new OrderBox();
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

        private readonly string VoteSaveUrl = string.Concat(SettingInfo.Instance.GetBaseConfig.Instance.ModulePath, "DataStore/OrderBoxInfo/");
        private OrderBox()
        {

            string sPath = HttpContext.Current.Server.MapPath(VoteSaveUrl);
            if(!FObject.IsExist(sPath,FsoMethod.Folder))
            {
                FObject.Create(sPath,FsoMethod.Folder);
            }

           
        }

        public List<ModuleCore.Entity.OrderBoxInfo> GetOrderByList()
        {
            List<ModuleCore.Entity.OrderBoxInfo> lst = ModuleCore.BLL.OrderBox.Instance.FillList();
            List<ModuleCore.Entity.OrderBoxInfo> nlst = (from i in lst orderby i.OrderID ascending select i).ToList();
            return nlst;
        }
        
        

    }
}