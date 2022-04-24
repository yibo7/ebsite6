#region Using

using System;
using System.Text;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Threading;

#endregion

namespace EbSite.BLL
{
    /// <summary>
    /// 业务逻辑处理基类
    /// </summary>
    /// <typeparam name="TYPE">某个业务</typeparam>
    /// <typeparam name="KEY">某个业务的ID</typeparam>
    [Serializable]
    public abstract class BusinessBase<TYPE, KEY> : IDataErrorInfo, INotifyPropertyChanged, IChangeTracking, IDisposable where TYPE : BusinessBase<TYPE, KEY>, new()
    {

        #region Properties

        private KEY _Id;
        /// <summary>
        /// 获取或设置某个对象的唯一ID
        /// </summary>
        public KEY Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private DateTime _DateCreated = DateTime.MinValue;
        /// <summary>
        /// The date on which the instance was created.
        /// 某个实例的创建日期
        /// </summary>
        public DateTime DateCreated
        {
            get
            {
                if (_DateCreated == DateTime.MinValue)
                    return _DateCreated;
                //BlogSettings.Instance.Timezone
                return _DateCreated.AddHours(-5);//此值从配置文件里设置叫 "保存时区"
            }
            set
            {
                if (_DateCreated != value) MarkChanged("DateCreated");
                _DateCreated = value;
            }
        }

        private DateTime _DateModified = DateTime.MinValue;
        /// <summary>
        /// The date on which the instance was modified.
        /// 某个实例被改变的时间
        /// </summary>
        public DateTime DateModified
        {
            get
            {
                if (_DateModified == DateTime.MinValue)
                    return _DateModified;

                return _DateModified.AddHours(-5); //此值从配置文件里设置叫 "保存时区"
            }
            set { _DateModified = value; }
        }

        /// <summary>
        /// Gets a value indicateing whether the current user is authenticated.
        /// 获取用户登录后的凭证
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is authenticated; otherwise, <c>false</c>.
        ///     true 如果当前实例可靠，返回true,否则 返回 false
        /// </value>
        protected bool IsAuthenticated
        {
            get
            {
                return true; //Thread.CurrentPrincipal.Identity.IsAuthenticated;
            }
        }


        #endregion

        #region IsNew, IsDeleted, IsChanged

        private bool _IsNew = true;
        /// <summary>
        /// Gets if this is a new object, False if it is a pre-existeing object.
        /// 获取一个新对象，如果已经存在，返回false
        /// </summary>
        public bool IsNew
        {
            get { return _IsNew; }
        }

        private bool _IsDeleted;
        /// <summary>
        /// Gets if this object is marked for deletion.
        /// 获取这个对象是否已经标记为删除
        /// </summary>
        public bool IsDeleted
        {
            get { return _IsDeleted; }
        }

        private bool _IsChanged = true;
        /// <summary>
        /// Gets if this object's data has been changed.
        /// 获取这个对象的数据是否已经改变
        /// </summary>
        public virtual bool IsChanged
        {
            get { return _IsChanged; }
        }

        /// <summary>
        /// Marks the object for deletion. It will then be 
        /// deleted when the object's Save() method is called.
        /// 标记一个对象为删除，当调用对象的save方法，就可以删除它
        /// </summary>
        public void Delete()
        {
            _IsDeleted = true;
            _IsChanged = true;
        }

        private StringCollection _ChangedProperties = new StringCollection();
        /// <summary>
        /// A collection of the properties that have 
        /// been marked as being dirty.
        /// </summary>
        protected virtual StringCollection ChangedProperties
        {
            get
            {
                return _ChangedProperties;
            }
        }

