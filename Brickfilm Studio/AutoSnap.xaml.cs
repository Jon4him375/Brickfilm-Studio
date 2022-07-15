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
    /// Interaction logic for AutoSnap.xaml
    /// </summary>
    public partial class AutoSnap : Window
    {
        public AutoSnap()
        {
            InitializeComponent();
        }
        private void CaptureAutoSnapStartButton_Click(object sender, EventArgs e)
        {
            CaptureAutoSnapStartButton.Visibility = System.Windows.Visibility.Hidden;
            CaptureAutoSnapStopButton.Visibility = System.Windows.Visibility.Visible;
        }
        private void CaptureAutoSnapStopButton_Click(object sender, EventArgs e)
        {
            CaptureAutoSnapStartButton.Visibility = System.Windows.Visibility.Visible;
            CaptureAutoSnapStopButton.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
