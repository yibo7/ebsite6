using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.MobileControls;
using EbSite.Core.DataBase.Entity;
using EbSite.Core.Strings;
using EbSite.Entity;

namespace EbSite.ModulesGenerate.Core.SysPlugins
{
    /// <summary>
    /// Web层代码组件
    /// </summary>
    public class BuilderWeb : IBuilder.IBuilderWeb
    {
        #region 私有字段
        protected string _key = "ID";//默认第一个主键字段		
        protected string _keyType = "int";//默认第一个主键类型        
        protected string _namespace = "EbSite"; //顶级命名空间名
        private string _folder = "";//所在文件夹
        protected string _modelname; //model类名           
        protected string _bllname; //model类名
        protected List<ColumnInfo> _fieldlist;
        protected List<ColumnInfo> _keys;
        protected string _dalname;
        protected List<FieldInfo> _SearchColum;
        protected List<FieldInfo> _SearchAdvColum;
        protected List<FieldInfo> _AddColum;
        protected List<FieldInfo> _ListColum;
        protected List<FieldInfo> _ShowColum;
        #endregion

        #region 权限
        //全部
        protected string Permission = Convert.ToString(Guid.NewGuid());
        //添中
        protected string PermissionAddID = Convert.ToString(Guid.NewGuid());
        //修改
        protected string PermissionModifyID = Convert.ToString(Guid.NewGuid());
        //删除
        protected string PermissionDelID = Convert.ToString(Guid.NewGuid());
        //导出
        protected string PermissionOutData = Convert.ToString(Guid.NewGuid());
        #endregion
        /// <summary>
        /// 搜索字段
        /// </summary>
        public List<FieldInfo> SearchColum
        {
            set { _SearchColum = value; }
            get { return _SearchColum; }
        }
        /// <summary>
        /// 高级搜索字段
        /// </summary>
        public List<FieldInfo> SearchAdvColum
        {
            set { _SearchAdvColum = value; }
            get { return _SearchAdvColum; }
        }
        /// <summary>
        ///  添加字段
        /// </summary>
        public List<FieldInfo> AddColum
        {
            set { _AddColum = value; }
            get { return _AddColum; }
        }
        /// <summary>
        /// 列表字段
        /// </summary>
        public List<FieldInfo> ListColum
        {
            set { _ListColum = value; }
            get { return _ListColum; }
        }
        /// <summary>
        /// 显示字段
        /// </summary>
        public List<FieldInfo> ShowColum
        {
            set { _ShowColum = value; }
            get { return _ShowColum; }
        }

        public string DalName
        {
            set { _dalname = value; }
            get { return _dalname; }

        }
        #region 公有属性
        /// <summary>
        /// 顶级命名空间名 
        /// </summary>        
        public string NameSpace
        {
            set { _namespace = value; }
            get { return _namespace; }
        }
        /// <summary>
        /// 所在文件夹名
        /// </summary>
        public string Folder
        {
            set { _folder = value; }
            get { return _folder; }
        }
        /// <summary>
        /// Model类名
        /// </summary>
        public string ModelName
        {
            set { _modelname = value; }
            get { return _modelname; }
        }
        /// <summary>
        /// BLL类名
        /// </summary>
        public string BLLName
        {
            set { _bllname = value; }
            get { return _bllname; }
        }

        /// <summary>
        /// 实体类的整个命名空间+类名
        /// </summary>
        public string ModelSpace
        {
            get
            {
                string _modelspace = _namespace + "." + "Model";
                if (_folder.Trim() != "")
                {
                    _modelspace += "." + _folder;
                }
                _modelspace += "." + ModelName;
                return _modelspace;
            }
        }

        /// <summary>
        /// 业务逻辑层的操作类名称定义
        /// </summary>
        private string BLLSpace
        {
            get
            {
                string _bllspace = _namespace + "." + "BLL";
                if (_folder.Trim() != "")
                {
                    _bllspace += "." + _folder;
                }
                _bllspace += "." + BLLName;
                return _bllspace;
            }
        }
        /// <summary>
        /// 选择的字段集合
        /// </summary>
        public List<ColumnInfo> Fieldlist
        {
            set { _fieldlist = value; }
            get { return _fieldlist; }
        }
        /// <summary>
        /// 主键或条件字段列表 
        /// </summary>
        public List<ColumnInfo> Keys
        {
            set { _keys = value; }
            get { return _keys; }
        }
        /// <summary>
        /// 主键标识字段
        /// </summary>
        protected string Key
        {
            get
            {
                foreach (ColumnInfo key in _keys)
                {
                    _key = key.ColumnName;
                    _keyType = key.TypeName;
                    if (key.IsIdentity)
                    {
                        _key = key.ColumnName;
                        _keyType = CodeCommon.DbTypeToCS(key.TypeName);
                        break;
                    }
                }
                return _key;
            }
        }
        #endregion

        public BuilderWeb()
        {
        }

        #region //欢乐2011-01-26 加权限的添加,给模块添加权限
        //public void AddPermission()
        //{
        //    List<ResponQx> lsit=new List<ResponQx>();
        //    Entity.ResponQx model=new ResponQx();
        //    model.name = ModelName;
        //    model.quanbu = this.Permission;
        //    model.xinzeng = this.PermissionAddID;
        //    model.xiguai = this.PermissionModifyID;
        //    model.shanchu = this.PermissionDelID;
        //    model.daochu = this.PermissionOutData;
        //    model.IsAll = "";

        //    //---其它没有用到先给成0
        //    model.chakan = "0";
        //    model.shenpi = "0";
        //    model.shouquan = "0";
        //    model.chaxun = "0";
        //    model.geren = "0";
        //    model.bumen = "0";
        //    model.gongsi = "0";
        //    model.xiaoshou = "0";
        //    model.parentid = 0;

        //    lsit.Add(model);
        //    System.Web.HttpContext.Current.Session["Permission"] = lsit;
        //   // BLL.ResponQx.Instance.Add(model);
        //}
        #endregion

