using System;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Ctrtem
{
    public partial class AddTem : UserControlBaseSave
    {

        public override string Permission
        {
            get
            {
                return "119";
            }
        }
        override protected string KeyColumnName
        {
            get
            {
                return "id";
            }
        }
        override protected void InitModifyCtr()
        {
            Entity.CtrTemList cm = BLL.Ctrtem.TemListInstace.TemBll(GetSiteID).SelectCtrTemLists(new Guid(SID));

            txtTemName.Text = cm.Title;
            drpTemClass.SelectedValue = cm.ClassId.ToString();

            //txtDes.Text = cm.Description;

            txtTem.Text = BLL.Ctrtem.TemListInstace.TemBll(GetSiteID).GetATemFileContent(new Guid(SID));
            //BindColumns();
            #region ModelClassID

            //string sClassID = cm.ClassId.ToString();
            //if (Equals(sClassID, "5f1ae5b4-440f-406f-ad13-54b9ba3378d0")) //分类列表模板
            //{
            //    drpModelClass.SelectedValue = cm.ModelClassID.ToString();
            //}
            //else if (Equals(sClassID, "22e3f215-0b2c-4f5b-b9dc-2aa08895e969")) //内容展示
            //{
            //    drpModelContent.SelectedValue = cm.ModelClassID.ToString();
            //}
            //else if (Equals(sClassID, "19482b0d-7207-4014-9802-ac4f98b8cc0c"))
            //{
                

            //}
            //else if (Equals(sClassID, "19482b0d-7207-4014-9802-ac4f98b8cc0c"))//专题列表类
            //{
                
            //}
            //else if (Equals(sClassID, "e1251549-0410-4cc6-b239-f51914180ded")) //部件数据模板(其他)
            //{
               
            //}
            //else                                                             //用户列表类
            //{
            //    drpModelUser.SelectedValue = cm.ModelClassID.ToString();

            //}

            #endregion
        }

        override protected void SaveModel()
        {
            Entity.CtrTemList mdNC = new CtrTemList();

            mdNC.Title = txtTemName.Text;
            mdNC.ClassId = new Guid(drpTemClass.SelectedValue);
            //mdNC.Description = txtDes.Text;
            mdNC.TemContent = txtTem.Text.Trim();
            #region ModelClassID
            //string sClassID = drpTemClass.SelectedValue.Trim();
            //if (Equals(sClassID, "5f1ae5b4-440f-406f-ad13-54b9ba3378d0")) //分类列表模板
            //{
            //    mdNC.ModelClassID =new Guid(drpModelClass.SelectedValue);   
            //}
            //else if (Equals(sClassID, "22e3f215-0b2c-4f5b-b9dc-2aa08895e969")) //内容展示
            //{
            //    mdNC.ModelClassID = new Guid(drpModelContent.SelectedValue);   
            //}
            //else if (Equals(sClassID, "19482b0d-7207-4014-9802-ac4f98b8cc0c"))
            //{
            //    mdNC.ModelClassID=Guid.Empty;
               
            //}
            //else if (Equals(sClassID, "19482b0d-7207-4014-9802-ac4f98b8cc0c"))//专题列表类
            //{
            //    mdNC.ModelClassID = Guid.Empty;
            //}
            //else if (Equals(sClassID, "e1251549-0410-4cc6-b239-f51914180ded")) //部件数据模板(其他)
            //{
            //    mdNC.ModelClassID = Guid.Empty;
            //}
            //else                                                             //用户列表类
            //{
            //    mdNC.ModelClassID = new Guid(drpModelUser.SelectedValue);

            //}

            #endregion
            if (!string.IsNullOrEmpty(SID)) //修改分类
            {
                mdNC.ID = new Guid(SID);
                mdNC.AddDate = DateTime.Now;
                BLL.Ctrtem.TemListInstace.TemBll(GetSiteID).UpdateCtrTemLists(mdNC);
            }

            else    //添加一级分类
            {
                mdNC.ID = Guid.NewGuid();
                mdNC.AddDate = DateTime.Now;
                BLL.Ctrtem.TemListInstace.TemBll(GetSiteID).InsertCtrTemLists(mdNC);
            }
        }

        private Guid ClassID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request["cid"]))
                {
                    return new Guid(Request["cid"]);
                }
                return Guid.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindData();
                //InitModify();
                //BindColumns();
                if (string.IsNullOrEmpty(SID))
                {
                    txtTem.Text = " <!--请在这里输入模板内容!-->\n\r<br/> ";
                }


            }


        }
        //private Guid id
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(Request["id"]))
        //        {
        //            return new Guid(Request["id"]);
        //        }
        //        return Guid.Empty;
        //    }
        //}

        private void BindData()
        {

            drpTemClass.DataTextField = "Title";
            drpTemClass.DataValueField = "id";
            drpTemClass.DataSource = BLL.Ctrtem.TemClass.FillCtrTemClasss();
            drpTemClass.DataBind();
            drpTemClass.SelectedValue = ClassID.ToString();

           


        }
        //private void InitModify()
        //{
        //    if (id != Guid.Empty)
        //    {
        //        Entity.CtrTemList cm = BLL.Ctrtem.TemList.SelectCtrTemLists(id);

        //        txtTemName.Text = cm.Title;
        //        drpTemClass.SelectedValue = cm.ClassId.ToString();

        //        txtDes.Text = cm.Description;

        //        txtInfo.Text = BLL.Ctrtem.TemList.GetATemFileContent(id);

        //        btnAdd.Text = "修改模板";

        //    }
        //}
        //private void BindColumns()
        //{
        //    string sClassID = drpTemClass.SelectedValue.Trim();
        //    if (Equals(sClassID, "5f1ae5b4-440f-406f-ad13-54b9ba3378d0")) //分类列表模板
        //    {
        //        drpModelClass.Visible = true;
        //        drpModelUser.Visible = false;
               
        //        drpModelContent.Visible = false;

        //        drpModelClass.Items.Clear();
        //        drpModelClass.DataTextField = "ModelName";
        //        drpModelClass.DataValueField = "id";
        //        drpModelClass.Items.Add(new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));
        //        drpModelClass.DataSource = BLL.ClassModel.Instance.ModelClassList;
        //        drpModelClass.DataBind();



        //        drpClassColumns.DataTextField = "Text";
        //        drpClassColumns.DataValueField = "Value";
        //        drpClassColumns.DataSource = TempFactory.Instance.GetClassColumnsForList();
        //        drpClassColumns.DataBind();

        //        drpClassColumns.Enabled = true;
        //        spClassColumns.Visible = true;
        //        drpContentColumns.Items.Clear();
        //        drpContentColumns.Enabled = false;
        //        spContentColumns.Visible = false;

        //        drpSpecial.Items.Clear();
        //        drpSpecial.Enabled = false;
        //        spSpecial.Visible = false;
        //    }
        //    else if (Equals(sClassID, "22e3f215-0b2c-4f5b-b9dc-2aa08895e969")) //内容展示
        //    {
        //        drpModelContent.Visible = true;
        //        drpModelUser.Visible = false;
        //        drpModelClass.Visible = false;
                
        //        drpModelContent.Items.Clear();
        //        drpModelContent.DataTextField = "ModelName";
        //        drpModelContent.DataValueField = "id";
               
        //        drpModelContent.Items.Add(new ListItem("请选择","00000000-0000-0000-0000-000000000000"));
        //        drpModelContent.DataSource = BLL.WebModel.Instance.ModelClassList;
        //        drpModelContent.DataBind();


        //        //////
        //        drpContentColumns.DataTextField = "Text";
        //        drpContentColumns.DataValueField = "Value";
        //        drpContentColumns.DataSource = TempFactory.Instance.GetContentColumnsForList();
        //        drpContentColumns.DataBind();
        //        drpContentColumns.Enabled = true;
        //        spContentColumns.Visible = true;

        //        drpClassColumns.Items.Clear();
        //        drpClassColumns.Enabled = false;
        //        spClassColumns.Visible = false;
        //        drpSpecial.Items.Clear();
        //        drpSpecial.Enabled = false;
        //        spSpecial.Visible = false;
        //    }
        //    else if (Equals(sClassID, "19482b0d-7207-4014-9802-ac4f98b8cc0c"))
        //    {

        //        drpModelUser.Visible = false;
        //        drpModelClass.Visible = false;
        //        drpModelContent.Visible = false;

        //        drpSpecial.DataTextField = "Text";
        //        drpSpecial.DataValueField = "Value";
        //        drpSpecial.DataSource = TempFactory.Instance.GetSpecialColumnsForList();
        //        drpSpecial.DataBind();
        //        drpSpecial.Enabled = true;
        //        spSpecial.Visible = true;

        //        drpContentColumns.Items.Clear();
        //        drpContentColumns.Enabled = false;
        //        spContentColumns.Visible = false;
        //        drpClassColumns.Items.Clear();
        //        drpClassColumns.Enabled = false;
        //        spClassColumns.Visible = false;
        //    }
        //    else if (Equals(sClassID, "19482b0d-7207-4014-9802-ac4f98b8cc0c"))//专题列表类
        //    {
        //        drpModelUser.Visible = false;
        //        drpModelClass.Visible = false;
        //        drpModelContent.Visible = false;
        //    }
        //    else if (Equals(sClassID, "e1251549-0410-4cc6-b239-f51914180ded")) //部件数据模板(其他)
        //    {
        //        drpModelUser.Visible = false;
        //        drpModelClass.Visible = false;
        //        drpModelContent.Visible = false;
        //    }
        //    else                                                             //用户列表类
        //    {

        //        drpModelUser.Visible = true;
        //        drpModelClass.Visible = false;
        //        drpModelContent.Visible = false;
        //        drpModelUser.Items.Clear();
        //        drpModelUser.DataTextField = "ModelName";
        //        drpModelUser.DataValueField = "id";
        //        drpModelUser.Items.Add(new ListItem("请选择", "00000000-0000-0000-0000-000000000000"));
        //        drpModelUser.DataSource = BLL.UserModel.Instance.ModelClassList;
        //        drpModelUser.DataBind();




        //        ////////////
        //        drpClassColumns.Items.Clear();
        //        drpClassColumns.Enabled = false;
        //        spClassColumns.Visible = false;

        //        drpContentColumns.Items.Clear();
        //        drpContentColumns.Enabled = false;
        //        spContentColumns.Visible = false;
        //        drpSpecial.Items.Clear();
        //        drpSpecial.Enabled = false;
        //        spSpecial.Visible = false;

        //    }
        //}

        //protected void btnAdd_Click(object sender, EventArgs e)
        //{

        //    Entity.CtrTemList mdNC = new CtrTemList();

        //    mdNC.Title = txtTemName.Text;
        //    mdNC.ClassId = new Guid(drpTemClass.SelectedValue);
        //    mdNC.Description = txtDes.Text;
        //    mdNC.TemContent = txtInfo.Text.Trim();
        //    if (id != Guid.Empty) //修改分类
        //    {
        //        mdNC.ID = id;
        //        BLL.Ctrtem.TemList.UpdateCtrTemLists(mdNC);  
        //    }

        //    else    //添加一级分类
        //    {
        //        mdNC.ID = Guid.NewGuid();
        //        mdNC.AddDate = DateTime.Now;
        //        BLL.Ctrtem.TemList.InsertCtrTemLists(mdNC);
        //    }


        //}

        //protected void drpTemClass_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindColumns();
        //}
        ////内容
        //protected void drpModelContent_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //   // drpContentColumns
        //    drpContentColumns.Items.Clear();
        //    drpContentColumns.DataTextField = "Text";
        //    drpContentColumns.DataValueField = "Value";
        //    //drpContentColumns.DataSource = BLL.Templates.GetContentColumnsForList(new Guid(drpModelContent.SelectedValue));GetContentColumns
        //    drpContentColumns.DataSource = TempFactory.Instance.GetContentColumnsForList(new Guid(drpModelContent.SelectedValue));
           
        //    drpContentColumns.DataBind();
        //    drpContentColumns.Enabled = true;
        //    spContentColumns.Visible = true;

        //    drpClassColumns.Items.Clear();
        //    drpClassColumns.Enabled = false;
        //    spClassColumns.Visible = false;
        //    drpSpecial.Items.Clear();
        //    drpSpecial.Enabled = false;
        //    spSpecial.Visible = false;

        //}
        ////分类
        //protected void drpModelClass_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    drpClassColumns.DataTextField = "Text";
        //    drpClassColumns.DataValueField = "Value";
        //    drpClassColumns.DataSource = TempFactory.Instance.GetClassColumns(new Guid(drpModelClass.SelectedValue));
        //    drpClassColumns.DataBind();

        //    drpClassColumns.Enabled = true;
        //    spClassColumns.Visible = true;
        //    drpContentColumns.Items.Clear();
        //    drpContentColumns.Enabled = false;
        //    spContentColumns.Visible = false;

        //    drpSpecial.Items.Clear();
        //    drpSpecial.Enabled = false;
        //    spSpecial.Visible = false;
        //}
        //用户
        protected void drpModelUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}