using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Core.DataBase.Interface;
using EbSite.ModulesGenerate.Core;

namespace EbSite.ModulesGenerate
{
    public partial class FieldAdd : EbSite.Base.ControlPage.UserControlBase
    {
        public override string Permission
        {
            get
            {
                return "1";
            }
        }

        public string tableName
        {
            get { return Request.QueryString["tbn"]; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            string dbName = Request.QueryString["dbn"];
            IDbObject dbobj = Session["dbobj"] as IDbObject;
            if (!Equals(dbobj, null))
            {
                this.gdList.DataSource = dbobj.GetColumnList(dbName, tableName);
                this.gdList.DataBind();
            }

        }

        private void GetEntity()
        {

        }
        List<FieldInfo> lsit = System.Web.HttpContext.Current.Session["FieldAdd"] as List<FieldInfo>;
        //protected List<FieldInfo> GetSessionList(List<FieldInfo> list)
        //{
        //    if (!Equals(lsit, null))
        //    {
        //        List<FieldInfo> NewList = (from li in lsit
        //                                   where (li.FieldName == columName) &&
        //                                         (li.TableName == tableName)
        //                                   select li
        //                                  ).ToList();
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        protected bool GetCheckColum(string columName)
        {
            bool isCheck = false;

            if (!Equals(lsit, null))
            {
                List<FieldInfo> NewList = (from li in lsit
                                           where (li.FieldName == columName) &&
                                               (li.TableName == tableName)
                                           select li
                                       ).ToList();
                if (NewList.Count > 0)
                {
                    isCheck = true;
                }
            }

            return isCheck;
        }
        protected string GetCheckControl(string columName)
        {
            string tag = "";        
            if (!Equals(lsit, null))
            {
                List<FieldInfo> NewList = (from li in lsit
                                           where (li.FieldName == columName) &&
                                               (li.TableName == tableName)
                                           select li
                                       ).ToList();
                if (NewList.Count > 0)
                {
                    tag = NewList[0].ControlId;
                }
            }

            return tag;
        }
        protected void gdList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList dp = (DropDownList)e.Row.FindControl("SelectControlID");
            Label Lb = (Label)e.Row.FindControl("columID");
            if (!Equals(Lb, null))
            {
                string tag = GetCheckControl(Lb.Text);
                if (tag != "")
                {
                    dp.SelectedValue = tag;
                }
            }
        }

        protected void bntOK_Click(object sender, EventArgs e)
        {

            List<FieldInfo> lsitALL = new List<FieldInfo>();
            List<FieldInfo> lsit = new List<FieldInfo>();

            if (!Equals(Session["FieldAdd"], null))
            {
                lsitALL = Session["FieldAdd"] as List<FieldInfo>;

                //为了修改时，不重复添加数据的字段，先删除当前的所有session记录,然后再添加.
                //删除 相当于查这个表之外的所有表
                lsitALL = (from li in lsitALL where li.TableName != tableName select li).ToList();

                foreach (GridViewRow row in gdList.Rows)
                {
                    CheckBox cb = (CheckBox)row.FindControl("Selector");
                    if (cb != null && cb.Checked)
                    {
                        EbSite.ModulesGenerate.Core.FieldInfo model = new FieldInfo();
                        Label columName = (Label)row.FindControl("columID");
                        model.FieldName = columName.Text;
                        model.TypeId = 2;//1:List 2:Add 3:Show 4：Search
                        DropDownList dp = (DropDownList)row.FindControl("SelectControlID");
                        model.ControlId = Convert.ToString(dp.SelectedValue);//1:文本控件.2.时间控件.3.文本编辑器
                        model.TableName = Request.QueryString["tbn"];
                        //Response.Write(columName.Text);

                        lsitALL.Add(model);
                    }

                }


                Session["FieldAdd"] = lsitALL;
            }
            else
            {
                foreach (GridViewRow row in gdList.Rows)
                {
                    CheckBox cb = (CheckBox)row.FindControl("Selector");
                    if (cb != null && cb.Checked)
                    {
                        EbSite.ModulesGenerate.Core.FieldInfo model = new FieldInfo();
                        Label columName = (Label)row.FindControl("columID");
                        model.FieldName = columName.Text;
                        model.TypeId = 2;//1:List 2:Add 3:Show 4：Search
                        DropDownList dp = (DropDownList)row.FindControl("SelectControlID");
                        model.ControlId = Convert.ToString(dp.SelectedValue);//1:文本控件.2.时间控件.3.文本编辑器
                        model.TableName = Request.QueryString["tbn"];
                        //Response.Write(columName.Text);

                        lsit.Add(model);
                    }

                }


                Session["FieldAdd"] = lsit;
            }

            //DataProvider 
            EbSite.Core.Strings.cJavascripts.RunClientJs(this, "ColseGreyBox();");



        }
    }
}