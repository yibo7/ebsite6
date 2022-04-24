using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Entity;

namespace EbSite.Widgets.SearchKeepWord
{
    public partial class edit : WidgetEditBase
    {
        private string sShortID = "";
        private string sPageName = "";
        public override void LoadData()
        {
            ctbTag.EndLiteral = llTagEnd;
            ctbTag.Items = "表单设置#tagsdiv0|部件配置#tagsdiv1";
                StringDictionary settings = GetSettings();
                //if (!Page.IsPostBack)
                //{
                    BindCtrList();
                    
                    if (!Equals(settings, null))
                    {
                        
                        drpTem.CtrlValue = settings["Tem"];

                        string sCtrID = settings["Widget"];

                        if (!string.IsNullOrEmpty(sCtrID))
                        {
                            CustomSearch.edit md = new CustomSearch.edit();
                            md.DataID = new Guid(sCtrID);

                            dtCustomSearch = md.GetSettingsTable();
                            StringDictionary settings2 = md.GetSettings();
                            sPageName = settings2["SoPage"];

                            drpWidgets.SelectedValue = sCtrID;



                            BuilderGvColumn();

                            ModelClass mcmd = new ModelClass();
                            mcmd.Configs = GetColumListByCtrID(sCtrID);
                            Utis.Instance.BindCustomControlsByModelID(phCustomControls, this, mcmd);
                        }

                        if (!Equals(GetModifyID, Guid.Empty))
                        {
                            DataRow dr = SelectData(GetModifyID);

                            Utis.Instance.InitModifyCtr(phCustomControls, dr);
                            txtReWritePath.Text = dr["ReWritePath"].ToString();
                            txtTitle.Text = dr["Title"].ToString();

                            sShortID = dr["ShortID"].ToString();

                            bntAddOne.Text = "修改记录";
                        }
                        else
                        {
                            sShortID = Core.Strings.GetString.RandomNUMSTR(5);
                        }
                    }
                    BinData();
                //}
        }

        private DataTable dtCustomSearch;
        private List<ColumFiledConfigs> GetColumListByCtrID(string sCtrID)
        {
            List<ColumFiledConfigs> cfcs = new List<ColumFiledConfigs>();
            if(!string.IsNullOrEmpty(sCtrID))
            {
               DataTable dt = dtCustomSearch;
               if (dt.Rows.Count > 0)
               {
                   foreach (DataRow dr in dt.Rows)
                   {
                      
                       string sModelCtrlID = dr["ModelCtrlID"].ToString();
                       string sColumnName = dr["SearchFiled"].ToString();

                       ColumFiledConfigs cfc = new ColumFiledConfigs();

                       cfc.ColumFiledName = sColumnName;
                       cfc.ColumShowName = dr["FormName"].ToString();

                       cfc.FieldControlTypeID = new Guid(sModelCtrlID);
                      
                       cfc.IsShowAdmin = true;

                       cfc.IsShowUser = true;


                       cfcs.Add(cfc);
                   }
               }
            }
            return cfcs;     
        }
        /// <summary>
        /// 绑定数据到控件
        /// </summary>
        private void BinData()
        {
            DataTable dt = GetSettingsTable();
            if (!Equals(dt, null))
            {
                gvData.DataSource = dt;
                gvData.DataBind();
            }
        }
        /// <summary>
        /// 生成guidview控件的列
        /// </summary>
        /// <param name="sRowConfigs"></param>
        private void BuilderGvColumn()
        {
            BoundField bf;
            
            DataTable dt = dtCustomSearch;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string sColumnEname = dr["SearchFiled"].ToString();
                    string sColumnCname = dr["FormName"].ToString();

                    bf = new BoundField();
                    bf.DataField = sColumnEname;
                    bf.HeaderText = sColumnCname;
                    gvData.Columns.Insert(0, bf);
                }
            }

            

            bf = new BoundField();
            bf.DataField = "ShortId";
            bf.HeaderText = "唯一ID";
            gvData.Columns.Insert(0, bf);

            bf = new BoundField();
            bf.DataField = "ReWritePath";
            bf.HeaderText = "页面名称";
            gvData.Columns.Insert(0, bf);
            
            bf = new BoundField();
            bf.DataField = "Title";
            bf.HeaderText = "标题";
            gvData.Columns.Insert(0, bf);
            bf = new BoundField();

            CommandField cf = new CommandField();
            cf.EditText = "修改";
            cf.ShowEditButton = true;
            cf.DeleteText = "删除";
            cf.ShowDeleteButton = true;

            gvData.Columns.Add(cf);
        }
        private void BindCtrList()
        {
            drpWidgets.DataTextField = "Title";
            drpWidgets.DataValueField = "ID";
            //drpWidgets.DataSource = WidgetUtils.GetWidgetByType("CustomSearch");
            drpWidgets.DataSource = Base.ExtWidgets.WidgetsManage.DataBLL.Instance.GetListByType("CustomSearch");
            drpWidgets.DataBind();
        }
        /// <summary>
        /// 返回部件数据构成所需要列格式
        /// </summary>
        /// <returns></returns>
        public override List<string> InitColumns()
        {
            StringDictionary settings = GetSettings();
            List<string> lst = new List<string>();
            if (!Equals(settings, null))
            {
                string sCtrID = settings["Widget"];
                if (!string.IsNullOrEmpty(sCtrID))
                {
                    CustomSearch.edit md = new CustomSearch.edit();
                    md.DataID = new Guid(sCtrID);

                    dtCustomSearch = md.GetSettingsTable();
                    if (dtCustomSearch.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtCustomSearch.Rows)
                        {
                            lst.Add(dr["SearchFiled"].ToString());
                        }
                    }
                }
            }
            lst.Add("ShortId");
            lst.Add("ReWritePath");
            lst.Add("Title");

            
            
            return lst;
        }

        public override void Save()
        {
            base.Save();

            StringDictionary settings = GetSettings();

            settings["Tem"] = drpTem.CtrlValue;
            settings["Widget"] = drpWidgets.SelectedValue;
            settings["SoPage"] = sPageName;
            

            SaveSettings(settings);

        }
        
        /// <summary>
        /// 关闭保存按钮，因为这里使用bntAddOne_Click来执行保存
        /// </summary>
        /// <returns></returns>
        public override bool IsDisabledSave()
        {
            return true;
        }

        
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bntAddOne_Click(object sender, EventArgs e)
        {
            DataRow dr = base.WD.dt.NewRow();
            List<string> lst = new List<string>();
            Utis.Instance.InitSaveCtr(phCustomControls, ref dr);

            foreach (string s in InitColumns())
            {
                lst.Add(dr[s].ToString());
            }

            
            lst[lst.Count - 1] = txtTitle.Text.Trim();
            lst[lst.Count - 2] = txtReWritePath.Text.Trim();
            lst[lst.Count - 3] = sShortID;
            

            

            if (Equals(GetModifyID, Guid.Empty))
            {
                InsertData(lst);
            }
            else
            {
                Update(GetModifyID, lst);
            }
            Response.Redirect(sUrlToAdd);
        }


        protected void bntSave_Click(object sender, EventArgs e)
        {
            Save();
            Response.Redirect(sUrlToAdd);
        }


        protected void gvData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;

            string sID = gvData.DataKeys[e.NewEditIndex].Value.ToString();

            string sUrl = string.Concat(sUrlToAdd, "&did=", sID);

            Response.Redirect(sUrl);
        }

        protected void gvData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sID = gvData.DataKeys[e.RowIndex].Value.ToString();
            Delete(new Guid(sID));
            Response.Redirect(sUrlToAdd);
        }

        
        
    }

}