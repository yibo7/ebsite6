using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.BLL.ModelBll;

namespace EbSite.Web.AdminHt.Controls.Admin_Model
{
    abstract public class ModelListBase<TYPE> : EbSite.Base.ControlPage.UserControlListBase
    {
        #region 权限

        public override string Permission
        {
            get
            {
                return "103";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "104";
            }
        }
        /// <summary>
        /// 修改数据的权限ID
        /// </summary>
        public override string PermissionModifyID
        {
            get
            {
                return "209";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "210";
            }
        }
        //override protected string AddUrl
        //{
        //    get
        //    {
        //        return "t=0";
        //    }
        //}

        #endregion

        public abstract ModelBase<TYPE> bllModel { get; }

        override protected object LoadList(out int iCount)
        {
            
            iCount = 0;
            return bllModel.ModelClassList;

        }

        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            List<Entity.ModelClass> lstRz = new List<Entity.ModelClass>();
            List<Entity.ModelClass> lst = bllModel.ModelClassList;
            string sKeyTitle = ucToolBar.GetItemVal(txtOne).Trim();

            if (!string.IsNullOrEmpty(sKeyTitle))
            {
                foreach (Entity.ModelClass item in lst)
                {
                    if (item.ModelName.IndexOf(sKeyTitle) > -1)
                    {
                        lstRz.Add(item);
                    }
                }
            }
            else
            {
                lstRz = lst;
            }
            
            return lstRz;
        }
        override protected void Delete(object iID)
        {
            bllModel.DeleteModelByID(new Guid(iID.ToString()));

        }

        protected TextBox txtOne = new TextBox();
        protected Label lblClassName = new Label();
        protected override void BindToolBar()
        {
            base.BindToolBar();

            ucToolBar.AddLine();

            lblClassName.ID = "lblClassName";
            ucToolBar.AddCtr(lblClassName);
            lblClassName.Text = "模型名称：";

            txtOne.ID = "txtKeyWord";
            ucToolBar.AddCtr(txtOne);

            base.ShowCustomSearch("查询");

        }

       abstract protected string GetOrderUrl(object id);

       override protected void gdList_RowCommand(object sender, GridViewCommandEventArgs e)
       {
           base.gdList_RowCommand(sender, e);
           if (Equals(e.CommandName, "CopyModel"))
           {
               string id = e.CommandArgument.ToString();

               bllModel.CopyModel(new Guid(id),false);

               base.gdList_Bind();

           }
           if (Equals(e.CommandName, "CopyModel2"))
           {
               string id = e.CommandArgument.ToString();

               bllModel.CopyModel(new Guid(id),true);

               base.gdList_Bind();

           }
       }

    }
}