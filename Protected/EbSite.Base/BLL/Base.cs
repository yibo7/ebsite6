using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI.WebControls;
using EbSite.Base.EBSiteEventArgs;
using EbSite.Base.Static;
using EbSite.Core;

namespace EbSite.Base.BLL
{
    [Serializable]
    public abstract class Base<TYPE, KEY> : IDisposable
    {
        protected string IISPath
        {
            get
            {
                return Base.AppStartInit.IISPath;
            }
        }
       
        public Base()
        {
            
            MasterCacheKeyArray = typeof(TYPE).Name;

        }
        public void Tips(string Title, string Info)
        {
            Tips(Title, Info, "");
        }
        public void Tips(string Title, string Info, string Url)
        {
            AppStartInit.TipsPageRender(Title, Info, Url);
        }
        private KEY _Id;
        /// <summary>
        /// 获取或设置某个对象的唯一ID
        /// </summary>
        public KEY Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public abstract TYPE GetEntity(KEY id);

        /// <summary>
        /// Updates the object in its data store.
        /// 更新一条数据
        /// </summary>
        public abstract void Update(TYPE model);

        /// <summary>
        /// Inserts a new object to the data store.
        /// 添加一条新的数据
        /// </summary>
        public abstract KEY Add(TYPE model);
        /// <summary>
        /// 可能存在问题，1ID为guid类型时相同，二标题没有加上一个复制标记，解决可能专门提供一个AddCopy的抽象方法，让子分类去做这个事情
        /// </summary>
        /// <param name="id"></param>
        virtual public void CopyData(KEY id)
        {
           TYPE model =  GetEntityEv(id);
           Add(model);
        }
        /// <summary>
        /// Deletes the object from the data store.
        /// 删除一条数据
        /// </summary>
        public abstract void Delete(KEY id);

        public abstract List<TYPE> GetListArray(int Top, string strWhere, string filedOrder);

        public abstract List<TYPE> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,
                                                 string oderby, out int RecordCount);
        /// <summary>
        /// 删除自己本身
        /// </summary>
        public void Delete()
        {
            Delete(Id);
        }

        protected TYPE GetEntityEv(KEY id)
        {
            SelectingEntityEventEventArgs Argsing = new SelectingEntityEventEventArgs();
            Argsing.KeyValue = id.ToString();
            OnSelectingEntity(Argsing);
            if (Argsing.StopContinue)
            {

                //return null;
            }

            TYPE etEntity = GetEntity(id);

            SelectedEntityEventEventArgs Argsed = new SelectedEntityEventEventArgs();
            Argsed.KeyValue = id.ToString();
            OnSelectedEntity(etEntity, Argsed);

            return etEntity;
        }

        /// <summary>
        /// Updates the object in its data store.
        /// 更新一条数据
        /// </summary>
        protected void UpdateEv(TYPE model)
        {
            UpdateingEntityEventEventArgs Argsing = new UpdateingEntityEventEventArgs();
            Argsing.KeyValue = Id.ToString();
            OnUpdateing(model, Argsing);
            if (Argsing.StopContinue) return;
            Update(model);
            UpdatedEntityEventEventArgs Argsed = new UpdatedEntityEventEventArgs();
            Argsed.KeyValue = Id.ToString();
            OnUpdated(model, Argsed);
        }

        /// <summary>
        /// Inserts a new object to the data store.
        /// 添加一条新的数据
        /// </summary>
        protected void AddEv(TYPE model)
        {

            AddingEventEventArgs arg = new AddingEventEventArgs();
            Base<TYPE, KEY>.OnAdding(model, arg);
            if (!arg.StopContinue)
            {
                KEY local = this.Add(model);
                AddedEventEventArgs args2 = new AddedEventEventArgs();
                args2.KeyValue = local.ToString();
                Base<TYPE, KEY>.OnAdded(model, args2);
            }

        }

        /// <summary>
        /// Deletes the object from the data store.
        /// 删除一条数据
        /// </summary>
        protected void DeleteEv(KEY id)
        {
            DeleteingEntityEventEventArgs Argsing = new DeleteingEntityEventEventArgs();
            Argsing.KeyValue = id.ToString();
            OnDeleteing(Argsing);
            if (Argsing.StopContinue) return;
            Delete(id);
            DeletedEntityEventEventArgs Argsed = new DeletedEntityEventEventArgs();
            Argsed.KeyValue = id.ToString();
            OnDeleted(Argsed);
        }

