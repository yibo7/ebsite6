using System;
using System.Collections.Generic;
using System.Data;

namespace EbSite.Modules.Wenda.ModuleCore.DALInterface
{
	/// <summary>
	/// ���ݷ�����a��
	/// </summary>
	public partial interface IDataProvider
	{
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool expandanswers_Exists(int id);

		/// <summary>
		/// ����һ������
		/// </summary>
		int expandanswers_Add(Entity.expandanswers model);

		/// <summary>
		/// ����һ������
		/// </summary>
		void expandanswers_Update(Entity.expandanswers model);
		
		/// <summary>
		/// ��ȡͳ��
		/// </summary>
		int expandanswers_GetCount(string strWhere);

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void expandanswers_Delete(int id);

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Entity.expandanswers expandanswers_GetEntity(int id);

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		List<Entity.expandanswers> expandanswers_GetListArray(string strWhere);

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet expandanswers_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		List<Entity.expandanswers> expandanswers_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// ��÷�ҳ����
		/// </summary>
		List<Entity.expandanswers> expandanswers_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// ����ʵ�������
		/// </summary>
		Entity.expandanswers expandanswers_ReaderBind(IDataReader dataReader);


	  
		#endregion  ��Ա����
	}
}

