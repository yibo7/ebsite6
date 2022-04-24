using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.AdminPages.Controls.GoodsManage
{
    public partial class Ad2GoodsType : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "商品类型添加2";
            }
        }
        public override string Permission
        {
            get
            {
                return "2";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "ID";
            }
        }



        override protected void InitModifyCtr()
        {
            ModuleCore.BLL.Supplier.Instance.InitModifyCtr(SID, phCtrList);
        }

        override protected void SaveModel()
        {
            int k = 0;

        }
        protected string TypeID
        {
            get
            {
                return Request.QueryString["tid"];
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addType_Click(object sender, EventArgs e)
        {

            ModuleCore.Entity.TypeNameValue md = new TypeNameValue();
            md.TypeNameID = Core.Utils.StrToInt(TypeID, 0);
            md.ValueName = txt_ValueName.Text;
            md.OrderID = Core.Utils.StrToInt(this.txt_OrderID.Text, 0); ;
            md.IsMoreSel = Core.Utils.StrToInt(txt_IsMoreSel.CtrValue);
            md.IsSele = Core.Utils.StrToInt(txt_IsSele.CtrValue);
            // md.DefaultValues = txt_DefaultValues.Text;
            int k = ModuleCore.BLL.TypeNameValue.Instance.Add(md);

            string[] arry = txt_DefaultValues.Text.Trim().Split(',');
            foreach (var s in arry)
            {
                ModuleCore.Entity.TypeNameValues model = new TypeNameValues();
                model.TypeValueName = txt_ValueName.Text;
                model.OrderID = 1;
                model.TValues = s;
                model.TypeNameValueID = k;
                model.ProductID = 0;
                ModuleCore.BLL.TypeNameValues.Instance.Add(model);


            }

            DataBind();
        }
        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddPro_Click(object  sender,EventArgs e)
        {
            string[] arry = TbProName.Text.Trim().Split(',');
            foreach (var s in arry)
            {
                ModuleCore.Entity.TypeNameValues model = new TypeNameValues();
                model.TypeValueName = "";
                model.OrderID = 1;
                model.TValues = s;
                model.TypeNameValueID = Core.Utils.StrToInt(this.TbProPid.Value, 0);
                model.ProductID = 0;
                ModuleCore.BLL.TypeNameValues.Instance.Add(model);
            }
            DataBind();

        }
        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GoThree_Click(object  sender,EventArgs e)
        {
            string sUrl = "GoodsManage.aspx?muid=e8b2cdd7-4299-497b-9215-a94e8c3a6c88&mid=cfccc599-4585-43ed-ba31-fdb50024714b";
            Response.Redirect(sUrl + "&t=8&tid=" + TypeID);
        }
        private void DataBind()
        {
            List<ModuleCore.Entity.TypeNameValue> modelList = ModuleCore.BLL.TypeNameValue.Instance.GetListArray(0, "TypeNameID=" + TypeID,
                                                                                                                 "");
            this.DataList.DataSource = modelList;
            this.DataList.DataBind();
        }
        public string GetProValue(int id)
        {
            string v = "";
            string tmp = "  <SPAN class=SKUValue><SPAN class=span1><A id=\"sa{1}\">{0}</A></SPAN> <SPAN class=span2><A href=\"javascript:deleteAttributeValue(this,'{1}');\">删除</A></SPAN> </SPAN>";


            List<ModuleCore.Entity.TypeNameValues> ls = ModuleCore.BLL.TypeNameValues.Instance.GetListArray(
                0, "TypeNameValueID=" + id, "");
            foreach (ModuleCore.Entity.TypeNameValues i in ls)
            {
                v += string.Format(tmp, i.TValues, i.id);
            }
            return v;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                DataBind();
        }

    }
}