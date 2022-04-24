//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using EbSite.Base.ExtWidgets.WidgetsManage;
//using EbSite.Entity.SearchCustom;

//namespace EbSite.BLL.SearchCustom
//{
//    public class Edit : WidgetEditBase
//    {

//        #region 控件
//        /// <summary>
//        /// ctbTag control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.CustomTagsBox ctbTag;

//        /// <summary>
//        /// txtFormName control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.TextBox txtFormName;

//        protected global::EbSite.ControlData.ModelCtr ExtensionsCtrls;

//        /// <summary>
//        /// drpTableName control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.DropDownList drpTableName;

//        /// <summary>
//        /// drpColumnList control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.DropDownList drpColumnList;

//        /// <summary>
//        /// drpDataType control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.DropDownList drpDataType;

//        /// <summary>
//        /// drpWhere control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.DropDownList drpWhere;

//        /// <summary>
//        /// drpAndOr control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.DropDownList drpAndOr;

//        /// <summary>
//        /// bntAddOne control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.Button bntAddOne;

//        /// <summary>
//        /// gvData control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.GridView gvData;

//        /// <summary>
//        /// drpTem control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.ExtensionsCtrls drpTem;

//        /// <summary>
//        /// txtSoPage control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.TextBox txtSoPage;

//        /// <summary>
//        /// txtPageSize control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.TextBox txtPageSize;

//        /// <summary>
//        /// drpTarget control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.DropDownList drpTarget;

//        /// <summary>
//        /// drpSubmitType control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.DropDownList drpSubmitType;

//        /// <summary>
//        /// mdSubMitTextOrImgUrl control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.ExtensionsCtrls mdSubMitTextOrImgUrl;

//        /// <summary>
//        /// drpMethod control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.DropDownList drpMethod;

//        /// <summary>
//        /// txtOnSubmit control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.TextBox txtOnSubmit;

//        /// <summary>
//        /// txtTableConfigs control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.TextBox txtTableConfigs;

//        /// <summary>
//        /// bntSave control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::EbSite.Control.Button bntSave;

//        /// <summary>
//        /// llTagEnd control.
//        /// </summary>
//        /// <remarks>
//        /// Auto-generated field.
//        /// To modify move field declaration from designer file to code-behind file.
//        /// </remarks>
//        protected global::System.Web.UI.WebControls.Literal llTagEnd;
//        #endregion

//        public override void LoadData()
//        {
//            ctbTag.EndLiteral = llTagEnd;
//            ctbTag.Items = "表单设置#tagsdiv0|部件配置#tagsdiv1";
//            StringDictionary settings = GetSettings();
//            if (!Page.IsPostBack)
//            {

//                ExtensionsCtrls.BindD();
//                //txtSoPage.Text = string.Concat(Base.AppStartInit.IISPath, "searchcustom.aspx");
//                if (!Equals(GetModifyID, Guid.Empty))
//                {
//                    DataRow dr = SelectData(GetModifyID);
//                    drpTableName.SelectedValue = dr["TableName"].ToString();
//                    txtFormName.Text = dr["FormName"].ToString();
//                    ExtensionsCtrls.SelectedValue = dr["ModelCtrlID"].ToString();
//                    drpWhere.SelectedValue = dr["Where"].ToString();
//                    drpColumnList.SelectedValue = dr["SearchFiled"].ToString();
//                    drpDataType.SelectedValue = dr["DataType"].ToString();
//                    drpAndOr.SelectedValue = dr["AndOr"].ToString();
//                    bntAddOne.Text = "修改记录";
//                }

//                txtTableConfigs.Text = GetDefaultTableConfigs();
//                if (!Equals(settings, null))
//                {
//                    drpTem.CtrlValue = settings["Tem"];

//                    if (!string.IsNullOrEmpty(settings["SoPage"]))
//                        txtSoPage.Text = settings["SoPage"];

//                    drpTarget.SelectedValue = settings["Target"];
//                    drpSubmitType.SelectedValue = settings["SubmitType"];

//                    drpMethod.SelectedValue = settings["Method"];
//                    txtOnSubmit.Text = settings["OnSubmit"];

//                    //mdSubMitTextOrImgUrl.CtrlValue = "fff";

//                    txtPageSize.Text = settings["PageSize"];

//                    string sTableConfigs = settings["TableConfigs"];
//                    if (!string.IsNullOrEmpty(sTableConfigs))
//                    {
//                        txtTableConfigs.Text = sTableConfigs;
//                    }

