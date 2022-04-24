using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Entity;
using EbSite.BLL;

namespace EbSite.Modules.Shop.ModuleCore
{
    public class ExMobileClassPageLoadEvent
    {
        private HttpContext _context;
        private int Special = -1;
        private int Brand = 0;
        private string orderby = "";
        private string valusTag = "";
        private int ClassID = 0;
        private string RawUrl = "";

        public ExMobileClassPageLoadEvent(HttpContext Context, int classid)
        {
            _context = Context;
            if (!string.IsNullOrEmpty(Context.Request["special"]))
            {
                Special = int.Parse(Context.Request["special"]);
            }
            // int Brand = 0;
            if (!string.IsNullOrEmpty(Context.Request["brand"]))
            {
                Brand = int.Parse(Context.Request["brand"]);
            }
            // string orderby = "";
            if (!string.IsNullOrEmpty(Context.Request["orderby"]))
            {
                orderby = Context.Request["orderby"];
            }
            // string valusTag="";//valueStr=2_8-1_4
            if (!string.IsNullOrEmpty(Context.Request["valueStr"]))
            {
                valusTag = Context.Request["valueStr"];
            }
            ClassID = classid;
            RawUrl = Context.Request.RawUrl;
        }



        #region 专题, 品牌  属性  On_ClassPageLoadEvent

        #region 专题
        /// <summary>
        /// 递归 专题分类
        /// </summary>
        /// <param name="sid">专题 子类id</param>
        /// <param name="spParentID">专题 子类id 的父类</param>
        /// <returns></returns>
        public string SpecialClass(int sid, int spParentID, int Brand, string orderby, string valusTag)
        {
            List<EbSite.Entity.SpecialClass> lsp = EbSite.BLL.SpecialClass.SpecialClass_GetParents(sid, "id ");
            string cTitle = "";
            foreach (var li in lsp)
            {
                string sUrl = SpecialUrl(li.ParentID, Brand, orderby, valusTag);
                cTitle += "<a href=\"" + sUrl + "\">" + li.SpecialName + "</a>  ";
            }
            return cTitle;
        }

        /// <summary>
        /// 专题的 超连接
        /// </summary>
        /// <param name="spParentID">专题 子类id 的父类</param>
        /// <returns></returns>
        public string SpecialUrl(int spParentID, int Brand, string orderby, string valusTag)
        {
            string Url = "";
            #region
            StringBuilder iEUrl = new StringBuilder();
            if (Brand > 0)
            {
                iEUrl.AppendFormat("&brand={0}", Brand);
            }
            if (!string.IsNullOrEmpty(orderby))
            {
                iEUrl.AppendFormat("&orderby={0}", orderby);
            }
            if (!string.IsNullOrEmpty(valusTag))
            {
                iEUrl.AppendFormat("&valueStr={0}", valusTag);
            }
            if (spParentID > 0)
            {
                Url = EbSite.Base.Host.Instance.MGetClassHref(ClassID, 1, SettingInfo.Instance.GetSiteID) + "?special=" + spParentID + iEUrl;
            }
            else
            {
                if (iEUrl.Length > 0)
                    iEUrl = iEUrl.Remove(0, 1);
                if (iEUrl.Length == 0)
                {
                    Url = EbSite.Base.Host.Instance.MGetClassHref(ClassID, 1, SettingInfo.Instance.GetSiteID);
                }
                else
                {
                    Url = EbSite.Base.Host.Instance.MGetClassHref(ClassID, 1, SettingInfo.Instance.GetSiteID) + "?" + iEUrl;
                }

            }

            #endregion
            return Url;
        }


