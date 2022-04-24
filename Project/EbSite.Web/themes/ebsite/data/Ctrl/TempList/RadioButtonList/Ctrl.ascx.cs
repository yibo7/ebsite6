using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Core;
using EbSite.Base.ExtWidgets.ModelCtr;

namespace EbSite.ExtensionsCtrls.RadioButtonList
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
                         rbList.Items.Add(li);
                     }
                 }
                    int iNum = 0;
                 if (settings.ContainsKey("RepeatColumns"))
                 {

                     iNum = Core.Utils.StrToInt(settings["RepeatColumns"]);
                     if (iNum>0)
                         rbList.RepeatColumns = iNum;
                 }
                 if (settings.ContainsKey("Width"))
                 {
                     iNum = Utils.StrToInt(settings["Width"]);
                     if (iNum > 0)
                         rbList.Width = iNum;
                 }
                 if (settings.ContainsKey("Heigth"))
                 {
                     iNum = Utils.StrToInt(settings["Heigth"]);
                     if (iNum > 0)
                         rbList.Width = iNum;
                 }
                 if (settings.ContainsKey("DefaultSelect"))
                 {

                     rbList.SelectedValue = settings["DefaultSelect"];
                 }
            

            //}
        }
        public override string Name
        {
            get { return "RadioButtonList"; }
        }
        /// <summary>
        /// 设置列表控件项的值
        /// </summary>
        /// <param name="sValue">每个项的值</param>
        public override void SetValue(string sValue)
        {
            rbList.SelectedValue = sValue;
        }
        /// <summary>
        /// 获取列表控件项的值
        /// </summary>
        /// <returns></returns>
        public override string GetValue()
        {
            return rbList.SelectedValue;
        }
    }
}