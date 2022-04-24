using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL.GetLink;
using EbSite.Core.FSO;


namespace EbSite.Web.AdminHt.Controls.Admin_Comment
{
    public partial class ClassList : UserControlListBase
    {
        public override string Permission
        {
            get
            {
                return "125";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "126";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "220";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "221";
            }
        }
        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }
        override protected object LoadList(out int iCount)
        {
            iCount = 0;
            return BLL.RemarkClass.Instance.GetModelList();
        }

        override protected object SearchList(out int iCount)
        {
            throw new NotImplementedException();
        }
        override protected void Delete(object iID)
        {
            int iId = int.Parse(iID.ToString());
            string sPath = BLL.RemarkClass.GetNewPath(iId);
            BLL.RemarkClass.Instance.Delete(iId);
            Core.FSO.FObject.Delete(Server.MapPath(sPath), FsoMethod.File);

            //同时删除 Remark表中 的内容 因为 分类 以xml保存,新增分类 时，有时会重复。

            List<EbSite.Entity.Remark> ls = BLL.Remark.GetListArray("remarkclassid="+iId, 0, "");
            foreach (var remark in ls)
            {
                BLL.Remark.Delete(remark.ID);
            }


        }
        public string GetType(object itype)
        {
            if(itype.ToString()=="1")
            {
                return "无限回答式";
            }
            else if(itype.ToString()=="2")
            {
                return "评价系统";
            }
            else
            {
                return "商家问答式";
            }
        }

       
        protected string MakeCoder(string ID, object itype, object ipage)
        {
            if (ipage.ToString() == "1")
            {
                return string.Format("<iframe id=\"win\" name=\"win\" style=\"width: 100%; height: 600px;\" src=\'<%=HostApi.GetDiscussHref(\"{0}\",{1}, GetSiteID,{2},Model.ClassID,0)%>' frameborder=\"0\" scrolling=\"no\"></iframe>", ID, itype, ipage);
          
            }
            else
            {
                return string.Format("<iframe id=\"win\" name=\"win\" style=\"width: 100%; height: 600px;\" src=\'<%=HostApi.GetDiscussHref(\"{0}\",{1}, GetSiteID,{2},Model.ClassID,Model.ID )%>' frameborder=\"0\" scrolling=\"no\"></iframe>", ID, itype, ipage);
            }
           
        }
        override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            base.gdList_RowCommand(sender, e);
            if (Equals(e.CommandName, "showcontent"))
            { 
                string [] arry = e.CommandArgument.ToString().Split('|');
                Response.Redirect("Admin_Comment.aspx?t=2&cid=" + arry[0]+"&st="+arry[1]);

            }
            else if (Equals(e.CommandName, "EditTem"))
            {
                string id = e.CommandArgument.ToString();

                Entity.RemarkClass md = BLL.RemarkClass.Instance.GetEntity(int.Parse(id));
                Response.Redirect("Admin_Comment.aspx?t=10&id=" + id+ "&type=" + md.Itype);
            }

            
        }
    }
}