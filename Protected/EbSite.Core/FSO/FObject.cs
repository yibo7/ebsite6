using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Xml;
using EbSite.Core.Strings;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;

namespace EbSite.Core.FSO
{
	/// <summary>
	/// 文件系统的处理对象
	/// </summary>
	public enum FsoMethod
	{
		/// <summary>
		/// 仅用于处理文件夹
		/// </summary>
		Folder = 0,
		/// <summary>
		/// 仅用于处理文件
		/// </summary>
		File,
		/// <summary>
		/// 文件和文件夹都参与处理
		/// </summary>
		All
	}
	/// <summary>
	/// FObject : 文件系统的处理类
	/// </summary>
	public abstract class FObject
	{
        
		# region "文件的读写操作"

		/// <summary>
		/// 以文件流的形式读取指定文件的内容
		/// </summary>
		/// <param name="file">指定的文件及其全路径</param>
		/// <returns>返回 String</returns>
		public static string ReadFile(string file)
		{
			string strResult = "";

			FileStream fStream		= new FileStream(file, FileMode.Open, FileAccess.Read);
			StreamReader sReader	= new StreamReader(fStream, Encoding.Default);

			try
			{
                
				strResult			= sReader.ReadToEnd();
			}
			catch{}
			finally
			{
				fStream.Flush();
				fStream.Close();
				sReader.Close();
			}

			return strResult;
		}

