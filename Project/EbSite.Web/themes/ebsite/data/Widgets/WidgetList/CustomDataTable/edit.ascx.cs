using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using EbSite.Base.ExtWidgets.WidgetsManage;
using EbSite.Entity;

namespace EbSite.Widgets.CustomDataTable
{
    public partial class edit : WidgetEditBase
    {
        public override void LoadData()
        {
            ctbTag.EndLiteral = llTagEnd;
            ctbTag.Items = "数据录入#tagsdiv0|部件配置#tagsdiv1";
                StringDictionary settings = GetSettings();
                if (!Equals(settings, null))
                {
                    drpTemList.CtrlValue = settings["TemList"];
                    string sRowConfigs = settings["Fileds"];
                    if (string.IsNullOrEmpty(sRowConfigs)) return;

                    txtFileds.Text = sRowConfigs;

                    BuilderGvColumn(sRowConfigs);
                    ModelClass mcmd = new ModelClass();
                    mcmd.Configs = GetColumListByConfigs(sRowConfigs);
                    DataTableUtis.Instance.BindCustomControlsByModelID(phCustomControls, this, mcmd);
                    //EbSite.Control.HiddenField tb = new EbSite.Control.HiddenField();
                    //tb.ID = "AddDate";
                    //phCustomControls.Controls.Add(tb);
                    if (!Equals(GetModifyID, Guid.Empty))
                    {
                        DataRow dr = SelectData(GetModifyID);

                        DataTableUtis.Instance.InitModifyCtr(phCustomControls, dr);
                        cbIsUpdateDate.Visible = true;
                        bntAddOne.Text = "修改记录";
                    }
                    //else
                    //{
                    //    tb.Value = DateTime.Now.ToString();
                    //}
                    
                    BinData();
  
                }
        }
        /// <summary>
        /// 从配置中分割出实体配置，读取次数多，可缓存
        /// </summary>
        /// <param name="Configs"></param>
        /// <returns></returns>
        private List<ColumFiledConfigs> GetColumListByConfigs(string Configs)
        {
            Regex re = new Regex("\r\n");

            string[] Fileds = re.Split(Configs);

            List<ColumFiledConfigs> cfcs = new List<ColumFiledConfigs>();
            foreach (string s in Fileds)
            {
                string[] sc = s.Split('|');
                ColumFiledConfigs cfc = new ColumFiledConfigs();

                cfc.ColumFiledName = sc[1];
                cfc.ColumShowName = sc[0];

                cfc.FieldControlTypeID = new Guid(sc[2]);
                if(sc.Length>3)
                 cfc.IsReadOnly =  bool.Parse(sc[3]);

                cfc.IsShowAdmin = true;
                
                cfc.IsShowUser = true;


                cfcs.Add(cfc);
            }
            return cfcs;
        }
        /// <summary>
        /// 生成guidview控件的列
        /// </summary>
        /// <param name="sRowConfigs"></param>
        private void BuilderGvColumn(string sRowConfigs)
        {

            List<ColumFiledConfigs> gclb = GetColumListByConfigs(sRowConfigs);
            BoundField bf;
            for (int i = (gclb.Count-1); i >= 0; i--)
            {
                ColumFiledConfigs lst = gclb[i];
                string sColumnEname = lst.ColumFiledName;
                string sColumnCname = lst.ColumShowName;

                bf = new BoundField();
                bf.DataField = sColumnEname;
                bf.HeaderText = sColumnCname;
                gvData.Columns.Insert(0, bf);
            }

           
            CommandField cf = new CommandField();
            cf.EditText = "修改";
            cf.ShowEditButton = true;
            cf.DeleteText = "删除";
            cf.ShowDeleteButton = true;

            gvData.Columns.Add(cf);
            
                
            //gvData.RowCommand += gvData_RowCommand;
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
        /// 返回部件数据构成所需要列格式
        /// </summary>
        /// <returns></returns>
        public override List<string> InitColumns()
        {
            List<string> lst = new List<string>();

            StringDictionary settings = GetSettings();
            if (!Equals(settings, null))
            {
                string sRowConfigs = settings["Fileds"];

                List<ColumFiledConfigs> gclb = GetColumListByConfigs(sRowConfigs);

                foreach (ColumFiledConfigs list in gclb)
                {
                    lst.Add(list.ColumFiledName);                    
                }
            }

            return lst;
        }

        public override void Save()
        {
            base.Save();

            StringDictionary settings = GetSettings();

            settings["Fileds"] = txtFileds.Text;
            settings["TemList"] = drpTemList.CtrlValue;

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
           
            List<string> lst = new List<string>();

            DataRow dr = base.WD.dt.NewRow();

            DataTableUtis.Instance.InitSaveCtr(phCustomControls, ref dr);
            
            foreach (string s in InitColumns())
            {
                lst.Add(dr[s].ToString());
            }

            if (Equals(GetModifyID, Guid.Empty))
            {
             
                //lst.Add(DateTime.Now.ToString());
                InsertData(lst);
            }
            else
            {
                //lst.Add(DateTime.Now.ToString());
                Update(GetModifyID, lst);
            }

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

        protected void bntSave_Click(object sender, EventArgs e)
        {
            Save();
            Response.Redirect(sUrlToAdd);
        }

       
        
    }
}