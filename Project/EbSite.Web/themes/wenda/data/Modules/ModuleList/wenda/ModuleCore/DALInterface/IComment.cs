using System;
using System.Collections.Generic;
using System.Data;
		
namespace EbSite.Modules.Wenda.ModuleCore.DALInterface
{
	/// <summary>
	/// ���ݷ�����Ask��
	/// </summary>
	public partial interface IDataProvider
	{
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		int Comment_GetMaxId();

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Comment_Exists(int id);

		/// <summary>
		/// ����һ������
		/// </summary>
		int Comment_Add(Entity.Comment model);

		/// <summary>
		/// ����һ������
		/// </summary>
		void Comment_Update(Entity.Comment model);
		
		/// <summary>
		/// ��ȡͳ��
		/// </summary>
		int Comment_GetCount(string strWhere);

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Comment_Delete(int id);

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Entity.Comment Comment_GetEntity(int id);

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		List<Entity.Comment> Comment_GetListArray(string strWhere);

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet Comment_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		List<Entity.Comment> Comment_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// ��÷�ҳ����
		/// </summary>
		List<Entity.Comment> Comment_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// ����ʵ�������
		/// </summary>
		Entity.Comment Comment_ReaderBind(IDataReader dataReader);

		#endregion  ��Ա����
	}
}

