//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace EbSite.BLL.Event
//{
//    public class AddingEventEventArgs : EventArgs
//    {
//        private bool _StopContinue;
//        /// <summary>
//        /// 是否阻住进行操作
//        /// </summary>
//        public bool StopContinue
//        {
//            get
//            {
//                return _StopContinue;
//            }
//            set
//            {
//                _StopContinue = value;
//            }
//        }
//        private string _KeyValue;
//        /// <summary>
//        ///如果当前生成带有id的，此处代表当前数据的唯一ID
//        /// </summary>
//        public string KeyValue
//        {
//            get
//            {
//                return _KeyValue;
//            }
//            set
//            {
//                _KeyValue = value;
//            }
//        }
//        public AddingEventEventArgs(string sKeyValue)
//        {
//            _KeyValue = sKeyValue;
//        }
//        public AddingEventEventArgs()
//        {
//        }
//    }

//    public class AddedEventEventArgs : EventArgs
//    {
//        private string _KeyValue;
//        /// <summary>
//        ///如果当前生成带有id的，此处代表当前数据的唯一ID
//        /// </summary>
//        public string KeyValue
//        {
//            get
//            {
//                return _KeyValue;
//            }
//            set
//            {
//                _KeyValue = value;
//            }
//        }
//        public AddedEventEventArgs(string sKeyValue)
//        {
//            _KeyValue = sKeyValue;
//        }
//        public AddedEventEventArgs()
//        {
//        }
//    }

//    public class DeleteingEntityEventEventArgs : EventArgs
//    {
//        private bool _StopContinue;
//        /// <summary>
//        /// 是否阻住进行操作
//        /// </summary>
//        public bool StopContinue
//        {
//            get
//            {
//                return _StopContinue;
//            }
//            set
//            {
//                _StopContinue = value;
//            }
//        }
//        private string _KeyValue;
//        /// <summary>
//        ///如果当前生成带有id的，此处代表当前数据的唯一ID
//        /// </summary>
//        public string KeyValue
//        {
//            get
//            {
//                return _KeyValue;
//            }
//            set
//            {
//                _KeyValue = value;
//            }
//        }
//        public DeleteingEntityEventEventArgs(string sKeyValue)
//        {
//            _KeyValue = sKeyValue;
//        }
//        public DeleteingEntityEventEventArgs()
//        {
//        }
//    }

//    public class DeletedEntityEventEventArgs : EventArgs
//    {
//        private string _KeyValue;
//        /// <summary>
//        ///如果当前生成带有id的，此处代表当前数据的唯一ID
//        /// </summary>
//        public string KeyValue
//        {
//            get
//            {
//                return _KeyValue;
//            }
//            set
//            {
//                _KeyValue = value;
//            }
//        }
//        public DeletedEntityEventEventArgs(string sKeyValue)
//        {
//            _KeyValue = sKeyValue;
//        }
//        public DeletedEntityEventEventArgs()
//        {
//        }
//    }
    
//    public class SelectingEntityEventEventArgs : EventArgs
//    {
//        private bool _StopContinue;
//        /// <summary>
//        /// 是否阻住进行操作
//        /// </summary>
//        public bool StopContinue
//        {
//            get
//            {
//                return _StopContinue;
//            }
//            set
//            {
//                _StopContinue = value;
//            }
//        }
//        private string _KeyValue;
//        /// <summary>
//        ///如果当前生成带有id的，此处代表当前数据的唯一ID
//        /// </summary>
//        public string KeyValue
//        {
//            get
//            {
//                return _KeyValue;
//            }
//            set
//            {
//                _KeyValue = value;
//            }
//        }
//        public SelectingEntityEventEventArgs(string sKeyValue)
//        {
//            _KeyValue = sKeyValue;
//        }
//        public SelectingEntityEventEventArgs()
//        {
//        }
//    }

//    public class SelectedEntityEventEventArgs : EventArgs
//    {
//        private string _KeyValue;
//        /// <summary>
//        ///如果当前生成带有id的，此处代表当前数据的唯一ID
//        /// </summary>
//        public string KeyValue
//        {
//            get
//            {
//                return _KeyValue;
//            }
//            set
//            {
//                _KeyValue = value;
//            }
//        }
//        public SelectedEntityEventEventArgs(string sKeyValue)
//        {
//            _KeyValue = sKeyValue;
//        }
//        public SelectedEntityEventEventArgs()
//        {
//        }
//    }

//    public class UpdateingEntityEventEventArgs : EventArgs
//    {
//        private bool _StopContinue;
//        /// <summary>
//        /// 是否阻住进行操作
//        /// </summary>
//        public bool StopContinue
//        {
//            get
//            {
//                return _StopContinue;
//            }
//            set
//            {
//                _StopContinue = value;
//            }
//        }
//        private string _KeyValue;
//        /// <summary>
//        ///如果当前生成带有id的，此处代表当前数据的唯一ID
//        /// </summary>
//        public string KeyValue
//        {
//            get
//            {
//                return _KeyValue;
//            }
//            set
//            {
//                _KeyValue = value;
//            }
//        }
//        public UpdateingEntityEventEventArgs(string sKeyValue)
//        {
//            _KeyValue = sKeyValue;
//        }
//        public UpdateingEntityEventEventArgs()
//        {
//        }
//    }

//    public class UpdatedEntityEventEventArgs : EventArgs
//    {
//        private string _KeyValue;
//        /// <summary>
//        ///如果当前生成带有id的，此处代表当前数据的唯一ID
//        /// </summary>
//        public string KeyValue
//        {
//            get
//            {
//                return _KeyValue;
//            }
//            set
//            {
//                _KeyValue = value;
//            }
//        }
//        public UpdatedEntityEventEventArgs(string sKeyValue)
//        {
//            _KeyValue = sKeyValue;
//        }
//        public UpdatedEntityEventEventArgs()
//        {
//        }
//    }

//    public class SelectingEntityListEventEventArgs : EventArgs
//    {
//        private bool _StopContinue;
//        /// <summary>
//        /// 是否阻住进行操作
//        /// </summary>
//        public bool StopContinue
//        {
//            get
//            {
//                return _StopContinue;
//            }
//            set
//            {
//                _StopContinue = value;
//            }
//        }
        
//        public SelectingEntityListEventEventArgs()
//        {
            
//        }
//    }

//    public class SelectedEntityListEventEventArgs : EventArgs
//    {
//        private int _Count;
//        /// <summary>
//        ///记录条数
//        /// </summary>
//        public int Count
//        {
//            get
//            {
//                return _Count;
//            }
//            set
//            {
//                _Count = value;
//            }
//        }
//        public SelectedEntityListEventEventArgs(int Count)
//        {
//            _Count = Count;
//        }
//    }
//}
