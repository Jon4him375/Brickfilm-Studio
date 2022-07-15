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
    /// Interaction logic for Storyboard.xaml
    /// </summary>
    public partial class Storyboard : UserControl
    {
        public Storyboard()
        {
            InitializeComponent();
        }
        public event EventHandler<EventArgs> NewStoryboard;
        private void Storyboard1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Storyboard1.BorderBrush = Brushes.Red;

        }
    }
}
