using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.WinBox
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {

                
                if (!Page.IsPostBack)
                {
                    
                    if (!Equals(GetModifyID, Guid.Empty))
                    {
                        DataRow dr = SelectData(GetModifyID);

                        txtTitle.Text = dr["Title"].ToString();
                        txtUrl.Text= dr["Url"].ToString();
                        txtUrlPic.Text = dr["UrlPic"].ToString(); ;

                        bntAddOne.Text = "修改记录";
                    }

                    StringDictionary settings = GetSettings();
                    if (!Equals(settings, null))
                    {

                        drpTem.SelectedValue = settings["Tem"] ;
                        drpType.SelectedValue = settings["Type"];
                        drpGroup.SelectedValue = settings["Group"];
                        txtWindowsTitle.Text = settings["WindowsTitle"];

                        txtWidth.Text = settings["Width"];
                        txtHeight.Text = settings["Height"];

                        if (!string.IsNullOrEmpty(settings["IsFull"]))
                        {
                            cbIsFull.Checked = bool.Parse(settings["IsFull"]);
                        }
                        

                        if(!string.IsNullOrEmpty(settings["HrefModel"]))
                        {
                            string sHf = settings["HrefModel"];
                            drpHrefModel.SelectedValue = sHf;
                            if(sHf=="2")
                            {
                                trUrlPic.Visible = true;
                            }
                            else
                            {
                                trUrlPic.Visible = false;
                            }
                        }
                        
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
            lst.Add("Title");
            lst.Add("Url");
            lst.Add("UrlPic");

            
            return lst;
        }

        public override void Save()
        {
            base.Save();

            StringDictionary settings = GetSettings();

            settings["Tem"] = drpTem.SelectedValue;
            settings["Type"] = drpType.SelectedValue;
            settings["Group"] = drpGroup.SelectedValue;
            settings["HrefModel"] = drpHrefModel.SelectedValue;
            settings["WindowsTitle"] = txtWindowsTitle.Text;
            settings["IsFull"] = cbIsFull.Checked.ToString();
            settings["Width"] = txtWidth.Text;
            settings["Height"] = txtHeight.Text.Trim();
            
            
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
            string sTitle = txtTitle.Text.Trim();
            string sUrl = txtUrl.Text.Trim();
            string sUrlPic = txtUrlPic.Text.Trim();

            List<string> lst = new List<string>();
            lst.Add(sTitle);
            lst.Add(sUrl);
            lst.Add(sUrlPic);
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