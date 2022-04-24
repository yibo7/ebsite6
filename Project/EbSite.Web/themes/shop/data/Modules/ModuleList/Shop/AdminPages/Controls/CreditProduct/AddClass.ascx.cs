using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;

namespace EbSite.Modules.Shop.AdminPages.Controls.CreditProduct
{
    public partial class AddClass : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "积分分类添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "88";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(SID))
                {
                    ModuleCore.Entity.creditproductclass m = ModuleCore.BLL.creditproductclass.Instance.GetEntity(int.Parse(SID));
                    if (m != null)
                    {
                        this.txtClassName.Text = m.ClassName;
                        this.txtOrderID.Text = m.OrderID.ToString();
                    }
                }
            }
        }


        override protected void InitModifyCtr()
        {
           


        }
        override protected void SaveModel()
        {
            ModuleCore.Entity.creditproductclass m = new ModuleCore.Entity.creditproductclass();
            m.ClassName = this.txtClassName.Text;
            m.OrderID =Core.Utils.StrToInt(this.txtOrderID.Text);
            if (string.IsNullOrEmpty(SID))
            {
                //添加
                m.AddTime = DateTime.Now;
                ModuleCore.BLL.creditproductclass.Instance.Add(m);
            }
            else
            { 
                //修改
                m.id = Core.Utils.StrToInt(SID, 0);
                ModuleCore.BLL.creditproductclass.Instance.Update(m);
            }
            base.RunJs("alert('操作成功');window.location='/themes/shop/data/Modules/ModuleList/Shop/AdminPages/CreditProduct.aspx?muid=45c6da33-3516-46fe-a9c6-f8ddbbf0b5da&mid=cfccc599-4585-43ed-ba31-fdb50024714b';");
        }
    }
}