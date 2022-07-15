using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Brickfilm_Studio
{
    class StatuesBar
    {
        public static MainWindow main = System.Windows.Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
     public static TreeViewEventArgs t;
      
        public static void Project_Selected(object sender, RoutedEventArgs e)
        {



             
                }
    }
}
