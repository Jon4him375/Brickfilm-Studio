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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
 using System.Windows.Threading;
using AForge.Video;
 

namespace Brickfilm_Studio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Class1
    {
        private Point startPoint;
        MainWindow main = new MainWindow();

        // Helper to search up the VisualTree

        public void Speed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            //   double value = Speed.Value;

            //  main.Title = "Value: " + value.ToString("0.0") + "/" + Speed.Maximum;
            //  fadein.Duration = TimeSpan.FromSeconds(.0666);


        }


        private void Window_Loaded(object sender, RoutedEventArgs e)

        {

            //add 2 jpg files to Resources directory of your project





        }




        int i = 2;


        public DoubleAnimation fadein = new DoubleAnimation() { };
        public static Storyboard sb;
        public static Storyboard myStoryboard2;
        internal void imagerotator()

        {

            myStoryboard2 = new Storyboard();

            myStoryboard2.SpeedRatio = 1;
           


            if (main.textBox.Text == "1") { fadein.Duration = TimeSpan.FromSeconds(.1); }
            if (main.textBox.Text == "2") { fadein.Duration = TimeSpan.FromSeconds(.050); }
            if (main.textBox.Text == "3") { fadein.Duration = TimeSpan.FromSeconds(.033); }
            if (main.textBox.Text == "4") { fadein.Duration = TimeSpan.FromSeconds(.025); }
            if (main.textBox.Text == "5") { fadein.Duration = TimeSpan.FromSeconds(.020); }
            if (main.textBox.Text == "6") { fadein.Duration = TimeSpan.FromSeconds(.016); }
            if (main.textBox.Text == "7") { fadein.Duration = TimeSpan.FromSeconds(.014); }
            if (main.textBox.Text == "8") { fadein.Duration = TimeSpan.FromSeconds(.0125); }
            if (main.textBox.Text == "9") { fadein.Duration = TimeSpan.FromSeconds(.0111); }
            if (main.textBox.Text == "10") { fadein.Duration = TimeSpan.FromSeconds(.010); }
            if (main.textBox.Text == "11") { fadein.Duration = TimeSpan.FromSeconds(.009); }
            if (main.textBox.Text == "12") { fadein.Duration = TimeSpan.FromSeconds(.0083); }
            if (main.textBox.Text == "13") { fadein.Duration = TimeSpan.FromSeconds(.00769); }
            if (main.textBox.Text == "14") { fadein.Duration = TimeSpan.FromSeconds(.00714); }
            if (main.textBox.Text == "15") { fadein.Duration = TimeSpan.FromSeconds(.00666); }
            if (main.textBox.Text == "16") { fadein.Duration = TimeSpan.FromSeconds(.00625); }
            if (main.textBox.Text == "17") { fadein.Duration = TimeSpan.FromSeconds(.00588); }
            if (main.textBox.Text == "18") { fadein.Duration = TimeSpan.FromSeconds(.00555); }
            if (main.textBox.Text == "19") { fadein.Duration = TimeSpan.FromSeconds(.00526); }
            if (main.textBox.Text == "20") { fadein.Duration = TimeSpan.FromSeconds(.005); }
            if (main.textBox.Text == "21") { fadein.Duration = TimeSpan.FromSeconds(.00476); }
            if (main.textBox.Text == "22") { fadein.Duration = TimeSpan.FromSeconds(.00454); }
            if (main.textBox.Text == "23") { fadein.Duration = TimeSpan.FromSeconds(.00434); }
            if (main.textBox.Text == "24") { fadein.Duration = TimeSpan.FromSeconds(.00416); }
            if (main.textBox.Text == "25") { fadein.Duration = TimeSpan.FromSeconds(.004); }
            if (main.textBox.Text == "26") { fadein.Duration = TimeSpan.FromSeconds(.00384); }
            if (main.textBox.Text == "27") { fadein.Duration = TimeSpan.FromSeconds(.00370); }
            if (main.textBox.Text == "28") { fadein.Duration = TimeSpan.FromSeconds(.00357); }
            if (main.textBox.Text == "29") { fadein.Duration = TimeSpan.FromSeconds(.00344); }
            if (main.textBox.Text == "30") { fadein.Duration = TimeSpan.FromSeconds(.00333); }

            //fadein.Duration = TimeSpan.FromSeconds(.00416);



            Storyboard.SetTarget(fadein, main.image1);
             
            Storyboard.SetTargetProperty(fadein, new PropertyPath(Image.OpacityProperty));

            sb = new Storyboard();

            sb.Children.Add(fadein);

            sb.Completed += new EventHandler(sb_Completed0);
            fadein.From = 1;

            fadein.To = 1;
            sb.Begin(main, true);
           
        }




        public void sb_Completed0(object sender, EventArgs e)

        {

            myStoryboard2 = new Storyboard();

            myStoryboard2.SpeedRatio = 1;







            Storyboard.SetTarget(fadein, main.image1);

            Storyboard.SetTargetProperty(fadein, new PropertyPath(Image.OpacityProperty));

            sb = new Storyboard();

            sb.Children.Add(fadein);

            sb.Completed += new EventHandler(sb_Completed);

            sb.Begin(main, true);


        }




        public void sb_Completed(object sender, EventArgs e)

        {

            string strUri2 = String.Format(@"C:\Users\Jonathan\Documents\Visual Studio 2015\Projects\WpfApplication1\WpfApplication1\Resources\Frame{0}.jpg", i.ToString());//change TheSolution with your own project name

            i++;

            if (i > 24)//number of pictures =2

            {

                i = 1;

            }

            main.image1.Source = new BitmapImage(new Uri(strUri2));

            myStoryboard2 = new Storyboard();

            myStoryboard2.SpeedRatio = 1;







            Storyboard.SetTarget(fadein, main.image1);
            Storyboard.SetTargetProperty(fadein, new PropertyPath(Image.OpacityProperty));

            sb = new Storyboard();

            sb.Children.Add(fadein);


            sb.Begin(main, true);


            imagerotator();

        }

        public void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D1 || e.Key > Key.D9)
            {
                e.Handled = true;
            }

        }

        public void PlayButton_Click(object sender, RoutedEventArgs e)
        {


        }

        public void PauseButton_Click(object sender, RoutedEventArgs e)
        {


        }



        internal void PlayPause_Click(object sender, RoutedEventArgs e)
        {

            if (main.PlayPause.IsChecked == true)
            {

                main.PlayImage.Visibility = Visibility.Hidden;
                main.PauseImage.Visibility = Visibility.Visible;
                main.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>

                {

                    imagerotator();

                    sb.Resume();

                }));
            }

            if (main.PlayPause.IsChecked == false)
            {
                main.PauseImage.Visibility = Visibility.Hidden;
                main.PlayImage.Visibility = Visibility.Visible;
                //  sb.Begin(main, false);
                sb.Pause();
                //  myStoryboard2.Pause();

                if (main.textBox.Text == "1") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "2") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "3") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "4") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "5") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "6") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "7") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "8") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "9") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "10") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "11") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "12") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "13") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "14") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "15") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "16") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "17") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "18") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "19") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "20") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "21") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "22") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "23") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "24") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "25") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "26") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "27") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "28") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "29") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "30") { fadein.Duration = TimeSpan.FromSeconds(0); }
                else
                {
                    fadein.Duration = TimeSpan.FromSeconds(0);
                }


            }

            if (main.PlayImage.Visibility.Equals(Visibility.Visible))
            {
                main.PauseImage.Visibility = Visibility.Hidden;
                main.PlayImage.Visibility = Visibility.Visible;
                //  sb.Begin(main, false);
                sb.Pause();
                //  myStoryboard2.Pause();

                if (main.textBox.Text == "1") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "2") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "3") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "4") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "5") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "6") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "7") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "8") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "9") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "10") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "11") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "12") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "13") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "14") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "15") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "16") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "17") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "18") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "19") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "20") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "21") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "22") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "23") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "24") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "25") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "26") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "27") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "28") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "29") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (main.textBox.Text == "30") { fadein.Duration = TimeSpan.FromSeconds(0); }
                else
                {
                    fadein.Duration = TimeSpan.FromSeconds(0);
                }
            }
            if (main.PauseImage.Visibility.Equals(Visibility.Visible))
            {

                main.PlayImage.Visibility = Visibility.Hidden;
                main.PauseImage.Visibility = Visibility.Visible;
                main.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>

                {

                    imagerotator();

                    sb.Resume();

                }));
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            sb.Stop();



            if (main.textBox.Text == "1") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "2") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "3") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "4") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "5") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "6") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "7") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "8") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "9") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "10") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "11") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "12") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "13") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "14") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "15") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "16") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "17") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "18") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "19") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "20") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "21") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "22") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "23") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "24") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "25") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "26") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "27") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "28") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "29") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (main.textBox.Text == "30") { fadein.Duration = TimeSpan.FromSeconds(0); }
            else
            {
                fadein.Duration = TimeSpan.FromSeconds(0);
            }
            main.PauseImage.Visibility = Visibility.Hidden;
            main.PlayImage.Visibility = Visibility.Visible;
        }

        /* */
    }


    // sb.Pause();



}




