using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace EbSite.Base.Entity
{

    /// <summary>
    /// 此实体基类为xml存储专用
    /// </summary>
    [Serializable]
    public abstract class XmlEntityBase<TYPE> : Base
    {
        private TYPE _Id;

        public TYPE Clone<TYPE>(TYPE ob)
        {
            BinaryFormatter formatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
            MemoryStream serializationStream = new MemoryStream();
            formatter.Serialize(serializationStream, ob);
            serializationStream.Position = 0L;
            object obj2 = formatter.Deserialize(serializationStream);
            serializationStream.Close();
            return (TYPE)obj2;
        }

        public TYPE id
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
        
    }

    ///// <summary>
    ///// 此实体基类为xml存储专用
    ///// </summary>
    //[Serializable]
    //public abstract class XmlEntityBase : Base
    //{
    //    private Guid _Id = Guid.NewGuid();

    //    public TYPE Clone<TYPE>(TYPE ob)
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
    //        MemoryStream serializationStream = new MemoryStream();
    //        formatter.Serialize(serializationStream, ob);
    //        serializationStream.Position = 0L;
    //        object obj2 = formatter.Deserialize(serializationStream);
    //        serializationStream.Close();
    //        return (TYPE)obj2;
    //    }

    //    public Guid id
    //    {
    //        get
    //        {
    //            return this._Id;
    //        }
    //        set
    //        {
    //            this._Id = value;
    //        }
    //    }
    //}
}
