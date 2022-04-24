using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using EbSite.Base.Configs.Model;
using EbSite.Base.Static;
using EbSite.Control;
using EbSite.Entity;
using System.Linq;
namespace EbSite.BLL.ModelBll
{
    public enum ModelType:int
    {
        /// <summary>
        /// 内容模型 
        /// </summary>
        NRMX = 0,
        /// <summary>
        /// 分类模型
        /// </summary>
        FLMX = 1,
        /// <summary>
        /// 用户模型
        /// </summary>
        YHMX = 2,
        /// <summary>
        /// 表单模型
        /// </summary>
        BDMX = 3
    }
    public abstract class ModelInterface
    {
        protected int SiteID = 0;
        public ModelInterface(int _SiteID)
        {
            SiteID = _SiteID;
        }
        public void CopyModel(Guid ID,bool key)
        {
            ModelClass md = GeModelByID(ID);
            //有缓存，所以要重新创建一个
            ModelClass mdNew = new ModelClass();
            mdNew.ID = Guid.NewGuid();
            mdNew.ModelName = string.Concat("复制-", md.ModelName);
            mdNew.IsSystem = false;
            mdNew.ModelInfo = md.ModelInfo;
            mdNew.ModuleID = md.ModuleID;
            mdNew.Configs = md.Configs;
            if (key)
            {
                if (Equals(md.TableName, null) || string.IsNullOrEmpty(md.TableName))
                    md.TableName = "newscontent";
                mdNew.TableName = NewsContent.NewTbName(md.TableName);
            }
            else
            {
                mdNew.TableName = md.TableName;
            }
            //mdNew.SiteID = md.SiteID;
            AddModel(mdNew);
        }
        ///// <summary>
        ///// 获取某个模型对象
        ///// </summary>
        ///// <param name="ID"></param>
        ///// <returns></returns>
        //public ModelClass GeModelByID(Guid ID)
        //{
        //    return GeModelByID(ID, 0);

        //}

        public ModelClass GeModelByID(Guid ID)
        {
            ModelClass cfList = null;
            //List<Entity.ModelClass> lstMC = GetModelClassList(SiteID);
            //if (SiteID> 0)
            //{
            //    lstMC = GetModelClassList(SiteID);
            //}
            //else
            //{
            //    lstMC = ModelClassList;
            //}
            List<Entity.ModelClass> lstMC = ModelClassList;
            foreach (ModelClass list in lstMC)
            {
                if (list.ID == ID)
                {
                    cfList = list;

                }
            }
            if (Equals(cfList, null))
            {
               
                if (HttpContext.Current != null)
                {
                    string hostIP = "";
                    string path = "";
                    string referer = "";
                    string useragent = string.Empty;
                    path = HttpContext.Current.Request.RawUrl;
                    hostIP = HttpContext.Current.Request.UserHostAddress;
                    referer = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
                    useragent = HttpContext.Current.Request.ServerVariables["http_user_agent"];

                    if (Base.Configs.SysConfigs.ConfigsControl.Instance.IsOpenAppLog)
                    {
                        Entity.Logs mdLogs = new Entity.Logs();
                        mdLogs.Title = string.Concat("找不模型ID[{0}]的模型:", ID, " 来路:", referer);
                        mdLogs.Description =
                            string.Format(
                                "找不模型ID[{0}]的模型，可能原因有:1.您删除了相应模板，2.数据库更改后具相应的模型没有复制过来！请确认 themes/{1}/data/Models/SetupData/{2}/{0}.config 是否存在\n来源:{3}\n来路:{4}\nIP:{5}\nUserAgent:{6}",
                                ID, EbSite.Base.Host.Instance.CurrentSite.PageTheme, WebModelName, path, referer, hostIP, useragent);
                        mdLogs.IP = hostIP;
                        mdLogs.AddDate = DateTime.Now;
                        BLL.AppErrLog.InsertLogs(mdLogs);
                    }
                  

                    Base.Host.Instance.Tips("访问出错了", string.Format("找不模型ID[{0}]的模型，可能原因有:1.您删除了相应模板，2.数据库更改后具相应的模型没有复制过来！请确认 themes/{1}/data/Models/SetupData/{2}/{0}.config 是否存在", ID, EbSite.Base.Host.Instance.CurrentSite.PageTheme, WebModelName));
                }
                else
                {
                    throw new Exception(string.Format("找不模型ID[{0}]的模型，可能原因有:1.您删除了相应模板，2.数据库更改后具相应的模型没有复制过来！请确认 themes/{1}/data/Models/SetupData/{2}/{0}.config 是否存在", ID, EbSite.Base.Host.Instance.CurrentSite.PageTheme, WebModelName)); 
                }
               
                
            }
            return cfList;
        }