//                    List<TableConfigsModel> lst = GetTableConfigs();

//                    drpTableName.DataTextField = "sTableCName";
//                    drpTableName.DataValueField = "sTableEName";
//                    drpTableName.DataSource = lst;
//                    drpTableName.DataBind();
//                    BindTableColumns();

//                }
//                BinData();
//            }
//        }


//        /// <summary>
//        /// 绑定数据到控件
//        /// </summary>
//        private void BinData()
//        {


//            DataTable dt = GetSettingsTable();
//            if (!Equals(dt, null))
//            {

//                gvData.DataSource = dt;
//                gvData.DataBind();
//            }


//        }
//        /// <summary>
//        /// 返回部件数据构成所需要列格式
//        /// </summary>
//        /// <returns></returns>
//        public override List<string> InitColumns()
//        {
//            List<string> lst = new List<string>();
//            lst.Add("TableName");
//            lst.Add("FormName");
//            lst.Add("ModelCtrlID");
//            lst.Add("SearchFiled");
//            lst.Add("Where");
//            lst.Add("DataType");
//            lst.Add("AndOr");


//            return lst;
//        }

//        public override void Save()
//        {
//            base.Save();

//            StringDictionary settings = GetSettings();

//            settings["Tem"] = drpTem.CtrlValue;
//            settings["TableConfigs"] = txtTableConfigs.Text.Trim();
//            settings["SoPage"] = txtSoPage.Text.Trim();
//            settings["Target"] = drpTarget.SelectedValue;
//            settings["SubmitType"] = drpSubmitType.SelectedValue;
//            settings["SubMitTextOrImgUrl"] = mdSubMitTextOrImgUrl.CtrlValue;
//            settings["Method"] = drpMethod.SelectedValue;
//            settings["OnSubmit"] = txtOnSubmit.Text;
//            settings["PageSize"] = txtPageSize.Text;
//            SaveSettings(settings);

//        }
//        /// <summary>
//        /// 这里获取要查询的表名与字段名，并保存到配置
//        /// </summary>
//        private void SaveTableConfigs()
//        {
//            StringDictionary settings = GetSettings();
//            string sTableNames = GetTableNames();
//            settings["TableNames"] = sTableNames;

//            string[] aTableName = sTableNames.Split(',');
//            StringBuilder sbColumns = new StringBuilder();
//            foreach (string tableName in aTableName)
//            {
//                TableConfigsModel tcm = GetTableConfigsByTableName(tableName);

//                sbColumns.Append(tcm.sColumnsWithTableName);

//                sbColumns.Append(",");
//            }
//            if (sbColumns.Length > 1) sbColumns.Remove(sbColumns.Length - 1, 1);
//            settings["Columns"] = sbColumns.ToString();

//            SaveSettings(settings);

//        }
//        /// <summary>
//        /// 关闭保存按钮，因为这里使用bntAddOne_Click来执行保存
//        /// </summary>
//        /// <returns></returns>
//        public override bool IsDisabledSave()
//        {
//            return true;
//        }
//        /// <summary>
//        /// 添加一条记录
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        protected void bntAddOne_Click(object sender, EventArgs e)
//        {
//            string sTableName = drpTableName.SelectedValue;
//            string sFormName = txtFormName.Text.Trim();
//            string sCtrID = ExtensionsCtrls.CtrValue;
//            string sSearchFiled = drpColumnList.SelectedValue;
//            string sWhere = drpWhere.SelectedValue;
//            string sDataType = drpDataType.SelectedValue;
//            string sAndOr = drpAndOr.SelectedValue;

//            if (Equals(sWhere, "1") || Equals(sWhere, "2"))
//            {
//                if (Equals(sDataType, "0") || Equals(sDataType, "2"))
//                {
//                    Core.Strings.cJavascripts.MessageShowBack("字符型与是否型不能比较大小");
//                    return;
//                }
//            }
//            if (Equals(sWhere, "3"))
//            {
//                if (!Equals(sDataType, "0"))
//                {
//                    Core.Strings.cJavascripts.MessageShowBack("条件为包含，只能应用于字符型");
//                    return;
//                }
//            }

//            List<string> lst = new List<string>();
//            lst.Add(sTableName);
//            lst.Add(sFormName);
//            lst.Add(sCtrID);
//            lst.Add(sSearchFiled);
//            lst.Add(sWhere);
//            lst.Add(sDataType);
//            lst.Add(sAndOr);

