using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Entity;
using DropDownList = EbSite.Control.DropDownList;

namespace EbSite.ControlData
{
    /// <summary>
    /// 分类模型 
    /// </summary>
    [DefaultProperty("Text"), ToolboxData("<{0}:ClassModels runat=server></{0}:ClassModels>")]
    public class ClassModels : DropDownList
    {
        public ClassModels()
        {

            BindD();
           
        }

        //private bool _IsAddDefaultItem = false;
        //public bool IsAddDefaultItem
        //{
        //    get { return _IsAddDefaultItem; }
        //    set { _IsAddDefaultItem = value; }
        //}
        public void BindD()
        {
            DataTextField = "ModelName";
            DataValueField = "ID";
            List<Entity.ModelClass> lst = BLL.ClassModel.Instance.ModelClassList;
            //if (IsAddDefaultItem)
            //{
            //    lst.Insert(0, new ModelClass() { ID = Guid.Empty, ModelName="请选择模型" });
            //}
            DataSource = lst;
            
            DataBind();

            
        }
         
    }
}
