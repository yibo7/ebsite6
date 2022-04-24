using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbSite.Modules.Wenda.ModuleCore
{
    public class GetLinks
    {
        #region PC
        public static string AskHot(int siteid)
        {
            return string.Format("{0}askhot-{1}.ashx", EbSite.Base.Host.Instance.IISPath, siteid);
        }
        public static string AskClassUrl(int siteid)
        {
            return string.Format("{0}askclasslist-{1}.ashx", EbSite.Base.Host.Instance.IISPath, siteid);
        }
        public static string AskPost(int siteid)
        {
            return string.Format("{0}askpost-{1}.ashx", EbSite.Base.Host.Instance.IISPath, siteid);
        }
        /// <summary>
        /// 上榜达人
        /// </summary>
        /// <param name="siteid"></param>
        /// <returns></returns>
        public static string Attractive(int siteid)
        {
            return string.Format("{0}attractive-{1}.ashx", EbSite.Base.Host.Instance.IISPath, siteid);
        }
        /// <summary>
        /// 回答达人
        /// </summary>
        /// <param name="siteid"></param>
        /// <returns></returns>
        public static string AnswerTop(int siteid)
        {
            return string.Format("{0}answer-{1}.ashx", EbSite.Base.Host.Instance.IISPath, siteid);
        }
        /// <summary>
        /// 新注册
        /// </summary>
        /// <param name="siteid"></param>
        /// <returns></returns>
        public static string NewReg(int siteid)
        {
            return string.Format("{0}newreg-{1}.ashx", EbSite.Base.Host.Instance.IISPath, siteid);
        }
        /// <summary>
        /// 专家
        /// </summary>
        /// <param name="siteid"></param>
        /// <returns></returns>
        public static string Expert(int siteid)
        {
            return string.Format("{0}expert-{1}.ashx", EbSite.Base.Host.Instance.IISPath, siteid);
        }
        public static string TiWen(int siteid, object uid)
        {
            return TiWen(siteid, uid, 1);
        }
        public static string buy(int siteid, object uid)
        {
            return buy(siteid, uid, 1);
        }
        public static string buy(int siteid, object uid, int PageIndex)//如果要修改attractivelist名称，记得修改分页控件对应的重写名称
        {
            return string.Format("{0}buy-{1}-{2}-{3}.ashx", EbSite.Base.Host.Instance.IISPath, siteid, uid, PageIndex);
        }
        public static string TiWen(int siteid, object uid, int PageIndex)//如果要修改attractivelist名称，记得修改分页控件对应的重写名称
        {
            return string.Format("{0}tiwen-{1}-{2}-{3}.ashx", EbSite.Base.Host.Instance.IISPath, siteid, uid, PageIndex);
        }
        public static string TongWen(int siteid, object uid)
        {
            return TongWen( siteid,  uid,1);
        }
        public static string TongWen(int siteid, object uid, int PageIndex)//如果要修改attractivelist名称，记得修改分页控件对应的重写名称
        {
            return string.Format("{0}tongwen-{1}-{2}-{3}.ashx", EbSite.Base.Host.Instance.IISPath, siteid, uid, PageIndex);
        }
        public static string JieDa(int siteid, object uid)
        {
            return JieDa(siteid, uid, 1);
        }
        public static string JieDa(int siteid, object uid, int PageIndex)//如果要修改attractivelist名称，记得修改分页控件对应的重写名称
        {
            return string.Format("{0}jieda-{1}-{2}-{3}.ashx", EbSite.Base.Host.Instance.IISPath, siteid, uid, PageIndex);
        }
        
        //审核中
        public static string TiWenCheck(int siteid, object uid)
        {
            //if(int.Parse(uid.ToString())==EbSite.Base.Host.Instance.UserID)
            //{
                return TiWenCheck(siteid, uid, 1);
            //}
            //return "#";
        }

        public static string TiWenCheck(int siteid, object uid, int PageIndex)//如果要修改attractivelist名称，记得修改分页控件对应的重写名称
        {
            return string.Format("{0}tiwencheck-{1}-{2}-{3}.ashx", EbSite.Base.Host.Instance.IISPath, siteid, uid, PageIndex);
        }

        //我的被问 myasked
        public static string MyAsked(int siteid, object uid)
        {
            //if (int.Parse(uid.ToString()) == EbSite.Base.Host.Instance.UserID)
            //{
                return MyAsked(siteid, uid, 1);
            //}
            //return "#";
          
        }

        public static string MyAsked(int siteid, object uid, int PageIndex)//如果要修改attractivelist名称，记得修改分页控件对应的重写名称
        {
            return string.Format("{0}myasked-{1}-{2}-{3}.ashx", EbSite.Base.Host.Instance.IISPath, siteid, uid, PageIndex);
        }

        //内容
        public static string WenTi(int siteid, object uid)
        {
            return "";
            //return string.Format("{0}{1}-{2}{3}", EbSite.Base.Host.Instance.IISPath, uid, siteid,SettingInfo.Instance.ContentPath);
        }
        #endregion

        #region Mobile
        public static string MAskPost(int siteid)
        {
            if (EbSite.Base.Host.Instance.UserID > 0)
            {
                return string.Format("/{2}{0}mobileask-{1}.ashx", EbSite.Base.Host.Instance.IISPath, siteid,
                                     EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.MPath);
            }
            else
            {
                return EbSite.Base.Host.Instance.MLoginRw + "?ru=" + string.Format("/{2}{0}mobileask-{1}.ashx", EbSite.Base.Host.Instance.IISPath, siteid,
                                     EbSite.Base.Configs.ContentSet.ConfigsControl.Instance.MPath); 
            }
        }
        #endregion
    }
}