        #region 页面html
        /// <summary>
        /// 路由页面html
        /// </summary>
        /// <returns></returns>
        public string GetRouteHTML()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"" + ModelName + ".aspx.cs\" Inherits=\"EbSite.Modules." + DalName + ".Pages." + ModelName + "\" ValidateRequest=\"false\" %>");
            strclass.AppendLine("<asp:content id='Content1' runat='Server' contentplaceholderid='ctphBody'>");
            strclass.AppendLine("<asp:PlaceHolder   id=\"phBodyControls\" runat=\"server\"></asp:PlaceHolder>");
            strclass.AppendLine("</asp:content>");
            return strclass.ToString();
        }

        /// <summary>
        /// 得到表示层增加窗体的html代码
        /// </summary>      
        public string GetAddHTML()
        {
            StringPlus strclass = new StringPlus();
            // strclass.AppendLine("<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"" + ModelName + "_add.ascx.cs\" Inherits=\"EbSite.Modules." + DalName + ".Pages.Controls." + ModelName + "." + ModelName + "_add\"%> ");
            strclass.AppendLine("<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"Add.ascx.cs\" Inherits=\"EbSite.Modules." + DalName + ".Pages.Controls." + ModelName + ".Add\"%> ");

            strclass.AppendLine("<%@ Register Assembly=\"EbSite.Control\" Namespace=\"EbSite.Control\" TagPrefix=\"XS\" %>");

            strclass.AppendLine("<asp:PlaceHolder ID=\"phCtrList\" runat=\"server\">");
            strclass.AppendSpaceLine(1, "<div class=\"admin_toobar\">");
            strclass.AppendSpaceLine(2, "<fieldset>");
            strclass.AppendSpaceLine(3, "<legend>添加信息</legend>");
            strclass.AppendSpaceLine(3, "<div>");

            strclass.AppendLine();
            strclass.AppendSpaceLine(3, "<table cellSpacing=\"0\" cellPadding=\"0\" width=\"100%\" border=\"0\">");


            //判断Session 是否为空。
            if (!Equals(AddColum, null))
            {


                #region 新版
                foreach (FieldInfo field in AddColum)
                {
                    string columnName = field.FieldName; //字段名
                    string controlID = field.ControlId; //控件名ID

                    strclass.AppendSpaceLine(3, "<tr>");
                    strclass.AppendSpaceLine(3, "<td height=\"25\" width=\"30%\" align=\"right\">");
                    strclass.AppendSpaceLine(4, columnName);
                    strclass.AppendSpaceLine(3, "：</td>");
                    strclass.AppendSpaceLine(3, "<td height=\"25\" width=\"*\" align=\"left\">");
                    switch (controlID.Trim().ToLower())
                    {
                        case "1":
                            strclass.AppendSpaceLine(4, "<XS:TextBoxVl id=\"" + columnName + "\" runat=\"server\" Width=\"200px\"></XS:TextBoxVl>");
                            break;
                        case "2":
                            strclass.AppendSpaceLine(4, "<XS:DatePicker Width=\"100\" ID=\"" + columnName + "\" runat=\"server\" />");
                            break;
                        case "3":// <XS:Editor ID="ctent" runat="server"  EditorTools="全功能模式" ExtImg="gif,jpg,GIF,JPG,png,PNG"  Width="600" Height="300" />

                            strclass.AppendSpaceLine(4, "<XS:Editor ID=\"" + columnName + "\"  EditorTools=\"全功能模式\"  runat=\"server\" ExtImg=\"gif,jpg,GIF,JPG,png,PNG\"  Width=\"600\" Height=\"300\" />");
                            break;


                    }
                    strclass.AppendSpaceLine(3, "</td></tr>");
                }
                #endregion
            }


            #region  原版
            //foreach (ColumnInfo field in Fieldlist)
            //{
            //    string columnName = field.ColumnName;
            //    string columnType = field.TypeName;
            //    string deText = field.DeText;
            //    bool ispk = field.IsPK;
            //    bool IsIdentity = field.IsIdentity;
            //    if (IsIdentity)
            //    {
            //        continue;
            //    }
            //    if (deText.Trim() == "")
            //    {
            //        deText = columnName;
            //    }
            //    strclass.AppendSpaceLine(3, "<tr>");
            //    strclass.AppendSpaceLine(3, "<td height=\"25\" width=\"30%\" align=\"right\">");
            //    strclass.AppendSpaceLine(4, deText);
            //    strclass.AppendSpaceLine(3, "：</td>");
            //    strclass.AppendSpaceLine(3, "<td height=\"25\" width=\"*\" align=\"left\">");
            //    switch (columnType.Trim().ToLower())
            //    {
            //        case "datetime":
            //        case "smalldatetime":
            //            strclass.AppendSpaceLine(4, "<XS:DatePicker Width=\"100\" ID=\"" + columnName + "\" runat=\"server\" />");
            //            break;
            //        case "bit":
            //            strclass.AppendSpaceLine(4, "<XS:CheckBox ID=\"" + columnName + "\" Text=\"" + deText + "\" runat=\"server\" Checked=\"False\"/>");
            //            break;
            //        default:
            //            strclass.AppendSpaceLine(4, "<XS:TextBox id=\"" + columnName + "\" runat=\"server\" Width=\"200px\"></XS:TextBox>");
            //            break;
            //    }
            //    strclass.AppendSpaceLine(3, "</td></tr>");
            //}
            #endregion
            strclass.AppendSpaceLine(2, "</table>");



            strclass.AppendSpaceLine(2, "</div>");
            strclass.AppendSpaceLine(2, "</fieldset>");
            strclass.AppendSpaceLine(1, "</div>");
            strclass.AppendLine("</asp:PlaceHolder>");
            strclass.AppendLine("<div style=\"text-align: center\">");
            strclass.AppendSpaceLine(1, "<XS:Button ID=\"bntSave\" runat=\"server\"  Text=\" 保存 \" />");
            strclass.AppendLine("</div>");

            return strclass.ToString();
        }
        /// <summary>
        /// 得到表示层列表窗体的html代码
        /// </summary>      
        public string GetListHTML()
        {

            StringPlus strclass = new StringPlus();
            // strclass.AppendLine("<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"" + ModelName + ".ascx.cs\" Inherits=\"EbSite.Modules." + DalName + ".Pages.Controls." + ModelName + "." + ModelName + "\"%> ");
            strclass.AppendLine("<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"List.ascx.cs\" Inherits=\"EbSite.Modules." + DalName + ".Pages.Controls." + ModelName + ".List\"%> ");

            strclass.AppendLine("<%@ Register Assembly=\"EbSite.Control\" Namespace=\"EbSite.Control\" TagPrefix=\"XS\" %>");

            strclass.AppendLine("<XS:ToolBar ID=\"ucToolBar\" runat=\"server\"></XS:ToolBar>");


            //开始主要部分
            strclass.AppendLine("<div id=\"PagesMain\">");
            strclass.AppendSpaceLine(1,
                                     "<XS:GridView ID=\"gdList\" runat=\"server\" AutoGenerateColumns=\"false\" DataKeyNames=\"" +
                                     Key + "\" >");
            strclass.AppendSpaceLine(2, "<Columns>");
                                       
            strclass.AppendSpaceLine(3, " <asp:TemplateField HeaderText=\"序号\"  ItemStyle-Width=\"50\"  ItemStyle-HorizontalAlign=\"Center\" ItemStyle-VerticalAlign=\"Middle\" > ");
            strclass.AppendSpaceLine(4, " <ItemTemplate>");
            strclass.AppendSpaceLine(5, " <div style=\" text-align:center;\">  <%# (this.pcPage.PageIndex-1) * this.pcPage.PageSize + Container.DataItemIndex + 1%></div> ");
            strclass.AppendSpaceLine(4, " </ItemTemplate>");
            strclass.AppendSpaceLine(3, " </asp:TemplateField>");

            if (!Equals(ListColum, null))
            {
                foreach (FieldInfo field in ListColum)
                {
                    string columnName = field.FieldName;


                    strclass.AppendSpaceLine(3, "<asp:TemplateField HeaderText=\"" + columnName + "\">");
                    strclass.AppendSpaceLine(4, "<ItemTemplate>");
                    strclass.AppendSpaceLine(5, "<%#Eval(\"" + columnName + "\")%>");
                    strclass.AppendSpaceLine(4, "</ItemTemplate>");
                    strclass.AppendSpaceLine(3, "</asp:TemplateField>");
                }
            }


            #region 原版
            //foreach (ColumnInfo field in Fieldlist)
            //{
            //    string columnName = field.ColumnName;
            //    string columnType = field.TypeName;
            //    string deText = field.DeText;
            //    bool ispk = field.IsPK;
            //    bool IsIdentity = field.IsIdentity;
            //    if (IsIdentity)
            //    {
            //        continue;
            //    }
            //    if (deText.Trim() == "")
            //    {
            //        deText = columnName;
            //    }

            //    strclass.AppendSpaceLine(3, "<asp:TemplateField HeaderText=\"" + deText + "\">");
            //    strclass.AppendSpaceLine(4, "<ItemTemplate>");
            //    strclass.AppendSpaceLine(5, "<%#Eval(\"" + columnName + "\")%>");
            //    strclass.AppendSpaceLine(4, "</ItemTemplate>");
            //    strclass.AppendSpaceLine(3, "</asp:TemplateField>");
            //}
            #endregion

            strclass.AppendSpaceLine(3, "<asp:TemplateField HeaderText=\"操作\">");
            strclass.AppendSpaceLine(4, "<ItemTemplate>");
            strclass.AppendSpaceLine(5, " <XS:LinkButton ID=\"lbDelete\" runat=\"server\" CommandArgument='<%#Eval(\"" + Key + "\") %>' CommandName=\"DeleteModel\" confirm=\"true\" Text=\"删除\"></XS:LinkButton>/");
            
            strclass.AppendSpaceLine(5, "<XS:EasyuiDialog ID=\"wbModify\" Title=\"修改\" Text=\"修改\" runat=\"server\"/>/");
            strclass.AppendSpaceLine(5, "<XS:EasyuiDialog ID=\"wbShow\"  Title=\"详细内容\" Text=\"详细内容\" runat=\"server\" />");

            strclass.AppendSpaceLine(4, "</ItemTemplate>");
            strclass.AppendSpaceLine(3, "</asp:TemplateField>");

            strclass.AppendSpaceLine(3, "<asp:TemplateField HeaderText=\"选择(<span onclick='on_checkback(PagesMain)'style='cursor:hand;color:#FF0000'>全选</span>)\">");
            strclass.AppendSpaceLine(4, "<ItemTemplate>");
            strclass.AppendSpaceLine(5, "<asp:CheckBox ID=\"Selector\" runat=\"server\" />");
            strclass.AppendSpaceLine(4, "</ItemTemplate>");
            strclass.AppendSpaceLine(3, "</asp:TemplateField>");

            strclass.AppendSpaceLine(2, "</Columns>");
            strclass.AppendSpaceLine(1, "</XS:GridView>");



            strclass.AppendLine("</div>");
            strclass.AppendLine("<div>");
            strclass.AppendSpaceLine(1, " <XS:PagesContrl ID=\"pcPage\" runat=\"server\" />");
            strclass.AppendLine("</div>");


            if (!Equals(SearchAdvColum, null))
            {

                //高级查询 2011-01-26
                int length = SearchAdvColum.Count * 25 + 100;
                strclass.AppendLine("<div id=\"divSearchadv\" title=\"高级查询\" style=\"height: " + length + "px; width: 280px; display: none\">");
                strclass.AppendLine("<div style=\"margin-top: 15px;margin-left: 15px;\">");
                strclass.AppendSpaceLine(2, "<table cellpadding=\"0\" cellspacing=\"0\" class=\"CustomTool\">");

                foreach (FieldInfo fieldInfo in SearchAdvColum)
                {

                    strclass.AppendSpaceLine(3, "<tr>");
                    strclass.AppendSpaceLine(4, "<td>");
                    strclass.AppendSpaceLine(5, fieldInfo.FieldName);
                    strclass.AppendSpaceLine(4, "</td>");
                    strclass.AppendSpaceLine(4, "<td>");

                    if (fieldInfo.ControlId != "datetime")//先用ControlId作为存放数据类型
                    {
                        strclass.AppendSpaceLine(4, "<XS:TextBoxVl ID=\"" + fieldInfo.FieldName + "\" runat=\"server\" Width=\"120px\" HintInfo=\"" + fieldInfo.FieldName + "\"></XS:TextBoxVl>");
                    }
                    else
                    {
                        strclass.AppendSpaceLine(4, "<XS:DatePicker Width=\"100\" ID=\"" + fieldInfo.FieldName + "\" runat=\"server\" />");
                    }

                    strclass.AppendSpaceLine(4, "</td>");
                    strclass.AppendSpaceLine(3, "</tr>");
                }

            }

            strclass.AppendSpaceLine(2, "</table>");

            strclass.AppendLine("</div>");
            strclass.AppendLine("</div>");
            ;
            return strclass.ToString();
        }
        /// <summary>
        /// 得到表示层显示窗体的html代码
        /// </summary>     
        public string GetShowHTML()
        {
            StringPlus strclass = new StringPlus();
            // strclass.AppendLine("<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"" + ModelName + "_show.ascx.cs\" Inherits=\"EbSite.Modules." + DalName + ".Pages.Controls." + ModelName + "." + ModelName + "_show\"%> ");
            strclass.AppendLine("<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"Show.ascx.cs\" Inherits=\"EbSite.Modules." + DalName + ".Pages.Controls." + ModelName + ".Show\"%> ");

            strclass.AppendLine("<%@ Register Assembly=\"EbSite.Control\" Namespace=\"EbSite.Control\" TagPrefix=\"XS\" %>");

            strclass.AppendLine("<div class=\"admin_toobar\">");
            strclass.AppendSpaceLine(1, "<fieldset>");
            strclass.AppendSpaceLine(2, "<legend>详细内容 </legend>");

            strclass.AppendSpaceLine(2, "<div style=\"margin-left:20px;\">");
            strclass.AppendSpaceLine(3, "<table cellpadding=\"0\" cellspacing=\"0\">");


            if (!Equals(ShowColum, null))
            {


                foreach (FieldInfo field in ShowColum)
                {
                    string columnName = field.FieldName;

                    strclass.AppendSpaceLine(4, "<tr>");
                    strclass.AppendSpaceLine(5, "<td>");
                    strclass.AppendSpaceLine(6, columnName + ":" + "<%=Model." + columnName + "%>");
                    strclass.AppendSpaceLine(5, "</td>");
                    strclass.AppendSpaceLine(4, "</tr>");
                }
            }

            #region 原版
            //foreach (ColumnInfo field in Fieldlist)
            //{
            //    string columnName = field.ColumnName;
            //    string columnType = field.TypeName;
            //    string deText = field.DeText;
            //    if (deText.Trim() == "")
            //    {
            //        deText = columnName;
            //    }

            //    strclass.AppendSpaceLine(4, "<tr>");
            //    strclass.AppendSpaceLine(5, "<td>");
            //    strclass.AppendSpaceLine(6, deText + ":" + "<%=Model." + columnName + "%>");
            //    strclass.AppendSpaceLine(5, "</td>");
            //    strclass.AppendSpaceLine(4, "</tr>");
            //}
            #endregion
            strclass.AppendSpaceLine(3, "</table>");
            strclass.AppendSpaceLine(2, "</div>");
            strclass.AppendSpaceLine(1, "</fieldset>");
            strclass.AppendLine("</div>");


            strclass.AppendLine("<div style=\"text-align: center\">");
            strclass.AppendSpaceLine(1, "<XS:Button ID=\"btnColseGreyBox\" runat=\"server\" Text=\" 关 闭 窗 口 \" />");
            // strclass.AppendSpaceLine(1, "<XS:Button ID=\"btnDelete\" runat=\"server\" Text=\" 删除当前记录 \" />");
            strclass.AppendLine("</div>");

            return strclass.ToString();
        }

        #endregion

        #region 表示层 CS
        /// <summary>
        /// 路由页面后台代码
        /// </summary>
        /// <returns></returns>
        public string GetRouteCS()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("using System;");
            strclass.AppendLine("using EbSite.Base.Modules;");
            strclass.AppendSpaceLine(2, "");
            // EbSite.Modules.CustomTools.Pages
            strclass.AppendLine("namespace EbSite.Modules." + DalName + ".Pages");
            strclass.Append("{");
            strclass.AppendSpaceLine(2, "");
            strclass.AppendSpaceLine(1, "public partial class " + ModelName + " :MPage");
            strclass.AppendSpaceLine(1, "{");

            //strclass.AppendSpaceLine(2, "public override string PageName");
            //strclass.AppendSpaceLine(2, "{");
            //strclass.AppendSpaceLine(3, "get");
            //strclass.AppendSpaceLine(3, "{");
            //strclass.AppendSpaceLine(4, "return \"\";");
            //strclass.AppendSpaceLine(3, "}");
            //strclass.AppendSpaceLine(2, "}");

            //strclass.AppendSpaceLine(2, "");

            strclass.AppendSpaceLine(2, "protected void Page_Load(object sender, EventArgs e)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(2, "");
            // strclass.AppendSpaceLine(3, "base.SetContolsPath(\"" + ModelName + "\");");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "");

            strclass.AppendSpaceLine(2, "protected override void AddControl()");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "if (PageType == 0)//添加");
            strclass.AppendSpaceLine(3, "{");
            // strclass.AppendSpaceLine(4, "base.LoadAControl(\"" + ModelName + "_add.ascx\");");
            strclass.AppendSpaceLine(4, "base.LoadAControl(\"Add.ascx\");");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(3, "else if (PageType == 1) //显示");
            strclass.AppendSpaceLine(3, "{");
            //strclass.AppendSpaceLine(4, "base.LoadAControl(\"" + ModelName + "_show.ascx\");");
            strclass.AppendSpaceLine(4, "base.LoadAControl(\"Show.ascx\");");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(3, "else");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(3, "base.AddControl();");
            strclass.AppendSpaceLine(3, "}");



            strclass.AppendSpaceLine(2, "}");
            strclass.AppendSpaceLine(1, "}");

            strclass.Append("}");
            return strclass.ToString();
        }

        /// <summary>
        /// 得到表示层增加窗体的代码
        /// </summary>      
        public string GetAddCs()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("using System;");
            // strclass.AppendLine("using EbSite.Base.BLL;");
            strclass.AppendLine("using EbSite.Base.Modules;");
            strclass.AppendSpaceLine(2, "");
            // namespace EbSite.Modules.CustomTools.Pages.Controls.CusttomQuery
            strclass.AppendLine("namespace EbSite.Modules." + DalName + ".Pages.Controls." + ModelName + "");
            strclass.Append("{");
            strclass.AppendSpaceLine(2, "");
            //public partial class WebSite_add : MPUCBaseSave
            // strclass.AppendSpaceLine(1, "public partial class " + ModelName + "_add : EbSite.Base.Modules.MPUCBaseSave");
            strclass.AppendSpaceLine(1, "public partial class Add : MPUCBaseSave");
            strclass.AppendSpaceLine(1, "{");


            strclass.AppendSpaceLine(2, "public override string Permission");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get");
            strclass.AppendSpaceLine(3, "{");
            // strclass.AppendSpaceLine(4, "return \"1\";");
            strclass.AppendSpaceLine(4, "return \"" + Permission + "\";");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");



            strclass.AppendSpaceLine(2, "override protected string KeyColumnName");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return \"" + Key + "\";");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");


            strclass.AppendSpaceLine(2, "override protected void InitModifyCtr()");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "ModuleCore.BLL." + ModelName + ".Instance.InitModifyCtr(SID, phCtrList);");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "override protected void SaveModel()");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "ModuleCore.BLL." + ModelName + ".Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);");
            strclass.AppendSpaceLine(3, "base.ShowTipsPop(\"添加成功\");");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(1, "}");
            strclass.AppendLine("}");

            return strclass.ToString();
        }
        /// <summary>
        /// 得到列表窗体的代码
        /// </summary>      
        public string GetListCs()
        {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("using System;");
            strclass.AppendLine("using EbSite.Base.Modules;");
            strclass.AppendLine("using EbSite.Base.Page;");
            strclass.AppendLine("using System.Collections.Generic;");
            strclass.AppendLine("using EbSite.Control;");
            strclass.AppendLine("using System.Web.UI.WebControls;");
            strclass.AppendLine("using TextBox = System.Web.UI.WebControls.TextBox;");
            strclass.AppendSpaceLine(2, "");
            // namespace EbSite.Modules.CustomTools.Pages.Controls.CusttomQuery
            strclass.AppendLine("namespace EbSite.Modules." + DalName + ".Pages.Controls." + ModelName + "");
            strclass.Append("{");
            strclass.AppendSpaceLine(2, "");
            //public partial class WebSite : UserControlListBase
            // strclass.AppendSpaceLine(1, "public partial class " + ModelName + ": EbSite.Base.Page.UserControlListBase");
            strclass.AppendSpaceLine(1, "public partial class List: MPUCBaseList");
            strclass.AppendSpaceLine(1, "{");

            strclass.AppendSpaceLine(2, "public override string PageName");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return \"" + ModelName + "\";");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 是否添加到管理页面菜单之中");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public override bool IsAddToAdminMenus");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return true;");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");

            // 权限全部
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 权限全部");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public override string Permission");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return \"" + Permission + "\";");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");

            //添加
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 添加");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public override string PermissionAddID");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return \"" + PermissionAddID + "\";");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");

            //修改
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 修改");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public override string PermissionModifyID");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return \"" + PermissionModifyID + "\";");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");

            //删除
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 删除");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public override string PermissionDelID");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return \"" + PermissionDelID + "\";");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");

            //导出
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 导出");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public override string PermissionOutData");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return \"" + PermissionOutData + "\";");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");

            //重写添加路径
            strclass.AppendSpaceLine(2, "override protected string AddUrl");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return \"" + ModelName + ".aspx?t=0\";");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");

            //重写显示路径
            strclass.AppendSpaceLine(2, "override protected string ShowUrl");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return \"" + ModelName + ".aspx?t=1\";");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");


            //重写默认查询
            strclass.AppendSpaceLine(2, "override protected object LoadList(out int iCount)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return ModuleCore.BLL." + ModelName + ".Instance.GetListPages(pcPage.PageIndex, iPageSize, out iCount);");
            strclass.AppendSpaceLine(2, "}");
            #region 这种查询不科学 ，不通用。
            ////重写查询条件2010-11-30
            //strclass.AppendSpaceLine(2, "/// <summary>");
            //strclass.AppendSpaceLine(2, "/// 重写查询条件");
            //strclass.AppendSpaceLine(2, "/// </summary>");
            //strclass.AppendSpaceLine(2, "override protected string BulderSearchWhere(bool IsValueEmpytNoSearch)");
            //strclass.AppendSpaceLine(2, "{");
            //StringBuilder strFieldName = new StringBuilder();
            //StringBuilder strCoulumName = new StringBuilder();
            //if (!Equals(SearchColum, null))
            //{
            //    int i = 0;
            //    foreach (FieldInfo fieldInfo in SearchColum)
            //    {
            //        if(fieldInfo.Matching!="4")
            //        {
            //            strFieldName.Append(fieldInfo.FieldName + fieldInfo.Matching + "'{" + i + "}' ");
            //            strFieldName.Append(" " + fieldInfo.Relevance + " ");

            //            strCoulumName.Append("this." + fieldInfo.FieldName + ".Text.Trim()");
            //            strCoulumName.Append(",");
            //        }
            //        else
            //        {
            //            strFieldName.Append(fieldInfo.FieldName + " between " + "'{" + i + "}'" + " and " + "'{" + Convert.ToInt32(++i) + "}'");
            //            strFieldName.Append(" " + fieldInfo.Relevance + " ");

            //            strCoulumName.Append("this." + fieldInfo.FieldName + "Star.Value");
            //            strCoulumName.Append(",");
            //            strCoulumName.Append("this." + fieldInfo.FieldName + "End.Value");
            //            strCoulumName.Append(",");
            //        }                   
            //        i++;
            //    }

            //    strCoulumName.Remove(strCoulumName.Length - 1, 1);
            //}
            //strclass.AppendSpaceLine(3, "return string.Format(\"" + strFieldName + "\", " + strCoulumName + ");");
            //strclass.AppendSpaceLine(2, "}");
            #endregion

            //重写查询条件2010-11-30
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 重写简单查询条件");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "override protected SearchParameter[] GetSearchParameters");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "List<SearchParameter> lstSp = new List<SearchParameter>();");
            strclass.AppendSpaceLine(4, "SearchParameter spModel = new SearchParameter();");

            strclass.AppendSpaceLine(4, "");
            strclass.AppendSpaceLine(4, "");
            if (!Equals(SearchColum, null))
            {
                foreach (FieldInfo fieldInfo in SearchColum)
                {
                    strclass.AppendSpaceLine(4, "spModel.ColumnName = \"" + fieldInfo.FieldName + "\";");
                    strclass.AppendSpaceLine(4, "spModel.ColumnValue=ucToolBar.GetItemVal(" + fieldInfo.FieldName + ");");
                    strclass.AppendSpaceLine(4, "spModel.IsString = true;");

                    //else
                    //{
                    //    strclass.AppendSpaceLine(4, "spModel.ColumnValue=this." + fieldInfo.FieldName + ".Value;");
                    //    strclass.AppendSpaceLine(4, "spModel.IsString = false;");
                    //}

                    //-----------------------------------
                    //简单查询就一个条件，所以没有关联模式
                    //-----------------------------------
                    #region
                    //switch (fieldInfo.Relevance.Trim())
                    //{
                    //    case "0":
                    //        strclass.AppendSpaceLine(4, "spModel.SearchLink = EmSearchLink.或者or;");
                    //        break;
                    //    case "1":
                    //        strclass.AppendSpaceLine(4, "spModel.SearchLink = EmSearchLink.与连and;");
                    //        break;
                    //    case "2":
                    //        strclass.AppendSpaceLine(4, "spModel.SearchLink = EmSearchLink.不连用于最后一个 ;");
                    //        break;
                    //}
                    #endregion
                    switch (fieldInfo.Matching.Trim())
                    {
                        case "0":
                            strclass.AppendSpaceLine(4, "spModel.SearchWhere = EmSearchWhere.相等匹配;");
                            break;
                        case "1":
                            strclass.AppendSpaceLine(4, "spModel.SearchWhere = EmSearchWhere.模糊匹配;");
                            break;
                        case "2":
                            strclass.AppendSpaceLine(4, "spModel.SearchWhere = EmSearchWhere.大于;");
                            break;
                        case "3":
                            strclass.AppendSpaceLine(4, "spModel.SearchWhere = EmSearchWhere.小于;");
                            break;


                    }
                    strclass.AppendSpaceLine(4, "lstSp.Add(spModel);");
                    strclass.AppendSpaceLine(4, "");
                    strclass.AppendSpaceLine(4, "");
                    #region
                    //else
                    //{
                    //    strclass.AppendSpaceLine(4, "spModel = new SearchParameter();");
                    //    strclass.AppendSpaceLine(4, "spModel.ColumnName = \"" + fieldInfo.FieldName + "\";");



                    //    strclass.AppendSpaceLine(4, "spModel.ColumnValue=this." + fieldInfo.FieldName + "Star.Value;");
                    //    strclass.AppendSpaceLine(4, "spModel.IsString = false;");
                    //    strclass.AppendSpaceLine(4, "spModel.SearchLink = EmSearchLink.与连and;");
                    //    strclass.AppendSpaceLine(4, "spModel.SearchWhere = EmSearchWhere.两个值之间;");

                    //    strclass.AppendSpaceLine(4, "lstSp.Add(spModel);");
                    //    strclass.AppendSpaceLine(4, "");
                    //    strclass.AppendSpaceLine(4, "");

                    //    strclass.AppendSpaceLine(4, "spModel = new SearchParameter();");
                    //    strclass.AppendSpaceLine(4, "spModel.ColumnName = \"" + fieldInfo.FieldName + "\";");



                    //    strclass.AppendSpaceLine(4, "spModel.ColumnValue=this." + fieldInfo.FieldName + "End.Value;");
                    //    strclass.AppendSpaceLine(4, "spModel.IsString = false;");
                    //    strclass.AppendSpaceLine(4, "spModel.SearchLink = EmSearchLink.与连and;");



                    //    switch (fieldInfo.Matching.Trim())
                    //    {
                    //        case "0":
                    //            strclass.AppendSpaceLine(4, "spModel.SearchWhere = EmSearchWhere.相等匹配;");
                    //            break;
                    //        case "1":
                    //            strclass.AppendSpaceLine(4, "spModel.SearchWhere = EmSearchWhere.模糊匹配;");
                    //            break;
                    //        case "2":
                    //            strclass.AppendSpaceLine(4, "spModel.SearchWhere = EmSearchWhere.大于;");
                    //            break;
                    //        case "3":
                    //            strclass.AppendSpaceLine(4, "spModel.SearchWhere = EmSearchWhere.小于;");
                    //            break;

                    //    }

                    //    strclass.AppendSpaceLine(4, "lstSp.Add(spModel);");
                    //    strclass.AppendSpaceLine(4, "");
                    //    strclass.AppendSpaceLine(4, "");
                    //}
                    #endregion
                }
            }

            strclass.AppendSpaceLine(4, "return lstSp.ToArray();");
            strclass.AppendSpaceLine(3, "}");

            strclass.AppendSpaceLine(2, "}");


            //重写查询条件2011-01-28
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 重写高级查询条件");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "override protected SearchParameter[] GetSearchParametersAdv");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "List<SearchParameter> lstSp = new List<SearchParameter>();");
            strclass.AppendSpaceLine(4, "SearchParameter spModel = new SearchParameter();");

            strclass.AppendSpaceLine(4, "");
            strclass.AppendSpaceLine(4, "");
            if (!Equals(SearchColum, null))
            {
                foreach (FieldInfo fieldInfo in SearchAdvColum)
                {
                    strclass.AppendSpaceLine(4, "spModel = new SearchParameter();");
                    strclass.AppendSpaceLine(4, "spModel.ColumnName = \"" + fieldInfo.FieldName + "\";");
                    strclass.AppendSpaceLine(4, "spModel.ColumnValue=ucToolBar.GetItemVal(" + fieldInfo.FieldName + ");");
                    strclass.AppendSpaceLine(4, "spModel.IsString = true;");

                                 
                    #region
                    switch (fieldInfo.Relevance.Trim())
                    {
                        case "0":
                            strclass.AppendSpaceLine(4, "spModel.SearchLink = EmSearchLink.或者or;");
                            break;
                        case "1":
                            strclass.AppendSpaceLine(4, "spModel.SearchLink = EmSearchLink.与连and;");
                            break;
                        case "2":
                           // strclass.AppendSpaceLine(4, "spModel.SearchLink = EmSearchLink.不连用于最后一个 ;");
                            break;
                    }
                    #endregion
                    switch (fieldInfo.Matching.Trim())
                    {
                        case "0":
                            strclass.AppendSpaceLine(4, "spModel.SearchWhere = EmSearchWhere.相等匹配;");
                            break;
                        case "1":
                            strclass.AppendSpaceLine(4, "spModel.SearchWhere = EmSearchWhere.模糊匹配;");
                            break;
                        case "2":
                            strclass.AppendSpaceLine(4, "spModel.SearchWhere = EmSearchWhere.大于;");
                            break;
                        case "3":
                            strclass.AppendSpaceLine(4, "spModel.SearchWhere = EmSearchWhere.小于;");
                            break;


                    }
                    strclass.AppendSpaceLine(4, "lstSp.Add(spModel);");
                    strclass.AppendSpaceLine(4, "");
                    strclass.AppendSpaceLine(4, "");
                   
                }
            }

            strclass.AppendSpaceLine(4, "return lstSp.ToArray();");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");


            //重写查询
            strclass.AppendSpaceLine(2, "override protected object SearchList(out int iCount)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "return ModuleCore.BLL." + ModelName + ".Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, base.GetWhere(true), \"\", out iCount);");
            strclass.AppendSpaceLine(2, "}");

            //重写删除
            //2010-11-29 long int 取到主健的数据类型
            string sKeyTypeName = "int";
            if (Keys.Count > 0) sKeyTypeName = CodeCommon.DbTypeToCS(Keys[0].TypeName);
            string strretu = sKeyTypeName;

            strclass.AppendSpaceLine(2, "override protected void Delete(object iID)");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "ModuleCore.BLL." + ModelName + ".Instance.Delete(" + strretu + ".Parse(iID.ToString()));");
            strclass.AppendSpaceLine(2, "}");


            #region  工具栏的初始化

            if (!Equals(SearchColum, null))
            {
                strclass.AppendSpaceLine(2, " #region  工具栏的初始化");
                string controlsName = "";

                foreach (FieldInfo fieldInfo in SearchColum)
                {

                    strclass.AppendSpaceLine(2, " protected System.Web.UI.WebControls.Label LbName=new Label();");

                    if (fieldInfo.ControlId != "datetime")
                    {
                        strclass.AppendSpaceLine(2,
                                                 " protected System.Web.UI.WebControls.TextBox " + fieldInfo.FieldName + " = new TextBox();");
                        controlsName = fieldInfo.FieldName;



                    }
                    else
                    {
                        strclass.AppendSpaceLine(2,
                                                " protected EbSite.Control.DatePicker " + fieldInfo.FieldName + "= new DatePicker();");


                        controlsName = fieldInfo.FieldName;

                    }

                }
                strclass.AppendSpaceLine(2, "override protected void BindToolBar()");
                strclass.AppendSpaceLine(2, "{");

                strclass.AppendSpaceLine(3, "base.BindToolBar();");
                strclass.AppendSpaceLine(3, "ucToolBar.AddLine();");
                strclass.AppendSpaceLine(3, "LbName.ID = \"LbName\";");
                strclass.AppendSpaceLine(3, "LbName.Text = \"" + controlsName + "\";");
                strclass.AppendSpaceLine(3, "ucToolBar.AddCtr(LbName);");


                strclass.AppendSpaceLine(3, "" + controlsName + ".ID = \"" + controlsName + "\";");
                strclass.AppendSpaceLine(3, "" + controlsName + ".Attributes.Add(\"style\", \"width:90px\");");
                strclass.AppendSpaceLine(3, "ucToolBar.AddCtr(" + controlsName + ");");


                strclass.AppendSpaceLine(3, "base.ShowCustomSearch(\"查询\");");
                if (!Equals(SearchAdvColum, null))
                {
                    strclass.AppendSpaceLine(3, "ucToolBar.AddLine();");
                    strclass.AppendSpaceLine(3, "base.ShowAdvSearch(\"高级查询\");");
                }


                strclass.AppendSpaceLine(2, "}");

                strclass.AppendSpaceLine(2, " #endregion");

            }

            #endregion

            strclass.AppendSpaceLine(1, "}");
            strclass.AppendLine("}");


            return strclass.ToString();
        }

        /// <summary>
        /// 得到表示层显示窗体的代码
        /// </summary>       
        public string GetShowCs()
        {

            StringPlus strclass = new StringPlus();
            strclass.AppendLine("using System;");
            strclass.AppendLine("using EbSite.Base.Modules;");
            strclass.AppendLine("using EbSite.Modules." + DalName + ".ModuleCore.Entity;");

            strclass.AppendSpaceLine(2, "");
            // namespace EbSite.Modules.CustomTools.Pages.Controls.CusttomQuery
            strclass.AppendLine("namespace EbSite.Modules." + DalName + ".Pages.Controls." + ModelName + "");
            strclass.Append("{");
            strclass.AppendSpaceLine(2, "");
            //public partial class WebSite_show : UserControlBaseShow<ModuleCore.Entity.Website>
            //strclass.AppendSpaceLine(1, "public partial class " + ModelName + "_show: EbSite.Base.Page.UserControlBaseShow<ModuleCore.Entity." + ModelName + ">");
            strclass.AppendSpaceLine(1, "public partial class Show: MPUCBaseShow<ModuleCore.Entity." + ModelName + ">");

            strclass.AppendSpaceLine(1, "{");

            // 权限全部
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 权限全部");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "public override string Permission");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "get");
            strclass.AppendSpaceLine(3, "{");
            strclass.AppendSpaceLine(4, "return \"" + Permission + "\";");
            strclass.AppendSpaceLine(3, "}");
            strclass.AppendSpaceLine(2, "}");

            //重写删除
            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 重写删除");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "protected override  void Delete()");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "Model.Delete();");
            strclass.AppendSpaceLine(2, "}");

            //重写Load事件
            //2010-11-29 long int 取到主健的数据类型
            string sKeyTypeName = "int";
            if (Keys.Count > 0) sKeyTypeName = CodeCommon.DbTypeToCS(Keys[0].TypeName);
            string strretu = sKeyTypeName;

            strclass.AppendSpaceLine(2, "/// <summary>");
            strclass.AppendSpaceLine(2, "/// 重写Load事件");
            strclass.AppendSpaceLine(2, "/// </summary>");
            strclass.AppendSpaceLine(2, "protected override ModuleCore.Entity." + ModelName + " LoadModel()");
            strclass.AppendSpaceLine(2, "{");
            strclass.AppendSpaceLine(3, "ModuleCore.Entity." + ModelName + " md = new ModuleCore.Entity." + ModelName + "(" + strretu + ".Parse(GetKeyID));");
            strclass.AppendSpaceLine(3, "if (Equals(md, null)) md = new ModuleCore.Entity." + ModelName + "();//防止删除后的页面出错");
            strclass.AppendSpaceLine(3, "return md;");
            strclass.AppendSpaceLine(2, "}");

            strclass.AppendSpaceLine(1, "}");
            strclass.AppendLine("}");


            return strclass.ToString();
        }
        ///// <summary>
        ///// 删除页面
        ///// </summary>
        ///// <returns></returns>
        //string CreatDeleteForm();
        //string CreatSearchForm();
        //string GetWebCode(bool ExistsKey, bool AddForm, bool UpdateForm, bool ShowForm, bool SearchForm);

        #endregion//表示层

        #region  生成aspx.designer.cs
        /// <summary>
        /// 得到路由页面设计代码
        /// </summary>
        /// <returns></returns>
        public string GetRouteDesigner()
        {
            StringPlus strclass = new StringPlus();
            // namespace EbSite.Modules.CustomTools.Pages {
            strclass.AppendLine("namespace EbSite.Modules." + DalName + ".Pages");
            strclass.Append("{");
            strclass.AppendSpaceLine(2, "");
            strclass.AppendSpaceLine(1, "public partial class " + ModelName + " ");
            strclass.AppendSpaceLine(1, "{");
            strclass.AppendSpaceLine(2, "");
            strclass.AppendSpaceLine(1, "}");
            strclass.AppendLine("}");
            return strclass.ToString();
        }

        /// <summary>
        /// 得到表示层增加窗体的html代码
        /// </summary>      
        public string GetAddDesigner()
        {
            StringPlus strclass = new StringPlus();
            // namespace EbSite.Modules.CustomTools.Pages.Controls.CusttomQuery {
            strclass.AppendLine("namespace EbSite.Modules." + DalName + ".Pages.Controls." + ModelName + "");
            strclass.Append("{");
            strclass.AppendSpaceLine(2, "");
            //strclass.AppendSpaceLine(1, "public partial class " + ModelName + "{");
            strclass.AppendSpaceLine(1, "public partial class Add{");

            foreach (FieldInfo field in AddColum)
            {
                string columnName = field.FieldName;
                string columnType = field.ControlId;


                switch (columnType.Trim().ToLower())
                {
                    case "1":
                        strclass.AppendSpaceLine(2, "protected global::EbSite.Control.TextBoxVl " + columnName + ";");
                        break;

                    case "2":
                        strclass.AppendSpaceLine(2, "protected global::EbSite.Control.DatePicker " + columnName + ";");
                        break;
                    case "3":
                        strclass.AppendSpaceLine(2, "protected global::EbSite.Control.Editor " + columnName + ";");
                        break;
                    default:
                        strclass.AppendSpaceLine(2, "protected global::EbSite.Control.TextBoxVl " + columnName + ";");
                        break;
                }
            }

            //foreach (ColumnInfo field in Fieldlist)
            //{
            //    //protected global::EbSite.Control.TextBox tbCusCode;

            //    string columnName = field.ColumnName;
            //    string columnType = field.TypeName;
            //    string deText = field.DeText;
            //    bool ispk = field.IsPK;
            //    bool IsIdentity = field.IsIdentity;
            //    if (IsIdentity)
            //    {
            //        continue;
            //    }
            //    if (deText.Trim() == "")
            //    {
            //        deText = columnName;
            //    }

            //    switch (columnType.Trim().ToLower())
            //    {
            //        case "datetime":
            //        case "smalldatetime":
            //            strclass.AppendSpaceLine(2, "protected global::EbSite.Control.DatePicker " + columnName + ";");
            //            break;
            //        case "bit":
            //            strclass.AppendSpaceLine(2, "protected global::EbSite.Control.CheckBox " + columnName + ";");
            //            break;
            //        default:
            //            strclass.AppendSpaceLine(2, "protected global::EbSite.Control.TextBoxVl " + columnName + ";");
            //            break;
            //    }
            //}
            strclass.AppendSpaceLine(1, "}");
            strclass.Append("}");

            return strclass.ToString();
        }
        /// <summary>
        /// 得到表示层列表窗体的html代码
        /// </summary>      
        public string GetListDesigner()
        {
            StringPlus strclass = new StringPlus();
            // namespace EbSite.Modules.CustomTools.Pages.Controls.CusttomQuery 
            strclass.AppendLine("namespace EbSite.Modules." + DalName + ".Pages.Controls." + ModelName + "");
            strclass.Append("{");
            //strclass.AppendSpaceLine(1, "public partial class " + ModelName + " ");
            strclass.AppendSpaceLine(1, "public partial class List ");
            strclass.AppendSpaceLine(1, "{");
            // protected global::EbSite.Control.TextBox AddTime;


            if (!Equals(SearchAdvColum, null))
            {

                foreach (FieldInfo fieldInfo in SearchAdvColum)
                {

                    if (fieldInfo.ControlId != "datetime")//先用ControlId作为存放数据类型
                    {
                        strclass.AppendSpaceLine(2, "protected global::EbSite.Control.TextBoxVl " + fieldInfo.FieldName + ";");
                    }
                    else
                    {
                       strclass.AppendSpaceLine(2, "protected global::EbSite.Control.DatePicker " + fieldInfo.FieldName + ";");                     
                    }
                }
            }
            strclass.AppendSpaceLine(2, "");
            strclass.AppendSpaceLine(1, "}");
            strclass.AppendLine("}");
            return strclass.ToString();
        }
        /// <summary>
        /// 得到表示层显示窗体的html代码
        /// </summary>     
        public string GetShowDesigner()
        {
            //namespace EbSite.Modules.CustomTools.Pages.Controls.CusttomQuery {
            StringPlus strclass = new StringPlus();
            strclass.AppendLine("namespace EbSite.Modules." + DalName + ".Pages.Controls." + ModelName + "");
            strclass.Append("{");
            strclass.AppendSpaceLine(2, "");
            //strclass.AppendSpaceLine(1, "public partial class " + ModelName + "_show ");
            strclass.AppendSpaceLine(1, "public partial class Show ");
            strclass.AppendSpaceLine(1, "{");
            strclass.AppendSpaceLine(2, "");
            strclass.AppendSpaceLine(1, "}");
            strclass.AppendLine("}");
            return strclass.ToString();

        }
        #endregion

        //#region Aspx页面html

        ///// <summary>
        ///// 得到表示层增加窗体的html代码
        ///// </summary>      
        //public string GetAddAspx()
        //{
        //    StringPlus strclass = new StringPlus();
        //    strclass.AppendLine();
        //    strclass.AppendLine("<table cellSpacing=\"0\" cellPadding=\"0\" width=\"100%\" border=\"0\">");
        //    foreach (ColumnInfo field in Fieldlist)
        //    {
        //        string columnName = field.ColumnName;
        //        string columnType = field.TypeName;
        //        string deText = field.DeText;
        //        bool ispk = field.IsPK;
        //        bool IsIdentity = field.IsIdentity;
        //        if (IsIdentity)
        //        {
        //            continue;
        //        }
        //        if (deText.Trim() == "")
        //        {
        //            deText = columnName;
        //        }
        //        strclass.AppendSpaceLine(1, "<tr>");
        //        strclass.AppendSpaceLine(1, "<td height=\"25\" width=\"30%\" align=\"right\">");
        //        strclass.AppendSpaceLine(2, deText);
        //        strclass.AppendSpaceLine(1, "：</td>");
        //        strclass.AppendSpaceLine(1, "<td height=\"25\" width=\"*\" align=\"left\">");
        //        switch (columnType.Trim().ToLower())
        //        {
        //            case "datetime":
        //            case "smalldatetime":
        //                strclass.AppendSpaceLine(2, "<INPUT onselectstart=\"return false;\" onkeypress=\"return false\" id=\"txt" + columnName + "\" onfocus=\"setday(this)\"");
        //                strclass.AppendSpaceLine(2, " readOnly type=\"text\" size=\"10\" name=\"Text1\" runat=\"server\">");
        //                break;
        //            case "bit":
        //                strclass.AppendSpaceLine(2, "<asp:CheckBox ID=\"chk" + columnName + "\" Text=\"" + deText + "\" runat=\"server\" Checked=\"False\" />");
        //                break;
        //            default:
        //                strclass.AppendSpaceLine(2, "<asp:TextBox id=\"txt" + columnName + "\" runat=\"server\" Width=\"200px\"></asp:TextBox>");
        //                break;
        //        }
        //        strclass.AppendSpaceLine(1, "</td></tr>");
        //    }

        //    //按钮
        //    strclass.AppendSpaceLine(1, "<tr>");
        //    strclass.AppendSpaceLine(1, "<td height=\"25\" colspan=\"2\"><div align=\"center\">");
        //    strclass.AppendSpaceLine(2, "<asp:Button ID=\"btnAdd\" runat=\"server\" Text=\"· 提交 ·\" OnClick=\"btnAdd_Click\" ></asp:Button>");
        //    //strclass.AppendSpaceLine(2, "<asp:Button ID=\"btnCancel\" runat=\"server\" Text=\"· 重填 ·\" OnClick=\"btnCancel_Click\" ></asp:Button>");
        //    strclass.AppendSpaceLine(1, "</div></td></tr>");
        //    strclass.AppendLine("</table>");
        //    return strclass.ToString();

        //}

        ///// <summary>
        ///// 得到表示层增加窗体的html代码
        ///// </summary>      
        //public string GetUpdateAspx()
        //{
        //    StringPlus strclass = new StringPlus();
        //    strclass.AppendLine("");
        //    strclass.AppendLine("<table cellSpacing=\"0\" cellPadding=\"0\" width=\"100%\" border=\"0\">");
        //    foreach (ColumnInfo field in Fieldlist)
        //    {
        //        string columnName = field.ColumnName;
        //        string columnType = field.TypeName;
        //        string deText = field.DeText;
        //        bool ispk = field.IsPK;
        //        bool IsIdentity = field.IsIdentity;
        //        if (deText.Trim() == "")
        //        {
        //            deText = columnName;
        //        }
        //        if ((ispk) || (IsIdentity))
        //        {
        //            strclass.AppendSpaceLine(1, "<tr>");
        //            strclass.AppendSpaceLine(1, "<td height=\"25\" width=\"30%\" align=\"right\">");
        //            strclass.AppendSpaceLine(2, deText);
        //            strclass.AppendSpaceLine(1, "：</td>");
        //            strclass.AppendSpaceLine(1, "<td height=\"25\" width=\"*\" align=\"left\">");
        //            strclass.AppendSpaceLine(2, "<asp:label id=\"lbl" + columnName + "\" runat=\"server\"></asp:label>");
        //            strclass.AppendSpaceLine(1, "</td></tr>");
        //        }
        //        else
        //        {
        //            //
        //            strclass.AppendSpaceLine(1, "<tr>");
        //            strclass.AppendSpaceLine(1, "<td height=\"25\" width=\"30%\" align=\"right\">");
        //            strclass.AppendSpaceLine(2, deText);
        //            strclass.AppendSpaceLine(1, "：</td>");
        //            strclass.AppendSpaceLine(1, "<td height=\"25\" width=\"*\" align=\"left\">");
        //            switch (columnType.Trim())
        //            {
        //                case "datetime":
        //                case "smalldatetime":
        //                    strclass.AppendSpaceLine(2, "<INPUT onselectstart=\"return false;\" onkeypress=\"return false\" id=\"txt" + columnName + "\" onfocus=\"setday(this)\"");
        //                    strclass.AppendSpaceLine(2, " readOnly type=\"text\" size=\"10\" name=\"Text1\" runat=\"server\">");
        //                    break;
        //                case "bit":
        //                    strclass.AppendSpaceLine(2, "<asp:CheckBox ID=\"chk" + columnName + "\" Text=\"" + deText + "\" runat=\"server\" Checked=\"False\" />");
        //                    break;
        //                default:
        //                    strclass.AppendSpaceLine(2, "<asp:TextBox id=\"txt" + columnName + "\" runat=\"server\" Width=\"200px\"></asp:TextBox>");
        //                    break;
        //            }
        //            strclass.AppendSpaceLine(1, "</td></tr>");
        //        }
        //    }

        //    //按钮
        //    strclass.AppendSpaceLine(1, "<tr>");
        //    strclass.AppendSpaceLine(1, "<td height=\"25\" colspan=\"2\"><div align=\"center\">");
        //    strclass.AppendSpaceLine(2, "<asp:Button ID=\"btnUpdate\" runat=\"server\" Text=\"· 提交 ·\" OnClick=\"btnUpdate_Click\" ></asp:Button>");
        //    //strclass.AppendSpaceLine(2, "<asp:Button ID=\"btnCancel\" runat=\"server\" Text=\"· 取消 ·\" OnClick=\"btnCancel_Click\" ></asp:Button>");
        //    strclass.AppendSpaceLine(1, "</div></td></tr>");
        //    strclass.AppendLine("</table>");
        //    return strclass.Value;

        //}

        ///// <summary>
        ///// 得到表示层显示窗体的html代码
        ///// </summary>     
        //public string GetShowAspx()
        //{
        //    StringPlus strclass = new StringPlus();
        //    strclass.AppendLine();
        //    strclass.AppendLine("<table cellSpacing=\"0\" cellPadding=\"0\" width=\"100%\" border=\"0\">");
        //    foreach (ColumnInfo field in Fieldlist)
        //    {
        //        string columnName = field.ColumnName;
        //        string columnType = field.TypeName;
        //        string deText = field.DeText;
        //        if (deText.Trim() == "")
        //        {
        //            deText = columnName;
        //        }
        //        strclass.AppendSpaceLine(1, "<tr>");
        //        strclass.AppendSpaceLine(1, "<td height=\"25\" width=\"30%\" align=\"right\">");
        //        strclass.AppendSpaceLine(2, deText);
        //        strclass.AppendSpaceLine(1, "：</td>");
        //        strclass.AppendSpaceLine(1, "<td height=\"25\" width=\"*\" align=\"left\">");
        //        switch (columnType.Trim())
        //        {
        //            case "bit":
        //                strclass.AppendSpaceLine(2, "<asp:CheckBox ID=\"chk" + columnName + "\" Text=\"" + deText + "\" runat=\"server\" Checked=\"False\" />");
        //                break;
        //            default:
        //                strclass.AppendSpaceLine(2, "<asp:Label id=\"lbl" + columnName + "\" runat=\"server\"></asp:Label>");
        //                break;
        //        }
        //        strclass.AppendSpaceLine(1, "</td></tr>");
        //    }
        //    strclass.AppendLine("</table>");
        //    return strclass.ToString();

        //}

        //#endregion

        //#region 表示层 CS


        ///// <summary>
        ///// 得到表示层增加窗体的代码
        ///// </summary>      
        //public string GetAddAspxCs()
        //{
        //    StringPlus strclass = new StringPlus();
        //    StringPlus strclass0 = new StringPlus();
        //    StringPlus strclass1 = new StringPlus();
        //    StringPlus strclass2 = new StringPlus();
        //    strclass.AppendLine();
        //    strclass.AppendSpaceLine(3, "string strErr=\"\";");
        //    foreach (ColumnInfo field in Fieldlist)
        //    {
        //        string columnName = field.ColumnName;
        //        string columnType = field.TypeName;
        //        string deText = field.DeText;
        //        bool ispk = field.IsPK;
        //        bool IsIdentity = field.IsIdentity;
        //        if ((IsIdentity))
        //        {
        //            continue;
        //        }
        //        switch (CodeCommon.DbTypeToCS(columnType.Trim().ToLower()).ToLower())
        //        {
        //            case "int":
        //            case "smallint":
        //                strclass0.AppendSpaceLine(3, "int " + columnName + "=int.Parse(this.txt" + columnName + ".Text);");
        //                strclass1.AppendSpaceLine(3, "if(!PageValidate.IsNumber(txt" + columnName + ".Text))");
        //                strclass1.AppendSpaceLine(3, "{");
        //                strclass1.AppendSpaceLine(4, "strErr+=\"" + columnName + "不是数字！\\\\n\";	");
        //                strclass1.AppendSpaceLine(3, "}");
        //                break;
        //            case "float":
        //            case "numeric":
        //            case "decimal":
        //                strclass0.AppendSpaceLine(3, "decimal " + columnName + "=decimal.Parse(this.txt" + columnName + ".Text);");
        //                strclass1.AppendSpaceLine(3, "if(!PageValidate.IsDecimal(txt" + columnName + ".Text))");
        //                strclass1.AppendSpaceLine(3, "{");
        //                strclass1.AppendSpaceLine(4, "strErr+=\"" + columnName + "不是数字！\\\\n\";	");
        //                strclass1.AppendSpaceLine(3, "}");
        //                break;
        //            case "datetime":
        //            case "smalldatetime":
        //                strclass0.AppendSpaceLine(3, "DateTime " + columnName + "=DateTime.Parse(this.txt" + columnName + ".Text);");
        //                strclass1.AppendSpaceLine(3, "if(!PageValidate.IsDateTime(txt" + columnName + ".Text))");
        //                strclass1.AppendSpaceLine(3, "{");
        //                strclass1.AppendSpaceLine(4, "strErr+=\"" + columnName + "不是时间格式！\\\\n\";	");
        //                strclass1.AppendSpaceLine(3, "}");
        //                break;
        //            case "bool":
        //                strclass0.AppendSpaceLine(3, "bool " + columnName + "=this.chk" + columnName + ".Checked;");
        //                break;
        //            case "byte[]":
        //                strclass0.AppendSpaceLine(3, "byte[] " + columnName + "= new UnicodeEncoding().GetBytes(this.txt" + columnName + ".Text);");
        //                break;
        //            default:
        //                strclass0.AppendSpaceLine(3, "string " + columnName + "=this.txt" + columnName + ".Text;");
        //                strclass1.AppendSpaceLine(3, "if(this.txt" + columnName + ".Text ==\"\")");
        //                strclass1.AppendSpaceLine(3, "{");
        //                strclass1.AppendSpaceLine(4, "strErr+=\"" + columnName + "不能为空！\\\\n\";	");
        //                strclass1.AppendSpaceLine(3, "}");
        //                break;
        //        }
        //        strclass2.AppendSpaceLine(3, "model." + columnName + "=" + columnName + ";");
        //    }
        //    strclass.AppendLine(strclass1.ToString());
        //    strclass.AppendSpaceLine(3, "if(strErr!=\"\")");
        //    strclass.AppendSpaceLine(3, "{");
        //    strclass.AppendSpaceLine(4, "MessageBox.Show(this,strErr);");
        //    strclass.AppendSpaceLine(4, "return;");
        //    strclass.AppendSpaceLine(3, "}");
        //    strclass.AppendLine(strclass0.ToString());
        //    strclass.AppendSpaceLine(3, ModelSpace + " model=new " + ModelSpace + "();");
        //    strclass.AppendLine(strclass2.ToString());
        //    strclass.AppendSpaceLine(3, BLLSpace + " bll=new " + BLLSpace + "();");
        //    strclass.AppendSpaceLine(3, "bll.Add(model);");
        //    return strclass.Value;
        //}

        ///// <summary>
        ///// 得到修改窗体的代码
        ///// </summary>      
        //public string GetUpdateAspxCs()
        //{
        //    StringPlus strclass = new StringPlus();
        //    StringPlus strclass0 = new StringPlus();
        //    StringPlus strclass1 = new StringPlus();
        //    StringPlus strclass2 = new StringPlus();
        //    strclass.AppendLine();
        //    strclass.AppendSpaceLine(3, "string strErr=\"\";");
        //    foreach (ColumnInfo field in Fieldlist)
        //    {
        //        string columnName = field.ColumnName;
        //        string columnType = field.TypeName;
        //        bool ispk = field.IsPK;
        //        bool IsIdentity = field.IsIdentity;
        //        if ((ispk) || (IsIdentity))
        //        {
        //            continue;
        //        }
        //        switch (CodeCommon.DbTypeToCS(columnType.Trim().ToLower()).ToLower())
        //        {
        //            case "int":
        //            case "smallint":
        //                strclass0.AppendSpaceLine(3, "int " + columnName + "=int.Parse(this.txt" + columnName + ".Text);");
        //                strclass1.AppendSpaceLine(3, "if(!PageValidate.IsNumber(txt" + columnName + ".Text))");
        //                strclass1.AppendSpaceLine(3, "{");
        //                strclass1.AppendSpaceLine(4, "strErr+=\"" + columnName + "不是数字！\\\\n\";	");
        //                strclass1.AppendSpaceLine(3, "}");
        //                break;
        //            case "float":
        //            case "numeric":
        //            case "decimal":
        //                strclass0.AppendSpaceLine(3, "decimal " + columnName + "=decimal.Parse(this.txt" + columnName + ".Text);");
        //                strclass1.AppendSpaceLine(3, "if(!PageValidate.IsDecimal(txt" + columnName + ".Text))");
        //                strclass1.AppendSpaceLine(3, "{");
        //                strclass1.AppendSpaceLine(4, "strErr+=\"" + columnName + "不是数字！\\\\n\";	");
        //                strclass1.AppendSpaceLine(3, "}");
        //                break;
        //            case "datetime":
        //            case "smalldatetime":
        //                strclass0.AppendSpaceLine(3, "DateTime " + columnName + "=DateTime.Parse(this.txt" + columnName + ".Text);");
        //                strclass1.AppendSpaceLine(3, "if(!PageValidate.IsDateTime(txt" + columnName + ".Text))");
        //                strclass1.AppendSpaceLine(3, "{");
        //                strclass1.AppendSpaceLine(4, "strErr+=\"" + columnName + "不是时间格式！\\\\n\";	");
        //                strclass1.AppendSpaceLine(3, "}");
        //                break;
        //            case "bool":
        //                strclass0.AppendSpaceLine(3, "bool " + columnName + "=this.chk" + columnName + ".Checked;");
        //                break;
        //            case "byte[]":
        //                strclass0.AppendSpaceLine(3, "byte[] " + columnName + "= new UnicodeEncoding().GetBytes(this.txt" + columnName + ".Text);");
        //                break;
        //            default:
        //                strclass0.AppendSpaceLine(3, "string " + columnName + "=this.txt" + columnName + ".Text;");
        //                strclass1.AppendSpaceLine(3, "if(this.txt" + columnName + ".Text ==\"\")");
        //                strclass1.AppendSpaceLine(3, "{");
        //                strclass1.AppendSpaceLine(4, "strErr+=\"" + columnName + "不能为空！\\\\n\";	");
        //                strclass1.AppendSpaceLine(3, "}");
        //                break;
        //        }
        //        strclass2.AppendSpaceLine(3, "model." + columnName + "=" + columnName + ";");

        //    }
        //    strclass.AppendLine(strclass1.ToString());
        //    strclass.AppendSpaceLine(3, "if(strErr!=\"\")");
        //    strclass.AppendSpaceLine(3, "{");
        //    strclass.AppendSpaceLine(4, "MessageBox.Show(this,strErr);");
        //    strclass.AppendSpaceLine(4, "return;");
        //    strclass.AppendSpaceLine(3, "}");
        //    strclass.AppendLine(strclass0.ToString());
        //    strclass.AppendLine();
        //    strclass.AppendSpaceLine(3, ModelSpace + " model=new " + ModelSpace + "();");
        //    strclass.AppendLine(strclass2.ToString());
        //    strclass.AppendSpaceLine(3, BLLSpace + " bll=new " + BLLSpace + "();");
        //    strclass.AppendSpaceLine(3, "bll.Update(model);");
        //    return strclass.ToString();
        //}

        ///// <summary>
        ///// 得到修改窗体的代码
        ///// </summary>       
        //public string GetUpdateShowAspxCs()
        //{
        //    StringPlus strclass = new StringPlus();
        //    strclass.AppendLine();
        //    string key = Key;
        //    strclass.AppendSpaceLine(1, "private void ShowInfo(" + CodeCommon.GetInParameter(Keys) + ")");
        //    strclass.AppendSpaceLine(1, "{");
        //    strclass.AppendSpaceLine(2, BLLSpace + " bll=new " + BLLSpace + "();");
        //    strclass.AppendSpaceLine(2, ModelSpace + " model=bll.GetModel(" + CodeCommon.GetFieldstrlist(Keys) + ");");
        //    foreach (ColumnInfo field in Fieldlist)
        //    {
        //        string columnName = field.ColumnName;
        //        string columnType = field.TypeName;
        //        string deText = field.DeText;
        //        bool ispk = field.IsPK;
        //        bool IsIdentity = field.IsIdentity;

        //        switch (CodeCommon.DbTypeToCS(columnType.Trim().ToLower()).ToLower())
        //        {
        //            case "int":
        //            case "smallint":
        //            case "float":
        //            case "numeric":
        //            case "decimal":
        //            case "datetime":
        //            case "smalldatetime":
        //                if ((ispk) || (IsIdentity))
        //                {
        //                    strclass.AppendSpaceLine(2, "this.lbl" + columnName + ".Text=model." + columnName + ".ToString();");
        //                }
        //                else
        //                {
        //                    strclass.AppendSpaceLine(2, "this.txt" + columnName + ".Text=model." + columnName + ".ToString();");
        //                }
        //                break;
        //            case "bool":
        //                strclass.AppendSpaceLine(2, "this.chk" + columnName + ".Checked=model." + columnName + ";");
        //                break;
        //            case "byte[]":
        //                strclass.AppendSpaceLine(2, "this.txt" + columnName + ".Text=model." + columnName + ".ToString();");
        //                break;
        //            default:
        //                if ((ispk) || (IsIdentity))
        //                {
        //                    strclass.AppendSpaceLine(2, "this.lbl" + columnName + ".Text=model." + columnName + ";");
        //                }
        //                else
        //                {
        //                    strclass.AppendSpaceLine(2, "this.txt" + columnName + ".Text=model." + columnName + ";");
        //                }
        //                break;
        //        }
        //    }
        //    strclass.AppendLine();
        //    strclass.AppendSpaceLine(1, "}");
        //    return strclass.Value;
        //}


        ///// <summary>
        ///// 得到表示层显示窗体的代码
        ///// </summary>       
        //public string GetShowAspxCs()
        //{
        //    StringPlus strclass = new StringPlus();
        //    strclass.AppendLine();
        //    string key = Key;
        //    strclass.AppendSpaceLine(1, "private void ShowInfo(" + CodeCommon.GetInParameter(Keys) + ")");
        //    strclass.AppendSpaceLine(1, "{");
        //    strclass.AppendSpaceLine(2, BLLSpace + " bll=new " + BLLSpace + "();");
        //    strclass.AppendSpaceLine(2, ModelSpace + " model=bll.GetModel(" + CodeCommon.GetFieldstrlist(Keys) + ");");
        //    foreach (ColumnInfo field in Fieldlist)
        //    {
        //        string columnName = field.ColumnName;
        //        string columnType = field.TypeName;
        //        string deText = field.DeText;
        //        bool ispk = field.IsPK;
        //        bool IsIdentity = field.IsIdentity;
        //        if ((ispk) || (IsIdentity))
        //        {
        //            continue;
        //        }
        //        switch (CodeCommon.DbTypeToCS(columnType.Trim().ToLower()).ToLower())
        //        {
        //            case "int":
        //            case "smallint":
        //            case "float":
        //            case "numeric":
        //            case "decimal":
        //            case "datetime":
        //            case "smalldatetime":
        //                strclass.AppendSpaceLine(2, "this.lbl" + columnName + ".Text=model." + columnName + ".ToString();");
        //                break;
        //            case "bool":
        //                strclass.AppendSpaceLine(2, "this.chk" + columnName + ".Checked=model." + columnName + ";");
        //                break;
        //            case "byte[]":
        //                strclass.AppendSpaceLine(2, "this.lbl" + columnName + ".Text=model." + columnName + ".ToString();");
        //                break;
        //            default:
        //                strclass.AppendSpaceLine(2, "this.lbl" + columnName + ".Text=model." + columnName + ";");
        //                break;
        //        }
        //    }
        //    strclass.AppendLine();
        //    strclass.AppendSpaceLine(1, "}");
        //    return strclass.ToString();
        //}

        ///// <summary>
        ///// 删除页面
        ///// </summary>
        ///// <returns></returns>
        //public string CreatDeleteForm()
        //{
        //    StringPlus strclass = new StringPlus();
        //    strclass.AppendSpaceLine(1, "if(!Page.IsPostBack)");
        //    strclass.AppendSpaceLine(1, "{");
        //    strclass.AppendSpaceLine(2, BLLSpace + " bll=new " + BLLSpace + "();");
        //    switch (_keyType.Trim())
        //    {
        //        case "int":
        //        case "smallint":
        //        case "float":
        //        case "numeric":
        //        case "decimal":
        //        case "datetime":
        //        case "smalldatetime":
        //            strclass.AppendSpaceLine(2, _keyType + " " + _key + "=" + _keyType + ".Parse(Request.Params[\"id\"]);");
        //            break;
        //        default:
        //            strclass.AppendSpaceLine(2, "string " + _key + "=Request.Params[\"id\"];");
        //            break;
        //    }
        //    strclass.AppendSpaceLine(2, "bll.Delete(" + _key + ");");
        //    strclass.AppendSpaceLine(2, "Response.Redirect(\"index.aspx\");");
        //    strclass.AppendSpaceLine(1, "}");
        //    return strclass.Value;

        //}

        //public string CreatSearchForm()
        //{
        //    StringPlus strclass = new StringPlus();

        //    return strclass.Value;
        //}



        //#endregion//表示层

        //#region  生成aspx.designer.cs
        ///// <summary>
        ///// 增加窗体的html代码
        ///// </summary>      
        //public string GetAddDesigner()
        //{
        //    StringPlus strclass = new StringPlus();
        //    strclass.AppendLine();
        //    foreach (ColumnInfo field in Fieldlist)
        //    {
        //        string columnName = field.ColumnName;
        //        string columnType = field.TypeName;
        //        string deText = field.DeText;
        //        bool ispk = field.IsPK;
        //        bool IsIdentity = field.IsIdentity;
        //        if (IsIdentity)
        //        {
        //            continue;
        //        }
        //        switch (CodeCommon.DbTypeToCS(columnType.Trim().ToLower()).ToLower())
        //        {
        //            case "datetime":
        //            case "smalldatetime":
        //                strclass.AppendSpaceLine(2, "protected global::System.Web.UI.WebControls.TextBox txt" + columnName + ";");
        //                break;
        //            case "bool":
        //                strclass.AppendSpaceLine(2, "protected global::System.Web.UI.WebControls.CheckBox chk" + columnName + ";");
        //                break;
        //            default:
        //                strclass.AppendSpaceLine(2, "protected global::System.Web.UI.WebControls.TextBox txt" + columnName + ";");
        //                break;
        //        }
        //    }
        //    //按钮
        //    strclass.AppendSpaceLine(1, "protected global::System.Web.UI.WebControls.Button btnAdd;");
        //    strclass.AppendSpaceLine(1, "protected global::System.Web.UI.WebControls.Button btnCancel;");
        //    return strclass.ToString();

        //}

        ///// <summary>
        ///// 修改窗体的html代码
        ///// </summary>      
        //public string GetUpdateDesigner()
        //{
        //    StringPlus strclass = new StringPlus();
        //    foreach (ColumnInfo field in Fieldlist)
        //    {
        //        string columnName = field.ColumnName;
        //        string columnType = field.TypeName;
        //        string deText = field.DeText;
        //        bool ispk = field.IsPK;
        //        bool IsIdentity = field.IsIdentity;
        //        if (deText.Trim() == "")
        //        {
        //            deText = columnName;
        //        }
        //        if ((ispk) || (IsIdentity))
        //        {
        //            strclass.AppendSpaceLine(1, "protected global::System.Web.UI.WebControls.Label lbl" + columnName + ";");
        //        }
        //        else
        //        {
        //            switch (CodeCommon.DbTypeToCS(columnType.Trim().ToLower()).ToLower())
        //            {
        //                case "datetime":
        //                case "smalldatetime":
        //                    strclass.AppendSpaceLine(2, "protected global::System.Web.UI.WebControls.TextBox txt" + columnName + ";");
        //                    break;
        //                case "bool":
        //                    strclass.AppendSpaceLine(2, "protected global::System.Web.UI.WebControls.CheckBox chk" + columnName + ";");
        //                    break;
        //                default:
        //                    strclass.AppendSpaceLine(2, "protected global::System.Web.UI.WebControls.TextBox txt" + columnName + ";");
        //                    break;
        //            }
        //        }
        //    }

        //    //按钮            
        //    strclass.AppendSpaceLine(1, "protected global::System.Web.UI.WebControls.Button btnAdd;");
        //    strclass.AppendSpaceLine(1, "protected global::System.Web.UI.WebControls.Button btnCancel;");
        //    return strclass.Value;

        //}

        ///// <summary>
        ///// 显示窗体的html代码
        ///// </summary>     
        //public string GetShowDesigner()
        //{
        //    StringPlus strclass = new StringPlus();
        //    foreach (ColumnInfo field in Fieldlist)
        //    {
        //        string columnName = field.ColumnName;
        //        string columnType = field.TypeName;
        //        string deText = field.DeText;

        //        if (deText.Trim() == "")
        //        {
        //            deText = columnName;
        //        }
        //        switch (CodeCommon.DbTypeToCS(columnType.Trim().ToLower()).ToLower())
        //        {
        //            case "bool":
        //                strclass.AppendSpaceLine(1, "protected global::System.Web.UI.WebControls.CheckBox chk" + columnName + ";");
        //                break;
        //            default:
        //                strclass.AppendSpaceLine(1, "protected global::System.Web.UI.WebControls.Label lbl" + columnName + ";");
        //                break;
        //        }

        //    }
        //    return strclass.ToString();

        //}
        //#endregion



    }
}