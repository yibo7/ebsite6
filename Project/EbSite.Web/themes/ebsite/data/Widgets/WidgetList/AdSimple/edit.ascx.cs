using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.Simple
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                List<Entity.CtrTemList> lst = BLL.Ctrtem.TemListInstace.TemBll(GetSiteID).SelectCtrTemLists_ByClassID(new Guid("90ec0970-ba39-49aa-b6a1-5d9182523216"));
                drCustomTem.DataTextField = "Title";
                drCustomTem.DataValueField = "ID";
                drCustomTem.DataSource = lst;
                drCustomTem.DataBind();

                BinData();
                
                 if(!Equals(GetModifyID,Guid.Empty))
                {
                   DataRow dr =  SelectData(GetModifyID);

                    txtImg.CtrValue = dr["imgpth"].ToString();
                    txtUrl.Text = dr["url"].ToString();
                    txtTitle.Text = dr["txttitle"].ToString();
                    txtInfo.Text = dr["info"].ToString();
                    txtPram1.Text = dr["pram1"].ToString();
                    txtPram2.Text = dr["pram2"].ToString();


                    bntAddOne.Text = "修改记录";

                   
                }
                

                StringDictionary settings = GetSettings();
                if (!Equals(settings, null))
                {
                    txtWidth.Text = settings["width"];

                    txtHeith.Text = settings["heith"];

                    rblLinkType.SelectedIndex =Core.Utils.StrToInt(settings["LinkType"],0);
                    //if(DataCount>0)
                    //    rblLinkType.Enabled = false;

                    drCustomTem.SelectedValue = settings["CustomTem"];
                }


                if (!string.IsNullOrEmpty(Request["lt"]))
                {
                    rblLinkType.SelectedIndex = Core.Utils.StrToInt(Request["lt"], 0);
                }
                
                rblLinkType_SelectedIndexChanged(null, null);
            }
           


        }

        //private int DataCount = 0;
        public void  BinData()
        {
            //gvData.RowCreated += new GridViewRowEventHandler(gvData_RowCreated);
            DataTable dt = GetSettingsTable();
            if (!Equals(dt, null))
            {
                //DataCount = dt.Rows.Count;
                gvData.DataSource = dt;
                gvData.DataBind();
            }

        }
        //void gvData_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow ||
        //        e.Row.RowType == DataControlRowType.Header)
        //    {
        //        e.Row.Cells[0].Visible = false;  
        //    }
            
        //}
        public override List<string> InitColumns()
        {
            List<string> lst = new List<string>();
            lst.Add("imgpth");
            lst.Add("url");
            lst.Add("txttitle");
            lst.Add("Info");
            lst.Add("Pram1");
            lst.Add("Pram2"); 

            return lst;
        }

        public override void Save()
        {
            base.Save();
            StringDictionary settings = GetSettings();

            settings["width"] = txtWidth.Text;
            settings["heith"] = txtHeith.Text;
            settings["LinkType"] = rblLinkType.SelectedIndex.ToString();
            settings["CustomTem"] = drCustomTem.SelectedValue;
            
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
            string sPath = txtImg.CtrValue.Trim();
            string sUrl = txtUrl.Text.Trim();
            string sTitle = txtTitle.Text.Trim();
            string sInfo = txtInfo.Text.Trim();
            string sPram1 = txtPram1.Text.Trim();
            string sPram2 = txtPram2.Text.Trim();


            List<string> lst = new List<string>();
            lst.Add(sPath);
            lst.Add(sUrl);
            lst.Add(sTitle);
            lst.Add(sInfo);
            lst.Add(sPram1);
            lst.Add(sPram2);

            if (Equals(GetModifyID, Guid.Empty))
            {
                InsertData(lst);
            }
            else
            {
                Update(GetModifyID, lst);
            }

            Response.Redirect(string.Concat(sUrlToAdd,"&lt=", rblLinkType.SelectedIndex));
        }

        protected void rblLinkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblLinkType.SelectedIndex == 0)
            {
                phTitle.Visible = false;
                phImg.Visible = true;
                phImgWH.Visible = true;
            }
            else
            {
                phTitle.Visible = true;
                phImg.Visible = false;
                phImgWH.Visible = false;
            }
        }
    }
}