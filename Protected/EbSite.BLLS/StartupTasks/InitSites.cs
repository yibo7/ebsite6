//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Bootstrap.Extensions.StartupTasks;
//using EbSite.Base;

//namespace EbSite.BLL.StartupTasks
//{
//    public class InitSites : IStartupTask
//    {

//        public void Reset()
//        {
//            throw new NotImplementedException();
//        }

//        public void Run()
//        {
            
//            List<EbSite.Entity.Sites> lst = EbSite.BLL.Sites.Instance.FillList();

//            foreach (Entity.Sites mdsites in lst)
//            {
//                if (!AppStartInit.Sites.ContainsKey(mdsites.id))
//                    AppStartInit.Sites.Add(mdsites.id, mdsites);
//            }
//        }
//    }
//}
