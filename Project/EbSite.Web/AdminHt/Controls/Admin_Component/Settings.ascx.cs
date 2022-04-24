using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.Base.Extension.Manager;
using GridView=System.Web.UI.WebControls.GridView;
using LinkButton=System.Web.UI.WebControls.LinkButton;

namespace EbSite.Web.AdminHt.Controls.Admin_Component
{
    public partial class Settings : PluginSettingsBase
    {
        override public ManagerExtBase ExtManager
        {
            get
            {
                return EbSite.Base.Extension.Manager.ExtensionManager.Instance;
            }
        }
        public override string Permission
        {
            get
            {
                return "142";
            }
        }
        /// <summary>
        /// Dynamically loads form controls or
        /// data grid and binds data to controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            _extensionName = this.ID;//此处ID在路由载入时读取,请参考路由

            _settings = ExtManager.GetSettings(_extensionName);
            //是否显示删除按钮
            GenerateDeleteButton = _settings.ShowDelete;
            //是否显示修改按钮
            GenerateEditButton = _settings.ShowEdit;

            if (_settings.ShowAdd) //显示修改或添加参数选项
                ExtManager.AddCtrToPH(_settings, phAddForm);
            
            if (!Page.IsPostBack)
            {
                //数据初始化
                if (_settings.IsScalar)
                {
                    //ctbTag.Items = string.Format("组件配置#tg1");
                    ExtManager.BindScalarToPh(_settings.Parameters, phAddForm, 0);
                }
                else
                {
                    //ctbTag.Items = string.Format("添加/修改#tg1|数据列表#tg2");
                    //生成表头
                    CreateTemplatedGridView();
                    //绑定列表数据
                    BindGrid();

                    tipsInfo.Visible = false;


                }
            }

            

            btnAdd.Click += new EventHandler(btnAdd_Click);
            //ctbTag.EndLiteral = llTagEnd;
           
            if (_settings.IsScalar)
            {
                btnAdd.Text = " 保 存 ";//Resources.labels.save;
            }
            else
            {
                if (_settings.ShowAdd)
                {
                    grid.RowEditing += new GridViewEditEventHandler(grid_RowEditing);
                    //grid.RowUpdating += new GridViewUpdateEventHandler(grid_RowUpdating);
                    //grid.RowCancelingEdit += delegate { Response.Redirect(Request.RawUrl); };
                    grid.RowDeleting += new GridViewDeleteEventHandler(grid_RowDeleting);
                    btnAdd.Text = " 添 加 ";
                }
                else
                    btnAdd.Visible = false;
            }
            if (iModifyRowIndex > -1)
            {
                //_settings.Parameters
                ExtManager.BindScalarToPh(_settings.Parameters, phAddForm, iModifyRowIndex);//[iModifyID]
                btnAdd.Text = " 修 改 ";
                lbAddLink.Text = string.Format("<a href='?t=1&ext={0}' >返回添加</a>", Request["ext"]);
            }

            
        }

        
        

        ///// <summary>
        ///// 更新数据 row in the grid
        ///// </summary>
        ///// <param name="sender">Grid View</param>
        ///// <param name="e">Event args</param>
        //void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    // extract and store input values in the collection
        //    StringCollection updateValues = new StringCollection();
        //    foreach (DataControlFieldCell cel in grid.Rows[e.RowIndex].Controls)
        //    {
        //        foreach (System.Web.UI.Control ctl in cel.Controls)
        //        {
        //            if (ctl.GetType().Name == "TextBox")
        //            {
        //                TextBox txt = (TextBox)ctl;
        //                updateValues.Add(txt.Text);
        //            }
        //        }
        //    }

        //    int paramIndex = ParameterValueIndex(sender, e.RowIndex);

        //    for (int i = 0; i < _settings.Parameters.Count; i++)
        //    {
        //        string parName = _settings.Parameters[i].Name;
        //        if (_settings.IsRequiredParameter(parName) && string.IsNullOrEmpty(updateValues[i]))
        //        {
        //            // throw error if required field is empty
        //            ErrorMsg.InnerHtml = "\"" + _settings.GetLabel(parName) + "\" 必须填写";//by Spoony 09.02.11
        //            ErrorMsg.Visible = true;
        //            e.Cancel = true;
        //            return;
        //        }
        //        else if (parName == _settings.KeyField && _settings.IsKeyValueExists(updateValues[i]))
        //        {
        //            // check if key value was changed; if not, it's ok to update
        //            if (!_settings.IsOldValue(parName, updateValues[i], paramIndex))
        //            {
        //                // trying to update key field with value that already exists
        //                ErrorMsg.InnerHtml = "\"" + updateValues[i] + "\" 已经存在";//by Spoony 09.02.11
        //                ErrorMsg.Visible = true;
        //                e.Cancel = true;
        //                return;
        //            }

        //        }
        //        else
        //            _settings.Parameters[i].Values[paramIndex] = updateValues[i];
        //    }

        //    ExtensionManager.SaveSettings(_extensionName, _settings);
        //    Response.Redirect(Request.RawUrl);
        //}


        

        

       
        

        
    }
}