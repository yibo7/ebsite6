using System;
using System.Text;
using System.Web.UI.WebControls;
using EbSite.Base.Configs.ContentSet;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using EbSite.BLL.User;
using EbSite.Core.Strings;

namespace EbSite.Web.AdminHt.Controls.Admin_Member
{
    public partial class AddMemberGroup : UserControlBaseSave
    {
        

        public override string Permission
        {
            get
            {
                return "74";
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
            UserGroupProfile ugp = UserGroupProfile.GetUserGroupProfile(int.Parse(SID));

            txtGruopName.Text = ugp.GroupName;
            //CreditShigher.Text = ugp.CreditShigher.ToString();
            //CreditSlower.Text = ugp.CreditSlower.ToString();

            txtManageIndexMaster.Text = ugp.ManageIndexMaster;// string.IsNullOrEmpty(ugp.ManageIndexMaster) ? ConfigsControl.Instance.ManageIndexMaster : ugp.ManageIndexMaster;

            if (BLL.UserModel.Instance.IsHaveModel(ugp.UserModelID))
                drpUserModel.SelectedValue = ugp.UserModelID.ToString();

            string[] aItems = ugp.AllowAddClass.Split(',');
            foreach (ListItem li in cblClass.Items)
            {
                if (Validate.InArray(li.Value, aItems))
                {
                    li.Selected = true;
                }
            }
            cbIsAuditing.Checked = ugp.IsAuditingMember;

            cbIsAllowDelete.Checked = ugp.IsAllowDelete;
            cbIsAllowModify.Checked = ugp.IsAllowModify;

            cbIsAuditingContent.Checked = ugp.IsAuditingContent;

            txtContentNum.Text = ugp.AllowAddContentNum.ToString();

            txtManageIndex.Text = ugp.ManageIndex;// string.IsNullOrEmpty(ugp.ManageIndex) ? ConfigsControl.Instance.UccIndex : ugp.ManageIndex;
            txtWebSite.Text = ugp.WebSiteIndex;//string.IsNullOrEmpty(ugp.WebSiteIndex) ? ConfigsControl.Instance.UserInfo : ugp.WebSiteIndex;
        }
        override protected void SaveModel()
        {
            if (!Page.IsValid)
                throw new InvalidOperationException("验证已经失效，重先登录再试");

            UserGroupProfile ugp;
            if (!string.IsNullOrEmpty(SID)) //id值大于0，说明修改数据
            {
                ugp = UserGroupProfile.GetUserGroupProfile(int.Parse(SID));
            }
            else
            {
                ugp = new UserGroupProfile();
            }
            ugp.GroupName = txtGruopName.Text.Trim();
            //ugp.CreditShigher = int.Parse(CreditShigher.Text.Trim());
            //ugp.CreditSlower = int.Parse(CreditSlower.Text.Trim());
            ugp.ManageIndexMaster = txtManageIndexMaster.Text.Trim();
            ugp.UserModelID = new Guid(drpUserModel.SelectedValue);
            //ugp.IsSys = IsSys.Checked;
            ugp.AllowAddClass = GetItems();
            ugp.IsAuditingMember = cbIsAuditing.Checked;

            ugp.IsAllowDelete = cbIsAllowDelete.Checked;
            ugp.IsAllowModify = cbIsAllowModify.Checked;

            ugp.IsAuditingContent = cbIsAuditingContent.Checked;

            ugp.ManageIndex = txtManageIndex.Text.Trim();
            ugp.WebSiteIndex = txtWebSite.Text;
            string sContentNum = txtContentNum.Text;

            if (!string.IsNullOrEmpty(sContentNum))
            {
                ugp.AllowAddContentNum = int.Parse(txtContentNum.Text);
            }
            if (string.IsNullOrEmpty(SID))
            {
                if (!EbSite.BLL.User.UserGroupProfile.IsExist(txtGruopName.Text.Trim()))
                {
                    ugp.Save();
                }
                else
                {
                    base.TipsAlert("用户组名称已存在。");
                }
            }
            else
            {
                ugp.Save();
            }
           
        }

        //自定义方法
        //protected int sID
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(SID))
        //        {
        //           return UserGroupProfile.GetRoleIDByUserName(SID);
        //        }
        //        return -1;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindClass();

