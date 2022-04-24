using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;
using EbSite.Control;


namespace EbSite.Modules.BBS.AdminPages.Controls.BBSmanagement
{
    public partial class Bbsconfigs_Post : MPUCBaseList
    {
        public override int OrderID
        {
            get
            {
                return 3;
            }
        }
        public override string PageName
        {
            get
            {
                return "帖子管理";
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("4bb3a41a-a80e-421f-916a-b5d44672bca2");
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
        

        private string sGetCls
        {
            get
            {
                return Request["cls"];
            }
        }
        public override string Permission
        {
            get
            {
                return "17";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "18";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "19";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "20";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=11";
            }
        }
       
        protected Label labelO = new Label(); 
        protected Label label = new Label();
        protected TextBoxVl txtOne = new TextBoxVl();
        protected TextBoxVl txtTwo = new TextBoxVl();
        protected override void BindToolBar()
        {
            base.BindToolBar(true, true, true, true,true);
            label.ID = "lblOne";
            label.Text = " 标 题 ";
            ucToolBar.AddCtr(label);

            txtOne.ID = "Name";
            txtOne.Height = 13;
            ucToolBar.AddCtr(txtOne);

            label.ID = "lblOne";
            labelO.Text = " 用户名 ";
            ucToolBar.AddCtr(labelO);

            txtTwo.ID = "Name";
            txtTwo.Height = 13;
            ucToolBar.AddCtr(txtTwo);
            base.ShowCustomSearch("查询");
        }

        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.Topics.Instance.GetListPagesCacheByCls(pcPage.PageIndex, pcPage.PageSize, out iCount, sGetCls, "");
        }

        override protected object SearchList(out int iCount)
        {
            return ModuleCore.BLL.Topics.Instance.GetListPagesCacheByCls(pcPage.PageIndex, pcPage.PageSize, out iCount, sGetCls, base.GetWhere(true).Trim());
        }

        override protected SearchParameter[] GetSearchParameters
        {
            get
            {
                List<SearchParameter> lstSp = new List<SearchParameter>();
                SearchParameter spModel = new SearchParameter();
                spModel.ColumnName = "TopicTitle";
                spModel.ColumnValue = ucToolBar.GetItemVal(txtOne).Trim();
                spModel.IsString = true;
                spModel.SearchLink = EmSearchLink.与连and;
                spModel.SearchWhere = EmSearchWhere.模糊匹配;
                lstSp.Add(spModel);
                spModel = new SearchParameter();
                spModel.ColumnName = "UserName";
                spModel.ColumnValue = ucToolBar.GetItemVal(txtTwo).Trim();
                spModel.IsString = true;
                spModel.SearchLink = EmSearchLink.不连用于最后一个;
                spModel.SearchWhere = EmSearchWhere.模糊匹配;
                lstSp.Add(spModel);
                return lstSp.ToArray();
            }
        }
        override protected void Delete(object iID)
        {
            string sCls = Request.QueryString["cls"];
            if (!string.Equals(sCls, "6"))
            {
                ModuleCore.Entity.Topics bbst = ModuleCore.BLL.Topics.Instance.GetEntity(int.Parse(Convert.ToString(iID)));
                bbst.DeleteFlag = 1;
                ModuleCore.BLL.Topics.Instance.Update(bbst);
            }
            else
            {
                List<ModuleCore.Entity.TopicReplies> bbstrList = ModuleCore.BLL.TopicReplies.Instance.GetListArrayByTopicId(Convert.ToInt32(iID));
                for (int k = 0; k < bbstrList.Count; k++)
                {
                    ModuleCore.BLL.TopicReplies.Instance.Delete(bbstrList[k].id);
                }
                ModuleCore.BLL.Topics.Instance.Delete(int.Parse(Convert.ToString(iID)));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ucCurrentTags.Items = string.Format("全部主题#{0}|未审核主题#{1}|推荐主题#{2}|板块置顶主题#{3}|全站置顶主题#{4}|加精主题#{5}|已删除主题#{6}", GetUrl + "&number=&tagname=tg3", GetUrl + "&cls=1&number=&tagname=tg3", GetUrl + "&cls=2&number=&tagname=tg3", GetUrl + "&cls=3&number=&tagname=tg3", GetUrl + "&cls=4&number=&tagname=tg3", GetUrl + "&cls=5&number=&tagname=tg3", GetUrl + "&cls=6&number=&tagname=tg3");
        }
        //protected string newurl()
        //{
        //    string starturl = HttpContext.Current.Request.Url.AbsolutePath;
        //    string pid = Convert.ToString(base.MenuID);
        //    string sid = Convert.ToString(base.ModuleID);
        //    string path = starturl + "?muid=" + pid + "&mid=" + sid;
        //    return path;
        //}

        protected void gdList_DataBound(object sender, EventArgs e)
        {
            if (string.Equals(sGetCls, "6"))
            {
                InitLbQXSC(true);
                InitwbGL(false);
            }
            else
            {
                InitLbQXSC(false);
                InitwbGL(true);
            }
        }

        protected void InitLbQXSC(bool b)
        {
            for (int i = 0; i < gdList.Rows.Count; i++)
            {
                gdList.Rows[i].FindControl("lbQXSC").Visible = b;
            }
        }

        protected void InitwbGL(bool b)
        {
            for (int i = 0; i < gdList.Rows.Count; i++)
            {
                gdList.Rows[i].FindControl("wbModify").Visible = b;
            }
        }
        /// <summary>
        /// 取消删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void blQXSC_Click(object sender, EventArgs e)
        {
            string tId = Request.Form["hName"];
            ModuleCore.Entity.Topics bbst = ModuleCore.BLL.Topics.Instance.GetEntity(int.Parse(tId));
            bbst.DeleteFlag = 0;
            ModuleCore.BLL.Topics.Instance.Update(bbst);
            Response.Redirect(GetUrl + "&number=" + Request.QueryString["number"] + "&t=" + Request.QueryString["t"] + "&tagname=" + Request.QueryString["tagname"] + "&cls=" + Request.QueryString["cls"]);
        }
    }
}