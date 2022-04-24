using System;
using System.Collections.Generic;
using System.Data;
using EbSite.Modules.Wenda.ModuleCore.DAL.MySQL;

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
		int Answers_GetMaxId();

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Answers_Exists(int id);

		/// <summary>
		/// ����һ������
		/// </summary>
		int Answers_Add(Entity.Answers model);

		/// <summary>
		/// ����һ������
		/// </summary>
		void Answers_Update(Entity.Answers model);
		
		/// <summary>
		/// ��ȡͳ��
		/// </summary>
		int Answers_GetCount(string strWhere);

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Answers_Delete(int id);

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Entity.Answers Answers_GetEntity(int id);

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		List<Entity.Answers> Answers_GetListArray(string strWhere);

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet Answers_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		List<Entity.Answers> Answers_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// ��÷�ҳ����
		/// </summary>
		List<Entity.Answers> Answers_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// ����ʵ�������
		/// </summary>
		Entity.Answers Answers_ReaderBind(IDataReader dataReader);

	    string HelpUserCount(int UserID);
		#endregion  ��Ա����

	    List<BNewsClass> DALBNews_GetListArray(int Top, string strWhere, string filedOrder);

        DataSet GetRandAskData(int bid,int top);

	    DataSet GetDataArticle(long id);
	}
}