        public static bool IsFileInUse(string fileName)
        {
            bool inUse = true;

            FileStream fs = null;
            try
            {

                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read,

                FileShare.None);

                inUse = false;
            }
            catch
            {

            }
            finally
            {
                if (fs != null)

                    fs.Close();
            }
            return inUse;//true表示正在使用,false没有使用  
        }
        //private static object LockObj = new object();
        /// <summary>
        /// 以文件流的形式将内容写入到指定文件中（如果该文件或文件夹不存在则创建）
        /// </summary>
        /// <param name="file">文件名和指定路径</param>
        /// <param name="fileContent">文件内容</param>
        /// <returns>返回布尔值</returns>
        public static string WriteFile(string file, string fileContent)
		{
            //lock (LockObj)
            //{
                FileInfo f = new FileInfo(file);
                // 如果文件所在的文件夹不存在则创建文件夹
                if (!Directory.Exists(f.DirectoryName)) Directory.CreateDirectory(f.DirectoryName);

                FileStream fStream = new FileStream(file, FileMode.Create, FileAccess.Write);
                StreamWriter sWriter = new StreamWriter(fStream, Encoding.GetEncoding("gb2312"));

                try
                {
                    sWriter.Write(fileContent);
                    return fileContent;
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.ToString());
                }
                finally
                {
                    sWriter.Flush();
                    fStream.Flush();
                    sWriter.Close();
                    fStream.Close();
                }
            //}
			
		}

        public static string WriteFileUtf8(string file, string fileContent)
        {
            //lock (LockObj)
            //{
                FileInfo f = new FileInfo(file);
                // 如果文件所在的文件夹不存在则创建文件夹
                if (!Directory.Exists(f.DirectoryName)) Directory.CreateDirectory(f.DirectoryName);

                FileStream fStream = new FileStream(file, FileMode.Create, FileAccess.Write);
                StreamWriter sWriter = new StreamWriter(fStream, Encoding.UTF8);

                try
                {
                    sWriter.Write(fileContent);
                    return fileContent;
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.ToString());
                }
                finally
                {
                    sWriter.Flush();
                    fStream.Flush();
                    sWriter.Close();
                    fStream.Close();
                }
            //}
        }

		/// <summary>
		/// 以文件流的形式将内容写入到指定文件中（如果该文件或文件夹不存在则创建）
		/// </summary>
		/// <param name="file">文件名和指定路径</param>
		/// <param name="fileContent">文件内容</param>
		/// <param name="Append">是否追加指定内容到该文件中</param>
		/// <returns>返回布尔值</returns>
		public static void WriteFile(string file, string fileContent, bool Append)
		{
			FileInfo f = new FileInfo(file);
			// 如果文件所在的文件夹不存在则创建文件夹
			if( !Directory.Exists(f.DirectoryName) ) Directory.CreateDirectory(f.DirectoryName);

			StreamWriter sWriter	= new StreamWriter(file, Append, Encoding.GetEncoding("gb2312"));

			try
			{
				sWriter.Write(fileContent);
			}
			catch( Exception exc )
			{
				throw new Exception(exc.ToString());
			}
			finally
			{
				sWriter.Flush();
				sWriter.Close();
			}
		}

        /// <summary>
        /// 以文件流的形式将内容写入到指定文件中（如果该文件或文件夹不存在则创建）-自定义编码
        /// </summary>
        /// <param name="file">文件名和指定路径</param>
        /// <param name="fileContent">文件内容</param>
        /// <param name="Append">是否追加指定内容到该文件中</param>
        /// <returns>返回布尔值</returns>
        public static void WriteFile(string file, string fileContent, bool Append,Encoding ec)
        {
            FileInfo f = new FileInfo(file);
            // 如果文件所在的文件夹不存在则创建文件夹
            if (!Directory.Exists(f.DirectoryName)) Directory.CreateDirectory(f.DirectoryName);

            StreamWriter sWriter = new StreamWriter(file, Append, ec);

            try
            {
                sWriter.Write(fileContent);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.ToString());
            }
            finally
            {
                sWriter.Flush();
                sWriter.Close();
            }
        }
		# endregion


		# region "文件夹信息的读取"


		/// <summary>
		/// 获取指定目录下的所有目录及其文件信息
		/// </summary>
		/// <param name="dir">文件夹</param>
		/// <param name="method">获取方式。</param>
		/// <returns>DataTable</returns>
		public static DataTable getDirectoryAllInfos(string dir, FsoMethod method)
		{
			DataTable Dt;

			try
			{
				DirectoryInfo dInfo = new DirectoryInfo(dir);
				Dt = getDirectoryAllInfo(dInfo, method);
			}
			catch(Exception exc)
			{
				throw new Exception(exc.ToString());
			}

			return Dt;
		}


		/// <summary>
		/// 获取指定目录下的所有目录及其文件信息
		/// </summary>
		/// <param name="d">实例化的目录</param>
		/// <param name="method">获取方式。1、仅获取文件夹结构  2、仅获取文件结构  3、同时获取文件和文件夹信息</param>
		/// <returns></returns>
		private static DataTable getDirectoryAllInfo(DirectoryInfo d,  FsoMethod method)
		{
			DataTable Dt = new DataTable();
			DataRow Dr;

			Dt.Columns.Add("name");			//名称
			Dt.Columns.Add("rname");		//名称
			Dt.Columns.Add("content_type");	//文件MIME类型，如果是文件夹则置空
			Dt.Columns.Add("type");			//类型：1为文件夹，2为文件
			Dt.Columns.Add("path");			//文件路径
			Dt.Columns.Add("creatime");		//创建时间
			Dt.Columns.Add("size");			//文件大小

			// 获取文件夹结构信息
			DirectoryInfo[] dirs = d.GetDirectories();
			foreach(DirectoryInfo dir in dirs)
			{
				if( method == FsoMethod.File )
				{
					Dt = copyDT(Dt,getDirectoryAllInfo(dir, method));
				}
				else
				{
					Dr = Dt.NewRow();

					Dr[0] = dir.Name;
					Dr[1] = dir.FullName;
					Dr[2] = "";
					Dr[3] = 1;
					Dr[4] = dir.FullName.Replace(dir.Name,"");
					Dr[5] = dir.CreationTime;
					Dr[6] = "";

					Dt.Rows.Add(Dr);

					Dt = copyDT(Dt,getDirectoryAllInfo(dir, method));
				}
			}

			// 获取文件结构信息
			if( method != FsoMethod.Folder )
			{
				FileInfo[] files = d.GetFiles();
				foreach(FileInfo file in files)
				{
					Dr = Dt.NewRow();

					Dr[0] = file.Name;
					Dr[1] = file.FullName;
					Dr[2] = file.Extension.Replace(".","");
					Dr[3] = 2;
					Dr[4] = file.DirectoryName + "\\";
					Dr[5] = file.CreationTime;
					Dr[6] = file.Length;

					Dt.Rows.Add(Dr);
				}
			}

			return Dt;
		}

		/// <summary>
		/// 将两个结构一样的 DataTable 组合成一个 DataTable
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="child"></param>
		/// <returns>DataTable</returns>
		public static DataTable copyDT(DataTable parent, DataTable child)
		{
			DataRow dr;
			for(int i = 0; i < child.Rows.Count; i++)
			{
				dr = parent.NewRow();
				for(int j = 0; j < parent.Columns.Count; j++)
				{
					dr[j] = child.Rows[i][j];
				}
				parent.Rows.Add(dr);
			}

			return parent;
		}



		/// <summary>
		/// 获取指定文件夹的信息，如：文件夹大小，文件夹数，文件数
		/// </summary>
		/// <param name="dir">指定文件夹路径</param>
		/// <returns>返回 String</returns>
		public static long[] getDirInfos(string dir)
		{
			long[] intResult = new long[3];
			DirectoryInfo d = new DirectoryInfo(dir);
			intResult = DirInfo(d);

			return intResult;
		}


		private static long[] DirInfo(DirectoryInfo d)
		{
			long[] intResult = new long[3];

			long Size = 0;
			long Dirs = 0;
			long Files = 0;
			// 计算文件大小
			FileInfo[] files = d.GetFiles();
			Files += files.Length;
			foreach(FileInfo file in files)
			{
				Size += file.Length;
			}
			// 计算文件夹
			DirectoryInfo[] dirs = d.GetDirectories();
			Dirs += dirs.Length;
			foreach(DirectoryInfo dir in dirs)
			{
				Size += DirInfo(dir)[0];
				Dirs += DirInfo(dir)[1];
				Files += DirInfo(dir)[2];
			}

			intResult[0] = Size;
			intResult[1] = Dirs;
			intResult[2] = Files;
			return intResult;
		}


		/// <summary>
		/// 获取指定目录的目录信息
		/// </summary>
		/// <param name="dir">指定目录</param>
		/// <param name="method">获取方式。1、仅获取文件夹结构  2、仅获取文件结构  3、同时获取文件和文件夹信息</param>
		/// <returns>返回 DataTable</returns>
		public static DataTable getDirectoryInfos(string dir, FsoMethod method)
		{
			DataTable Dt = new DataTable();
			DataRow Dr;

			Dt.Columns.Add("name");//名称
			Dt.Columns.Add("type");//类型：1为文件夹，2为文件
			Dt.Columns.Add("size");//文件大小，如果是文件夹则置空
			Dt.Columns.Add("content_type");//文件MIME类型，如果是文件夹则置空
			Dt.Columns.Add("createTime");//创建时间
			Dt.Columns.Add("lastWriteTime");//最后修改时间

			// 获取文件夹结构信息
			if( method != FsoMethod.File )
			{
				for(int i = 0; i < getDirs(dir).Length; i++)
				{
					Dr = Dt.NewRow();
					DirectoryInfo d = new DirectoryInfo(getDirs(dir)[i]);

					Dr[0] = d.Name;
					Dr[1] = 1;
					Dr[2] = "";
					Dr[3] = "";
					Dr[4] = d.CreationTime;
					Dr[5] = d.LastWriteTime;

					Dt.Rows.Add(Dr);
				}
			}

			// 获取文件结构信息
			if( method != FsoMethod.Folder )
			{
				for(int i = 0; i < getFiles(dir).Length; i++)
				{
					Dr = Dt.NewRow();
					FileInfo f = new FileInfo(getFiles(dir)[i]);

					Dr[0] = f.Name;
					Dr[1] = 2;
					Dr[2] = f.Length;
					Dr[3] = f.Extension.Replace(".","");
					Dr[4] = f.CreationTime;
					Dr[5] = f.LastWriteTime;

					Dt.Rows.Add(Dr);
				}
			}

			return Dt;
		}


		private static string[] getDirs(string dir)
		{
			return Directory.GetDirectories(dir);
		}

		private static string[] getFiles(string dir)
		{
			return Directory.GetFiles(dir);
		}

		# endregion


		# region "文件系统的相应操作"

		/// <summary>
		/// 判断文件或文件夹是否存在
		/// </summary>
		/// <param name="file">指定文件及其路径</param>
		/// <param name="method">判断方式</param>
		/// <returns>返回布尔值</returns>
		public static bool IsExist(string file, FsoMethod method)
		{
			try
			{
				if( method == FsoMethod.File )
				{
					return File.Exists(file);
				}
				else if( method == FsoMethod.Folder )
				{
					return Directory.Exists(file);
				}
				else
				{
					return false;
				}
			}
			catch(Exception exc)
			{
				throw new Exception(exc.ToString());
			}
		}

		# region "新建"

		/// <summary>
		/// 新建文件或文件夹
		/// </summary>
		/// <param name="file">文件或文件夹及其路径</param>
		/// <param name="method">新建方式</param>
		public static void Create(string file, FsoMethod method)
		{
			try
			{
				if( method == FsoMethod.File )
				{
					WriteFile(file, "");
				}
				else if( method == FsoMethod.Folder )
				{
					Directory.CreateDirectory(file);
				}
			}
			catch(Exception exc)
			{
				throw new Exception(exc.ToString());
			}
		}

		# endregion


		# region "复制"

		# region "复制文件"
		/// <summary>
		/// 复制文件，如果目标文件已经存在则覆盖掉
		/// </summary>
		/// <param name="oldFile">源文件</param>
		/// <param name="newFile">目标文件</param>
		public static void CopyFile(string oldFile, string newFile)
		{
			try
			{
				File.Copy(oldFile, newFile, true);
			}
			catch(Exception exc)
			{
				throw new Exception(exc.ToString());
			}
		}

		
		/// <summary>
		/// 以流的形式复制拷贝文件
		/// </summary>
		/// <param name="oldPath">源文件</param>
		/// <param name="newPath">目标文件</param>
		/// <returns></returns>
		public static bool CopyFileStream(string oldPath, string newPath)
		{
			try
			{
				//建立两个FileStream对象
				FileStream fsOld = new FileStream(oldPath, FileMode.Open, FileAccess.Read);
				FileStream fsNew = new FileStream(newPath, FileMode.Create, FileAccess.Write);

				//分别建立一个读写类
				BinaryReader br = new BinaryReader(fsOld);
				BinaryWriter bw = new BinaryWriter(fsNew);

				//将读取文件流的指针指向流的头部
				br.BaseStream.Seek(0, SeekOrigin.Begin);
				//将写入文件流的指针指向流的尾部
				br.BaseStream.Seek(0, SeekOrigin.End);

				while(br.BaseStream.Position < br.BaseStream.Length)
				{
					//从br流中读取一个Byte并马上写入bw流
					bw.Write(br.ReadByte());
				}
				//释放所有被占用的资源
				br.Close();
				bw.Close();
				fsOld.Flush();
				fsOld.Close();
				fsNew.Flush();
				fsNew.Close();
				return true;
			}
			catch
			{
				return false;
			}

		}

		# endregion

		# region "复制文件夹"

		/// <summary>
		/// 复制文件夹中的所有内容及其子目录所有文件
		/// </summary>
		/// <param name="oldDir">源文件夹及其路径</param>
		/// <param name="newDir">目标文件夹及其路径</param>
		public static void CopyDirectory(string oldDir, string newDir)
		{
			try
			{
				DirectoryInfo dInfo = new DirectoryInfo(oldDir);
				CopyDirInfo(dInfo,oldDir,newDir);
			}
			catch(Exception exc)
			{
				throw new Exception(exc.ToString());
			}
		}

		private static void CopyDirInfo(DirectoryInfo od, string oldDir, string newDir)
		{
			// 寻找文件夹
			if( !IsExist(newDir, FsoMethod.Folder ) ) Create(newDir, FsoMethod.Folder);
			DirectoryInfo[] dirs = od.GetDirectories();
			foreach(DirectoryInfo dir in dirs)
			{
				CopyDirInfo(dir,dir.FullName,newDir + dir.FullName.Replace(oldDir,""));
			}
			// 寻找文件
			FileInfo[] files = od.GetFiles();
			foreach(FileInfo file in files)
			{
				CopyFile(file.FullName,newDir + file.FullName.Replace(oldDir,""));
			}
		}

		# endregion

		# endregion
        /// <summary>
        /// 检查文件对应的目录是否存在，不存在就创建目录
        /// </summary>
        /// <param name="sPath">路径</param>
        public static void ExistsDirectory(string sPath)
        {
            FileInfo f = new FileInfo(sPath);
            // 如果文件所在的文件夹不存在则创建文件夹
            if (!Directory.Exists(f.DirectoryName)) Directory.CreateDirectory(f.DirectoryName);   
        }

		# region "移动"

		/// <summary>
		/// 移动文件或文件夹
		/// </summary>
		/// <param name="oldFile">原始文件或文件夹</param>
		/// <param name="newFile">目标文件或文件夹</param>
		/// <param name="method">移动方式：1、为移动文件，2、为移动文件夹</param>
		public static void Move(string oldFile, string newFile, FsoMethod method)
		{
			try
			{
                FileInfo f = new FileInfo(newFile);
                // 如果文件所在的文件夹不存在则创建文件夹
                if (!Directory.Exists(f.DirectoryName)) Directory.CreateDirectory(f.DirectoryName);


				if( method == FsoMethod.File )
				{
					File.Move(oldFile, newFile);
				}
				if( method == FsoMethod.Folder )
				{
					Directory.Move(oldFile, newFile);
				}
			}
			catch(Exception exc)
			{
				throw new Exception(exc.ToString());
			}
		}

		# endregion


		# region "删除"

		/// <summary>
		/// 删除文件或文件夹
		/// </summary>
		/// <param name="file">文件或文件夹及其路径</param>
		/// <param name="method">删除方式：1、为删除文件，2、为删除文件夹</param>
		public static void Delete(string file, FsoMethod method)
		{
			try
			{
				if( method == FsoMethod.File )
				{
					File.Delete(file);
				}
				if( method == FsoMethod.Folder )
				{
					Directory.Delete(file, true);//删除该目录下的所有文件以及子目录
				}
			}
			catch(Exception exc)
			{
				throw new Exception(exc.ToString());
			}
		}


        /// <summary>
        /// 删除某个目录下所有文件，保留目录- 删除目录再创建相同目录
        /// </summary>
        /// <param name="strDir">目录地址</param>
        public static void DeleteFiles(string strDir)
        {
            if (Directory.Exists(strDir))
            {
                Directory.Delete(strDir, true);
                Directory.CreateDirectory(strDir);
                //Console.WriteLine("文件删除成功！");
            }
            else
            {
                //Console.WriteLine("此目录不存在！");
            }
        }

		# endregion

		# endregion

		#region 生成静态页面-模板替换法-刷新
		/// <summary>
		/// 生成静态页面-模板替换法-刷新
		/// </summary>
		/// <param name="iStar"></param>
		/// <param name="iEnd"></param>
		/// <param name="iRefreshnum"></param>
		/// <param name="strRefreshPage"></param>
		/// <param name="strHtmPath"></param>
		/// <param name="strTemContent"></param>
		/// <param name="sarrTemTap"></param>
		/// <param name="arrReplaceTap"></param>
		/// <param name="lbInfo"></param>
		public static void MakeHtml(int iStar,int iEnd,int iRefreshnum,string strRefreshPage,string strHtmPath,string strTemContent,string[] sarrTemTap,string[] arrReplaceTap,System.Web.UI.WebControls.Label lbInfo)
		{
			int refreshnum = 1;
			string strAllPath ="";
			string strReplaceContent = "";
			System.Web.HttpResponse Response = HttpContext.Current.Response;
			for(int i=iStar;i<=iEnd;i++)
			{
				int iReplaceTap = 0;
				foreach(string strTap in sarrTemTap)
				{
					strReplaceContent = strTemContent.Replace(strTap,arrReplaceTap[iReplaceTap]);
					strTemContent = strReplaceContent;
					iReplaceTap = iReplaceTap+1;

				}
				strAllPath = strHtmPath+i+".html";
				
				WriteFile(strAllPath,strTemContent,false);

				if (refreshnum == iRefreshnum)
				{
					Response.Write("<meta http-equiv=\"refresh\" content=\"0;url='"+strRefreshPage+ (i+1).ToString() + "'>");
				}
				refreshnum = refreshnum + 1;
				
			}
			lbInfo.Text = "<font color=#FF0000>已经完成:<br>"+iStar+"/"+iEnd+"</font>";
		}
		/// <summary>
		/// 生成静态,非刷新，加进度条可用
		/// </summary>
		/// <param name="strHtmPath">生成路径及名称</param>
		/// <param name="strTemContent">生成内容</param>
		/// <param name="sarrTemTap">要替换的标志</param>
		/// <param name="arrReplaceTap">要替换的内容</param>
		/// <param name="isClearSpace">是否清除回车换行</param>
		public static void MakeHtml(string strHtmPath,string strTemContent,string[] sarrTemTap,string[] arrReplaceTap,bool isClearSpace)
		{
			string strAllPath ="";
			string strReplaceContent = "";
			int iReplaceTap = 0;
			foreach(string strTap in sarrTemTap)
			{
					strReplaceContent = strTemContent.Replace(strTap,arrReplaceTap[iReplaceTap]);
					strTemContent = strReplaceContent;
					iReplaceTap = iReplaceTap+1;

			}
			strAllPath = strHtmPath;
			if(isClearSpace)strTemContent = cConvert.ClearBack(strTemContent);

			WriteFile(strAllPath,strTemContent,false);
		}
		
		#endregion

        #region 文件的打包解包处理

        private static void zip(string strFile, ZipOutputStream s, string staticFile)
        {
            if (strFile[strFile.Length - 1] != Path.DirectorySeparatorChar)
            {
                strFile = strFile + Path.DirectorySeparatorChar;
            }
            Crc32 crc = new Crc32();
            string[] fileSystemEntries = Directory.GetFileSystemEntries(strFile);
            foreach (string str in fileSystemEntries)
            {
                if (Directory.Exists(str))
                {
                    zip(str, s, staticFile);
                }
                else
                {
                    FileStream stream = File.OpenRead(str);
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    ZipEntry entry = new ZipEntry(str.Substring(staticFile.LastIndexOf(@"\") + 1));
                    entry.DateTime = DateTime.Now;
                    entry.Size = stream.Length;
                    stream.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    s.PutNextEntry(entry);
                    s.Write(buffer, 0, buffer.Length);
                }
            }
        }
        /// <summary>
        /// 打包指定目录下的文件
        /// </summary>
        /// <param name="strFile">指定目录</param>
        /// <param name="strZip">打包文件名称</param>
        public static void ZipFile(string strFile, string strZip)
        {
            if (strFile[strFile.Length - 1] != Path.DirectorySeparatorChar)
            {
                strFile = strFile + Path.DirectorySeparatorChar;
            }
            ZipOutputStream s = new ZipOutputStream(File.Create(strZip));
            s.SetLevel(6);
            zip(strFile, s, strFile);
            s.Finish();
            s.Close();
        }
        /// <summary>
        /// 打包指定文件
        /// </summary>
        /// <param name="lstFilesPath"></param>
        /// <param name="strZip"></param>
        public static void ZipFilesList(List<string> lstFilesPath, string strZip)
        {
            string sTemPath = HttpContext.Current.Server.MapPath(EbSite.Base.AppStartInit.IISPath+"UploadFile/temp/" + Path.GetRandomFileName()+"/");
           if(!FSO.FObject.IsExist(sTemPath,FsoMethod.Folder))
           {
               Create(sTemPath, FsoMethod.Folder);
               string sFileName = "";
               foreach (string sPath in lstFilesPath)
               {
                   sFileName = Core.Strings.GetString.GetFileName(sPath);
                   if (IsExist(sPath, FsoMethod.File))
                    CopyFile(sPath, string.Concat(sTemPath,sFileName));
               }
               ZipFile(sTemPath, strZip);

               Delete(sTemPath,FsoMethod.Folder);
           }
           else
           {
               throw new Exception("复制文件发生错误!");
           }
        }
        public static bool UnZipFile(string zipFilePath, string unZipDir)
        {
            if (unZipDir == string.Empty)
            {
                unZipDir = zipFilePath.Replace(Path.GetFileName(zipFilePath), Path.GetFileNameWithoutExtension(zipFilePath));
            }
            if (!unZipDir.EndsWith(@"\"))
            {
                unZipDir = unZipDir + @"\";
            }
            if (!Directory.Exists(unZipDir))
            {
                Directory.CreateDirectory(unZipDir);
            }
            using (ZipInputStream stream = new ZipInputStream(File.OpenRead(zipFilePath)))
            {
                ZipEntry entry;
                while ((entry = stream.GetNextEntry()) != null)
                {
                    string directoryName = Path.GetDirectoryName(entry.Name);
                    string fileName = Path.GetFileName(entry.Name);
                    if (directoryName.Length > 0)
                    {
                        Directory.CreateDirectory(unZipDir + directoryName);
                    }
                    if (!directoryName.EndsWith(@"\"))
                    {
                        directoryName = directoryName + @"\";
                    }
                    if (fileName != string.Empty)
                    {
                        using (FileStream stream2 = File.Create(unZipDir + entry.Name))
                        {
                            bool flag2;
                            int count = 0x800;
                            byte[] buffer = new byte[0x800];
                            goto Label_0134;
                        Label_0101:
                            count = stream.Read(buffer, 0, buffer.Length);
                            if (count > 0)
                            {
                                stream2.Write(buffer, 0, count);
                            }
                            else
                            {
                                goto Label_0152;
                            }
                        Label_0134:
                            flag2 = true;
                            goto Label_0101;
                        }
                    Label_0152: ;
                    }
                }
            }
            return true;
        }

        #endregion


        public static FileInfo[] GetFileListByType(string dirpath, string Type)
        {
            return GetFileListByType(dirpath, Type, false);
        }
        public static FileInfo[] GetFileListByType(string dirpath, string Type,bool IsFullPath)
        {
            DirectoryInfo info;
            if(IsFullPath)
            {
                info = new DirectoryInfo(dirpath);
            }
            else
            {
                info = new DirectoryInfo(HttpContext.Current.Server.MapPath(dirpath));
            }
            
            return info.GetFiles("*." + Type);
        }

        public static List<FileInfo> GetFileListByTypes(string dirpath, string[] Types)
        {
            List<FileInfo> list = new List<FileInfo>();
            foreach (string str in Types)
            {
                FileInfo[] fileListByType = GetFileListByType(dirpath, str);
                foreach (FileInfo info in fileListByType)
                {
                    list.Add(info);
                }
            }
            return list;
        }

     


    }

	
}
