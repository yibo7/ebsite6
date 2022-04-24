using System;
using System.Collections.Generic;
using System.Data;
		
namespace EbSite.Modules.BBS.ModuleCore.DALInterface
{
	/// <summary>
	/// ���ݷ�����BBS��
	/// </summary>
	public partial interface IDataProvider
	{
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		int imitateuser_GetMaxId();

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool imitateuser_Exists(int id);

		/// <summary>
		/// ����һ������
		/// </summary>
		int imitateuser_Add(Entity.imitateuser model);

		/// <summary>
		/// ����һ������
		/// </summary>
		void imitateuser_Update(Entity.imitateuser model);
		
		/// <summary>
		/// ��ȡͳ��
		/// </summary>
		int imitateuser_GetCount(string strWhere);

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void imitateuser_Delete(int id);

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Entity.imitateuser imitateuser_GetEntity(int id);

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		List<Entity.imitateuser> imitateuser_GetListArray(string strWhere);

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet imitateuser_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		List<Entity.imitateuser> imitateuser_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// ��÷�ҳ����
		/// </summary>
		List<Entity.imitateuser> imitateuser_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// ����ʵ�������
		/// </summary>
		Entity.imitateuser imitateuser_ReaderBind(IDataReader dataReader);

		#endregion  ��Ա����

	    Entity.imitateuser GetRandByUserID(int UserID);
	}
}