        #region 专题的数据源
        public List<ListItemModelEx> SpecialList(int pid)
        {
            //在专题分类中 关联的分类 现在是 若关联的专题大类。子类全部 承现。【子类也可以按关联专题】
            List<ListItemModelEx> nls = new List<ListItemModelEx>();

            string strsql = "RelateClassIDs like '%" + ClassID + "%' and parentid=" + pid;
            if (pid > 0)
            {
                strsql = " parentid=" + pid; //子类没有关联
            }
            else
            {
                strsql = "RelateClassIDs like '%" + ClassID + "%' and parentid=" + pid; //关联分类
            }
            List<EbSite.Entity.SpecialClass> arry = EbSite.BLL.SpecialClass.GetListArr(strsql, SettingInfo.Instance.GetSiteID);

            foreach (var childTemp in arry)
            {
                ListItemModelEx md = new ListItemModelEx();
                md.ID = childTemp.id.ToString();
                md.Value = childTemp.id.ToString();
                md.Text = childTemp.SpecialName;

                #region
                StringBuilder iEUrl = new StringBuilder();
                if (Brand > 0)
                {
                    iEUrl.AppendFormat("&brand={0}", Brand);
                }
                if (!string.IsNullOrEmpty(orderby))
                {
                    iEUrl.AppendFormat("&orderby={0}", orderby);
                }
                if (!string.IsNullOrEmpty(valusTag))
                {
                    iEUrl.AppendFormat("&valueStr={0}", valusTag);
                }
                md.Url = EbSite.Base.Host.Instance.MGetClassHref(ClassID, 1, SettingInfo.Instance.GetSiteID) + "?special=" + childTemp.id + iEUrl;
                #endregion


                if (Special == Convert.ToInt32(childTemp.id))
                {
                    md.StyleBg = "cur";
                }

                nls.Add(md);
            }
            return nls;
        }
        #endregion
        #endregion

        #region 品牌

        /// <summary>
        /// 品牌的数据源 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<ListItemModelEx> BrandList(string value)
        {
            List<ListItemModelEx> nls = new List<ListItemModelEx>();
            string[] arry = value.Split(',');

            foreach (var childTemp in arry)
            {
                ListItemModelEx md = new ListItemModelEx();
                md.ID = childTemp;
                md.Value = childTemp;
                md.Text = ModuleCore.BLL.GoodsBrand.Instance.GetEntity(Convert.ToInt32(childTemp)).BrandName;

                #region
                StringBuilder iEUrl = new StringBuilder();
                if (Special > 0)
                {
                    iEUrl.AppendFormat("&special={0}", Special);
                }
                if (!string.IsNullOrEmpty(orderby))
                {
                    iEUrl.AppendFormat("&orderby={0}", orderby);
                }
                if (!string.IsNullOrEmpty(valusTag))
                {
                    iEUrl.AppendFormat("&valueStr={0}", valusTag);
                }
                md.Url = EbSite.Base.Host.Instance.MGetClassHref(ClassID, 1, SettingInfo.Instance.GetSiteID) + "?brand=" + childTemp + iEUrl;
                #endregion

                if (Brand == Convert.ToInt32(childTemp))
                {
                    md.StyleBg = "cur";
                }

                nls.Add(md);
            }
            return nls;
        }
        #endregion

        #region 属性


        /// <summary>
        /// 得到 属性 3_8 中的3
        /// </summary>
        protected int?[] AttributeID
        {
            get
            {
                if (!string.IsNullOrEmpty(valusTag))
                {
                    int?[] temp = new int?[0];
                    string[] arry = valusTag.Split('-');
                    temp = new int?[arry.Length];
                    for (int i = 0; i < arry.Length; i++)
                    {
                        string[] child = arry[i].Split('_');
                        temp[i] = Convert.ToInt32(child[0]);
                    }
                    return temp;
                }
                return new int?[0];
            }
        }

