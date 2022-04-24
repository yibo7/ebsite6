using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EbSite.Base.Entity;

namespace EbSite.Modules.Wenda.ModuleCore.Entity
{
    /// <summary>
    /// 回答专家表
    /// </summary>
     [Serializable]
    public class ExpertsInfo : XmlEntityBase<int>
    {
        private int _userid;
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        private string _username;
        /// <summary>
        /// 用户名称
        /// </summary>
        public string  UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        private string _userniname;
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNiName
        {
            get { return _userniname; }
            set { _userniname = value; }
        }
        private string _field;
        /// <summary>
        ///擅长领域
        /// </summary>
        public string Field
        {
            get { return _field; }
            set { _field = value; }
        }

        private string  _area;
        /// <summary>
        /// 地区
        /// </summary>
        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }
        private int _solvcount;
        /// <summary>
        /// 解决的问题总数
        /// </summary>
        public int SolveCount
        {
            get { return _solvcount; }
            set { _solvcount = value; }
          
        }

        private string _brand;
        /// <summary>
        ///擅长品牌
        /// </summary>
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        private string _jianjie;
        /// <summary>
        ///简介
        /// </summary>
        public string JianJie
        {
            get { return _jianjie; }
            set { _jianjie = value; }
        }

         /// <summary>
         /// 是否审核通过
         /// </summary>
        private int _isaudit;

        public int IsAudit
        {
            get { return _isaudit; }
            set { _isaudit = value; }
        }


        /// <summary>
        /// 解决的问题总数
        /// </summary>
        public int ExSolveCount
        {
            get
            {
                ModuleCore.Entity.UserHelp model = ModuleCore.BLL.UserHelp.Instance.GetEntity(UserID);
                if (!Equals(model, null))
                {
                    return model.ACount;
                }
                return 0;
            }
        }
        private string _postition;
        /// <summary>
        ///简介
        /// </summary>
        public string Postition
        {
            get { return _postition; }
            set { _postition = value; }
        }
    }
}