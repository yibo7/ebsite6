using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.Controls.Admin_Special
{
    public partial class DataInit : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            drpTemPc.DataValueField = "ID";
            drpTemPc.DataTextField = "TemName";
            drpTemPc.DataSource = TempFactory.Instance.GetListByType(3);
            drpTemPc.DataBind();
        }
        /// <summary>
        /// 修改 PC 页面模板 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSpecialPcTem_Click(object sender, EventArgs e)
        {
            string sSID = drpPcSoure.Value;
            string sTem = drpTemPc.CtrValue;
            int SelID = int.Parse(sSID);
            if (SelID > 0)
            {
                string IDS = EbSite.BLL.SpecialClass.GetSubIDs(SelID, base.GetSiteID);
                if (!string.IsNullOrEmpty(IDS))
                {
                    IDS = string.Concat(IDS, ",", SelID);
                }
                else
                {
                    IDS = SelID.ToString();
                }
              
                EbSite.BLL.SpecialClass.SpecialClass_Update("id in(" + IDS + ")", "SpecialTemID", "'" + sTem + "'");
            }
            else
            {
                Tips("请选择专题","请选择想要更换模板的专题！");
            }
           

        }
        /// <summary>
        /// 修改 手机版 页面模板 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSpecialMobileTem_Click(object sender, EventArgs e)
        {
            string sSID = drpMobileSoure.Value;
            string sTem = drpTemMobile.CtrValue;

            string IDS = EbSite.BLL.SpecialClass.GetSubIDs(int.Parse(sSID), base.GetSiteID);

            EbSite.BLL.SpecialClass.SpecialClass_Update("id in(" + IDS + ")", "SpecialTemIDMobile", "'" + sTem + "'");
        }

        protected void bntAddSpecial_Click(object sender, EventArgs e)
        {
            string sCoumnName = txtSp_ContentFiled.Text.Trim();
            int iTY = int.Parse(drpSp_Where.SelectedValue);
            BLL.SpecialNews.AddFormContentColumn(sCoumnName, iTY, base.GetSiteID);
        }
        protected void bntClassToDefault_Click(object sender, EventArgs e)
        {
            //未完成
            //BLL.NewsClass.ClassToDefault();
        }
        protected void bntClassResetOrderID_Click(object sender, EventArgs e)
        {
            BLL.SpecialClass.ResetOrderID_Start(base.GetSiteID);
        }

        protected void bntAddSpecialDet_Click(object sender, EventArgs e)
        {
            string sCoumnName = txtAnyName.Text.Trim();//内容表中任意字段名称
            int iTY = int.Parse(drp_Sw.SelectedValue);//
            string key = txtKey.Text.Trim();
            int specialID = int.Parse(slSpecialID.Value);

            BLL.SpecialNews.AddFormContentToSpecial(sCoumnName, iTY, key, specialID, base.GetSiteID);
        }

    }
}