        /// <summary>
        /// 得到 属性  3_8 中的8
        /// </summary>
        protected int?[] AttributeValuesID
        {
            get
            {
                if (!string.IsNullOrEmpty(valusTag))
                {
                    int?[] temp = new int?[0];
                    string[] arry = valusTag.Split('-');
                    temp = new int?[arry.Length];
                    for (int i = 0; i < arry.Length; i++)
                    {
                        string[] child = arry[i].Split('_');
                        temp[i] = Convert.ToInt32(child[1]);
                    }
                    return temp;
                }
                return new int?[0];
            }
        }
        public List<ListItemModelEx> SkuBind(int value)
        {
            List<ListItemModelEx> nls = new List<ListItemModelEx>();
            List<ModuleCore.Entity.TypeNameValues> xls = ModuleCore.BLL.TypeNameValues.Instance.GetListArray(0, "TypeNameValueID=" + value, "");

            foreach (var childTemp in xls)
            {
                ListItemModelEx md = new ListItemModelEx();
                md.ID = childTemp.TypeNameValueID.ToString();//父类
                md.Value = childTemp.id.ToString();
                md.Text = childTemp.TValues;
                if (CheckValueSku(childTemp.id))
                {
                    md.StyleBg = "cur";
                }
                if (CheckSku(Convert.ToInt32(childTemp.TypeNameValueID)))
                {
                    if (RawUrl.ToLower().IndexOf("brand") == -1 && RawUrl.ToLower().IndexOf("valuestr") == -1 && RawUrl.ToLower().IndexOf("special") == -1 && RawUrl.ToLower().IndexOf("orderby") == -1)//不包含 
                    {
                        md.Url = EbSite.Base.Host.Instance.MGetClassHref(ClassID, 1, SettingInfo.Instance.GetSiteID) + "?valueStr=" + md.ID + "_" + md.Value;
                    }
                    else if (RawUrl.ToLower().IndexOf("valuestr") == -1 && (RawUrl.ToLower().IndexOf("brand") > -1 || RawUrl.ToLower().IndexOf("special") > -1 || RawUrl.ToLower().IndexOf("orderby") > -1))
                    {
                        StringBuilder iEUrl = new StringBuilder();

                        if (Special > 0)
                        {
                            iEUrl.AppendFormat("&special={0}", Special);
                        }
                        if (Brand > 0)
                        {
                            iEUrl.AppendFormat("&brand={0}", Brand);
                        }
                        if (!string.IsNullOrEmpty(orderby))
                        {
                            iEUrl.AppendFormat("&orderby={0}", orderby);
                        }

                        if (iEUrl.Length > 0)
                            iEUrl = iEUrl.Remove(0, 1);

                        if (iEUrl.Length == 0)
                        {
                            md.Url = EbSite.Base.Host.Instance.MGetClassHref(ClassID, 1, SettingInfo.Instance.GetSiteID);
                        }
                        else
                        {
                            md.Url = EbSite.Base.Host.Instance.MGetClassHref(ClassID, 1, SettingInfo.Instance.GetSiteID) + "?" + iEUrl + "&valueStr=" + md.ID + "_" + md.Value;
                        }

                        //  md.Url = RawUrl + "&valueStr=" + md.ID + "_" + md.Value;
                    }
                    else if (RawUrl.ToLower().IndexOf("valuestr") > -1 && RawUrl.ToLower().IndexOf("brand") == -1 && RawUrl.ToLower().IndexOf("special") == -1 && RawUrl.ToLower().IndexOf("orderby") == -1)
                    {
                        string strurl = "";
                        string[] ary = valusTag.Split('-');
                        for (int i = 0; i < ary.Length; i++)
                        {
                            string key = ary[i].Split('_')[0];
                            if (key != md.ID) //不是同类 加入
                            {
                                strurl += key + "_" + ary[i].Split('_')[1] + "-";
                            }

                        }
                        md.Url = EbSite.Base.Host.Instance.MGetClassHref(ClassID, 1, SettingInfo.Instance.GetSiteID) + "?valueStr=" + strurl + md.ID + "_" + md.Value;

                    }
                    else
                    {   //?brand=1&valueStr=2_6-1_1
                        string strurl = "";
                        string[] ary = valusTag.Split('-');
                        for (int i = 0; i < ary.Length; i++)
                        {
                            string key = ary[i].Split('_')[0];
                            if (key != md.ID) //不是同类 加入
                            {
                                strurl += key + "_" + ary[i].Split('_')[1] + "-";
                            }

                        }
                        StringBuilder iEUrl = new StringBuilder();

                        if (Special > 0)
                        {
                            iEUrl.AppendFormat("&special={0}", Special);
                        }
                        if (Brand > 0)
                        {
                            iEUrl.AppendFormat("&brand={0}", Brand);
                        }
                        if (!string.IsNullOrEmpty(orderby))
                        {
                            iEUrl.AppendFormat("&orderby={0}", orderby);
                        }
                        if (!string.IsNullOrEmpty(valusTag))
                        {
                            iEUrl.AppendFormat("&valueStr={0}", strurl + md.ID + "_" + md.Value);
                        }
                        if (iEUrl.Length > 0)
                            iEUrl = iEUrl.Remove(0, 1);

                        if (iEUrl.Length == 0)
                        {
                            md.Url = EbSite.Base.Host.Instance.MGetClassHref(ClassID, 1, SettingInfo.Instance.GetSiteID);
                        }
                        else
                        {
                            md.Url = EbSite.Base.Host.Instance.MGetClassHref(ClassID, 1, SettingInfo.Instance.GetSiteID) + "?" + iEUrl;
                        }


                    }
                }
                else
                {
                    if (RawUrl.ToLower().IndexOf("valuestr") == -1)//不包含 
                    {
                        if (RawUrl.ToLower().IndexOf("brand") == -1 && RawUrl.ToLower().IndexOf("special") == -1 && RawUrl.ToLower().IndexOf("orderby") == -1)//不包含 
                        {
                            md.Url = EbSite.Base.Host.Instance.MGetClassHref(ClassID, 1, SettingInfo.Instance.GetSiteID) + "?valueStr=" + md.ID + "_" + md.Value;
                        }
                        else //同类 有bug
                        {
                            StringBuilder iEUrl = new StringBuilder();

                            if (Special > 0)
                            {
                                iEUrl.AppendFormat("&special={0}", Special);
                            }
                            if (Brand > 0)
                            {
                                iEUrl.AppendFormat("&brand={0}", Brand);
                            }
                            if (!string.IsNullOrEmpty(orderby))
                            {
                                iEUrl.AppendFormat("&orderby={0}", orderby);
                            }

                            if (iEUrl.Length > 0)
                                iEUrl = iEUrl.Remove(0, 1);

                            if (iEUrl.Length == 0)
                            {
                                md.Url = EbSite.Base.Host.Instance.MGetClassHref(ClassID, 1, SettingInfo.Instance.GetSiteID);
                            }
                            else
                            {
                                md.Url = EbSite.Base.Host.Instance.MGetClassHref(ClassID, 1, SettingInfo.Instance.GetSiteID) + "?" + iEUrl + "&valueStr=" + md.ID + "_" + md.Value;
                            }

                            // md.Url = RawUrl + "&valueStr=" + md.ID + "_" + md.Value;
                        }
                    }
                    else
                    {
                        StringBuilder iEUrl = new StringBuilder();
                        if (Special > 0)
                        {
                            iEUrl.AppendFormat("&special={0}", Special);
                        }
                        if (Brand > 0)
                        {
                            iEUrl.AppendFormat("&brand={0}", Brand);
                        }
                        if (!string.IsNullOrEmpty(orderby))
                        {
                            iEUrl.AppendFormat("&orderby={0}", orderby);
                        }
                        md.Url = EbSite.Base.Host.Instance.MGetClassHref(ClassID, 1, SettingInfo.Instance.GetSiteID) + "?valueStr=" + valusTag + "-" + md.ID + "_" + md.Value + iEUrl;
                    }

                }
                nls.Add(md);
            }
            return nls;
        }
        /// <summary>
        /// 检测 是否是 是同类
        /// </summary>
        /// <param name="valueId"></param>
        /// <returns></returns>
        public bool CheckSku(int valueId)
        {
            int iCount = 0;
            if (AttributeID.Length > 0)
            {
                iCount = (from i in AttributeID where i == valueId select i).Count();
                if (iCount > 0)
                {
                    return true;
                }
            }
            return false;

        }

