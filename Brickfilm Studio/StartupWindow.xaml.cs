using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Brickfilm_Studio
{
    /// <summary>
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();
        }
        public static MainWindow main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;

        private void label_Copy1_MouseEnter(object sender, MouseEventArgs e)
        {
            label_Copy1.Foreground = Brushes.Orange;
        }

        private void label_Copy1_MouseLeave(object sender, MouseEventArgs e)
        {
            label_Copy1.Foreground = Brushes.Black;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            main.Show();
          //  StartupWindow start = new StartupWindow();
         
          //  start.Owner = main;
        }
    }
}