        /// <summary>
        /// Marks an object as being dirty, or changed.
        /// 标记一个对象被改变
        /// </summary>
        /// <param name="propertyName">(改变的属性名称)The name of the property to mark dirty.</param>
        protected virtual void MarkChanged(string propertyName)
        {
            _IsChanged = true;
            if (!_ChangedProperties.Contains(propertyName))
            {
                _ChangedProperties.Add(propertyName);
            }

            OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// Marks the object as being an clean, 
        /// which means not dirty.
        /// </summary>
        public virtual void MarkOld()
        {
            _IsChanged = false;
            _IsNew = false;
            _ChangedProperties.Clear();
        }

        ///// <summary>
        ///// Check whether or not the specified property has been changed
        ///// </summary>
        ///// <param name="propertyName">The name of the property to check.</param>
        //protected bool IsPropertyDirty(string propertyName)
        //{
        //  return DirtyProperties.Contains(propertyName.ToLowerInvariant());
        //}

        ///// <summary>
        ///// Check whether or not the specified properties has been changed
        ///// </summary>
        ///// <param name="propertyNames">The names of the properties to check.</param>
        ///// <returns>True if all of the specified properties have been changed.</returns>
        //protected bool IsPropertyDirty(string[] propertyNames)
        //{
        //  foreach (string name in propertyNames)
        //  {
        //    if (!DirtyProperties.Contains(name.ToUpperInvariant()))
        //    {
        //      return false;
        //    }
        //  }

        //  return true;
        //}

        #endregion

        #region Validation

        private StringDictionary _BrokenRules = new StringDictionary();

        /// <summary>
        /// Add or remove a broken rule.
        /// 添加或者移除一个不符合的规则
        /// </summary>
        /// <param name="propertyName">属性名称The name of the property.</param>
        /// <param name="errorMessage">错误信息The description of the error</param>
        /// <param name="isBroken">如果true: 此规则是否已经不符合 True if the validation rule is broken.</param>
        protected virtual void AddRule(string propertyName, string errorMessage, bool isBroken)
        {
            if (isBroken)
            {
                _BrokenRules[propertyName] = errorMessage;
            }
            else
            {
                if (_BrokenRules.ContainsKey(propertyName))
                {
                    _BrokenRules.Remove(propertyName);
                }
            }
        }

        /// <summary>
        /// Reinforces the business rules by adding additional rules to the 
        /// broken rules collection.
        /// 通过给不符合规则集合添加额外规则来增强业务规则
        /// </summary>
        protected abstract void ValidationRules();

        /// <summary>
        /// Gets whether the object is valid or not.
        /// 查看对象是否通过验证
        /// </summary>
        public bool IsValid
        {
            get
            {
                ValidationRules();
                return this._BrokenRules.Count == 0;
            }
        }

        /// /// <summary>
        /// If the object has broken business rules, use this property to get access
        /// to the different validation messages.
        /// 如果对象的业务规则被破坏，这个属性可以取得不同的验证信息
        /// </summary>
        public virtual string ValidationMessage
        {
            get
            {
                if (!IsValid)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string messages in this._BrokenRules.Values)
                    {
                        sb.AppendLine(messages);
                    }

                    return sb.ToString();
                }

                return string.Empty;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads an instance of the object based on the Id.
        /// 通过id获取一个对象
        /// </summary>
        /// <param name="id">The unique identifier of the object 这个对象的唯一id</param>
        public static TYPE Load(KEY id)
        {
            TYPE instance = new TYPE();
            instance = instance.DataSelect(id);
            instance.Id = id;

            if (instance != null)
            {
                instance.MarkOld();
                return instance;
            }

            return null;
        }

        /// <summary>
        /// Saves the object to the data store (inserts, updates or deletes).
        /// 对于内部数据的处理BusinessBase使用了IsNew,IsChanged和IsDeleted统一了编程模型，
        /// 并定义了一个SaveAction枚举来实现统一的处理与通知消息的封装
        /// </summary>
        virtual public SaveAction Save()
        {
            if (IsDeleted && !IsAuthenticated)
                throw new System.Security.SecurityException("你没有删除权限");

            if (!IsValid && !IsDeleted)
                throw new InvalidOperationException(ValidationMessage);

            if (IsDisposed && !IsDeleted)
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "{0}已经被回收(Disposed)，不能保存", this.GetType().Name));

            if (IsChanged)
            {
                return Update();
            }

            return SaveAction.None;
        }

        /// <summary>
        /// Is called by the save method when the object is old and dirty.
        /// 当对象不可用，可以通过save这个方法从新更新
        /// </summary>
        private SaveAction Update()
        {
            SaveAction action = SaveAction.None;

            if (this.IsDeleted)  //删除一条数据
            {
                if (!this.IsNew)
                {
                    action = SaveAction.Delete;
                    OnSaving(this, action);
                    DataDelete();
                }
            }
            else
            {
                if (this.IsNew) //添加新数据
                {
                    if (_DateCreated == DateTime.MinValue)
                        _DateCreated = DateTime.Now;

                    _DateModified = DateTime.Now;
                    action = SaveAction.Insert;
                    OnSaving(this, action);
                    DataInsert();
                }
                else  //更新一条数据
                {
                    this._DateModified = DateTime.Now; ;
                    action = SaveAction.Update;
                    OnSaving(this, action);
                    DataUpdate();
                }

                MarkOld();
            }

            OnSaved(this, action);
            return action;
        }

