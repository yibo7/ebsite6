using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.BLL;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.SpecialListBox
{
    public partial class Ctrl : ModelCtrlBase
    {
        public override string GetValue()
        {
            return this.drpClassList.SelectedValue;
        }

        public override void LoadData()
        {
            StringDictionary settings = base.GetSettings();
            if (settings.ContainsKey("CustomItems"))
            {
                string sCustomItems = settings["CustomItems"];
                foreach (string item in sCustomItems.Split(new char[] { '|' }))
                {
                    string[] aOne = item.Split(new char[] { ',' });
                    ListItem li = new ListItem(aOne[0], aOne[1]);
                    this.drpClassList.Items.Add(li);
                }
            }
            string sValueRule = "";
            string sTextRule = "";
            if (settings.ContainsKey("ValueRule"))
            {
                sValueRule = settings["ValueRule"];
                
            }
            if (settings.ContainsKey("TextRule"))
            {
                sTextRule = settings["TextRule"];
            }

            if (settings.ContainsKey("Onchange"))
            {
                string sOnchange  = settings["Onchange"];

                if(!string.IsNullOrEmpty(sOnchange))
                {

                    drpClassList.Attributes.Add("onchange", sOnchange);
                }
            }
            
            
            if (settings.ContainsKey("ClassNum"))
            {
                int iClassNum = int.Parse(settings["ClassNum"]);

                List<Entity.SpecialClass> lst = SpecialClass.GetListArr(iClassNum,EbSite.Base.Host.Instance.GetSiteID);
                foreach (Entity.SpecialClass md in lst)
                {

                    string sText = md.SpecialName;
                    string sValue = md.id.ToString();

                    if (!string.IsNullOrEmpty(sTextRule)) sText = string.Format(sTextRule, sValue, sText);
                    if (!string.IsNullOrEmpty(sValueRule)) sValue = string.Format(sValueRule, sValue, sText);

                    ListItem li = new ListItem(sText, sValue);
                    
                    this.drpClassList.Items.Add(li);
                }
                //this.drpClassList.DataValueField = "ID";
                //this.drpClassList.DataTextField = "ClassName";
                //this.drpClassList.DataSource = 
                //this.drpClassList.DataBind();
            }
        }

        

        public override void SetValue(string sValue)
        {
            //string Themes = "";
            //Themes = EbSite.BLL.Sites.Instance.GetEntity(GetSiteID).PageTheme;
            if (!string.IsNullOrEmpty(sValue) && TempFactory.Instance.IsHaveTem(new Guid(sValue)))
            {
                this.drpClassList.SelectedValue = sValue;
            }
        }

        public override string Name
        {
            get
            {
                return "SpecialListBox";
            }
        }
    }
}