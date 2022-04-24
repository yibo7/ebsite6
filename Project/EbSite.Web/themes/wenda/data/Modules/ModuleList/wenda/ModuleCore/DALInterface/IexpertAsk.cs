using System;
using System.Collections.Generic;
using System.Data;
		
namespace EbSite.Modules.Wenda.ModuleCore.DALInterface
{
	/// <summary>
	/// ���ݷ�����EbSite.Modules.Wenda��
	/// </summary>
	public partial interface IDataProvider
	{
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		int expertAsk_GetMaxId();

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool expertAsk_Exists(int id);

		/// <summary>
		/// ����һ������
		/// </summary>
		int expertAsk_Add(Entity.expertAsk model);

		/// <summary>
		/// ����һ������
		/// </summary>
		void expertAsk_Update(Entity.expertAsk model);
		
		/// <summary>
		/// ��ȡͳ��
		/// </summary>
		int expertAsk_GetCount(string strWhere);

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void expertAsk_Delete(int id);

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Entity.expertAsk expertAsk_GetEntity(int id);

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		List<Entity.expertAsk> expertAsk_GetListArray(string strWhere);

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet expertAsk_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		List<Entity.expertAsk> expertAsk_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// ��÷�ҳ����
		/// </summary>
		List<Entity.expertAsk> expertAsk_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// ����ʵ�������
		/// </summary>
		Entity.expertAsk expertAsk_ReaderBind(IDataReader dataReader);

		#endregion  ��Ա����
	}
}

