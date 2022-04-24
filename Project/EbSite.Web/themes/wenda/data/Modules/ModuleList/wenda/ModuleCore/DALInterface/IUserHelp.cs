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
		int UserHelp_GetMaxId();

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool UserHelp_Exists(int id);

		/// <summary>
		/// ����һ������
		/// </summary>
		int UserHelp_Add(Entity.UserHelp model);

		/// <summary>
		/// ����һ������
		/// </summary>
		void UserHelp_Update(Entity.UserHelp model);
		
		/// <summary>
		/// ��ȡͳ��
		/// </summary>
		int UserHelp_GetCount(string strWhere);

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void UserHelp_Delete(int id);

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Entity.UserHelp UserHelp_GetEntity(int id);

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		List<Entity.UserHelp> UserHelp_GetListArray(string strWhere);

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet UserHelp_GetList(int Top,string strWhere,string filedOrder);
		
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		List<Entity.UserHelp> UserHelp_GetListArray(int Top,string strWhere,string filedOrder);

		/// <summary>
		/// ��÷�ҳ����
		/// </summary>
		List<Entity.UserHelp> UserHelp_GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds, string oderby,out int RecordCount);

		/// <summary>
		/// ����ʵ�������
		/// </summary>
		Entity.UserHelp UserHelp_ReaderBind(IDataReader dataReader);

		#endregion  ��Ա����
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Entity.UserHelp UserHelp_GetEntityByUserID(int UserID);


	    int SumAskNum();
        DataSet GetRandomContent(int top);
	    DataSet GetRandomContentIDS(string ids);

        DataSet GetRandomContentIDS(int top,string ids);
         /// <summary>
        /// ����ҳ �����ʴ��ṩ����Դ ÿ�����5000��
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        DataSet GetNewsContent5000(int top);



        DataSet GetNewsPageContent(int PageIndex, int PageSize);
	}
}

