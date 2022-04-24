

namespace EbSite.Control.FileManager
{
    public class BindFactory
    {
        
        public BindFactory()
        {
            
        }

        public  enum ListType
        {
            Img = 1,
            Music = 2,
            Flash = 3,
            Other = 4,
            Aspx = 5

        }

        public static BindBase CreateInstance(ListType iType)
        {
            BindBase Insctance = null;
            switch (iType)
            {
                case ListType.Img:   //图片
                    Insctance = new BindImg();
                    break;
                case ListType.Music:   //音乐类
                case ListType.Flash:   //flash类
                case ListType.Aspx:   //flash类
                case ListType.Other:   //其他类
                    Insctance = new BindOrtherFiles();
                    break;
            }
            return Insctance;
        }

    }
}
