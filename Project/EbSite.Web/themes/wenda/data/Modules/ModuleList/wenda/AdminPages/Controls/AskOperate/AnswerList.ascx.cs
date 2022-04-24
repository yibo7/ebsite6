using System;
using EbSite.Base.ControlPage;
using EbSite.Base.EntityAPI;
using EbSite.Base.Modules;
using EbSite.Base.Page;
using System.Collections.Generic;
using EbSite.Control;
using System.Web.UI.WebControls;
using EbSite.Entity;
using EbSite.Modules.Wenda.ModuleCore.BLL;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace EbSite.Modules.Wenda.AdminPages.Controls.AskOperate
{
    public partial class AnswerList : MPUCBaseList
    {
      

        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("d2c3ecc0-e645-443f-ba5b-3ad4e627ab90");
            }
        }
        public override string PageName
        {
            get
            {
                return "回答列表";
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
        /// 权限全部
        /// </summary>
        public override string Permission
        {
            get
            {
                return "21";
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        public override string PermissionAddID
        {
            get
            {
                return "22";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "23";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "24";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=8";
            }
        }
        override protected string ShowUrl
        {
            get
            {
                return "t=9";
            }
        }
        public override int OrderID
        {
            get
            {
                return 4;
            }
        }


        private string AskID
        {
            get { return Request["iid"]; }
        }

        protected string GetTitle
        {
            get { return Request["title"]; }
        }

        override protected object LoadList(out int iCount)
        {
            string strsql = "IsApproved=0";
            if (!string.IsNullOrEmpty(AskID))
            {
                strsql = string.Concat("qid=", AskID);//"IsApproved=0"

            }
            return ModuleCore.BLL.Answers.Instance.GetListPages(pcPage.PageIndex, iPageSize, strsql, "id desc", out iCount);
        }

       
        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
      

        override protected void Delete(object iID)
        {
            ModuleCore.BLL.Answers.Instance.Delete(int.Parse(iID.ToString()));
        }
        protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CheckModel")
            {
                string id = e.CommandArgument.ToString();
                TranAnswer(int.Parse(id));
               

               
            }
        }

        private void TranAnswer(int id)
        {
            ModuleCore.Entity.Answers md = ModuleCore.BLL.Answers.Instance.GetEntity(id);
            md.IsApproved = 1;
            md.id = id;
            ModuleCore.BLL.Answers.Instance.Update(md);
        }
       
        #region  工具栏的初始化
        protected System.Web.UI.WebControls.Label QuName = new Label();
        protected System.Web.UI.WebControls.TextBox QTitle = new TextBox();

        protected System.Web.UI.WebControls.Label LbName = new Label();
        protected System.Web.UI.WebControls.TextBox Qusername = new TextBox();

        protected System.Web.UI.WebControls.Label ALbName = new Label();
        protected System.Web.UI.WebControls.TextBox Ausername = new TextBox();

        protected System.Web.UI.WebControls.Label LbCheckName = new Label();
        protected EbSite.Control.DropDownList DrpListCheck = new EbSite.Control.DropDownList();
        override protected void BindToolBar()
        {
            base.BindToolBar(true,true,true,true,true);
            ucToolBar.AddBnt("批量通过", string.Concat(IISPath, "images/Menus/Image-Ok.gif"), "allow");
            //QuName.ID = "QuName";
            //QuName.Text = "问题";
            //ucToolBar.AddCtr(QuName);
            //QTitle.ID = "QTitle";
            //QTitle.Attributes.Add("style", "width:150px");
            //ucToolBar.AddCtr(QTitle);

            //ucToolBar.AddLine();
            //LbName.ID = "LbName";
            //LbName.Text = "提问者";
            //ucToolBar.AddCtr(LbName);
            //Qusername.ID = "Qusername";
            //Qusername.Attributes.Add("style", "width:90px");
            //ucToolBar.AddCtr(Qusername);

            //ALbName.ID = "ALbName";
            //ALbName.Text = "回答者";
            //ucToolBar.AddCtr(ALbName);
            //Ausername.ID = "Ausername";
            //Ausername.Attributes.Add("style", "width:90px");
            //ucToolBar.AddCtr(Ausername);

            // if (EbSite.Base.Configs.SysConfigs.ConfigsControl.Instance.AuditingContent)
            //{
            //    LbCheckName.ID = "LbCheckName";
            //    LbCheckName.Text = "是否审核";
            //    ucToolBar.AddCtr(LbCheckName);
            //    DrpListCheck.ID = "DrpListCheck";
            //    DrpListCheck.Attributes.Add("style", "width:75px");
            //    ListItem li31 = new ListItem("全部", "");
            //    ListItem li32 = new ListItem("未审核", "0");
            //    ListItem li33 = new ListItem("已审核", "1");
            //    DrpListCheck.Items.Add(li31);
            //    DrpListCheck.Items.Add(li32);
            //    DrpListCheck.Items.Add(li33);

            //    ucToolBar.AddCtr(DrpListCheck);
            //}


            //base.ShowCustomSearch("查询");
        }
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "allow":
                    foreach (GridViewRow row in gdList.Rows)
                    {

                        System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)row.FindControl("Selector");
                        if (cb != null && cb.Checked)
                        {
                            int iID = Convert.ToInt32(gdList.DataKeys[row.RowIndex].Value);
                            TranAnswer(iID);
                        }
                    }
                    gdList_Bind();
                    break;
            }
        }
        #endregion
    }
}
