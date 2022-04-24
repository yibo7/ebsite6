using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;


namespace EbSite.Modules.BBS.AdminPages.Controls.BBSmanagement
{
    public partial class Bbsconfigs_rp : MPUCBaseList
    {
        public override int OrderID
        {
            get
            {
                return 5;
            }
        }
        public override string PageName
        {
            get
            {
                return "回复管理";
            }
        }
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("5007bcd5-54b7-4ba2-9f70-2284be9da4eb");
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


        public override string Permission
        {
            get
            {
                return "25";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "26";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "27";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "28";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=10";
            }
        }
        protected Label label = new Label(); protected TextBox txtOne = new TextBox();
        protected override void BindToolBar()
        {
            base.BindToolBar(true, false, true, true, true);
            label.ID = "lblOne";
            label.Text = " 回复内容 ";
            ucToolBar.AddCtr(label);

            txtOne.ID = "txtReplyContent";
            ucToolBar.AddCtr(txtOne);

            base.ShowCustomSearch("查询");
        }

        override protected object LoadList(out int iCount)
        {
            return ModuleCore.BLL.TopicReplies.Instance.GetListPageByCls(pcPage.PageIndex, pcPage.PageSize, out iCount, sGetCls, "");
        }

        override protected object SearchList(out int iCount)
        {
            return ModuleCore.BLL.TopicReplies.Instance.GetListPageByCls(pcPage.PageIndex, pcPage.PageSize, out iCount, sGetCls,base.GetWhere(true).Trim());
        }

        override protected SearchParameter[] GetSearchParameters
        {
            get
            {
                List<SearchParameter> lstSp = new List<SearchParameter>();
                SearchParameter spModel = new SearchParameter();
                spModel.ColumnName = "ReplyContent";
                spModel.ColumnValue = ucToolBar.GetItemVal(txtOne).Trim();
                spModel.IsString = true;
                spModel.SearchLink = EmSearchLink.不连用于最后一个;
                spModel.SearchWhere = EmSearchWhere.模糊匹配;
                lstSp.Add(spModel);
                return lstSp.ToArray();
            }
        }
        override protected void Delete(object iID)
        {
            // ModuleCore.BLL.TopicReplies.Instance.Delete(long.Parse(Convert.ToString(iID)));
            ModuleCore.Entity.TopicReplies md = ModuleCore.BLL.TopicReplies.Instance.GetEntity(long.Parse(iID.ToString()));
            md.DeleteFlag = 1;
            ModuleCore.BLL.TopicReplies.Instance.Update(md);
        }

        private string sGetCls
        {
            get
            {
                return Request["cls"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ucCurrentTags.Items = string.Format("全部回复#{0}|删除回复#{1}", GetUrl, GetUrl + "&cls=1");
        }
        protected string GetImgs(string str)
        {
            string sImg = str.Replace("img", "img width='30px' height='30px'");
            sImg = sImg.Replace("IMG", "img width='30px' height='30px'");
            return sImg;
        }
        protected void gdList_DataBound(object sender, EventArgs e)
        {
            if (string.Equals(sGetCls, "1"))
            {
                InitReDel(true);
                InitDel(false);
            }
            else
            {
                InitReDel(false);
                InitDel(true);
            }
        }
        protected void InitReDel(bool b)
        {
            for (int i = 0; i < gdList.Rows.Count; i++)
            {
                gdList.Rows[i].FindControl("lbQXSC").Visible = b;
            }
        }
        protected void InitDel(bool b)
        {
            for (int i = 0; i < gdList.Rows.Count; i++)
            {
                gdList.Rows[i].FindControl("lbDelete").Visible = b;
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
            ModuleCore.Entity.TopicReplies bbst = ModuleCore.BLL.TopicReplies.Instance.GetEntity(long.Parse(tId));
            bbst.DeleteFlag = 0;
            ModuleCore.BLL.TopicReplies.Instance.Update(bbst);
            Response.Redirect(GetUrl + "&number=" + Request.QueryString["number"] + "&t=" + Request.QueryString["t"] + "&tagname=" + Request.QueryString["tagname"] + "&cls=" + Request.QueryString["cls"]);
        }
    }
}