//            if (Equals(GetModifyID, Guid.Empty))
//            {
//                InsertData(lst);
//            }
//            else
//            {
//                Update(GetModifyID, lst);
//            }
//            SaveTableConfigs();
//            Response.Redirect(sUrlToAdd);
//        }


//        protected void bntSave_Click(object sender, EventArgs e)
//        {
//            Save();
//            Response.Redirect(sUrlToAdd);
//        }

//        protected void drpTableName_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            BindTableColumns();
//        }


//        #region 与表相关的处理

//        private string GetTableNames()
//        {
//            List<string> TableNames = new List<string>();
//            DataTable dt = GetSettingsTable();

//            if (dt.Rows.Count > 0)
//            {
//                foreach (DataRow dr in dt.Rows)
//                {
//                    string sTableName = dr["TableName"].ToString();
//                    if (!TableNames.Contains(sTableName))
//                    {
//                        TableNames.Add(sTableName);
//                    }
//                }
//            }
//            string[] at = TableNames.ToArray();
//            return string.Join(",", at);
//        }


//        ///// <summary>
//        ///// 默认给出两个表
//        ///// </summary>
//        ///// <returns></returns>
//        //private string GetDefaultTableConfigs()
//        //{
//        //    StringBuilder sb = new StringBuilder();

//        //    sb.AppendFormat("内容表|{0}NewsContent", Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix);
//        //    sb.Append("\r\n");
//        //    sb.Append("id,ClassName,classid,NewsTitle,ContentInfo,Advs,ClassName,SmallPic,dayHits,IsGood,OrderID,TitleStyle,weekHits,IsComment,hits,monthhits,UserID,UserNiName,UserName,Addtime,HtmlName,Annex1,Annex2,Annex3,Annex4,Annex5,Annex6,Annex7,Annex8,Annex9,Annex10");
//        //    sb.Append("\r\n");

//        //    sb.AppendFormat("分类表|{0}NewsClass", Base.Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix);
//        //    sb.Append("\r\n");
//        //    sb.Append("id,ClassName,Info,monthhits,SubClassModelID,ListTemID,TitleStyle,SeoKeyWord,SubDefaultContentModelID,ClassModelID,SeoTitle,SeoDescription,SubDefaultContentTemID,ContentModelID,hits,OutLike,SubClassAddName,SubIsCanAddSub,ContentTemID,dayHits,IsCanAddContent,SubClassTemID,SubIsCanAddContent,ClassTemID,weekHits,IsCanAddSub,Annex1,Annex2,Annex3,Annex4,Annex5,Annex6,Annex7,Annex8 ");


//        //    return sb.ToString();
//        //}


//        public TableConfigsModel GetTableConfigsByTableName(string sTableName)
//        {
//            List<TableConfigsModel> lst = GetTableConfigs();

//            TableConfigsModel tcm = null;

//            foreach (TableConfigsModel model in lst)
//            {
//                if (model.sTableEName == sTableName)
//                {
//                    tcm = model;
//                    break;
//                }
//            }

//            return tcm;
//        }
//        private List<TableConfigsModel> GetTableConfigs()
//        {
//            StringDictionary settings = GetSettings();
//            List<TableConfigsModel> lst = new List<TableConfigsModel>();
//            if (!Equals(settings, null))
//            {
//                string sTableConfigs = settings["TableConfigs"];

//                Regex re = new Regex("\r\n");
//                string sCf = !string.IsNullOrEmpty(sTableConfigs) ? sTableConfigs : GetDefaultTableConfigs();
//                string[] aTables = re.Split(sCf);

//                for (int i = 0; i < aTables.Length; i += 2)
//                {
//                    string[] aTableName = aTables[i].Split('|');
//                    TableConfigsModel tcm = new TableConfigsModel();

//                    if (aTableName.Length == 2)
//                    {
//                        tcm.sTableCName = aTableName[0];
//                        tcm.sTableEName = aTableName[1];
//                        tcm.sTableColumns = aTables[i + 1];

//                        lst.Add(tcm);
//                    }
//                }

//            }
//            return lst;
//        }

//        private void BindTableColumns()
//        {

//            string sTableName = drpTableName.SelectedValue;

//            TableConfigsModel tcm = GetTableConfigsByTableName(sTableName);

//            if (!Equals(tcm, null))
//            {
//                drpColumnList.DataSource = tcm.aTableColumns;
//                drpColumnList.DataBind();

//            }

//        }

//        #endregion
//    }
//}
