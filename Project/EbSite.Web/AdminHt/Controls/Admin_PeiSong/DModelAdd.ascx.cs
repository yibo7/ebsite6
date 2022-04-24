using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.ReachPayConfigs;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_PeiSong
{
    public partial class DModelAdd : UserControlBaseSave
    {

        public override string Permission
        {
            get
            {
                return "159";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }

        override protected void InitModifyCtr()
        {
            Entity.PsDelivery md = BLL.PsDelivery.Instance.GetEntity(int.Parse(SID));

            this.TbContent.Text = md.Content;
            this.ModeName.Text = md.ModeName;
            this.DropTem.SelectedValue = md.ShippingTemplatesId.ToString();
            this.IsCod.Checked = md.IsCod;
            this.IsPercent.Checked = md.IsPercent;
            this.UseMoney.Text = md.UseMoney.ToString();

            ISCodBind();

            List<EbSite.Entity.PsCompany> ls = EbSite.BLL.PsCompany.Instance.FillList();

            ChBCompanyIDs.DataValueField = "ID";
            ChBCompanyIDs.DataTextField = "CompanyName";
            ChBCompanyIDs.DataSource = ls;
            ChBCompanyIDs.DataBind();

            for (int i = 0; i < md.PsCompanyIds.Split(',').Length; i++)//给CheckBoxList选中的复选框 赋值                  { 
            {
                for (int j = 0; j < ChBCompanyIDs.Items.Count; j++)
                {
                    if (md.PsCompanyIds.Split(',')[i] == ChBCompanyIDs.Items[j].Value)
                    {
                        ChBCompanyIDs.Items[j].Selected = true;
                    }
                }
            }
        }

        override protected void SaveModel()
        {
            Entity.PsDelivery md = new PsDelivery();
            md.Content = this.TbContent.Text;
            md.ModeName = this.ModeName.Text;
            string companyids = "";
            for (int i = 0; i < ChBCompanyIDs.Items.Count; i++)
            {
                if (ChBCompanyIDs.Items[i].Selected)
                {
                    companyids += ChBCompanyIDs.Items[i].Value + ",";
                }

            }
            if (companyids.Length > 0)
                companyids = companyids.Remove(companyids.Length - 1, 1);
            md.PsCompanyIds = companyids;
            if (DropTem.SelectedValue == "-1")
            {
                base.TipsAlert("请选择运费模板");
            }
            else
            {
                md.ShippingTemplatesId = Convert.ToInt32(DropTem.SelectedValue);
                md.IsCod = Convert.ToBoolean(this.IsCod.Checked);
                if (md.IsCod)
                {
                    md.IsPercent = Convert.ToBoolean(this.IsPercent.CtrValue);
                    if (!string.IsNullOrEmpty(this.UseMoney.Text.Trim()))
                        md.UseMoney = Convert.ToDecimal(this.UseMoney.Text.Trim());

                    

                    //if (ConfigsControl.Instance.IsCod)
                    //{
                        
                    //}
                    //else
                    //{
                    //    base.TipsAlert("请到 支付管理->货到付款 中先开启。");
                    //}
                }
                if (Equals(SID, null))
                {
                    EbSite.BLL.PsDelivery.Instance.Add(md);
                }
                else
                {
                    md.id = int.Parse(SID);
                    EbSite.BLL.PsDelivery.Instance.Update(md);
                }

            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Equals(SID, null))
                {
                    List<EbSite.Entity.PsCompany> ls = EbSite.BLL.PsCompany.Instance.FillList();

                    ChBCompanyIDs.DataValueField = "ID";
                    ChBCompanyIDs.DataTextField = "CompanyName";
                    ChBCompanyIDs.DataSource = ls;
                    ChBCompanyIDs.DataBind();

                }
                List<EbSite.Entity.PsFreight> fls = EbSite.BLL.PsFreight.Instance.FillList();
                DropTem.DataTextField = "TemplateName";
                DropTem.DataValueField = "ID";
                DropTem.DataSource = fls;
                DropTem.DataBind();
                DropTem.Items.Insert(0, new ListItem("请选择运费模板", "-1"));

            }
        }

        protected void IsCod_CheckedChanged(object sender, EventArgs e)
        {
            if (IsCod.Checked)
            {
                phIsCod.Visible = true;
                if (ConfigsControl.Instance.IsCod)
                {
                    this.IsPercent.Enabled = true;
                    this.UseMoney.Enabled = true;
                }
                else
                {
                    base.TipsAlert("请到 支付管理->货到付款 中先开启。");
                     this.IsCod.Enabled = false;
                }
            }
            else
            {
                phIsCod.Visible = false;
            }
        }
        private void ISCodBind()
        {
            if (IsCod.Checked)
            {
                phIsCod.Visible = true;
            }
            else
            {
                this.phIsCod.Visible = false;
            }
        }
    }
}