        public List<TYPE> GetListArrayEv(int Top, string strWhere, string filedOrder)
        {
            SelectingEntityListEventEventArgs Argsing = new SelectingEntityListEventEventArgs();
            OnSelectingList(Argsing);
            if (Argsing.StopContinue) return null;

            List<TYPE> lst = GetListArray(Top, strWhere, filedOrder);

            SelectedEntityListEventEventArgs Argsed = new SelectedEntityListEventEventArgs(lst.Count);

            OnSelectedList(lst, Argsed);

            return lst;
        }

        public List<TYPE> GetListPagesEv(int PageIndex, int PageSize, string strWhere, string Fileds,
                                                  string oderby, out int RecordCount)
        {
            SelectingEntityListEventEventArgs Argsing = new SelectingEntityListEventEventArgs();
            OnSelectingList(Argsing);
            if (Argsing.StopContinue)
            {
                RecordCount = 0;
                return null;
            }

            List<TYPE> lst = GetListPages(PageIndex, PageSize, strWhere, Fileds,
                                                   oderby, out  RecordCount);

            SelectedEntityListEventEventArgs Argsed = new SelectedEntityListEventEventArgs(lst.Count);
            OnSelectedList(lst, Argsed);

            return lst;
        }




        #region 事件处理

        #region 对外接口
        /// <summary>
        /// 向外面接收相关处理办法
        /// </summary>
        static public event EventHandler<AddingEventEventArgs> Adding;
        /// <summary>
        /// 向外面接收相关处理办法
        /// </summary>
        static public event EventHandler<AddedEventEventArgs> Added;
        /// <summary>
        /// 向外面接收相关处理办法
        /// </summary>
        static public event EventHandler<DeleteingEntityEventEventArgs> Deleteing;
        /// <summary>
        /// 向外面接收相关处理办法
        /// </summary>
        static public event EventHandler<DeletedEntityEventEventArgs> Deleted;
        /// <summary>
        /// 向外面接收相关处理办法
        /// </summary>
        static public event EventHandler<SelectingEntityEventEventArgs> SelectingEntity;
        /// <summary>
        /// 向外面接收相关处理办法
        /// </summary>
        static public event EventHandler<SelectedEntityEventEventArgs> SelectedEntity;
        /// <summary>
        /// 向外面接收相关处理办法
        /// </summary>
        static public event EventHandler<UpdateingEntityEventEventArgs> Updateing;
        /// <summary>
        /// 向外面接收相关处理办法
        /// </summary>
        static public event EventHandler<UpdatedEntityEventEventArgs> Updated;
        /// <summary>
        /// 向外面接收相关处理办法
        /// </summary>
        static public event EventHandler<SelectingEntityListEventEventArgs> SelectingList;
        /// <summary>
        /// 向外面接收相关处理办法
        /// </summary>
        static public event EventHandler<SelectedEntityListEventEventArgs> SelectedList;
        #endregion

        /// <summary>
        /// 添加记录前触发事件
        /// </summary>
        static public void OnAdding(TYPE mdEntity, AddingEventEventArgs arg)
        {
            if (!Equals(Adding, null))
            {
                Adding(mdEntity, arg);
            }
        }
        /// <summary>
        /// 添加记录后触发事件
        /// </summary>
        static public void OnAdded(TYPE mdEntity, AddedEventEventArgs arg)
        {
            if (!Equals(Added, null))
            {
                Added(mdEntity, arg);
            }
        }
        /// <summary>
        /// 删除记录前触发事件
        /// </summary>
        static public void OnDeleteing(DeleteingEntityEventEventArgs arg)
        {
            if (!Equals(Deleteing, null))
            {
                Deleteing(null, arg);
            }
        }
        /// <summary>
        /// 删除记录后触发事件
        /// </summary>
        static public void OnDeleted(DeletedEntityEventEventArgs arg)
        {
            if (!Equals(Deleted, null))
            {
                Deleted(null, arg);
            }
        }
        /// <summary>
        /// 获取一条记录前触发事件
        /// </summary>
        static public void OnSelectingEntity(SelectingEntityEventEventArgs arg)
        {
            if (!Equals(SelectingEntity, null))
            {
                SelectingEntity(null, arg);
            }
        }
        /// <summary>
        /// 获取一条记录后触发事件
        /// </summary>
        static public void OnSelectedEntity(TYPE mdEntity, SelectedEntityEventEventArgs arg)
        {
            if (!Equals(SelectedEntity, null))
            {
                SelectedEntity(mdEntity, arg);
            }
        }
        /// <summary>
        /// 更新一条记录前触发事件
        /// </summary>
        static public void OnUpdateing(TYPE mdEntity, UpdateingEntityEventEventArgs arg)
        {
            if (!Equals(Updateing, null))
            {
                Updateing(mdEntity, arg);
            }
        }
        /// <summary>
        /// 更新一条记录后触发事件
        /// </summary>
        static public void OnUpdated(TYPE mdEntity, UpdatedEntityEventEventArgs arg)
        {
            if (!Equals(Updated, null))
            {
                Updated(mdEntity, arg);
            }
        }
        /// <summary>
        /// 获取数据集合前触发事件
        /// </summary>
        static public void OnSelectingList(SelectingEntityListEventEventArgs arg)
        {
            if (!Equals(SelectingList, null))
            {
                SelectingList(null, arg);
            }
        }
        /// <summary>
        /// 获取数据集合后触发事件
        /// </summary>
        static public void OnSelectedList(List<TYPE> lstEntity, SelectedEntityListEventEventArgs arg)
        {
            if (!Equals(SelectedList, null))
            {
                SelectedList(lstEntity, arg);
            }
        }
        #endregion

