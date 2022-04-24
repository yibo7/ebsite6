using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Core;
using System.Linq;
using EbSite.Core.FSO;

namespace EbSite.Entity
{
    /// <summary>
    /// 实体类Remark 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ModelClass
    {
        public ModelClass()
        { }
        #region Model
        public DateTime AddDate { get; set; }
        public long AddDateInt { get; set; }
        public Guid ID { get; set; }
        //public int SiteID { get; set; }
        private List<ColumFiledConfigs> _Configs;
        public List<ColumFiledConfigs> Configs
        {
            get
            {
                //if (_Configs!=null)
                //        _Configs.Sort();
                
                return _Configs;
            } 
            set
            {

                _Configs = value;
            }
        }
        public bool IsHaveFiled(string sFiledName)
        {
            bool ishave = false;
            if (Configs != null && Configs.Count>0)
            {
                ishave =  Configs.Exists(d => d.ColumFiledName == sFiledName);
                if(ishave)
                {
                    ColumFiledConfigs config = _Configs.Single(d => d.ColumFiledName == sFiledName);
                    if(!config.IsShowAdmin&&!config.IsShowUser)
                    {
                        ishave = false;
                    }
                }
            }
            return ishave;
        }

       

        public ColumFiledConfigs DeleteFiled(string FiledName)
        {

            ColumFiledConfigs md = _Configs.Single(d => d.ColumFiledName == FiledName);

            if(!md.IsOutFiled)
            {
                md.IsShowAdmin = false;
                md.IsShowUser = false;
            }
            else
            {
                _Configs.Remove(md);
            }
            return md;
        }
        public void AddFiled(ColumFiledConfigs cfc)
        {
            if(cfc.IsOutFiled)
            {

                int OrderID = GetUsedFileds().Count>0? GetUsedFileds().Max(d => d.OrderNum):0;
                cfc.OrderNum = OrderID + 1;
                _Configs.Add(cfc);
            }
            else
            {
                //ColumFiledConfigs md = _Configs.Single(d => d.ColumFiledName == cfc.ColumFiledName);

                //md = cfc;
                foreach (ColumFiledConfigs config in _Configs)
                {
                    if (config.ColumFiledName.Equals(cfc.ColumFiledName))
                    {
                        //config.ColumFiledName = cfc.ColumFiledName;
                        config.ColumShowName = cfc.ColumShowName;
                        if (!config.IsReadOnly)
                            config.FieldControlTypeID = cfc.FieldControlTypeID;
                        config.IsOutFiled = false;
                        config.IsShowAdmin = true;
                        config.IsShowUser = cfc.IsShowUser;
                        int OrderID = GetUsedFileds().Max(d => d.OrderNum);
                        config.OrderNum = OrderID + 1;
                        config.PlaceHolderID = cfc.PlaceHolderID;
                        break;
                    }
                        
                }
            }
           
        }
        public void UpdateFiled(ColumFiledConfigs cfc)
        {
            ColumFiledConfigs config = _Configs.Single(d => d.ColumFiledName == cfc.ColumFiledName);

            if (config != null)
            {
                config.ColumShowName = cfc.ColumShowName;
                if (!config.IsReadOnly)
                    config.FieldControlTypeID = cfc.FieldControlTypeID;
                config.IsShowUser = cfc.IsShowUser;
                config.PlaceHolderID = cfc.PlaceHolderID;
            }
        }
        public List<ColumFiledConfigs> GetCustomFileds()
        {
             
                return _Configs.Where(d => d.IsOutFiled).ToList();
             
        }
        public List<ColumFiledConfigs> GetUsedFileds()
        {
            
                return _Configs.Where(d => d.IsShowAdmin || d.IsShowUser).OrderByDescending(d=>d.OrderNum).ToList();
            
            
        }
        public List<ColumFiledConfigs> GetUnUsedFileds()
        {
             
                return _Configs.Where(d => !d.IsShowAdmin && !d.IsShowUser).ToList();
             
        }

        #region 只适用于表单模型
        private string Tem_HTML = "<%@ Page Language=\"C#\" AutoEventWireup=\"true\" Inherits=\"EbSite.Web.Pages.customform\" %>\n\t<%@ Register Assembly=\"EbSite.Control\" Namespace=\"EbSite.Control\" TagPrefix=\"XS\" %>\n\t<%@ Import Namespace=\"EbSite.BLL.GetLink\"%>\n\t<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n\t<html xmlns=\"http://www.w3.org/1999/xhtml\">\n\t<head runat=\"server\">\n\t</head>\n\t<body ><form id=\"form1\" runat=\"server\">\n\t<asp:PlaceHolder ID=\"phFileds\" runat=\"server\">\n\t内容\n\t</asp:PlaceHolder>\n\t<XS:Button  ID=\"btnSaveData\"   Text=\" 提 交 \" runat=\"server\" />\n\t<%=KeepUserState()%>\n\t</form></body>\n\t</html>";
        public string GetTemHtml()
        {
           
            string url = GetFormTemUrl();
           return Core.FSO.FObject.ReadFile(HttpContext.Current.Server.MapPath(url));
        }
        public string GetFormTemUrl()
        {
            return Base.Host.Instance.CurrentSite.GetCurrentPageUrl(string.Concat("form_", FormTempName, ".aspx"));
        }
        public void DeleteFormTem()
        {
            string url = GetFormTemUrl();
            Core.FSO.FObject.Delete(HttpContext.Current.Server.MapPath(url), FsoMethod.File);
        }

        public void AddFormTem()
        {
            UpdateFormTem(Tem_HTML);
        }

        public void UpdateFormTem(string html)
        {
            string url = GetFormTemUrl();
            
            Core.FSO.FObject.WriteFile(HttpContext.Current.Server.MapPath(url), html);
        }

        public string FormTempName { get; set; }

        #endregion
       
        public string ModelInfo { get; set; }
        public string ModelName { get; set; }
        public bool IsSystem { get; set; }
        public string TableName { get; set; }//YHL 2014-1-22
        public Guid ListTemID { get; set; }//YHL 2014-2-27 您可以自定义后台内容管理模板  

        /// <summary>
        /// 所属模型ID,如果系统模型将为Guid.Empty
        /// </summary>
        public Guid ModuleID { get; set; }
        /// <summary>
        /// 从ID获取某个容器控件
        /// </summary>
        /// <param name="pg"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlaceHolder GetFiledPlaceHolderID(UserControl pg,string id)
        {
           //以上使用缓存，好像不可以应用在控件
            PlaceHolder ph = null;
            List<PlaceHolder> lst = GetFiledPlaceHolder(pg);
            foreach (PlaceHolder holder in lst)
            {
                if (holder.ID.Equals(id))
                {
                    ph = holder;
                    break;
                }
            }

            return ph;
        }

        /// <summary>
        /// 获取当前模型所用到的容器控件
        /// </summary>
        /// <param name="pg"></param>
        /// <returns></returns>
        public List<PlaceHolder> GetFiledPlaceHolder(UserControl pg)
        {

            //控件缓存会失去当前上下文属性
            List<PlaceHolder> lst = new List<PlaceHolder>();
            List<string> lstKey = new List<string>();
            foreach (ColumFiledConfigs config in Configs)
            {
                if (!lstKey.Contains(config.PlaceHolderID))
                {
                    lstKey.Add(config.PlaceHolderID);
                    PlaceHolder ph = (PlaceHolder)pg.FindControl(config.PlaceHolderID);
                    if (ph != null)
                    {
                        lst.Add(ph);
                        //config.PH = ph;
                    }


                }

            }

            return lst;

        }
        #endregion Model

    }

