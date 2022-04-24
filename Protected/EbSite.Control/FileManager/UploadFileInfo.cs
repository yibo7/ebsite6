using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Control.FileManager
{


    [Serializable]
    public class UploadFileInfo : XmlEntityBase<Guid>, IEquatable<UploadFileInfo>
    {
        private DateTime _AddDate;
        private string _FileNewName;
        private string _FileOldName;
        private bool _IsSave = false;
        public UploadFileInfo()
        {
            base.id = Guid.NewGuid();
        }
        public bool Equals(UploadFileInfo other)
        {
            return (this._FileNewName.ToLower().Trim() == other._FileNewName.ToLower().Trim());
        }

        public DateTime AddDate
        {
            get
            {
                return this._AddDate;
            }
            set
            {
                this._AddDate = value;
            }
        }

        public string FileNewName
        {
            get
            {
                return this._FileNewName;
            }
            set
            {
                this._FileNewName = value;
            }
        }

        public string FileOldName
        {
            get
            {
                return this._FileOldName;
            }
            set
            {
                this._FileOldName = value;
            }
        }

        public bool IsSave
        {
            get
            {
                return this._IsSave;
            }
            set
            {
                this._IsSave = value;
            }
        }
    }
}
