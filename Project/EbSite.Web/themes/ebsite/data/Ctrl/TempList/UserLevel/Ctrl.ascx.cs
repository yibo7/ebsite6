using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Core;
using EbSite.Base.ExtWidgets.ModelCtr;
using System.Collections.Generic;
using EbSite.BLL.User;
using EbSite.BLL;
using System.Data;

namespace EbSite.ExtensionsCtrls.UserLevel
{
    public partial class Ctrl : ModelCtrlBase
    {

        public override void LoadData()
        {
            //flz
            StringDictionary settings = GetSettings();
            string sDroItem = "", showModel = "", isMC = "";
            if (settings.ContainsKey("UserDataSourceType"))
            {
                sDroItem = settings["UserDataSourceType"];
            }
            if (settings.ContainsKey("UserShowModel"))
            {
                showModel = settings["UserShowModel"];
            }
            if (settings.ContainsKey("IsMustChoose"))
            {
                isMC = settings["IsMustChoose"];
            } 
            //设置单选还是多选
            if (showModel.Equals("0"))
            {
                lbList.SelectionMode = ListSelectionMode.Single;
                lbList.Rows = 1;
            }
            else
            {
                lbList.SelectionMode = ListSelectionMode.Multiple;
                lbList.Rows = 5;
            }
            //获取数据源
            switch (sDroItem)
            { 
                case "0":
                    //会员组
                    List<UserGroupProfile> s = UserGroupProfile.UserGroupProfiles;
                    lbList.DataTextField = "groupname";
                    lbList.DataValueField = "id";
                    lbList.DataSource = s;
                    lbList.DataBind();
                    break;
                case "1":
                    //会员级别
                    List<Entity.UserLevel> u= EbSite.BLL.UserLevel.Instance.GetListArray("");
                    if (u != null && u.Count > 0)
                    {
                        lbList.DataTextField = "LevelName";
                        lbList.DataValueField = "id";
                        lbList.DataSource = u;
                        lbList.DataBind();
                    }
                    break;
                case "2":
                    //管理员角色
                    DataSet d=AccountsTool.GetRoleList();
                    if (d != null && d.Tables.Count> 0)
                    {
                        lbList.DataTextField = "description";
                        lbList.DataValueField = "roleid";
                        lbList.DataSource = d;
                        lbList.DataBind();
                    }
                    break;
            }
            if (isMC.Equals("0"))
            {
                lbList.Items.Insert(0, new ListItem("全部", "0"));
            }
        }
        public override string Name
        {
            get { return "UserLevel"; }
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