using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ResizeGrip
{
    /// <summary>
    /// Interaction logic for DialogReplica.xaml
    /// </summary>
    public partial class DialogReplica : UserControl
    {
        private Cursor _cursor;

        public DialogReplica()
        {
            InitializeComponent();
        }

        private void OnResizeThumbDragStarted(object sender, DragStartedEventArgs e)
        {
            _cursor = Cursor;
            Cursor = Cursors.SizeNWSE;
        }

        private void OnResizeThumbDragCompleted(object sender, DragCompletedEventArgs e)
        {
            Cursor = _cursor;
        }

        private void OnResizeThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            double yAdjust = sizableContent.Height + e.VerticalChange;
            double xAdjust = sizableContent.Width + e.HorizontalChange;

            //make sure not to resize to negative width or heigth            
            xAdjust = (sizableContent.ActualWidth + xAdjust) > sizableContent.MinWidth ? xAdjust : sizableContent.MinWidth;
            yAdjust = (sizableContent.ActualHeight + yAdjust) > sizableContent.MinHeight ? yAdjust : sizableContent.MinHeight;

            sizableContent.Width = xAdjust;
            sizableContent.Height = yAdjust;
        }
    }

}