        public void ResetSiteID()
        {
            List<Entity.ModelClass> mdList = EbSite.Base.Configs.Model.ConfigsControl.GetModelList(WebModelName, SiteID);
             Base.Configs.Model.ConfigsControl md;
            if (mdList != null)
            {
                foreach (ModelClass modelClass in mdList)
                {
                    //modelClass.SiteID = siteid;
                    md = new ConfigsControl(modelClass.ID, WebModelName, SiteID);
                    md.SaveConfig(modelClass);
                }
            }

        }

        public List<Entity.ModelClass> GetModelClassList()
        {
            return EbSite.Base.Configs.Model.ConfigsControl.GetModelList(WebModelName, SiteID);
        }
        private static object _SyncRoot = new object();
        virtual  public List<Entity.ModelClass> ModelClassList
        {

            get
            {
                //int siteid = Base.Host.Instance.GetSiteID;
                string sKey = string.Concat("WebModelList-", WebModelName, SiteID);

                List<Entity.ModelClass> mdList = EbSite.Base.Host.CacheRawApp.GetCacheItem<List<Entity.ModelClass>>(sKey,"mcl");// as List<Entity.ModelClass>;

                if (mdList == null)
                {
                    lock (_SyncRoot)
                    {
                        if (mdList == null)
                        {
                            mdList = EbSite.Base.Configs.Model.ConfigsControl.GetModelList(WebModelName, SiteID);
                            //按_orderid降序来排序
                            //mdList.Sort();
                            if (mdList != null)
                            {
                                //cfd5666c-0bd5-4beb-884b-75d23e7ca158
                                //yhl 2012-09-19 因为用户模型是不分站点的。是共享的。
                                //mdList = (from o in mdList where o.SiteID == Base.Host.Instance.GetSiteID || o.ID == new Guid("cfd5666c-0bd5-4beb-884b-75d23e7ca158") select o).ToList();
                                //mdList.OrderByDescending(d => d.AddDate);
                                //EbSite.Base.Host.CacheApp.AddCacheItem(sKey, mdList);

                                //mdList = (from o in mdList where o.SiteID == Base.Host.Instance.GetSiteID || o.ID == new Guid("cfd5666c-0bd5-4beb-884b-75d23e7ca158") select o).ToList();
                                mdList.OrderByDescending(d => d.AddDate);
                                EbSite.Base.Host.CacheRawApp.AddCacheItem(sKey, mdList, 3, ETimeSpanModel.XS, "mcl");

                            }



                        }
                    }
                }

                return mdList;
            }
        }

        public void Save()
        {
            Base.Configs.Model.ConfigsControl md;
            //int siteid = Base.Host.Instance.GetSiteID;
            foreach (ModelClass modelClass in ModelClassList)
            {
                md = new ConfigsControl(modelClass.ID, WebModelName, SiteID);
                md.SaveConfig(modelClass);
            }
        }

        public void DeleteFiled(ModelClass modelClass, string FiledName)
        {
            ColumFiledConfigs cfc = modelClass.DeleteFiled(FiledName);
            Save();
            OnFiledDeleted(modelClass, cfc);
        }

        public void Save(ModelClass modelClass,ColumFiledConfigs cfc)
        {
            Base.Configs.Model.ConfigsControl md = new ConfigsControl(modelClass.ID, WebModelName, SiteID);
            OnSaved(modelClass, cfc);
            md.SaveConfig(modelClass);
        }

        protected virtual void OnFiledDeleted(ModelClass mc, ColumFiledConfigs cfc)
        {
        }

        virtual protected void OnSaved(ModelClass mc, ColumFiledConfigs cfc)
        {

        }
        public abstract string WebModelName { get; }
        public abstract string[] aColums { get; }
     