        #endregion

        #region Data access

        /// <summary>
        /// Retrieves the object from the data store and populates it.
        /// 查询一条记录
        /// </summary>
        /// <param name="id">id 是唯一的标识符  The unique identifier of the object.  </param>
        /// <returns>True if the object exists and is being populated successfully  
        /// 返回ture，表明对象已存在
        /// </returns>
        protected abstract TYPE DataSelect(KEY id);

        /// <summary>
        /// Updates the object in its data store.
        /// 更新一条数据
        /// </summary>
        protected abstract void DataUpdate();

        /// <summary>
        /// Inserts a new object to the data store.
        /// 添加一条新的数据
        /// </summary>
        protected abstract void DataInsert();

        /// <summary>
        /// Deletes the object from the data store.
        /// 删除一条数据
        /// </summary>
        protected abstract void DataDelete();

        #endregion

        #region Equality overrides

        /// <summary>
        /// A uniquely key to identify this particullar instance of the class
        /// 唯一值 ID 可以识别这个类的实例
        /// </summary>
        /// <returns>A unique integer value 返回一个唯一的整数值</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>
        /// Compares this object with another
        /// 对象之间的对比
        /// </summary>
        /// <param name="obj">The object to compare  对比对象</param>
        /// <returns>True if the two objects as equal  如果两个对象相同则 ， 返回 ture 。</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() == this.GetType())
            {
                return obj.GetHashCode() == this.GetHashCode();
            }

            return false;
        }

        /// <summary>
        /// Checks to see if two business objects are the same.
        /// 验证两个业务对象是否相等/相同，并返回值
        /// </summary>
        public static bool operator ==(BusinessBase<TYPE, KEY> first, BusinessBase<TYPE, KEY> second)
        {
            if (Object.ReferenceEquals(first, second))
            {
                return true;
            }

            if ((object)first == null || (object)second == null)
            {
                return false;
            }

            return first.GetHashCode() == second.GetHashCode();
        }

        /// <summary>
        /// Checks to see if two business objects are different.
        /// 验证两个业务对象是否不同 ，并返回值。
        /// </summary>
        public static bool operator !=(BusinessBase<TYPE, KEY> first, BusinessBase<TYPE, KEY> second)
        {
            return !(first == second);
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the class is Saved
        /// 某个类被要保存的时候,需要判断是后已经存在!
        /// </summary>
        public static event EventHandler<SavedEventArgs> Saved;
        /// <summary>
        /// Raises the Saved event.增加存储事件
        /// </summary>
        protected static void OnSaved(BusinessBase<TYPE, KEY> businessObject, SaveAction action)
        {
            if (Saved != null)
            {
                Saved(businessObject, new SavedEventArgs(action));
            }
        }

        /// <summary>
        /// Occurs when the class is Saved 某个类被要保存的时候,需要判断是后已经存在!
        /// </summary>
        public static event EventHandler<SavedEventArgs> Saving;
        /// <summary>
        /// Raises the Saving event  增加存储事件
        /// </summary>
        protected static void OnSaving(BusinessBase<TYPE, KEY> businessObject, SaveAction action)
        {
            if (Saving != null)
            {
                Saving(businessObject, new SavedEventArgs(action));
            }
        }

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
                _ChangedProperties.Clear();
                _BrokenRules.Clear();
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
            get { return ValidationMessage; }
        }

        /// <summary>
        /// Gets the <see cref="System.String"/> with the specified column name.指定和获取 columnName
        /// IDataErrorInfo 接口的实现
        /// </summary>
        public string this[string columnName]
        {
            get
            {
                if (_BrokenRules.ContainsKey(columnName))
                    return _BrokenRules[columnName];

                return string.Empty;
            }
        }

        #endregion

        #region IChangeTracking Members

        /// <summary>
        /// Resets the object抯 state to unchanged by accepting the modifications.
        /// 通过接受对象的修改 ,重新设置对象状态，不可改变
        /// </summary>
        void IChangeTracking.AcceptChanges()
        {
            Save();
        }

        #endregion
    }
}
