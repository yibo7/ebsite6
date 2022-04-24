using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Modules.Shop.ModuleCore.BLL;
using NormRelationProduct = EbSite.Modules.Shop.ModuleCore.Entity.NormRelationProduct;

namespace EbSite.Modules.Shop.ModuleCore.Pages
{
    /// <summary>
    /// 团购与抢购的展示基类
    /// </summary>
    abstract public class GRShowBase : BasePageM
    {

        protected EbSite.Entity.NewsContent Model = null;
        //protected ModuleCore.Entity.GroupBuy ModelG = null;
        protected BLL.GRShow.GRShowModel ModelG = null;
        protected string EndSecond = "0";
        protected global::System.Web.UI.WebControls.Repeater rpPicList;
        protected global::System.Web.UI.WebControls.Repeater rpGGList;
        protected global::System.Web.UI.WebControls.Image ebproductbigimg;
        protected global::System.Web.UI.HtmlControls.HtmlInputHidden hpAllNormkey;

        protected global::System.Web.UI.WebControls.Repeater rpListGGParameter;

        abstract protected BLL.GRShow.IBase Bll { get; }

        public GRShowBase()
        {
            base.Load += new EventHandler(this.GRShowBase_Load);
        }

        private void GRShowBase_Load(object sender, EventArgs e)
        {
            //ModuleCore.BLL.GroupBuy.Instance.AutoSetGroupStaus();
            Bll.AutoSetGroupStaus();
            if (GroupId > 0 && !string.IsNullOrEmpty(Request["id"]))
            {
                int iGroupID = GroupId;
                int iProductID = ProductID;

                //ModelG = ModuleCore.BLL.GroupBuy.Instance.GetEntity(iGroupID);

                ModelG = Bll.GetEntity(iGroupID);

                if (!Equals(ModelG, null))
                {
                    if (ModelG.ProductID == iProductID)
                    {
                        //计算团购结束时间
                        //DateTime endTime = DateTime.Parse(ModelG.EndDate.ToString());
                        DateTime endTime = ModelG.EndDate;
                        double ts = endTime.Subtract(DateTime.Now).TotalSeconds;
                        if (ts > 0)
                        {
                            EndSecond = ts.ToString();
                        }

                        Model = Base.AppStartInit.NewsContentInstDefault.GetModel(ModelG.ProductID,GetSiteID);

                        #region 图片

                        List<ModuleCore.Entity.ProductsImg> lst = ModuleCore.BLL.ProductsImg.Instance.GetListByProductID(iProductID);
                        if (lst.Count > 0)
                        {
                            rpPicList.DataSource = lst;
                            rpPicList.DataBind();

                            if (!Equals(ebproductbigimg, null))
                                ebproductbigimg.ImageUrl = lst[0].BigImg;

                        }

                        #endregion


                        BindGGList();

                        BindGGParameter();
                    }
                    else
                    {
                        Tips("出错了", "参数不正确！");
                    }

                }
            }
        }

        protected int GroupId
        {
            get
            {
                string gid = Request["gid"];
                string qid = Request["qid"];
                if (!string.IsNullOrEmpty(gid))
                {
                    return int.Parse(Request["gid"]);
                }
                if (!string.IsNullOrEmpty(qid))
                {
                    return int.Parse(Request["qid"]);
                }
                return 0;
            }
        }
        protected int ProductID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    return int.Parse(Request["id"]);
                }
                return 0;
            }
        }


        #region 规格
        protected void BindGGList()
        {
            rpGGList.ItemDataBound += new RepeaterItemEventHandler(rpGGListEx_ItemDataBound);
            List<ModuleCore.Entity.NormRelationProduct> lst = ModuleCore.BLL.NormRelationProduct.Instance.GetListByProductID(ProductID);
            if (lst.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (NormRelationProduct nrp in lst)
                {
                    sb.Append(nrp.NormsValues);
                    sb.Append("#");
                }
                //sAllNormkey = sb.ToString();
                //System.Web.UI.HtmlControls.HtmlInputHidden imageProduct = FindControl("hpAllNormkey") as HtmlInputHidden;
                //if (!Equals(imageProduct, null))
                //{
                //    imageProduct.Value = sb.ToString();
                //}
                if (sb!=null&&sb.Length > 0&&hpAllNormkey!=null)
                {
                    hpAllNormkey.Value = sb.ToString();
                }
                StrData = ModuleCore.BLL.NormRelationProduct.Instance.GetDataListByList(lst);
                rpGGList.DataSource = ModuleCore.BLL.NormRelationProduct.Instance.GetHeaderTextByList(lst);
                rpGGList.DataBind();

            }


        }
        private static List<ChildTemp> StrData = new List<ChildTemp>();
        // protected static string sAllNormkey;

        public static void rpGGListEx_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                EbSite.Base.EntityAPI.ListItemModel drData = (Base.EntityAPI.ListItemModel)e.Item.DataItem;
                //提取分类ID 
                string strClassID = drData.ID;
                if (!string.IsNullOrEmpty(strClassID))
                {
                    Repeater llClassList = (Repeater)e.Item.Controls[0].FindControl("rpSubList");

                    llClassList.DataSource = GetSkuBind(int.Parse(strClassID));
                    llClassList.DataBind();
                }

            }
        }
        public static List<Base.EntityAPI.ListItemModel> GetSkuBind(int id)
        {
            List<Base.EntityAPI.ListItemModel> nls = new List<Base.EntityAPI.ListItemModel>();
            var xls = (from i in StrData where i.pid == id select i.id).Distinct().ToList();

            foreach (var childTemp in xls)
            {
                EbSite.Base.EntityAPI.ListItemModel md = new Base.EntityAPI.ListItemModel();
                md.ID = childTemp.ToString();
                md.Value = id.ToString();//这是父ID
                ModuleCore.Entity.NormsValue tmpMd = ModuleCore.BLL.NormsValue.Instance.GetEntity(childTemp);
                if (tmpMd != null)
                {
                    md.Text = tmpMd.NormsValueName;
                }
                else
                {
                    md.Text = "";
                }
                nls.Add(md);
            }
            return nls;
        }
        #endregion



        #region 规格属性参数
        public void BindGGParameter()
        {
            if (!Equals(rpListGGParameter, null))
            {
                List<ModuleCore.Entity.TypeRelationProduct> lst = ModuleCore.BLL.TypeRelationProduct.Instance.GetListArrayCache(0, string.Concat("item>0 and ProductID=", ProductID, " GROUP BY attributeId"), "");
                if (lst.Count > 0)
                {
                    rpListGGParameter.DataSource = lst;
                    rpListGGParameter.DataBind();
                }
            }
        }
        #endregion

        public string GetBuyCounts(object groupID)
        {
            if (groupID != null)
            {
                int gid = EbSite.Core.Utils.ObjectToInt(groupID, 0);
                if (gid > 0)
                {
                    return ModuleCore.BLL.GroupBuy.Instance.GetOrderCount(gid).ToString();
                }
            }
            return "0";
        }

    }
}