        public void AddModel(ModelClass Model)
        {
            Model.AddDate = DateTime.Now;
            Model.AddDateInt =  long.Parse(Core.SqlDateTimeInt.NewOrderNumber(Model.AddDate));
            //Model.SiteID = Base.Host.Instance.GetSiteID;
            ModelClassList.Add(Model);
            Save();
        }
        public void DeleteModelByID(Guid ID)
        {
            ModelClass md = new ModelClass();
            foreach (ModelClass list in ModelClassList)
            {
                if (list.ID == ID)
                {
                    md = list;
                }
            }
            if (ModelClassList.Contains(md))
            {
                md.DeleteFormTem();
                ModelClassList.Remove(md);
                //int siteid = Base.Host.Instance.GetSiteID;
                ConfigsControl.DeleteModel(ID, WebModelName, SiteID);

            }

            Save();

        }
        /// <summary>
        /// 检测是否存在某个模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsHaveModel(Guid id)
        {
            bool isok = false;
            foreach (ModelClass list in ModelClassList)
            {
                if (list.ID == id)
                {
                    isok = true;
                    break;
                }
            }
            return isok;
        }
        //用于常规部件数据制作
        public void BindCustomControlsByModelID(PlaceHolder ph, UserControl pg, ModelClass ModelConfigs)
        {
            //获取当前分类
            //Model.NewsClass ClassModel = BLL.NewsClass.GetModelByCache(cid);
            //获取当前模型的字段配置
            List<ColumFiledConfigs> lst = ModelConfigs.Configs;//GeModelByID(ClassModel.ModelID).Configs;
            foreach (ColumFiledConfigs field in lst)
            {
               
                string sHtml1 = string.Concat("<tr><td>", field.ColumShowName, "</td><td >");
                string sHtml2 = "</td></tr>";
                ph.Controls.Add(pg.ParseControl(sHtml1));
                System.Web.UI.Control Ctr = GetControlsOfField(field, pg.Page);
                ph.Controls.Add(Ctr);
                ph.Controls.Add(pg.ParseControl(sHtml2));
            }
        }

        public void BindCustomControlsByModelID(UserControl pg, ModelClass ModelConfigs, bool isAdmin)
        {

            BindCustomControlsByModelIDPT(pg, ModelConfigs, isAdmin);

        }
        /// <summary>
        /// 制作采集部件专用
        /// </summary>
        /// <param name="ph"></param>
        /// <param name="pg"></param>
        /// <param name="ModelConfigs"></param>
        /// <param name="isAdmin"></param>
        public void BindCustomControlsForSpider(PlaceHolder ph, UserControl pg, ModelClass ModelConfigs, bool isAdmin)
        {
            //获取当前分类
            //Model.NewsClass ClassModel = BLL.NewsClass.GetModelByCache(cid);
            //获取当前模型的字段配置
            List<ColumFiledConfigs> lst = ModelConfigs.Configs;//GeModelByID(ClassModel.ModelID).Configs;
            foreach (ColumFiledConfigs field in lst)
            {
                if (!isAdmin)
                {
                    if (!field.IsShowUser) continue;//是否用户可见
                }
                else
                {
                    if (!field.IsShowAdmin) continue;//是否管理员可见
                }

                string sHtml1 = string.Concat("<tr><td><input type=\"checkbox\" name=\"cl\" value=\"", string.Concat(field.ColumFiledName, "|", field.ColumShowName), "\" />", field.ColumShowName, "</td><td >");
                string sHtml2 = "</td></tr>";
                ph.Controls.Add(pg.ParseControl(sHtml1));
                System.Web.UI.Control Ctr = GetControlsOfField(field, pg.Page);
                ph.Controls.Add(Ctr);
                ph.Controls.Add(pg.ParseControl(sHtml2));
            }
        }


        public List<ColumFiledConfigs> GetFieldsOrder(ModelClass ModelConfigs)
        {
            List<ColumFiledConfigs> lstOrder = new List<ColumFiledConfigs>();
            List<ColumFiledConfigs> lst = ModelConfigs.Configs;//GeModelByID(ClassModel.ModelID).Configs;
            lst.Sort();
            foreach (ColumFiledConfigs field in lst)
            {
                if (!field.IsShowUser || !field.IsShowAdmin) continue;//是否用户可见

                lstOrder.Add(field);

            }

            return lstOrder;
        }
        private void BindCustomControlsByModelIDPT(UserControl pg, ModelClass ModelConfigs, bool isAdmin)
        {
            //获取当前分类
            //Model.NewsClass ClassModel = BLL.NewsClass.GetModelByCache(cid);
            //获取当前模型的字段配置



            List<ColumFiledConfigs> lst = ModelConfigs.Configs;//GeModelByID(ClassModel.ModelID).Configs;
            lst.Sort();
            foreach (ColumFiledConfigs field in lst)
            {
                
                PlaceHolder PH = ModelConfigs.GetFiledPlaceHolderID(pg, field.PlaceHolderID);
                if (PH != null)
                {
                    if (!isAdmin)
                    {
                        if (!field.IsShowUser) continue;//是否用户可见
                    }
                    else
                    {
                        
                        if (!field.IsShowAdmin) continue;//是否管理员可见
                    }

                    string sHtml1 = string.Concat("<tr><td>", field.ColumShowName, "</td><td id=\"td", field.ColumFiledName, "\" >");

                    PH.Controls.Add(pg.ParseControl(sHtml1));

                    System.Web.UI.Control Ctr = GetControlsOfField(field, pg.Page);
                    Ctr.SkinID = field.IsOutFiled.ToString();
                    PH.Controls.Add(Ctr);

                    string sHtml2 = "</td></tr>";

                    PH.Controls.Add(pg.ParseControl(sHtml2));
                }

            }
        }

