using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;

using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using EbSite.Core;

namespace EbSite.Web.AdminHt.Controls.Admin_Component
{
    public partial class Coder : Base.ControlPage.UserControlBase
    {
        public override string Permission
        {
            get
            {
                return "142";
            }
        }
        static protected string _errorMsg = string.Empty;
        static protected string _extensionName = string.Empty;

        /// <summary>
        /// Handles page load event
        /// </summary>
        /// <param name="sender">Page</param>
        /// <param name="e">Event args</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //btnSave.Enabled = true;
            _extensionName = Request.QueryString["ext"];
            txtTem.Text = ReadFile(GetExtFileName());
        }

        /// <summary>
        /// Buttons save hanler
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Event args</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {

            

            //string ext = Request.QueryString["ext"];

            //if (WriteFile(GetExtFileName(), txtTem.Text))
            //{ 
            //}
            //else
            //{
            //    txtTem.Text = _errorMsg;
            //    txtTem.ForeColor = System.Drawing.Color.Red;
            //    btnSave.Enabled = false;
            //}
        }

        /// <summary>
        /// Returns extension file name
        /// </summary>
        /// <returns>File name</returns>
        string GetExtFileName()
        {
            string fileName = HttpContext.Current.Request.PhysicalApplicationPath;
            
            ArrayList codeAssemblies = Utils.CodeAssemblies();
            foreach (Assembly a in codeAssemblies)
            {
                Type[] types = a.GetTypes();
                foreach (Type type in types)
                {
                    if (type.Name == _extensionName)
                    {
                        string assemblyName = type.Assembly.FullName.Split(".".ToCharArray())[0];
                        assemblyName = assemblyName.Replace("App_SubCode_", "App_Code\\");
                        string fileExt = assemblyName.Contains("VB_Code") ? ".vb" : ".cs";
                        fileName += assemblyName + "\\Plugins\\" + _extensionName + fileExt;
                    }
                }
            }
            return fileName;
        }

        /// <summary>
        /// Read extension source file from disk
        /// </summary>
        /// <param name="fileName">File Name</param>
        /// <returns>Source file text</returns>
        string ReadFile(string fileName)
        {
            string val = "Source for [" + fileName + "] not found";
            try
            {
                val = File.ReadAllText(fileName);
            }
            catch (Exception)
            {
               // btnSave.Enabled = false;
            }
            return val;
        }

        /// <summary>
        /// Writes file to the disk
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="val">File source (text)</param>
        /// <returns>True if successful</returns>
        static bool WriteFile(string fileName, string val)
        {
            try
            {
                Core.FSO.FObject.WriteFileUtf8(fileName, val);
                //StreamWriter sw = File.CreateText(fileName);
               
                //sw.Write(val);
                //sw.Close();
            }
            catch (Exception e)
            {
                _errorMsg = e.Message;
                return false;
            }
            return true;
        }
    }
}