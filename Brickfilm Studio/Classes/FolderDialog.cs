using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Brickfilm_Studio
{
    class FolderDialog
    {
       
         public static  void folderDialog ()   
        {
            var create = System.Windows.Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is CreateProject) as CreateProject;


            FolderBrowserDialog dialog = new FolderBrowserDialog() { };
            dialog.RootFolder = Environment.SpecialFolder.MyDocuments;
            dialog.SelectedPath = @"C:\Users\" + Environment.UserName + @"\Documents\BrickFilm Studio\Projects";
            var result= dialog.ShowDialog(); 
            
            if(result == DialogResult.OK)
            {
                
                create.ProjectLoc.Text = dialog.SelectedPath;
             //   MessageBox.Show(dialog.SelectedPath);
            }
            else
            {
               
            }
          
            
        }

    }
}
