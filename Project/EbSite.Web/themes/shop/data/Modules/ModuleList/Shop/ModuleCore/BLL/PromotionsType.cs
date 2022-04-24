using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.BLL.User;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.ModuleCore.BLL
{
    #region 促销类型

    public enum EPromotionsType
    {
        满额打折= 1,
        买几送几= 2,
        满额免费用= 3,
        批发打折= 4
    }
	/// <summary>
	/// 促销类型
	/// </summary>
    public class PromotionsType
	{
        static public List<ListItemModel> GetPromotionsTypes()
		{
            List<ListItemModel> lst = new List<ListItemModel>();
            ListItemModel md = new ListItemModel("1", "满额打折", "1");
            lst.Add(md);
            md = new ListItemModel("2", "买几送几", "2");
            lst.Add(md);
            md = new ListItemModel("3", "满额免费用", "3");
            lst.Add(md);
            md = new ListItemModel("4", "批发打折", "4");
            lst.Add(md);
            return lst;
		}
        static public ListItemModel GetPromotionsType(string ID)
        {
            List<ListItemModel> lst = GetPromotionsTypes();
            foreach (ListItemModel md in lst)
            {
                if (md.ID.Equals(ID))
                    return md;
                
            }
            return null;
        }
        static public string GetPromotionsTypeName(string ID)
        {
            ListItemModel md = GetPromotionsType(ID);
            if(!Equals(md,null))
            {
                return md.Text;
            }

            return "";
        }
	}

    #endregion 促销类型

    #region 用户等级类型

    //public enum EPromotionUserLevel
    //{ 
    //    普通会员=1,
    //    高级会员=2,
    //    VIP会员=3
    //}
    /// <summary>
    /// 用户等级类型
    /// </summary>
    public class PromotionUserLevelType
    {
        static public List<ListItemModel> GetPromotionUserLevelTypes()
        {
            List<UserGroupProfile> lsGroup=   UserGroupProfile.UserGroupProfiles;

            List<ListItemModel> lst = new List<ListItemModel>();

            foreach (var li in lsGroup)
            {
                ListItemModel md = new ListItemModel(li.Id.ToString(), li.GroupName, li.Id.ToString());
                lst.Add(md);
            }
            
            return lst;
        }
        static public ListItemModel GetPromotionUserLevelType(string ID)
        {
            List<ListItemModel> lst = GetPromotionUserLevelTypes();
            foreach (ListItemModel md in lst)
            {
                if (md.ID.Equals(ID))
                    return md;

            }
            return null;
        }
        static public string GetPromotionUserLevelTypeName(string ID)
        {
            ListItemModel md = GetPromotionUserLevelType(ID);
            if (!Equals(md, null))
            {
                return md.Text;
            }

            return "";
        }
    }

    #endregion 用户等级类型

    #region 订单免费项目

    public enum EPromotionFreeItem
    {
        运费=1,
        订单可选项产生的费用=2,
        支付手续费=3
    }
    /// <summary>
    /// 用户等级类型
    /// </summary>
    public class PromotionFreeItemType
    {
        static public List<ListItemModel> GetPromotionFreeItemTypes()
        {
            List<ListItemModel> lst = new List<ListItemModel>();
            ListItemModel md = new ListItemModel("1", "运费", "1");
            lst.Add(md);
            md = new ListItemModel("2", "订单可选项产生的费用", "2");
            lst.Add(md);
            md = new ListItemModel("3", "支付手续费", "3");
            lst.Add(md);
            return lst;
        }
        static public ListItemModel GetPromotionFreeItemType(string ID)
        {
            List<ListItemModel> lst = GetPromotionFreeItemTypes();
            foreach (ListItemModel md in lst)
            {
                if (md.ID.Equals(ID))
                    return md;

            }
            return null;
        }
        static public string GetPromotionFreeItemTypeName(string ID)
        {
            ListItemModel md = GetPromotionFreeItemType(ID);
            if (!Equals(md, null))
            {
                return md.Text;
            }

            return "";
        }
    }

    #endregion 订单免费项目
}