    //public class ColumFiledConfigsFull : ColumFiledConfigs
    //{
    //    public PlaceHolder PH;
    //}

    [Serializable]
    public class ColumFiledConfigs : IComparable<ColumFiledConfigs>
    {
        public ColumFiledConfigs()
        { }
        #region Model

        //public string BindCoreForPageTemEsy
        //{
        //    get
        //    {
        //        return string.Format("&lt;%=Bind(\"{0}\")%&gt;", _ColumFiledName);
        //    }
        //}
        public string BindCoreForPageTemAdv
        {
            get
            {
                if (!IsOutFiled)
                {
                    return string.Format("&lt;%=Model.{0}%&gt;", _ColumFiledName);
                }
                else
                {
                    return string.Format("&lt;%=Model.Fileds[\"{0}\"]%&gt;", _ColumFiledName);
                }
            }
        }

        public string BindCoreForCtrTem
        {
            get
            {
                //((StringDictionary)Eval("Fileds"))["wlw"]
                if (!IsOutFiled)
                {
                    return string.Format("&lt;%#Eval(\"{0}\")%&gt;", _ColumFiledName);
                }
                else
                {
                    return string.Format("&lt;%#EbSite.Common.GetCustomFiled(Eval(\"Fileds\"),\"{0}\")%&gt;", _ColumFiledName);
                }
                
            }
        }

