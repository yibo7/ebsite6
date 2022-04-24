using System;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.GetContent
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {
            if (!Page.IsPostBack)
            {
                StringDictionary settings = GetSettings();
                if (!Equals(settings, null))
                {
                    string sType = settings["drpType"];

                    if (!string.IsNullOrEmpty(sType))
                    {
                        drpType.SelectedValue = sType;
                    }
                   
                    txtCount.Text = settings["Count"];
                    drpTem.CtrlValue = settings["TemTitle"];

                    //txtCountImg.Text = settings["CountImg"];
                    //drpTemImg.CtrlValue = settings["TemImg"];

                    //drpListModel.SelectedValue =   settings["ListModel"];

                    string sClassID = settings["ClassID"];

                    //string sIsShowNum =  settings["IsShowNum"];
                    //if (!string.IsNullOrEmpty(sIsShowNum))
                    //{
                    //    cbIsShowNum.Checked = bool.Parse(sIsShowNum);
                    //}
                    string sIsGetSub = settings["IsGetSub"];
                    if (!string.IsNullOrEmpty(sIsGetSub))
                    {
                        cbIsGetSub.Checked = bool.Parse(sIsGetSub);
                    }

                    string sIsGetSmallImg = settings["IsGetSmallImg"];
                    if (!string.IsNullOrEmpty(sIsGetSmallImg))
                    {
                        cbIsGetSmallImg.Checked = bool.Parse(sIsGetSmallImg);
                    }
                   
                    BindClass();
                    if (!string.IsNullOrEmpty(sClassID))
                    {
                        string sIsSetID =  settings["IsSetID"];
                        if(sIsSetID=="1")
                        {
                            txtIDs.Text = sClassID;
                        }
                        else
                        {
                            drpClass.SelectedValue = sClassID; 
                        }
                    }
                        


                }

            }


        }
        private void BindClass()
        {
            drpClass.DataValueField = "ID";
            drpClass.DataTextField = "ClassName";
            drpClass.DataSource = BLL.NewsClass.GetContentClassesTree(base.GetSiteID);
            drpClass.DataBind();
            
        }
        public override void Save()
        {
            base.Save();

            StringDictionary settings = GetSettings();

            string sType = drpType.SelectedValue;

            //string sListModel = drpListModel.SelectedValue;

            //settings["ListModel"] = sListModel;

            settings["drpType"] = sType;
            

            settings["Count"] = txtCount.Text;
            settings["TemTitle"] = drpTem.CtrlValue;

            //settings["CountImg"] = txtCountImg.Text;
            //settings["TemImg"] = drpTemImg.CtrlValue;
            string sClassID = string.Empty;
            if(!string.IsNullOrEmpty(txtIDs.Text.Trim()))
            {
                sClassID = txtIDs.Text.Trim();
                settings["IsSetID"] = "1";
            }
            else
            {
                sClassID = drpClass.SelectedValue;

                settings["IsSetID"] = "0";
            }
            settings["ClassID"] = sClassID;

            //settings["IsShowNum"] = cbIsShowNum.Checked.ToString();

            settings["IsGetSub"] = cbIsGetSub.Checked.ToString();

            settings["IsGetSmallImg"] = cbIsGetSmallImg.Checked.ToString();
            
            SaveSettings(settings);
        }

    }
}