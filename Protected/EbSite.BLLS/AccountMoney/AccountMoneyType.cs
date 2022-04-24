using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Entity;

namespace EbSite.BLL
{
    public enum EAccountMoneyType
    {
        ZDCZ=1,//自助充值
        HTJK =2,//后台加款
        XF =3,//消费
        TX =4,//提现
        DDTK =5,//订单退款
        TJRTC =6,//推荐人提成
        TXWC = 7 //提现完成

    }
	/// <summary>
	/// 业务逻辑类AccountMoneyLog 的摘要说明。
	/// </summary>
    public class AccountMoneyType
	{

        static public List<Entity.ListItemModel> GetAccountMoneyTypes()
		{
            List<Entity.ListItemModel> lst = new List<ListItemModel>();
            ListItemModel md = new ListItemModel("1", "自助充值","");
            lst.Add(md);
            md = new ListItemModel("2", "后台加款", "");
            lst.Add(md);
            md = new ListItemModel("3", "消费", "");
            lst.Add(md);
            md = new ListItemModel("4", "提现", "");
            lst.Add(md);
            md = new ListItemModel("5", "订单退款", "");
            lst.Add(md);
            md = new ListItemModel("6", "推荐人提成", "");
            lst.Add(md);
            md = new ListItemModel("7", "提现完成","");
            lst.Add(md);
            return lst;
		}
        /// <summary>
        /// 管理员 后台 调用
        /// </summary>
        /// <returns></returns>
        static public List<Entity.ListItemModel> GetAccountMoneyTypesHt()
        {
            List<Entity.ListItemModel> lst = new List<ListItemModel>();
            ListItemModel md = new ListItemModel("2", "后台加款", "");
            lst.Add(md);
           
            md = new ListItemModel("5", "订单退款", "");
            lst.Add(md);
            
            return lst;
        }
        static public Entity.ListItemModel GetAccountMoneyType(string ID)
        {
            List<Entity.ListItemModel> lst = GetAccountMoneyTypes();
            foreach (ListItemModel md in lst)
            {
                if (md.ID.Equals(ID))
                    return md;
                
            }
            return null;
        }
        static public string GetAccountMoneyTypeName(string ID)
        {
            ListItemModel md = GetAccountMoneyType(ID);
            if(!Equals(md,null))
            {
                return md.Text;
            }

            return "";
        }



	}
}

