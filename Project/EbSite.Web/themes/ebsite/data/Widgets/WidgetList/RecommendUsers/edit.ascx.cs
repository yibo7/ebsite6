using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using EbSite.Base.ExtWidgets.WidgetsManage;

namespace EbSite.Widgets.RecommendUsers
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
                    txtCount.Text = settings["txtCount"];
                    drpTem.CtrlValue = settings["txtTem"];       
                }

            }


        }
       
        public override void Save()
        {
           
            // 要先检测 删除
            List<RecommendUsers> ls = RecommendUsersControl.Instance.FillList();
            foreach (var recommendUserse in ls)
            {
                RecommendUsersControl.Instance.Delete(recommendUserse.id);
            }

            if (!string.IsNullOrEmpty(txtUserInfo2.UserID))
            {
                base.Save();

                StringDictionary settings = GetSettings();

                //string sType = cblClass.SelectedValue;

                settings["txtCount"] = txtCount.Text;
                settings["txtTem"] = drpTem.CtrlValue;
            


                string[] strArryIDS = txtUserInfo2.UserID.Split(',');
                string[] strArryNames = txtUserInfo2.UserName.Split(',');
                string[] strArryNis = txtUserInfo2.UserNiName.Split(',');
                for (int i = 0; i < strArryIDS.Length; i++)
                {
                    RecommendUsers md = new RecommendUsers();
                    md.UserID = int.Parse(strArryIDS[i]);
                    md.UserName = strArryNames[i];
                    md.UserNiName = strArryNis[i];
                    RecommendUsersControl.Instance.Add(md);
                }
                SaveSettings(settings);
            }
           
        }

    }
}