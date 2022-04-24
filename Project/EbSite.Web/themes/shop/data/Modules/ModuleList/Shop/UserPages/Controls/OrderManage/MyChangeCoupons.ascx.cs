using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base;
using EbSite.Base.Modules;
using EbSite.Modules.Shop.ModuleCore;
using EbSite.Modules.Shop.ModuleCore.Entity;

namespace EbSite.Modules.Shop.UserPages.Controls.OrderManage
{
    public partial class MyChangeCoupons : MPUCBaseListForUserRp
    {

        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("7b48f9a0-c6da-4267-bc48-c3036f6813fc");
            }
        }
        /// <summary>
        /// 查询分类ID
        /// </summary>
        protected int ClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["tid"]))
                {
                    return int.Parse(Request.QueryString["tid"]);
                }
                else
                {
                    return 0;
                }
            }
        }
        public override string PageName
        {
            get
            {

                return "积分兑换优惠券";
            }
        }
        /// <summary>
        /// 是否添加到管理页面菜单之中
        /// </summary>
        public override bool IsAddToAdminMenus
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// 此权限ID不为空，将要求用户登录后才能访问此页面
        /// </summary>
        public override string Permission
        {
            get
            {
                return "4";
            }
        }
       

      
        override protected object LoadList(out int iCount)
        {
            return EbSite.BLL.Coupons.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, "NeedPoint>0 and EndDateTime>'" + DateTime.Now + "' ", "", out iCount);
            
        }

        override protected object SearchList(out int iCount)
        {

           
            iCount = 0;
            return null;

        }
       
        override protected void Delete(object iID)
        {

        }

        #region 
        protected void gdList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                if (e.CommandName == "ExChangeModel")
                {
                    string id = e.CommandArgument.ToString();
                    
                    int iScore = EbSite.Base.Host.Instance.GetUserCreditsByID(base.UserID);
                    EbSite.Entity.Coupons md = EbSite.BLL.Coupons.Instance.GetEntity(EbSite.Core.Utils.StrToInt(id, 0));
                    if (!Equals(md, null))
                    {
                        //兑换 1.检测用户的总积分
                        if (iScore < md.NeedPoint)
                        {
                            TipsAlert("当前积分不够兑换此优惠券");
                        }
                        else
                        {
                            //开始兑换 
                            Guid gid = Guid.NewGuid();
                            Entity.CouponItems mditem = new Entity.CouponItems();
                            mditem.CouponId = Core.Utils.StrToInt(id, 0);
                            mditem.LotNumber = gid.ToString();
                            mditem.ClaimCode = Core.Strings.GetString.RandomNUMSTR(15);
                            mditem.AddDateTime = DateTime.Now;
                            mditem.UserId = base.UserID;
                            
                            BLL.CouponItems.Instance.Add(mditem);

                            //更新 主表中的总券数量
                            md.SentCount += 1;
                            md.Update();

                            //总积分减去 兑换的积分
                            EbSite.Base.Host.Instance.MinusUserCreditsByID(base.UserID, md.NeedPoint);


                            //写入积分日志 yhl 2013-12-12
                            ModuleCore.Entity.pointdetails pointModel = new pointdetails();

                            pointModel.UserId = EbSite.Base.Host.Instance.UserID;
                            pointModel.TradeType = Convert.ToInt32(SystemEnum.MyPointType.兑换优惠券);
                            pointModel.Increased = 0;
                            pointModel.Reduced = md.NeedPoint;
                            pointModel.Points = iScore - md.NeedPoint;
                            pointModel.TradeDate = DateTime.Now;
                            pointModel.OrderId = 0;
                            ModuleCore.BLL.pointdetails.Instance.Add(pointModel);

                            TipsAlert("兑换成功，请查看您的优惠券");
                        }
                    }
                    
                    gdList_Bind();
                }
            }
        }
        #endregion

        #region 工具栏的初始化
      

     
        override protected void BindToolBar()
        {

            base.BindToolBar(true, true);
          
        }
        #endregion

      
         protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Equals(gdList, null))
            // {
            //     this.gdList.ItemCommand += new RepeaterCommandEventHandler(this.gdList_ItemCommand);
            // }
        }
            
    }
}