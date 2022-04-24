using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.CQ.ModuleCore.Entity;

namespace EbSite.Modules.CQ.AdminPages.Controls.OrderBox
{
    public partial class OrderBoxList : MPUCBaseList
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("57a22138-e37d-4ca1-904a-4dd6b013cffc");
            }
        }
        public override string PageName
        {
            get
            {
                return "下单流程";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        public override int OrderID
        {
            get
            {
                return 1;
            }
        }
        public override string Permission
        {
            get
            {
                return "11";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "12";
            }
        }

        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "12";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "12";
            }
        }

        override protected string AddUrl
        {
            get
            {
                return "t=0";
            }
        }

       
        override protected object LoadList(out int iCount)
        {
            iCount = 0;

            return ModuleCore.BLL.OrderBox.Instance.GetOrderByList();
        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            ModuleCore.BLL.OrderBox.Instance.Delete(int.Parse(iID.ToString()));
        }
        override protected void CopyData(object iID)
        {
            ModuleCore.BLL.OrderBox.Instance.CopyData(int.Parse(iID.ToString()));
        }

        protected void btnSaveJs_Click(object sender, EventArgs e)
        {
            List<ModuleCore.Entity.OrderBoxInfo> lst = ModuleCore.BLL.OrderBox.Instance.GetOrderByList();
            if (lst.Count > 0)
            {
                string sPath = Server.MapPath("../dialog/chatorder.js");
                StringBuilder sb = new StringBuilder("var orderstep = [");
                foreach (OrderBoxInfo obitem in lst)
                {
                    sb.Append("{");
                    sb.AppendFormat(" id: {0}, name: \"{1}\", itype: {2}, pid: \"{3}\", utem: \"{4}\", seltip: \"{5}\" , val: \"\", valid: \"\",rule: \"{6}\",isnull: \"{7}\",fildname: \"{8}\",souretable:{9}",
                        obitem.id, obitem.Tips, obitem.StepType, obitem.DefaultParentClassID, obitem.Utem, obitem.Seltip, obitem.ValidationRule, obitem.IsNullText, obitem.FieldName, obitem.SoureTable
                        );
                    sb.Append("},");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("];");

                Core.FSO.FObject.WriteFileUtf8(sPath, sb.ToString());
            }
            


        }

        protected void btnReSetOutNum_Click(object sender, EventArgs e)
        {
            List<ModuleCore.Entity.OrderBoxInfo> lst = ModuleCore.BLL.OrderBox.Instance.GetOrderByList();
            foreach (OrderBoxInfo orderBoxInfo in lst)
            {
                orderBoxInfo.CloseNum = 0;
                ModuleCore.BLL.OrderBox.Instance.Update(orderBoxInfo);
            }
        }
    }
}