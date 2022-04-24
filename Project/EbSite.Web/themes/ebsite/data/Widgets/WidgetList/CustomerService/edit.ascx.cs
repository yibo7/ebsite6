using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.CustomerService
{
    public partial class edit : WidgetEditBase
    {
        

        public override void LoadData()
        {
                
                if (!Page.IsPostBack)
                {
                    StringDictionary settings = GetSettings();
                    if (!Equals(GetModifyID, Guid.Empty))
                    {
                        DataRow dr = SelectData(GetModifyID);
                        drpTms.SelectedValue = dr["Tms"].ToString();
                        txtServiceName.Text = dr["ServiceName"].ToString();
                        txtTmUserName.Text = dr["TmUserName"].ToString();
                        txtEmail.Text = dr["Email"].ToString();
                        bntAddOne.Text = "修改记录";
                    }

                    if (!Equals(settings, null))
                    {
                        drpThemes.SelectedValue = settings["Themes"];
                        drpFloat.SelectedValue = settings["Float"];

                        txtChatonline.Text = settings["Chatonline"];
                        if (!string.IsNullOrEmpty(settings["IsClose"]))
                        cbIsClose.Checked = bool.Parse(settings["IsClose"]);
                    }
                    BinData();
                }
        }
        
        /// <summary>
        /// 绑定数据到控件
        /// </summary>
        private void BinData()
        {


            DataTable dt = GetSettingsTable();
            if (!Equals(dt, null))
            {
                
                gvData.DataSource = dt;
                gvData.DataBind();
            }

            
        }
        /// <summary>
        /// 返回部件数据构成所需要列格式
        /// </summary>
        /// <returns></returns>
        public override List<string> InitColumns()
        {
            List<string> lst = new List<string>();
            lst.Add("Tms");
            lst.Add("ServiceName");
            lst.Add("TmUserName");
            lst.Add("Email");
            
            
            return lst;
        }

        public override void Save()
        {
            base.Save();

            StringDictionary settings = GetSettings();

            settings["Themes"] = drpThemes.SelectedValue;
            settings["Float"] = drpFloat.SelectedValue;
            settings["Chatonline"] = txtChatonline.Text.Trim();
            settings["IsClose"] = cbIsClose.Checked.ToString();
            SaveSettings(settings);

        }
        /// <summary>
        /// 关闭保存按钮，因为这里使用bntAddOne_Click来执行保存
        /// </summary>
        /// <returns></returns>
        public override bool IsDisabledSave()
        {
            return true;
        }
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bntAddOne_Click(object sender, EventArgs e)
        {
            string sTms = drpTms.SelectedValue;
            string sServiceName = txtServiceName.Text.Trim();
            string sTmUserName = txtTmUserName.Text.Trim();
            string sEmail = txtEmail.Text.Trim();
           
            List<string> lst = new List<string>();
            lst.Add(sTms);
            lst.Add(sServiceName);
            lst.Add(sTmUserName);
            lst.Add(sEmail);

            if (Equals(GetModifyID, Guid.Empty))
            {
                InsertData(lst);
            }
            else
            {
                Update(GetModifyID, lst);
            }
            Response.Redirect(sUrlToAdd);
        }


        protected void bntSave_Click(object sender, EventArgs e)
        {
            Save();
            Response.Redirect(sUrlToAdd);
        }
        
        
    }

}