                BindUserModel();


                //txtManageIndex.Text = ConfigsControl.Instance.UccIndex;

                //txtWebSite.Text = ConfigsControl.Instance.UserInfo;

                //txtManageIndexMaster.Text = ConfigsControl.Instance.ManageIndexMaster;
            }
        }
        private void BindClass()
        {
            cblClass.DataValueField = "ID";
            cblClass.DataTextField = "ClassName";
            cblClass.DataSource = BLL.NewsClass.GetContentClassesTree(base.GetSiteID);
            cblClass.DataBind();

        }
        private void BindUserModel()
        {
            drpUserModel.DataTextField = "ModelName";
            drpUserModel.DataValueField = "ID";
            drpUserModel.DataSource = UserModel.Instance.ModelClassList;
            drpUserModel.DataBind();
            //drpUserModel.Items[0].Selected = true;
        }

        private string GetItems()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ListItem li in cblClass.Items)
            {
                if (li.Selected)
                {
                    if (string.IsNullOrEmpty(li.Value)) continue;
                    sb.Append(li.Value);
                    sb.Append(",");
                }
            }
            if (sb.Length > 1) sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
        //private void BindModifyData()
        //{
        //    if (sID <1) return;
        //    UserGroupProfile ugp = UserGroupProfile.GetUserGroupProfile(sID);

        //    txtGruopName.Text = ugp.GroupName;
        //    CreditShigher.Text = ugp.CreditShigher.ToString();
        //    CreditSlower.Text = ugp.CreditSlower.ToString();
        //    ShowColor.Color = ugp.ShowColor;
        //    drpUserModel.SelectedValue = ugp.UserModelID.ToString();

        //    string[] aItems = ugp.AllowAddClass.Split(',');
        //    foreach (ListItem li in cblClass.Items)
        //    {
        //        if (Validate.InArray(li.Value,aItems))
        //        {
        //            li.Selected = true;
        //        }
        //    }
        //    cbIsAuditing.Checked = ugp.IsAuditingMember;

        //    cbIsAllowDelete.Checked = ugp.IsAllowDelete;
        //    cbIsAllowModify.Checked = ugp.IsAllowModify;

        //    cbIsAuditingContent.Checked = ugp.IsAuditingContent;

        //    txtContentNum.Text = ugp.AllowAddContentNum.ToString();
        //    txtManageIndex.Text = ugp.ManageIndex;
        //    //IsSys.Checked = ugp.IsSys;
        //    btnAdd.Text = "修改用户组";
        //}


        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    if (!Page.IsValid)
        //        throw new InvalidOperationException("验证已经失效，重先登录再试");

        //    UserGroupProfile ugp;
        //    if (sID>0) //id值大于0，说明修改数据
        //    {
        //        ugp = UserGroupProfile.GetUserGroupProfile(sID);
        //    }
        //    else
        //    {
        //        ugp = new UserGroupProfile();
        //    }
        //    ugp.GroupName = txtGruopName.Text.Trim();
        //    ugp.CreditShigher = int.Parse(CreditShigher.Text.Trim());
        //    ugp.CreditSlower = int.Parse(CreditSlower.Text.Trim());
        //    ugp.ShowColor = ShowColor.Color.Trim();
        //    ugp.UserModelID = new Guid(drpUserModel.SelectedValue);
        //    //ugp.IsSys = IsSys.Checked;
        //    ugp.AllowAddClass = GetItems();
        //    ugp.IsAuditingMember = cbIsAuditing.Checked;

        //    ugp.IsAllowDelete = cbIsAllowDelete.Checked;
        //    ugp.IsAllowModify = cbIsAllowModify.Checked;

        //    ugp.IsAuditingContent = cbIsAuditingContent.Checked;

        //    ugp.ManageIndex = txtManageIndex.Text;

        //    string sContentNum = txtContentNum.Text;

        //    if(!string.IsNullOrEmpty(sContentNum))
        //    {
        //        ugp.AllowAddContentNum = int.Parse(txtContentNum.Text);    
        //    }
        //    ugp.Save();  
        //}


    }
}