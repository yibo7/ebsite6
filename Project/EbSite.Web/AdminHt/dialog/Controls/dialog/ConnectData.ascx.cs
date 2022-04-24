using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;

namespace EbSite.Web.AdminHt.dialog.Controls.dialog
{
    public partial class ConnectData : UserControlListBase
    {
        protected override string AddUrl
        {
            get { throw new NotImplementedException(); }
        }
        protected override void Delete(object ID)
        {
            throw new NotImplementedException();
        }
        protected override object LoadList(out int iCount)
        {
            throw new NotImplementedException();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOtherLink();
            }
        }

        private void BindOtherLink()
        {
            ListItem li = new ListItem("标签列表连接", "<a href=\"<%=EbSite.Common.TagsList(1) %>\" >所有标签</a>");
            drpOtherLink.Items.Add(li);

            li = new ListItem("在线用户列表", string.Format("<a href=\"{0}u/useronline.aspx %>\" >在线用户</a>", Base.AppStartInit.IISPath));
            drpOtherLink.Items.Add(li);
        }
    }
}
