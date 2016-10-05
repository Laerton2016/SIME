using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SIME.Produtos
{
    public partial class UploadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ler_Click(object sender, EventArgs e)
        {
           // String caminho = @"c:\XML\";
            String arq = "";
            DirectoryInfo diretorio = new DirectoryInfo(@"c:\xml");
            diretorio.FullName.Replace(" ", "_");
                if (!diretorio.Exists)
                {
                    diretorio.Create();
                }

            if (upXML.FileName != "") 
            {
                arq = upXML.FileName;
                upXML.PostedFile.SaveAs(diretorio.FullName + @"/" + arq );
            }
        }
    }
}