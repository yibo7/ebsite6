using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.Modules;
using EbSite.BLL;
using EbSite.Entity;

namespace EbSite.Modules.Wenda.UserPages.Controls.MyAskManage
{
    public partial class MyMsg : MPUCBaseListForUserRp
    {
        public override Guid ModuleMenuID
        {
            get
            {
                return new Guid("8cd05ba1-9b8d-4e03-96f4-c96433a0b496");
            }
        }
        public override string PageName
        {
            get
            {
                return "我的消息";
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
        //public override bool IsCloseTagsTitle
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}
        public override int OrderID
        {
            get
            {
                return 5;
            }
        }

        protected string GetModifyUrl
        {
            get
            {
                return "?box=1&t=0&id=";
            }
        }
        protected int iLoadCount = 0;
        override protected object LoadList(out int iCount)
        {
            string usname = EbSite.Base.Host.Instance.UserName;
            List<Msg> ls = EbSite.BLL.Msg.GetMsgs(usname, true);
            List<Msg> newls = (from i in ls orderby i.SendDate descending select i).ToList();
            iCount = ls.Count;
            iLoadCount = ls.Count;
            return newls;

        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            EbSite.BLL.Msg.DeleteMsg(int.Parse(iID.ToString()), base.UserName);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.gdList.Items.Count; i++)
            {
                CheckBox cb = this.gdList.Items[i].FindControl("Selector") as CheckBox;
                HiddenField hf = this.gdList.Items[i].FindControl("hf") as HiddenField;
                if (cb != null && cb.Checked && hf != null)
                {
                    Delete(hf.Value);  
                }
            }
        }
    }
}