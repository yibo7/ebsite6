using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Entity;

namespace EbSite.Web.AdminHt.Controls.Admin_Content
{
    public partial class TagColor : UserControlListBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region 权限

        public override string Permission
        {
            get
            {
                return "164";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "232";
            }
        }

        #endregion

        override protected string AddUrl
        {
            get
            {
                return "";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return BLL.TagColor.Instance.FillList();
        }


        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            Guid id = new Guid(iID.ToString());
            BLL.TagColor.Instance.Delete(id);

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {

            Entity.TagColorInfo md = new TagColorInfo();
            md.ColorName = txtShowColor.Color;
            md.MaxShowNum = int.Parse(txtMaxShowNum.Text);
            BLL.TagColor.Instance.Add(md);
            base.gdList_Bind();

        }
    }
}