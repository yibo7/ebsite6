using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EbSite.Core.FSO;

namespace EbSite.BLL
{
    public class SendArea : EbSite.Base.Datastore.XMLProviderBaseInt<Entity.SendArea>
    {
         public static readonly SendArea Instance = new SendArea();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(string.Concat(IISPath, "datastore/peisong/SendArea/"));
            }
        }
        private SendArea()
        {
            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }
        public int GetSendAreaIDByAreaIDs(string AreaIDs)
        {
            int SendAreaID = 0;
            string[] arryIDs = AreaIDs.Split(',');
            List<Entity.SendArea> ls = EbSite.BLL.SendArea.Instance.FillList();
            foreach (var sendArea in ls)
            {
                for (int i = 0; i < arryIDs.Length; i++)
                {
                    var num = arryIDs[i].ToString();
                    string[] source = sendArea.CityIDs.Split(',');
                    int bl = (from j in source where j.ToString() == num select j).Count();
                    if (bl == 1)
                    {
                        SendAreaID = sendArea.id;
                        break;
                    }
                }
                if (SendAreaID > 0)
                    break;
            }
            return SendAreaID;
        }
    }
}
