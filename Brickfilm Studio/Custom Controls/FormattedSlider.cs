using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Brickfilm_Studio
{
    public class FormattedSlider : Slider
    {
       // internal static MainWindow main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;

        private ToolTip _autoToolTip;
        private string _autoToolTipFormat;

        public string AutoToolTipFormat
        {
            get { return _autoToolTipFormat; }
            set { _autoToolTipFormat = value; }
        }

        protected override void OnThumbDragStarted(DragStartedEventArgs e)
        {
            base.OnThumbDragStarted(e);
            this.FormatAutoToolTipContent();


        }
        protected override void OnThumbDragDelta(DragDeltaEventArgs e)
        {
            base.OnThumbDragDelta(e);
            this.FormatAutoToolTipContent();
        }
        

        private void FormatAutoToolTipContent()
        {

            if(!string.IsNullOrEmpty(this.AutoToolTipFormat))
            {
                this.AutoToolTip.Content = string.Format(

                    this.AutoToolTipFormat,
                    this.AutoToolTip.Content
                    );

            }
        }

        private ToolTip AutoToolTip
        {
            get
            {
                if(_autoToolTip == null)
                {
                    FieldInfo field = typeof(Slider).GetField(
                        "_autoToolTip",
                        BindingFlags.NonPublic | BindingFlags.Instance

                        );
                    _autoToolTip = field.GetValue(this) as ToolTip;
                }
                return _autoToolTip;
            }
        }
    }
}
