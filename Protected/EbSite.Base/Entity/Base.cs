using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EbSite.Base.Entity
{

    [Serializable]
    public abstract class Base
    {
        protected Base()
        {
        }
        protected string IISPath()
        {
            return EbSite.Base.AppStartInit.IISPath;
        }
        public string GetValueForColumn(string sColumnName)
        {
            foreach (PropertyInfo info in this.GetFieldInfos())
            {
                if (object.Equals(info.Name.ToLower(), sColumnName.ToLower()))
                {
                    return info.GetValue(this, null).ToString();
                }
            }
            return "";
        }

        public void SetValueForColumn(string sColumnName, string sValue)
        {
            foreach (PropertyInfo info in this.GetFieldInfos())
            {
                if (object.Equals(info.Name.ToLower(), sColumnName.ToLower()))
                {
                    ////如果是guid类型，会发生从“System.String”到“System.Guid”的强制转换无效。 所以这里做个判断
                    if (object.Equals(info.PropertyType, typeof(Guid)))
                    {
                        Guid guid = new Guid(sValue);
                        info.SetValue(this, Convert.ChangeType(guid, info.PropertyType), null);
                    }
                    else
                    {
                        info.SetValue(this, Convert.ChangeType(sValue, info.PropertyType), null);
                    }
                    //info.SetValue(this, Convert.ChangeType(sValue, info.PropertyType), null);
                    break;
                }
            }
        }

        public List<string> GetColumNames()
        {
            List<string> list = new List<string>();
            PropertyInfo[] properties = GetType().GetProperties();
            foreach (PropertyInfo info in properties)
            {
                if (info.CanRead && info.CanWrite)
                    list.Add(info.Name);

            }
            return list;
        }

        public List<PropertyInfo> GetFieldInfos()
        {
            List<PropertyInfo> list = new List<PropertyInfo>();
            PropertyInfo[] properties = GetType().GetProperties();
            foreach (PropertyInfo info in properties)
            {
                if (info.CanRead && info.CanWrite)
                    list.Add(info);
            }
            return list;
        }
    }

    /*
    abstract public class Base
    {
        protected string IISPath
        {
            get
            {
               return Base.AppStartInit.IISPath;
            }
        }


        protected Base()
        {
        }

        public string GetValueForColumn(string sColumnName)
        {
            foreach (PropertyInfo info in this.GetFieldInfos)
            {
                if (object.Equals(info.Name.ToLower(), sColumnName.ToLower()))
                {
                    return info.GetValue(sColumnName, null).ToString();
                }
            }
            return "";
        }

        public void SetValueForColumn(string sColumnName, string sValue)
        {
            foreach (PropertyInfo info in this.GetFieldInfos)
            {
                if (object.Equals(info.Name.ToLower(), sColumnName.ToLower()))
                {
                    info.SetValue(this, Convert.ChangeType(sValue, info.PropertyType), null);
                    break;
                }
            }
        }

        public List<string> GetColumNames
        {
            get
            {
                List<string> list = new List<string>();
                PropertyInfo[] properties = base.GetType().GetProperties();
                foreach (PropertyInfo info in properties)
                {
                    list.Add(info.Name);
                }
                return list;
            }
        }

        public List<PropertyInfo> GetFieldInfos
        {
            get
            {
                List<PropertyInfo> list = new List<PropertyInfo>();
                PropertyInfo[] properties = base.GetType().GetProperties();
                foreach (PropertyInfo info in properties)
                {
                    list.Add(info);
                }
                return list;
            }
        }

        ///// <summary>
        ///// 获取一个实体类的公共属性
        ///// </summary>
        //public List<FieldInfo> GetFieldInfos
        //{
        //    get
        //    {
        //        List<FieldInfo> lst = new List<FieldInfo>();

        //        FieldInfo[] piNonpublicArray = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        //        //这里只操作公有属性
        //        foreach (FieldInfo fi in piNonpublicArray)
        //        {
        //            lst.Add(fi);
        //        }
        //        return lst;
        //    }

        //}
        ///// <summary>
        ///// 获取某个字段值
        ///// </summary>
        ///// <param name="sColumnName"></param>
        ///// <returns></returns>
        //public string GetValueForColumn(string sColumnName)
        //{
        //    string sValue = "";
        //    foreach (FieldInfo info in GetFieldInfos)
        //    {
        //        if (Equals(info.Name.ToLower(), sColumnName.ToLower()))
        //        {
        //            sValue = info.GetValue(null).ToString();
        //            break;
        //        }
        //    }

        //    return sValue;
        //}
    }
     */
}
