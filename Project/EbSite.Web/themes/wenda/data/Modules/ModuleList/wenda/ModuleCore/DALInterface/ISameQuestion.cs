using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Modules.Wenda.ModuleCore.DALInterface
{
	/// <summary>
	/// ���ݷ�����bb��
	/// </summary>
	public partial interface IDataProvider
	{
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		int SameQuestion_GetMaxId();

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool SameQuestion_Exists(int id);

		/// <summary>
		/// ����һ������
		/// </summary>
		int SameQuestion_Add(Entity.SameQuestion model);

		/// <summary>
		/// ����һ������
		/// </summary>
		void SameQuestion_Update(Entity.SameQuestion model);
		
		/// <summary>
		/// ��ȡͳ��
		/// </summary>
		int SameQuestion_GetCount(string strWhere);

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void SameQuestion_Delete(int id);

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Entity.SameQuestion SameQuestion_GetEntity(int id);

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		List<Entity.SameQuestion> SameQuestion_GetListArray(string strWhere);

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet SameQuestion_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		List<Entity.SameQuestion> SameQuestion_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// ��÷�ҳ����
		/// </summary>
		List<Entity.SameQuestion> SameQuestion_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// ����ʵ�������
		/// </summary>
		Entity.SameQuestion SameQuestion_ReaderBind(IDataReader dataReader);

		#endregion  ��Ա����
	}
}

