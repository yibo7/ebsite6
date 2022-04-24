using System;
using EbSite.Base.Modules;
using EbSite.Modules.Wenda.ModuleCore.Entity;

namespace EbSite.Modules.Wenda.AdminPages.Controls.AskOperate
{
    public partial class AnswerShow : MPUCBaseShow<ModuleCore.Entity.Answers>
    {
        /// <summary>
        /// Ȩ��ȫ��
        /// </summary>
        public override string Permission
        {
            get
            {
                return "25";
            }
        }
        /// <summary>
        /// ��дɾ��
        /// </summary>
        protected override void Delete()
        {
            Model.Delete();
        }
        /// <summary>
        /// ��дLoad�¼�
        /// </summary>
        protected override ModuleCore.Entity.Answers LoadModel()
        {
            ModuleCore.Entity.Answers md = new ModuleCore.Entity.Answers(int.Parse(GetKeyID));
            if (Equals(md, null)) md = new ModuleCore.Entity.Answers();//��ֹɾ�����ҳ�����
            return md;
        }




    }
}
