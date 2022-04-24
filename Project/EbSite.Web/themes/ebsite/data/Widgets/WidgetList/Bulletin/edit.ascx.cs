using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.Bulletin
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
                    txtInfo.Text = dr["Info"].ToString();
                    
                    bntAddOne.Text = "修改记录";
                }

                StringDictionary settings = GetSettings();
                if (!Equals(settings, null))
                {
                    txtCount.Text = settings["txtCount"];
                    drpTemMoreList.CtrlValue = settings["txtTem"];
                    
                }

                BinData();
            }


        }
        private void BinData()
        {
            DataTable dt = GetSettingsTable();
            if (!Equals(dt, null))
            {

                gvData.DataSource = dt;
                gvData.DataBind();
            }


        }
        public override List<string> InitColumns()
        {
            List<string> lst = new List<string>();
            lst.Add("Title");
            lst.Add("Info");
            return lst;
        }
        /// <summary>
        /// 关闭保存按钮，因为这里使用bntAddOne_Click来执行保存
        /// </summary>
        /// <returns></returns>
        public override bool IsDisabledSave()
        {
            return true;
        }
        protected void bntSave_Click(object sender, EventArgs e)
        {
            Save();
            Response.Redirect(sUrlToAdd);
        }
        protected void bntAddOne_Click(object sender, EventArgs e)
        {
            List<string> lst = new List<string>();
            string sTitle = txtTitle.Text.Trim();
            lst.Add(sTitle);
            string sInfo = txtInfo.Text.Trim();
            lst.Add(sInfo);
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

        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();
            settings["txtCount"] = txtCount.Text;
            settings["txtTem"] = drpTemMoreList.CtrlValue;
            
            SaveSettings(settings);
        }

    }
}