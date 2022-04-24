using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.ControlPage;
using EbSite.BLL;
using System.Reflection;


namespace EbSite.Web.AdminHt.Controls.Admin_Data
{
    public partial class TemMethodList : UserControlListBase
    {

        #region 权限

        public override string Permission
        {
            get
            {
                return "288";
            }
        }
        public override string PermissionAddID
        {
            get
            {
                return "288";
            }
        }
        public override string PermissionModifyID
        {
            get
            {
                return "288";
            }
        }
        /// <summary>
        /// 删除数据的权限ID
        /// </summary>
        public override string PermissionDelID
        {
            get
            {
                return "288";
            }
        }

        #endregion

        override protected string AddUrl
        {
            get
            {
                return "t=1";
            }
        }
        override protected object LoadList(out int iCount)
        {
            return BLL.TemMethod.Instance.GetListPages(pcPage.PageIndex, pcPage.PageSize, out iCount);
        }


        override protected object SearchList(out int iCount)
        {
            iCount = 0;
            return null;
        }
        override protected void Delete(object iID)
        {
            Guid id = new Guid(iID.ToString());
            BLL.TemMethod.Instance.Delete(id);
        }
        protected override void BindToolBar()
        {
            base.BindToolBar(false, false, false, false, false);
            ucToolBar.AddBnt("生成方法", IISPath + "images/menus/Doc-Next.gif", "MakeFa", "导入静态方法");

        }
        protected override void ucToolBar_ItemClick(object source, Control.ItemClickArgs e)
        {
            base.ucToolBar_ItemClick(source, e);
            switch (e.ItemTag)
            {
                case "MakeFa":
                    //  <Title>获取分类连接地址-电脑版</Title>
                    //  <GetCode>&lt;%=EbSite.Common.GetClassHref(object iID, object HtmlPath, int pIndex)%&gt;</GetCode>
                    //  <Author>ebsite</Author>
                    //  <Demo>/// &lt;summary&gt;
                    ///// 获取分类连接地址
                    ///// &lt;/summary&gt;
                    ///// &lt;param name="iID"&gt;分类ID&lt;/param&gt;
                    ///// &lt;param name="HtmlPath"&gt;html生成名称&lt;/param&gt;
                    ///// &lt;param name="pIndex"&gt;页码&lt;/param&gt;
                    // /// &lt;returns&gt;&lt;/returns&gt;</Demo>
                   
                    //object o = Activator.CreateInstance("EbSite.Common", "类型");
                    //o.GetType().GetMethod("方法名").Invoke(null, null);
                    // Type type = assembly.GetType("程序集.类名");获取当前类的类型
                    //5,Activator.CreateInstance(type); 创建此类型实例
                    //6,MethodInfo mInfo = type.GetMethod("方法名");获取当前方法
                    //7,mInfo.Invoke(null,方法参数);

                     Assembly assem = Assembly.GetExecutingAssembly();
                     object o = assem.CreateInstance("EbSite.Common");

                    //List<TemMethodInfo> ls = new List<TemMethodInfo>();
                    //TemMethodInfo md = new TemMethodInfo();
                    //md.Author = "11";
                    //md.Title = "22";
                    //md.GetCode = "33";
                    //md.Demo = "44";
                    //BLL.TemMethod.Instance.Add(md);
                    base.gdList_Bind();
                    break;

            }


        }

    }

}