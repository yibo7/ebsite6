using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Payment
{
    public partial class PaymentType : UserControlListBase
    {
        public override string PageName
        {
            get
            {
                return "支付方式分类";
            }
        }
        #region 权限

        public override string Permission
        {
            get
            {
                return "160";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "159";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "230";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "229";
            }
        }

        #endregion

        override protected string AddUrl
        {
            get
            {
                return "t=2";
            }
        }
       
        public override int OrderID
        {
            get
            {
                return 3;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        protected override void Delete(object ID)
        {
           BLL.PayTypeInfo.Instance.Delete(int.Parse(ID.ToString()));
        }

        protected override object LoadList(out int iCount)
        {
            iCount = 0;
            return BLL.PayTypeInfo.Instance.GetSalesTeamTree(10000);
        }
    }
}