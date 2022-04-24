using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.Modules.Wenda.ModuleCore.Entity;

namespace EbSite.Modules.Wenda.AdminPages.Controls.ImitatePost
{
    public partial class PostUserAdd : MPUCBaseSave
    {
        public override string PageName
        {
            get
            {
                return "模拟发帖用户添加";
            }
        }
        public override string Permission
        {
            get
            {
                return "33";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }

        override protected void InitModifyCtr()
        {

           

        }


        override protected void SaveModel()
        {
            if ( !string.IsNullOrEmpty(txtUserInfo2.UserID))
            {
               
                // 要先检测  不能存在  主用户ID, UserNameField 不能存在重复项
                string[] strArryIDS = txtUserInfo2.UserID.Split(',');
                string[] strArryNames = txtUserInfo2.UserName.Split(',');
                string[] strArryNis = txtUserInfo2.UserNiName.Split(',');
                for (int i = 0; i < strArryIDS.Length;i++ )
                {
                    ModuleCore.Entity.PostUser md = new PostUser();
                    md.UserID = int.Parse(strArryIDS[i]);
                    md.UserName = strArryNames[i];
                    md.UserNiName = strArryNis[i];
                    ModuleCore.BLL.PostUserControl.Instance.Add(md);
                }

                   
                
            }
        }
    }
}