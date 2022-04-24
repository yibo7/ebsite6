using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.AdminPages.Controls.GoodsManage
{
    public partial class EditGoodsType : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "商品类型修改";
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("e8b2cdd7-4299-497b-9215-a94e8c3a6c88");
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


        protected void Page_Load(object sender, EventArgs e)
        {
            ctbTag.EndLiteral = llTagEnd;
            ctbTag.Items = string.Format("基本设置#tg1|扩展属性#tg2|规 格#tg3");
            //ModuleCore.Entity.TypeNames md = ModuleCore.BLL.TypeNames.Instance.GetEntity(int.Parse(SID));
            //this.TypeName.Text = md.TypeName;
            //this.OrderID.Text = md.OrderID.ToString();
           
        }
        override protected void InitModifyCtr()
        {
            ModuleCore.BLL.TypeNames.Instance.InitModifyCtr(SID, phCtrList);
            ModuleCore.Entity.TypeNames model = ModuleCore.BLL.TypeNames.Instance.GetEntity(Convert.ToInt32(SID));
            tx_BrandIDs.DataSource = ModuleCore.BLL.GoodsBrand.Instance.GetListArrayCache(0, "", "");//ModuleCore.BLL.GoodsBrand.Instance.FillList();
            tx_BrandIDs.DataTextField = "brandname";
            tx_BrandIDs.DataValueField = "id";
            tx_BrandIDs.RepeatColumns = 5;
            tx_BrandIDs.DataBind();
            if (!string.IsNullOrEmpty(model.BrandIDs))
            {
                string[] arry = model.BrandIDs.Split(',');
                foreach (var s in arry)
                {
                    for (int i = 0; i < tx_BrandIDs.Items.Count; i++)
                    {
                        if (tx_BrandIDs.Items[i].Value==s)
                        {
                            tx_BrandIDs.Items[i].Selected = true;
                        }
                    }
                }
            }

            Ck_IsSpecial.Checked = model.IsSpecial;
            DataBind();
            DataBind3();


        }
        private void DataBind()
        {
            List<ModuleCore.Entity.TypeNameValue> modelList = ModuleCore.BLL.TypeNameValue.Instance.GetListArray(0, "TypeNameID=" + SID,
                                                                                                                 "");
            this.DataList.DataSource = modelList;
            this.DataList.DataBind();
        }
        override protected void SaveModel()
        {

        }
        /// <summary>
        /// 修改完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addType_Click(object sender, EventArgs e)
        {


            ModuleCore.Entity.TypeNameValue md = new TypeNameValue();
            md.TypeNameID = Core.Utils.StrToInt(SID, 0);
            md.ValueName = txt_ValueName.Text;
            md.OrderID = Core.Utils.StrToInt(this.OrderID.Text, 0);
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
            Page.RegisterStartupScript("showDiv", "<script>ShowTag(1) </script>");
        }
        protected void EditType_Click(object sender, EventArgs e)
        {
            string brands = "";
            for (int i = 0; i < tx_BrandIDs.Items.Count; i++)
            {
                if (tx_BrandIDs.Items[i].Selected)
                {
                    brands += tx_BrandIDs.Items[i].Value + ",";
                }
            }
            if (brands.Length > 0)
                brands = brands.Remove(brands.Length - 1, 1);
            EbSite.Base.BLL.OtherColumn otherColumn = new OtherColumn("brandids", brands);
            lstOtherColumn.Add(otherColumn);

            otherColumn = new OtherColumn("IsSpecial", Ck_IsSpecial.Checked.ToString());
            lstOtherColumn.Add(otherColumn);

            

            ModuleCore.BLL.TypeNames.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);

            base.TipsAlert("修改成功");

            Page.RegisterStartupScript("showDiv", "<script>ShowTag(0) </script>");
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
        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddPro_Click(object sender, EventArgs e)
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
            Page.RegisterStartupScript("showDiv", "<script>ShowTag(1) </script>");
        }

        #region 规格
        protected string GetProValue3(int id, string ismig)
        {
            string v = "";
            string tmp = "  <SPAN class=SKUValue><SPAN class=span1><A id=\"sa{1}\">{0}</A></SPAN> <SPAN class=span2><A href=\"javascript:deleteAttributeValue3(this,'{1}');\">删除</A></SPAN> </SPAN>";
            string tmp1 = "  <SPAN class=SKUValue><SPAN class=span1><A id=\"sa{1}\"><IMG alt={0} src={2} width=23 height=20></A></SPAN> <SPAN class=span2><A href=\"javascript:deleteAttributeValue(this,'{1}');\">删除</A></SPAN> </SPAN>";


            List<ModuleCore.Entity.NormsValue> ls = ModuleCore.BLL.NormsValue.Instance.GetListArray(
                0, "NormID=" + id, "");
            foreach (ModuleCore.Entity.NormsValue i in ls)
            {
                if (ismig == "0")
                { v += string.Format(tmp, i.NormsValueName, i.id); }
                else
                {
                    v += string.Format(tmp1, i.NormsValueName, i.id, i.NormsIco);
                }
            }
            return v;
        }
        protected void addNormsName_Click(object sender, EventArgs e)
        {
            ModuleCore.Entity.Norms md = new Norms();
            md.NormsName = this.txt_NormsName.Text;
            md.OrderID = 1;
            md.TypeNameID = Core.Utils.StrToInt(SID, 0);
            md.IsImg = Core.Utils.StrToInt(RaIsImg.SelectedValue, 0);
            ModuleCore.BLL.Norms.Instance.Add(md);
            DataBind3();

            Page.RegisterStartupScript("showDiv", "<script>ShowTag(2) </script>");

        }
        protected void btnAddPro3_Click(object sender, EventArgs e)
        {
            string[] arry = TextBox1.Text.Trim().Split(',');
            foreach (var s in arry)
            {
                ModuleCore.Entity.NormsValue md = new NormsValue();
                md.NormsValueName = s;
                md.OrderID = 1;
                md.NormID = Core.Utils.StrToInt(TbProPid.Value);
                md.NormsIco = "";
                ModuleCore.BLL.NormsValue.Instance.Add(md);
            }
            DataBind3();
            Page.RegisterStartupScript("showDiv", "<script>ShowTag(2) </script>");
        }
        protected void btnAddSKU_Click(object sender, EventArgs e)
        {
            ModuleCore.Entity.NormsValue md = new NormsValue();
            md.NormsValueName = PicDescription.Text;
            md.OrderID = 1;
            md.NormID = Core.Utils.StrToInt(TbProPid.Value);
            md.NormsIco = fileUpLoad.CtrValue;
            ModuleCore.BLL.NormsValue.Instance.Add(md);
            DataBind3();
            Page.RegisterStartupScript("showDiv", "<script>ShowTag(2) </script>");
        }

        private void DataBind3()
        {
            List<ModuleCore.Entity.Norms> modelList = ModuleCore.BLL.Norms.Instance.GetListArray(0, "TypeNameID=" + SID,
                                                                                                                 "");
            this.RepPro.DataSource = modelList;
            this.RepPro.DataBind();
        }
        #endregion
    }
}