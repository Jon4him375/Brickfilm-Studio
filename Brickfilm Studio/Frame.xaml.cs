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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Brickfilm_Studio
{
    /// <summary>
    /// Interaction logic for Frame.xaml
    /// </summary>
    public partial class Frame : UserControl
    {
        public Frame()
        {
            InitializeComponent();
        }

        private void FrameImage_Loaded(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            FrameImage.Source = CreateShot.imgCapture.Source;
        }
    }
}
