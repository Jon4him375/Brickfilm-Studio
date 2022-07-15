using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System;
using System.Linq;

namespace Brickfilm_Studio
{
    public class MoveThumb : Thumb
    {
        public MoveThumb()
        {
            DragDelta += new DragDeltaEventHandler(this.MoveThumb_DragDelta);
        }

        private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;

            ContentControl designerItem = DataContext as ContentControl;

            if (designerItem != null)
            {
                Point dragDelta = new Point(e.HorizontalChange, e.VerticalChange);

                RotateTransform rotateTransform = designerItem.RenderTransform as RotateTransform;
                if (rotateTransform != null)
                {
                    dragDelta = rotateTransform.Transform(dragDelta);
                }

                Canvas.SetLeft(designerItem, Canvas.GetLeft(designerItem) + dragDelta.X);
                Canvas.SetTop(designerItem, Canvas.GetTop(designerItem) + dragDelta.Y);
            }
        }
    }
}
