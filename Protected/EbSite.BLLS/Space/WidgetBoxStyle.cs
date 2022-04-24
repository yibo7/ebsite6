using System;
using System.Collections.Generic;

using System.Web;
using EbSite.Core.FSO;
using EbSite.Entity;

namespace EbSite.BLL
{
    public class WidgetBoxStyle : EbSite.Base.Datastore.XMLProviderBase<Entity.WidgetBoxStyle>
    {
        public static readonly WidgetBoxStyle Instance = new WidgetBoxStyle();
        /// <summary>
        /// 重写菜单的保存路径-绝对
        /// </summary>
        public override string SavePath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(IISPath + "datastore/WidgetBoxStyle/");
            }
        }
        private WidgetBoxStyle()
        {

            if (!FObject.IsExist(SavePath, FsoMethod.Folder))
            {
                FObject.Create(SavePath, FsoMethod.Folder);
            }
        }

        //public string GetStyleByID(Guid id, int ThemeID,out int ColorPramIndex,out string ThemePramIndex)
        //{
        //    string boxStyle = string.Empty;
        //    List<Entity.WidgetBoxStyle> lst = GetBoxStyleList(ThemeID);

        //    foreach (Entity.WidgetBoxStyle mdBoxStyle in lst)
        //    {
        //        if (mdBoxStyle.id == id)
        //        {
        //            boxStyle = mdBoxStyle.StyleTemp;
        //            //ColorPram = mdBoxStyle.
        //            break;
        //        }
        //    }

        //    return boxStyle;
        //}

        public Entity.WidgetBoxStyle GetStyleByID(Guid id, int ThemeID)
        {
            Entity.WidgetBoxStyle boxStyle = null;
            List<Entity.WidgetBoxStyle> lst = GetBoxStyleList(ThemeID);

            foreach (Entity.WidgetBoxStyle mdBoxStyle in lst)
            {
                if(mdBoxStyle.id==id)
                {
                    boxStyle = mdBoxStyle;
                    break;
                }
            }
            return boxStyle;
        }
        /// <summary>
        /// 获取边框样式
        /// </summary>
        /// <param name="ThemeID">ThemeID 为0表示只获取公共边框，大于0获取公共边框与对应皮肤ID的边框</param>
        /// <returns></returns>
        public List<Entity.WidgetBoxStyle> GetBoxStyleList(int ThemeID)
        {
            List<Entity.WidgetBoxStyle> lst = new List<Entity.WidgetBoxStyle>();
            foreach (Entity.WidgetBoxStyle md in base.FillList())
            {
                if(md.ThemeID==0||md.ThemeID==ThemeID)
                {
                    lst.Add(md);
                }
            }
            lst.Insert(0, new Entity.WidgetBoxStyle() { id = Guid.Empty, StyleName = "不使用边框", StyleTemp = "", ThemeID=0 });

            return lst;
        }

    }
}