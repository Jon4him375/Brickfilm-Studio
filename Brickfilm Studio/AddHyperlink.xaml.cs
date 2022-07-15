using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Diagnostics;
using System.Windows.Navigation;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Brickfilm_Studio
{
    /// <summary>
    /// Interaction logic for AddHyperlink.xaml
    /// </summary>
    public partial class AddHyperlink : Window
    {
        public AddHyperlink()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            var main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            Hyperlink link = new Hyperlink() { NavigateUri = new Uri("https://www.google.com/?gws_rd=ssl") };
            link.Inlines.Add("hi");
            CreateScript.Paragraph1.Inlines.Add(link);
            Close(); 
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
