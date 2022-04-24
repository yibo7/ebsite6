using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.ModelListBox
{
    public partial class Ctrl : ModelCtrlBase
    {
       
        protected string AddModelUrl = "";
        public override void LoadData()
        {
            //if (!IsPostBack)
            //{
                
                StringDictionary settings = GetSettings();
                if (settings.ContainsKey("CustomItems"))
                {
                    string sCustomItems = settings["CustomItems"];
                    foreach (string item in sCustomItems.Split(new char[] { '|' }))
                    {
                        string[] aOne = item.Split(new char[] { ',' });
                        ListItem li = new ListItem(aOne[0], aOne[1]);
                        this.drpModels.Items.Add(li);
                    }
                }
                if (settings.ContainsKey("ModelType"))
                {
                    string sSetingV = settings["ModelType"];
                    if (!string.IsNullOrEmpty(sSetingV))
                    {
                        int iType = int.Parse(sSetingV);
                        BindModelList(iType);

                        AddModelUrl = GetAddModelUrl(iType);
                    }
                    
                    
                }

            //}
        }
        private string GetAddModelUrl(int iType)
        {
            if(iType==0) //分类
            {
                return "admin_Class.aspx?t=2";
            }
            else if (iType == 1)//内容模型
            {
                return "Admin_Content.aspx?t=3";
            }
            else if (iType == 2)//用户模型
            {
                return "Admin_Member.aspx?t=8";
            }
            return "";
        }
        private void BindModelList(int  modeltype)
        {
            drpModels.DataValueField = "ID";
            drpModels.DataTextField = "ModelName";
            if (Equals(modeltype,0))//分类模型
            {
                drpModels.DataSource = BLL.ClassModel.Instance.ModelClassList;
            }
            else if (Equals(modeltype, 1))//内容模型
            {
                drpModels.DataSource = BLL.WebModel.Instance.ModelClassList;
            }
            else if (Equals(modeltype, 2))//用户模型
            {
                drpModels.DataSource = BLL.UserModel.Instance.ModelClassList;
            }
            
            drpModels.DataBind();
        }
        public override void SetValue(string sValue)
        {
            if (!string.IsNullOrEmpty(sValue))
            {
                drpModels.SelectedValue = sValue;
            }
            
            
        }

        public override string Name
        {
            get { return "ModelListBox"; }
        }

        public override string GetValue()
        {
            return drpModels.SelectedValue;
        }
    }
}