        /// <summary>
        /// 检测 是否是 是同类
        /// </summary>
        /// <param name="valueId"></param>
        /// <returns></returns>
        public bool CheckValueSku(int valueId)
        {
            int iCount = 0;
            if (AttributeValuesID.Length > 0)
            {
                iCount = (from i in AttributeValuesID where i == valueId select i).Count();
                if (iCount > 0)
                {
                    return true;
                }
            }
            return false;

        }
        #endregion
        #endregion


        #region
        /// <summary>
        /// 一级专题的绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void rpSpecial_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rpSubList");
                llClassList.DataSource = SpecialList(0);
                llClassList.DataBind();
            }

        }
        /// <summary>
        /// 二级专题子类的绑定 为什么有两个呢。因为 1.样式不一样。2.这个上方的标题 是 向上递归的专题+超连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void rpSpecialSmall_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ListItemModelEx drData = (ListItemModelEx)e.Item.DataItem;
                string strSpecialID = drData.ID;
                Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rpSubList");
                llClassList.DataSource = SpecialList(Convert.ToInt16(strSpecialID));
                llClassList.DataBind();
            }
        }

        #endregion

        #region 品牌

        public void rpBrand_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ListItemModelEx drData = (ListItemModelEx)e.Item.DataItem;
                string strClassID = drData.Value;
                if (drData.Text == "品牌")
                {
                    Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rpSubList");
                    llClassList.DataSource = BrandList(strClassID);
                    llClassList.DataBind();
                }
            }
        }

        #endregion

        #region 属性
        public int iCount = 0;
        public void rpSKUList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ListItemModelEx drData = (ListItemModelEx)e.Item.DataItem;
                string strClassID = drData.Value;
                if (!string.IsNullOrEmpty(strClassID))
                {
                    Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rpSubList");
                    llClassList.DataSource = SkuBind(int.Parse(strClassID));
                    llClassList.DataBind();
                }
            }
        }
        #endregion

    }

    public class ExMobileIndexPageLoadEvent
    {
        public ExMobileIndexPageLoadEvent()
        {

        }
        #region 手机版首页楼层扩展

        public static void rpMFloorList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ModuleCore.Entity.MFloorSet drData = (ModuleCore.Entity.MFloorSet)e.Item.DataItem;
                if (null != drData)
                { 
                    #region MFloorBigClass

                    List<ModuleCore.Entity.MFloorBigClass> lsBig = ModuleCore.BLL.MFloorBigClassInfo.Instance.FillList();
                    List<ModuleCore.Entity.MFloorBigClass> NlsBig = (from i in lsBig where i.FloorSetId == drData.FloorId select i).ToList();
                    Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rpMBigClass");
                    if (!Equals(llClassList, null))
                    {
                        llClassList.DataSource = NlsBig;
                        llClassList.DataBind();
                    }

                    #endregion MFloorBigClass

                    #region MFloorSmallClass

                    List<ModuleCore.Entity.MFloorSmallClass> lsSmall = ModuleCore.BLL.MFloorSmallClassInfo.Instance.FillList();
                    List<ModuleCore.Entity.MFloorSmallClass> NlsSmall = (from i in lsSmall where i.FloorSetId == drData.FloorId select i).ToList();
                    Repeater llClassLisSmall = (Repeater)e.Item.Controls[0].FindControl("rpMSmallClass");
                    if (!Equals(llClassLisSmall, null))
                    {
                        llClassLisSmall.DataSource = NlsSmall;
                        llClassLisSmall.DataBind();
                    }

                    #endregion MFloorSmallClass
                }
            }
        }

        #endregion 手机版首页楼层扩展

    }
    
}                                       