        /// <summary>
        /// 根据字段获取相应的控件
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private System.Web.UI.Control GetControlsOfField(ColumFiledConfigs field, Page pg)
        {

            EbSite.Control.ExtensionsCtrls ctr = new ExtensionsCtrls();
            ctr.ModelCtrlID = field.FieldControlTypeID;
            ctr.ID = field.ColumFiledName;
            return ctr;


        }
        /// <summary>
        /// 获取默认的字段列表,如果对newcontent表的字段做了添加或修改，请修改aColums数据
        /// </summary>
        /// <returns></returns>
        public List<ColumFiledConfigs> GetDefaultColumList()
        {
            return GetDefaultColumListPT();
        }
        private List<ColumFiledConfigs> GetDefaultColumListPT()
        {
            List<ColumFiledConfigs> lst = new List<ColumFiledConfigs>();
            foreach (string colum in aColums)
            {
                ColumFiledConfigs cl = new ColumFiledConfigs();
                string[] aC = colum.Split('|');
                cl.ColumFiledName = aC[0];
                cl.ColumShowName = aC[1];
                cl.IsShowAdmin = true;
                cl.IsShowUser = false;
                cl.IsReadOnly = bool.Parse(aC[2]);

                if (cl.IsReadOnly || aC.Length==4) //如果是只读的字段，我们系统要给一个默认的控件，因为用户无法对此字段进行控件选择
                {
                    cl.FieldControlTypeID = new Guid(aC[3]);
                }

                lst.Add(cl);
            }
            return lst;
        }

        /// <summary>
        /// 设置控件的值
        /// </summary>
        /// <param name="uc"></param>
        /// <param name="Value"></param>
        public void SetValueFromControl(System.Web.UI.Control uc, string Value)
        {
            SetValueFromControlPT(uc, Value);
        }
        private void SetValueFromControlPT(System.Web.UI.Control uc, string Value)
        {
            //Type tp = uc.GetType();
            if (uc is ExtensionsCtrls)
            {
                ExtensionsCtrls myuc = (ExtensionsCtrls)uc;
                myuc.CtrlValue = Value;
            }
            //else if (uc is ModelCtrlBase)
            //{
            //    ModelCtrlBase myuc = (ModelCtrlBase)uc;
            //    myuc.SetValue(Value);
            //}
            else if (uc is Literal) //只显示信息时用，目前只应用于用户模型，查看用户信息时用
            {
                Literal myuc = (Literal)uc;
                myuc.Text = Value;
            }
        }

        /// <summary>
        /// 获取控件的值
        /// </summary>
        /// <param name="uc"></param>
        /// <returns></returns>
        public string GetValueFromControl(System.Web.UI.Control uc)
        {
            return GetValueFromControlPT(uc);
        }
        private string GetValueFromControlPT(System.Web.UI.Control uc)
        {
            string sValue = string.Empty;


            //Type tp = uc.GetType();

            if (uc is ExtensionsCtrls)
            {
                ExtensionsCtrls myuc = (ExtensionsCtrls)uc;
                
                sValue = myuc.CtrlValue;
            }

            return sValue;
        }
    }
    public abstract class ModelBase<MODELTYPE> : ModelInterface
    {
        public ModelBase(int _SiteID)
            : base(_SiteID)
        {
            
        }
        public abstract void InitModifyCtr(PlaceHolder ph, MODELTYPE ModifyModel);
        public abstract void InitSaveCtr(PlaceHolder ph, ref MODELTYPE ModifyModel);

        
    }
}
