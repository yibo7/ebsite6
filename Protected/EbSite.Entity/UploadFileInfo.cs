using System;
using System.Collections.Generic;
using System.Text;
using EbSite.Base.Entity;

namespace EbSite.Entity
{


    [Serializable]
    public class UploadFileInfo : Base.Entity.EntityBase<UploadFileInfo, int>, IEquatable<UploadFileInfo>
    {
        private DateTime _AddDate;
        private string _FileNewName;
        private string _FileOldName;
        private bool _IsSave = false;
        public UploadFileInfo()
        {
           base.CurrentModel = this;
        }

       
		public UploadFileInfo(int ID)
		{
			base.id = ID;
			base.InitData(this);
			base.CurrentModel = this;
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
