using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Core;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.ListBox
{
    public partial class Ctrl : ModelCtrlBase
    {

        public override void LoadData()
        {
            //if(!IsPostBack)
            //{

                 StringDictionary settings = GetSettings();
                 if (settings.ContainsKey("Items"))
                 {
                     string sDroItem = settings["Items"];

                     string[] aItem = sDroItem.Split('\n');

                     foreach (string s in aItem)
                     {
                         string sv = s.Replace("\r", "");
                         ListItem li = new ListItem(sv, sv);
                         lbList.Items.Add(li);
                     }
                 }
                    int iNum = 0;
                    if (settings.ContainsKey("SelectionMode"))
                 {

                     iNum = Core.Utils.StrToInt(settings["SelectionMode"]);
                     if (iNum==0)
                     {
                         lbList.SelectionMode = ListSelectionMode.Single;
                     }
                     else
                     {
                         lbList.SelectionMode = ListSelectionMode.Multiple;
                     }

                         
                 }
                 if (settings.ContainsKey("Width"))
                 {
                     iNum = Utils.StrToInt(settings["Width"]);
                     if (iNum > 0)
                         lbList.Width = iNum;
                 }
                 if (settings.ContainsKey("Heigth"))
                 {
                     iNum = Utils.StrToInt(settings["Heigth"]);
                     if (iNum > 0)
                         lbList.Width = iNum;
                 }
                 if (settings.ContainsKey("DefaultSelect"))
                 {

                     SetValue(settings["DefaultSelect"]);
                 }

            //}
        }
        public override string Name
        {
            get { return "ListBox"; }
        }
        /// <summary>
        /// 设置列表控件项的值
        /// </summary>
        /// <param name="sValue">每个项的值，用逗号分开</param>
        public override void SetValue(string sValue)
        {
            ControlManage.SetItemsList(lbList.Items, sValue);
        }
        /// <summary>
        /// 获取列表控件项的值,用逗号分开
        /// </summary>
        /// <returns></returns>
        public override string GetValue()
        {
            return ControlManage.GetItemsListOfString(lbList.Items);
        }
    }
}