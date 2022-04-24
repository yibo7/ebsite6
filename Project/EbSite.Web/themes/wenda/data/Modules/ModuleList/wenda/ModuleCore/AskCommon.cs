using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Modules.Wenda.ModuleCore.Entity;


namespace EbSite.Modules.Wenda.ModuleCore
{
    public class AskCommon
    {
        static public string GetUserName(string id)
        {
            var theValue = EbSite.Base.Host.Instance.EBMembershipInstance.Users_GetEntity(int.Parse(id));
            if (!Equals(null, theValue)) return theValue.UserName;
            else return "未知";
        }
        static public int GetUserScore(string id)
        {
            var theValue = EbSite.Base.Host.Instance.EBMembershipInstance.Users_GetEntity(int.Parse(id));
            if (!Equals(null, theValue)) return theValue.Credits;
            else return 0;
        }
        static public string GetCutAskTitle(string id)
        {
            return id.Length > 20 ? id.Substring(0, 20) + "..." : id;
        }
        static public string GetCutAskTitle(string id,int length)
        {
            return id.Length > length ? id.Substring(0, length) + "..." : id;
        }

        static public string GetAskByID(string id)
        {
            var entity = Base.AppStartInit.NewsContentInstDefault.GetModelDefaultFiled(int.Parse(id));
            if(null != entity)
            {
                string name = entity.NewsTitle;

                if (null != name)
                {
                    return name.Length > 20 ? name.Substring(0, 20) + "..." : name;
                }
                else
                {
                    return "问题未找到";
                }
            }
            else
            {
                return "问题未找到";
            }
            
        }

        static public string GetAskStatu(int id)
        {
            string s = "";
            switch(id)
            {
                case 1:
                   
                    s = " <span style='color:red;'>未解决</span>";
                    break;
                case 2:
                    s = "<span style='color:#65ae1c;'>已解决</span>";
                    break;
                case 3:
                    s = "<span style='color:#4557e1;'>已关闭</span>";
                    break;
                default:
                    s = "未知";
                    break;
            }
            return s;
        }
        static public string GetDelText(string id)
        {
            string s = "";
            switch (id)
            {
                case "0":
                    s = "否";
                    break;
                case "1":
                    s = "是";
                    break;
                default:
                    s = "未知";
                    break;
            }
            return s;
        }
        static public string GetAskCheck(string id)
        {
            string s = "";
            if (!string.IsNullOrEmpty(id))
            {
                switch (id)
                {
                    case "0":
                        s = "<span style='color:red;'> 未审核</span>";
                        break;
                    case "1":
                        s = "已审核";
                        break;

                }
            }
            return s;
        }
        static public string GetBoolText(bool b)
        {
            return b == true ? "<span style='color:red;'> 是</span>" : "<span style='color:#008000;'>否</span>";

            //ConfigControl.GetInstance.
        }

        static public bool InitUserInfo(int uid)
        {
            ModuleCore.Entity.UserHelp uh = new UserHelp();
            uh.UserID = uid;
            uh.QCount = 0;
            uh.ACount = 0;
            uh.AdoptionCount = 0;
            uh.LikeAskClass = "";
            uh.TotalScore = 20;  //预先假定给20分

            int i= ModuleCore.BLL.UserHelp.Instance.Add(uh);
            return i > 0 ? true : false;
        }

        static public int GetRandNum()
        {
            int min = 1;
            int max = 1000;
            Random a = new Random();
            int result = a.Next(min, max);

            return result;

        }
       
    }
}