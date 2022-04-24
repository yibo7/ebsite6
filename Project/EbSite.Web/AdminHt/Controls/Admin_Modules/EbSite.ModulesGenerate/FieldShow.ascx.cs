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

    public partial class FieldShow : EbSite.Base.ControlPage.UserControlBase
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
        protected bool GetCheckColum(string columName)
        {
            bool isCheck = false;

            List<FieldInfo> lsit = System.Web.HttpContext.Current.Session["FieldShow"] as List<FieldInfo>;

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
        protected void bntOK_Click(object sender, EventArgs e)
        {

            List<FieldInfo> lsitALL = new List<FieldInfo>();
            List<FieldInfo> lsit = new List<FieldInfo>();
            if (!Equals(Session["FieldShow"], null))
            {
                lsitALL = Session["FieldShow"] as List<FieldInfo>;
                //为了修改时，不重复添加数据的字段，先删除当前的所有session记录,然后再添加.
                //删除 相当于查这个表之外的所有表
                lsitALL = (from li in lsitALL where li.TableName != tableName select li).ToList();
                foreach (GridViewRow row in gdList.Rows)
                {
                    EbSite.ModulesGenerate.Core.FieldInfo model = new FieldInfo();
                    CheckBox cb = (CheckBox)row.FindControl("Selector");
                    if (cb != null && cb.Checked)
                    {
                        Label columName = (Label)row.FindControl("columID");
                        model.FieldName = columName.Text;
                        model.TypeId = 3;//1:List 2:Add 3:Show 4：Search


                        model.TableName = Request.QueryString["tbn"];

                        lsitALL.Add(model);
                    }
                }


                Session["FieldShow"] = lsitALL;

            }
            else
            {
                foreach (GridViewRow row in gdList.Rows)
                {
                    EbSite.ModulesGenerate.Core.FieldInfo model = new FieldInfo();
                    CheckBox cb = (CheckBox)row.FindControl("Selector");
                    if (cb != null && cb.Checked)
                    {
                        Label columName = (Label)row.FindControl("columID");
                        model.FieldName = columName.Text;
                        model.TypeId = 3;//1:List 2:Add 3:Show 4：Search


                        model.TableName = Request.QueryString["tbn"];

                        lsit.Add(model);
                    }
                }


                Session["FieldShow"] = lsit;

            }
            EbSite.Core.Strings.cJavascripts.RunClientJs(this, "ColseGreyBox();");
        }
    }
}