        /// /////////////////////
        /// 
        //public string BindCoreForPageTemEsy2
        //{
        //    get
        //    {
        //        return string.Format("<%=Bind(\"{0}\")%>", _ColumFiledName);
        //    }
        //}
        public string BindCoreForPageTemAdv2
        {
            get
            { 
                if (!IsOutFiled)
                {
                    return string.Format("<%=Model.{0}%>", _ColumFiledName);
                }
                else
                {
                    return string.Format("<%=Model.Fileds[\"{0}\"]%>", _ColumFiledName);
                }
            }
        }

        public string BindCoreForCtrTem2
        {
            get
            {
                return string.Format("<%#Eval(\"{0}\")%&gt;", _ColumFiledName);
            }
        }
  

        private string _ColumFiledName = string.Empty;
        private string _ColumShowName = string.Empty;
        private bool _IsShowAdmin = true;
        private bool _IsShowUser = true;
        private Guid _FieldControlTypeID;
        private string _PlaceHolderID = "phDefaultFileds";
        private int _OrderNum;
        /// <summary>
        /// 字段数据类型长度
        /// </summary>
        public int DataTypeLen { get; set; }
        /// <summary>
        /// 字段数据类型 文本(varchar) 内容(longtext) 字符(char) 数字(int) 小数两位(decimal) 时间(datetime) 是否(bit)
        /// </summary>
        public int DataType { get; set; }//EbSite.Base.EntityAPI.EDataFiledType
        /// <summary>
        /// 是否自定义字段
        /// </summary>
        public bool IsOutFiled { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public int OrderNum
        {
            set { _OrderNum = value; }
            get { return _OrderNum; }
        }
        /// <summary>
        /// 容器ID
        /// </summary>
        public string PlaceHolderID
        {
            set { _PlaceHolderID = value; }
            get { return _PlaceHolderID; }
        }
        /// <summary>
        /// 用来展示字段的控件类别Id
        /// </summary>
        public Guid FieldControlTypeID
        {
            set
            {
                _FieldControlTypeID = value;
            }
            get { return _FieldControlTypeID; }
        }
        public string ColumFiledName
        {
            set { _ColumFiledName = value; }
            get { return _ColumFiledName; }
        }
        public bool IsShowAdmin
        {
            set { _IsShowAdmin = value; }
            get { return _IsShowAdmin; }
        }
        /// <summary>
        /// 是否显示在用户前台,但在表单里表示为:在后台的管理表里是否显示此字段
        /// </summary>
        public bool IsShowUser
        {
            set { _IsShowUser = value; }
            get { return _IsShowUser; }
        }

        private bool _IsReadOnly = false;
        /// <summary>
        /// 添加模型是是否只读
        /// </summary>
        public bool IsReadOnly
        {
            set { _IsReadOnly = value; }
            get { return _IsReadOnly; }
        }
        public string ColumShowName
        {
            set { _ColumShowName = value; }
            get { return _ColumShowName; }
        }

        //[field: NonSerializedAttribute()]
        //public PlaceHolder PH;
        
        #endregion Model

        #region 实现IComparable接口,以便在List里可以使用Sort对orderid 进行排序
        /// <summary>
        /// 按orderid的降序来排序,实现这个方法，可以让List.Sort(),按这个比较大小来排序
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(ColumFiledConfigs other)
        {

            return other.OrderNum.CompareTo(this.OrderNum);
        }

        #endregion

    }
}

