using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using EbSite.Base.BLL;

namespace EbSite.Base.Entity
{


    /// <summary>
    /// 此实体基类为数据业务专用
    /// </summary>
    /// <typeparam name="TYPE"></typeparam>
    /// <typeparam name="KEY"></typeparam>
    [Serializable]
    public class EntityBase<TYPE, KEY> : Base where TYPE : EntityBase<TYPE, KEY>, new()  //public class EntityBase<TYPE, KEY> : Base where TYPE : EntityBase<TYPE, KEY>, new()
    {
        private KEY _Id;
        protected TYPE CurrentModel;
        /// <summary>
        /// 唯一ID
        /// </summary>
        public KEY id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this._Id = value;
            }
        }
        private bool _IsNew = true;
        /// <summary>
        /// Gets if this is a new object, False if it is a pre-existing object.
        /// </summary>
        public bool IsNew
        {
            get { return _IsNew; }
        }
        public virtual void MarkOld()
        {
            _IsNew = false;
        }


        #region 增删查改

        public KEY Add()
        {
            return this.Bll().Add(this.CurrentModel);
        }

        public void Delete()
        {
            this.Bll().Delete(this.id);
        }

        protected TYPE GetEntity()
        {
            return this.Bll().GetEntity(this.id);
        }

        protected void InitData(TYPE md)
        {
            TYPE entity = this.GetEntity();
            FieldInfo[] fields = md.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo[] infoArray2 = entity.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0; i < fields.Length; i++)
            {
                object obj2 = infoArray2[i].GetValue(entity);
                fields[i].SetValue(md, obj2);
            }
        }

        public void Save()
        {
            bool flag = false;
            if (!object.Equals(this.id, null))
            {
                if (object.Equals(typeof(KEY), typeof(int)) || object.Equals(typeof(KEY), typeof(long)))
                {
                    if (!object.Equals(this.id.ToString(), "0"))
                    {
                        flag = true;
                    }
                }
                else if (object.Equals(typeof(KEY), typeof(Guid)))
                {
                    Guid objA = new Guid(this.id.ToString());
                    if (!object.Equals(objA, Guid.Empty))
                    {
                        flag = true;
                    }
                }
            }
            if (flag)
            {
                this.Update();
            }
            else
            {
                this.Add();
            }
        }

        public void Update()
        {
            this.Bll().Update(this.CurrentModel);
        }

        protected virtual BllBase<TYPE, KEY> Bll()
        {
            
                throw new Exception("还没有实现业务实例");
             
        }


        #endregion



        public override bool Equals(object obj)
        {
            TYPE pTemp = obj as TYPE;
            if (pTemp != null)
            {
                if (!pTemp.id.Equals(this.id)) { return false; }
                return true;
            }
            return false;
        }
    }

}
