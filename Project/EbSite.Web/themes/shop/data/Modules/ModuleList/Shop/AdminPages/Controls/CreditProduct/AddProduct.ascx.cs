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
    public partial class AddProduct : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "积分商品添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "84";
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
                List<ModuleCore.Entity.creditproductclass> ls = ModuleCore.BLL.creditproductclass.Instance.GetListArray("");
                if (ls != null&&ls.Count>0)
                {
                    this.ddlProductClass.DataTextField = "classname";
                    this.ddlProductClass.DataValueField = "id";
                    this.ddlProductClass.DataSource = ls;
                    this.ddlProductClass.DataBind();
                    this.ddlProductClass.Items.Insert(0, new ListItem("--选择分类--", ""));
                }
                //绑定默认值
                if (!string.IsNullOrEmpty(SID))
                {
                    ModuleCore.Entity.creditproduct m = ModuleCore.BLL.creditproduct.Instance.GetEntity(int.Parse(SID));
                    if (m != null)
                    {
                        this.txtProductName.Text = m.ProductName;
                        this.txtUnit.Text = m.Unit;
                        this.txtScore.Text=m.Credit.ToString();//默认为10000分
                        this.txtCostPrice.Text=m.CostPrice.ToString();
                        this.txtRefPrice.Text=m.MarketPrice.ToString();
                        this.txtSimplInfo.Text=m.Outline;
                        this.txtPageDesc.Text=m.SeoDes;
                        this.txtPageKeyWord.Text = m.SeoKeyWord;
                        this.txtPageTitle.Text = m.SeoTitle;
                        this.txtProductInfo.Text = m.Info;
                        this.rdoIsSale.SelectedValue=m.IsSaling.ToString();
                        this.txtProductCount.Text=m.Stock.ToString();
                        this.ddlProductClass.SelectedValue=m.ClassID.ToString();
                        this.txtExchangeNum.Text = m.ExchangeNum.ToString();//隐藏 兑换次数
                        this.showimg.ImageUrl = m.SmallImg;
                        this.ImgUpLoad.CtrValue = m.BigImg;
                        //if (!string.IsNullOrEmpty(m.BigImg))
                        //{
                        //    this.showimg.ImageUrl =string.Concat(this.ImgUpLoad.SaveFolder,m.BigImg);
                        //}
                    }
                }
            }
        }


        override protected void InitModifyCtr()
        {
            
        }
        override protected void SaveModel()
        {
            ModuleCore.Entity.creditproduct m = new ModuleCore.Entity.creditproduct();
            m.ProductName = this.txtProductName.Text;
            m.Unit = this.txtUnit.Text;
            m.Credit =EbSite.Core.Utils.StrToInt(this.txtScore.Text,10000);//默认为10000分
            m.CostPrice = string.IsNullOrEmpty(this.txtCostPrice.Text) ? 0 : decimal.Parse(this.txtCostPrice.Text);
            m.MarketPrice = string.IsNullOrEmpty(this.txtRefPrice.Text) ? 0 : decimal.Parse(this.txtRefPrice.Text);
            m.Outline = this.txtSimplInfo.Text;
            m.SeoDes = this.txtPageDesc.Text;
            m.SeoKeyWord = this.txtPageKeyWord.Text;
            m.SeoTitle = this.txtPageTitle.Text;
            m.Info = this.txtProductInfo.Text;
            m.IsSaling =Core.Utils.StrToInt(this.rdoIsSale.SelectedValue,0);
            m.Stock = Core.Utils.StrToInt(this.txtProductCount.Text, 0);
            m.ClassID = Core.Utils.StrToInt(this.ddlProductClass.SelectedValue, 0);
           
            m.BigImg = this.ImgUpLoad.ValSavePath;
            m.AddTime = Core.SqlDateTimeInt.GetSecond(DateTime.Now);
            m.AddUserID = base.UserID;
            if (string.IsNullOrEmpty(SID))
            {
                ModuleCore.BLL.creditproduct.Instance.Add(m);
            }
            else
            {
                m.ExchangeNum = EbSite.Core.Utils.StrToInt(this.txtExchangeNum.Text, 0);
                m.id = Core.Utils.StrToInt(SID);
                ModuleCore.BLL.creditproduct.Instance.Update(m);
            }
        }
    }
}