        #region IDisposable

        private bool _IsDisposed;
        /// <summary>
        /// Gets or sets if the object has been disposed.
        /// 如果这个对象已经被处理过了,就可以通过get或者set来获取相应的值.
        /// <remarks>
        /// If the objects is disposed, it must not be disposed a second
        /// time. The IsDisposed property is set the first time the object
        /// is disposed. If the IsDisposed property is true, then the Dispose()
        /// method will not dispose again. This help not to prolong the object's
        /// life if the Garbage Collector.
        /// 如果对象被处理,但一定不能被处理两次.如果处理属性是第一次处理对象可以通过set，如果处理属性是ture
        /// Dispose（）方法将再次处理它.如果在垃圾收集工里处理,将会减少对象的寿命!
        /// </remarks>
        /// </summary>
        protected bool IsDisposed
        {
            get { return _IsDisposed; }
        }

        /// <summary>
        /// Disposes the object and frees ressources for the Garbage Collector.
        /// 处理对象和摆脱垃圾收集工的来源
        /// </summary>
        /// <param name="disposing">如果对象被处理了,则返回ture! If true, the object gets disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.IsDisposed)
                return;

            if (disposing)
            {
                _IsDisposed = true;
            }
        }

        /// <summary>
        /// Disposes the object and frees ressources for the Garbage Collector.
        /// 处理对象和摆脱垃圾收集工的来源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IDataErrorInfo Members

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// 获取错误的信息，这个对象有什么样的错误标志 。
        /// </summary>
        /// <returns>An error message indicating what is wrong with this object. 
        /// The default is an empty string ("").</returns>
        /// 默认是一个空的 string("")
        public string Error
        {
            get { return "发生错误了!"; }
        }

        /// <summary>
        /// Gets the <see cref="System.String"/> with the specified column name.指定和获取 columnName
        /// IDataErrorInfo 接口的实现
        /// </summary>
        public string this[string columnName]
        {
            get
            {

                return string.Empty;
            }
        }

        #endregion
        /// <summary>
        /// Occurs when this instance is marked dirty.  
        /// It means the instance has been changed but not saved.
        /// 实例属性被改变而不是存储
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises the PropertyChanged event safely.
        /// 增加属性改变事件的安全性
        /// </summary>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        protected void SetValueFromControl(System.Web.UI.Control uc, string Value)
        {
            Utils.SetValueFromControl(uc, Value);

        }
        protected string GetValueFromControl(System.Web.UI.Control uc)
        {
            return Utils.GetValueFromControl(uc);
        }

        protected bool GetIDFromCtr(PlaceHolder ph, out string obKey)
        {
            bool IsHaveKey = false;
            obKey = "0";
            foreach (System.Web.UI.Control uc in ph.Controls)
            {
                if (Equals(uc.ID, null)) continue;
                string sValue = GetValueFromControl(uc);
                if (Equals(uc.ID.ToLower(), "Id".ToLower()))
                {
                    obKey = sValue;
                    IsHaveKey = true;
                    break;
                }
            }
            return IsHaveKey;
        }

       

        #region 缓存处理
        protected string MasterCacheKeyArray = "cudata" ;
        virtual protected string GetCacheKey(string cacheKey)
        {
            return string.Concat(MasterCacheKeyArray, "-", cacheKey);

        }
        public T GetCacheItem<T>(string rawKey) where T : class
        {
            return Host.CacheApp.GetCacheItem<T>(rawKey, MasterCacheKeyArray);
        }
        public void AddCacheItem<T>(string rawKey, T value)
        {
             Host.CacheApp.AddCacheItem(rawKey, value, 60, ETimeSpanModel.M, MasterCacheKeyArray);
        }
        public void InvalidateCache()
        {
            Host.CacheApp.InvalidateCache(MasterCacheKeyArray);
            //// 清除依赖项
            //HttpRuntime.Cache.Remove(MasterCacheKeyArray[0]);
        }

        #endregion


    }

    
}
