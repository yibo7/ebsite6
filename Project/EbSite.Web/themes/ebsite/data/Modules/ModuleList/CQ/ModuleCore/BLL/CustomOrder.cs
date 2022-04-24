using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Core.FSO;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.ModuleCore.BLL
{
    public class CustomOrder:EbSite.Base.Datastore.XMLProviderBaseInt<CustomOrderInfo>
    {
        public static readonly CustomOrder Instance = new CustomOrder();
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

        private readonly string VoteSaveUrl = string.Concat(SettingInfo.Instance.GetBaseConfig.Instance.ModulePath, "DataStore/CustomsOrder/");
        private CustomOrder()
        {

            string sPath = HttpContext.Current.Server.MapPath(VoteSaveUrl);
            if(!FObject.IsExist(sPath,FsoMethod.Folder))
            {
                FObject.Create(sPath,FsoMethod.Folder);
            }
        }

      
        public void DeleteStep(int did)
        {
             CustomOrderInfo md = ModuleCore.BLL.CustomOrder.Instance.GetEntity(did);

            List<CustomOrderInfo> lsSour = ModuleCore.BLL.CustomOrder.Instance.FillList();
            List<CustomOrderInfo> newlist =
                (from c in lsSour where c.TimeStamp == md.TimeStamp select c).ToList();
            foreach (CustomOrderInfo customOrderInfo in newlist)
            {
                ModuleCore.BLL.CustomOrder.Instance.Delete(customOrderInfo.id);
            }
        }
        private void BuilderGvColumn(Control.GridView gv, string ColumFiledName, string ColumShowName)
        {
            BoundField bf = new BoundField();
            bf.DataField = ColumFiledName;
            bf.HeaderText = ColumShowName;
            gv.Columns.Insert(0, bf);

        }
        /// <summary>
        /// 数据源
        /// </summary>
        /// <param name="gv">GridView</param>
        /// <param name="PageIndex">当前面码</param>
        /// <param name="PageSize">每页大小</param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public DataTable GetDataTable(Control.GridView gv,int PageIndex, int PageSize,  out int RecordCount)
        {
            List<ModuleCore.Entity.OrderBoxInfo> lsSour = ModuleCore.BLL.OrderBox.Instance.FillList();
            List<ModuleCore.Entity.OrderBoxInfo> nls = (from c in lsSour orderby c.id descending select c).ToList();
            DataTable dt = new DataTable();
           
            dt.Columns.Add("id");
            dt.Columns.Add("OrderNum");
            BuilderGvColumn(gv, "OrderNum", "定单号");
            dt.Columns.Add("ServiceName");
            BuilderGvColumn(gv, "ServiceName", "客服");
            dt.Columns.Add("OpTime");
            BuilderGvColumn(gv, "OpTime", "时间");
            foreach (ModuleCore.Entity.OrderBoxInfo configs in nls)
            {
                dt.Columns.Add(configs.Title);
                BuilderGvColumn(gv, configs.Title, configs.Title);
            }
            List<CustomOrderInfo> daALL = ModuleCore.BLL.CustomOrder.Instance.FillList();
            var query = from l in daALL
                        orderby l.OpDateTime descending
                        group l by new { l.TimeStamp }
                            into g
                            select new
                            {
                                Name = g.Key.TimeStamp
                            };
            var rance = query.Select(t => t).Skip((PageIndex - 1) * PageSize).Take(PageSize);
            foreach (var q in rance)
            {
                Guid fas = new Guid(q.Name.ToString());
                List<CustomOrderInfo> dataSour =
                    (from c in daALL where c.TimeStamp == fas select c).ToList();
                if (dataSour.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    foreach (ModuleCore.Entity.OrderBoxInfo configs in nls)
                    {
                        var md = (from c in dataSour where c.StepsID == configs.id.ToString() select c).ToList();
                        if (md.Count>0)
                        {
                            dr[configs.Title] = md[0].ClassName;
                            dr["id"] = md[0].id;
                            dr["ServiceName"] = md[0].ServiceName;
                            dr["OpTime"] = md[0].OpDateTime;
                            dr["OrderNum"] = md[0].OrderNum;
                        }
                     
                    }
                    dt.Rows.Add(dr);
                }
            }
            RecordCount = query.Count();
            return dt;
        }
    }
}