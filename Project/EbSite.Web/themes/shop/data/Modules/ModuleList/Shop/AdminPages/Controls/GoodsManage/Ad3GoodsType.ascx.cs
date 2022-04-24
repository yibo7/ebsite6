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
    public partial class Ad3GoodsType : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "商品类型添加3";
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

        private void DataBind()
        {
            List<ModuleCore.Entity.Norms> modelList = ModuleCore.BLL.Norms.Instance.GetListArray(0, "TypeNameID=" + TypeID,
                                                                                                                 "");
            this.DataList.DataSource = modelList;
            this.DataList.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                DataBind();
        }
        /// <summary>
        /// 添加新规格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addNormsName_Click(object sender, EventArgs e)
        {
            ModuleCore.Entity.Norms md = new Norms();
            md.NormsName = this.txt_NormsName.Text;
            md.OrderID = 1;
            md.TypeNameID = Core.Utils.StrToInt(TypeID, 0);
            md.IsImg = Core.Utils.StrToInt(RaIsImg.SelectedValue, 0);
            ModuleCore.BLL.Norms.Instance.Add(md);
            DataBind();


        }
        protected void btnAddPro_Click(object sender, EventArgs e)
        {
            string[] arry = TbProName.Text.Trim().Split(',');
            foreach (var s in arry)
            {
                ModuleCore.Entity.NormsValue md = new NormsValue();
                md.NormsValueName = s;
                md.OrderID = 1;
                md.NormID = Core.Utils.StrToInt(TbProPid.Value);
                md.NormsIco = "";
                ModuleCore.BLL.NormsValue.Instance.Add(md);
            }
            DataBind();
        }
        protected  void btnAddSKU_Click(object sender,EventArgs e)
        {
            ModuleCore.Entity.NormsValue md = new NormsValue();
            md.NormsValueName = PicDescription.Text;
            md.OrderID = 1;
            md.NormID = Core.Utils.StrToInt(TbProPid.Value);
            md.NormsIco = fileUpLoad.CtrValue;
            ModuleCore.BLL.NormsValue.Instance.Add(md);
            DataBind();
        }
        protected string GetProValue(int id,string ismig)
        {
            string v = "";
            string tmp = "  <SPAN class=SKUValue><SPAN class=span1><A id=\"sa{1}\">{0}</A></SPAN> <SPAN class=span2><A href=\"javascript:deleteAttributeValue(this,'{1}');\">删除</A></SPAN> </SPAN>";
            string tmp1 = "  <SPAN class=SKUValue><SPAN class=span1><A id=\"sa{1}\"><IMG alt={0} src={2} width=23 height=20></A></SPAN> <SPAN class=span2><A href=\"javascript:deleteAttributeValue(this,'{1}');\">删除</A></SPAN> </SPAN>";


            List<ModuleCore.Entity.NormsValue> ls = ModuleCore.BLL.NormsValue.Instance.GetListArray(
                0, "NormID=" + id, "");
            foreach (ModuleCore.Entity.NormsValue i in ls)
            {
                if(ismig=="0")
                { v += string.Format(tmp, i.NormsValueName, i.id);}
                else
                {
                    v += string.Format(tmp1, i.NormsValueName,i.id,i.NormsIco);
                }
            }
            return v;
        }
    }
}