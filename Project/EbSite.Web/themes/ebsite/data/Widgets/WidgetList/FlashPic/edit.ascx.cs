using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.FlashPic
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                BinData();

                if(!Equals(GetModifyID,Guid.Empty))
                {
                   DataRow dr =  SelectData(GetModifyID);

                    txtPath.CtrValue = dr["flashpath"].ToString();
                    txtUrl.Text = dr["url"].ToString();

                    bntAddOne.Text = "修改记录";
                }

                StringDictionary settings = GetSettings();
                if (!Equals(settings, null))
                {
                    txtWidth.Text = settings["width"];

                    txtHeith.Text = settings["heith"];

                }
            }
            

        }
        public void  BinData()
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
            lst.Add("flashpath");
            lst.Add("url");
            return lst;
        }

        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();

            settings["width"] = txtWidth.Text;
            settings["heith"] = txtHeith.Text;

            SaveSettings(settings);

        }
        /// <summary>
        /// 关闭保存按钮，因为这里使用bntAddOne_Click来执行保存
        /// </summary>
        /// <returns></returns>
        //public override bool IsDisabledSave()
        //{
        //    return true;
        //}

        protected void bntAddOne_Click(object sender, EventArgs e)
        {
            string sPath = txtPath.CtrValue.Trim();
            string sUrl = txtUrl.Text.Trim();
            
            List<string> lst = new List<string>();
            lst.Add(sPath);
            lst.Add(sUrl);
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

        
    }
}