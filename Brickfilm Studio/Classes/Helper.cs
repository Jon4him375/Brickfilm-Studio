using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows;

namespace Brickfilm_Studio
{
    //Design by Pongsakorn Poosankam
    class Helper
    {
        //Block Memory Leak
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr handle);
        public static BitmapSource bs;
        public static IntPtr ip;
        public static BitmapSource LoadBitmap(System.Drawing.Bitmap source)
        {

            ip = source.GetHbitmap();

            bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip, IntPtr.Zero, System.Windows.Int32Rect.Empty,

                System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

            DeleteObject(ip);

            return bs;

        }
        public static MainWindow main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
        public static CreateShot shot = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is CreateShot) as CreateShot;

        public static string text = CreateProject.Project.Header.ToString();

        public static void SaveImageCapture(BitmapSource bitmap)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));
            encoder.QualityLevel = 100;


            // Configure save file dialog box
            /*   Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
               dlg.FileName = "Image"; // Default file name
               dlg.DefaultExt = ".Jpg"; // Default file extension
               dlg.Filter = "All supported Images| *.jpg;*.jpeg;*.png|" +
                   "JPEG (*.jpg;*.jpeg) | *.jpg;*.jpeg|" +
                   "Portable Network Graphics (*.png) |*.png" +
                    "GIF (*.gif) | *.gif|" ; // Filter files by extension*/

            // Show save file dialog box
            //  Nullable<bool> result = dlg.ShowDialog();
            string name = "Frame" + NumericCounter.FrameNumber.Value + ".jpg";
            string textShot = CreateShot.ShotName.Header.ToString();

            string path = @"C:\Users\" + Environment.UserName + @"\Documents\BrickFilm Studio\Projects" + @"\" + text + @"\" + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header + @"\" + @"Shots" + @"\" + textShot + @"\" + name;
            // Process save file dialog box results
            FileStream fs = null;
            if (!File.Exists(path))
            {

                fs = new FileStream(path, FileMode.Create);
                encoder.Save(fs);



            }


        }
    }
}
