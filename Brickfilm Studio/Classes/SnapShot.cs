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

namespace Brickfilm_Studio 
{
   public  class SnapShot
    {

        
      

        private Point startPoint;
        int i = 2;


        public DoubleAnimation fadein = new DoubleAnimation() { };
        public static System.Windows.Media.Animation.Storyboard sb;
        public static System.Windows.Media.Animation.Storyboard myStoryboard2;
        private void imagerotator()

        {

            myStoryboard2 = new System.Windows.Media.Animation.Storyboard();

            myStoryboard2.SpeedRatio = 1;




            if (CreateShot.fpsTextbox.Text == "1") { fadein.Duration = TimeSpan.FromSeconds(.5); }
            if (CreateShot.fpsTextbox.Text == "2") { fadein.Duration = TimeSpan.FromSeconds(.3); }
            if (CreateShot.fpsTextbox.Text == "3") { fadein.Duration = TimeSpan.FromSeconds(.18); }
            if (CreateShot.fpsTextbox.Text == "4") { fadein.Duration = TimeSpan.FromSeconds(.108); }
            if (CreateShot.fpsTextbox.Text == "5") { fadein.Duration = TimeSpan.FromSeconds(.0648); }
            if (CreateShot.fpsTextbox.Text == "6") { fadein.Duration = TimeSpan.FromSeconds(.0388); }
            if (CreateShot.fpsTextbox.Text == "7") { fadein.Duration = TimeSpan.FromSeconds(.0234); }
            if (CreateShot.fpsTextbox.Text == "8") { fadein.Duration = TimeSpan.FromSeconds(.0140); }
            if (CreateShot.fpsTextbox.Text == "9") { fadein.Duration = TimeSpan.FromSeconds(.0084); }
            if (CreateShot.fpsTextbox.Text == "10") { fadein.Duration = TimeSpan.FromSeconds(.0014); }
            if (CreateShot.fpsTextbox.Text == "11") { fadein.Duration = TimeSpan.FromSeconds(.0009); }
            if (CreateShot.fpsTextbox.Text == "12") { fadein.Duration = TimeSpan.FromSeconds(.000); }
            if (CreateShot.fpsTextbox.Text == "13") { fadein.Duration = TimeSpan.FromSeconds(.00769); }
            if (CreateShot.fpsTextbox.Text == "14") { fadein.Duration = TimeSpan.FromSeconds(.00714); }
            if (CreateShot.fpsTextbox.Text == "15") { fadein.Duration = TimeSpan.FromSeconds(.00666); }
            if (CreateShot.fpsTextbox.Text == "16") { fadein.Duration = TimeSpan.FromSeconds(.00625); }
            if (CreateShot.fpsTextbox.Text == "17") { fadein.Duration = TimeSpan.FromSeconds(.00588); }
            if (CreateShot.fpsTextbox.Text == "18") { fadein.Duration = TimeSpan.FromSeconds(.00555); }
            if (CreateShot.fpsTextbox.Text == "19") { fadein.Duration = TimeSpan.FromSeconds(.00526); }
            if (CreateShot.fpsTextbox.Text == "20") { fadein.Duration = TimeSpan.FromSeconds(.005); }
            if (CreateShot.fpsTextbox.Text == "21") { fadein.Duration = TimeSpan.FromSeconds(.00476); }
            if (CreateShot.fpsTextbox.Text == "22") { fadein.Duration = TimeSpan.FromSeconds(.00454); }
            if (CreateShot.fpsTextbox.Text == "23") { fadein.Duration = TimeSpan.FromSeconds(.00434); }
            if (CreateShot.fpsTextbox.Text == "24") { fadein.Duration = TimeSpan.FromSeconds(.00416); }
            if (CreateShot.fpsTextbox.Text == "25") { fadein.Duration = TimeSpan.FromSeconds(.004); }
            if (CreateShot.fpsTextbox.Text == "26") { fadein.Duration = TimeSpan.FromSeconds(.00384); }
            if (CreateShot.fpsTextbox.Text == "27") { fadein.Duration = TimeSpan.FromSeconds(.00370); }
            if (CreateShot.fpsTextbox.Text == "28") { fadein.Duration = TimeSpan.FromSeconds(.00357); }
            if (CreateShot.fpsTextbox.Text == "29") { fadein.Duration = TimeSpan.FromSeconds(.00344); }
            if (CreateShot.fpsTextbox.Text == "30") { fadein.Duration = TimeSpan.FromSeconds(.00333); }

            //fadein.Duration = TimeSpan.FromSeconds(.00416);



            System.Windows.Media.Animation.Storyboard.SetTarget(fadein, CreateShot.imgVideo);

            System.Windows.Media.Animation.Storyboard.SetTargetProperty(fadein, new PropertyPath(Image.OpacityProperty));

            sb = new System.Windows.Media.Animation.Storyboard();

            sb.Children.Add(fadein);

            sb.Completed += new EventHandler(sb_Completed0);
            fadein.From = 1;

            fadein.To = 1;
            sb.Begin();

        }




        public void sb_Completed0(object sender, EventArgs e)

        {

            myStoryboard2 = new System.Windows.Media.Animation.Storyboard();

            myStoryboard2.SpeedRatio = 1;







            System.Windows.Media.Animation.Storyboard.SetTarget(fadein, CreateShot.imgVideo);

            System.Windows.Media.Animation.Storyboard.SetTargetProperty(fadein, new PropertyPath(Image.OpacityProperty));

            sb = new System.Windows.Media.Animation.Storyboard();

            sb.Children.Add(fadein);

            sb.Completed += new EventHandler(sb_Completed);

            sb.Begin();


        }




        private void sb_Completed(object sender, EventArgs e)

        {

            string strUri2 = String.Format(@"C:\Users\Jonathan\Documents\Visual Studio 2015\Projects\Brickfilm Studio\Brickfilm Studio\Resources\Frame1.jpg", i.ToString());//change TheSolution with your own project name

            i++;

            if (i > 24)//number of pictures =2

            {

                i = 1;

            }
            string packUri = @"C:\Users\Jonathan\Documents\Visual Studio 2015\Projects\Brickfilm Studio\Brickfilm Studio\Resources\Frame1.jpg";
            CreateShot.imgVideo.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;

          //  CreateShot.imgVideo.Source = new BitmapImage(new Uri(strUri2));

            myStoryboard2 = new System.Windows.Media.Animation.Storyboard();

            myStoryboard2.SpeedRatio = 1;







            System.Windows.Media.Animation.Storyboard.SetTarget(fadein, CreateShot.imgVideo);
            System.Windows.Media.Animation.Storyboard.SetTargetProperty(fadein, new PropertyPath(Image.OpacityProperty));

            sb = new System.Windows.Media.Animation.Storyboard();

            sb.Children.Add(fadein);


            sb.Begin();


            imagerotator();

        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D1 || e.Key > Key.D9)
            {
                e.Handled = true;
            }

        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {


        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {


        }



        internal void PlayPause_Click(object sender, RoutedEventArgs e)
        {
            if (CreateShot.PlayPauseButton.IsChecked == true)
            {
                CreateShot.PlayImage.Visibility = Visibility.Hidden;
                CreateShot.PauseImage.Visibility = Visibility.Visible;
                 
             /*  Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>

                {

                    

                }));*/

                imagerotator();

                sb.Resume();
            }

            if (CreateShot.PlayPauseButton.IsChecked == false)
            {
                CreateShot.PauseImage.Visibility = Visibility.Hidden;
                CreateShot.PlayImage.Visibility = Visibility.Visible;
                //  sb.Begin(this, false);
                sb.Pause();
                //  myStoryboard2.Pause();

                if (CreateShot.fpsTextbox.Text == "1") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "2") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "3") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "4") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "5") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "6") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "7") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "8") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "9") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "10") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "11") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "12") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "13") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "14") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "15") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "16") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "17") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "18") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "19") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "20") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "21") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "22") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "23") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "24") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "25") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "26") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "27") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "28") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "29") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "30") { fadein.Duration = TimeSpan.FromSeconds(0); }
                else
                {
                    fadein.Duration = TimeSpan.FromSeconds(0);
                }


            }

            if (CreateShot.PlayImage.Visibility.Equals(Visibility.Visible))
            {
                CreateShot.PauseImage.Visibility = Visibility.Hidden;
                CreateShot.PlayImage.Visibility = Visibility.Visible;
                //  sb.Begin(this, false);
                sb.Pause();
                //  myStoryboard2.Pause();

                if (CreateShot.fpsTextbox.Text == "1") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "2") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "3") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "4") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "5") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "6") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "7") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "8") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "9") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "10") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "11") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "12") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "13") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "14") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "15") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "16") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "17") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "18") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "19") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "20") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "21") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "22") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "23") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "24") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "25") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "26") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "27") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "28") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "29") { fadein.Duration = TimeSpan.FromSeconds(0); }
                if (CreateShot.fpsTextbox.Text == "30") { fadein.Duration = TimeSpan.FromSeconds(0); }
                else
                {
                    fadein.Duration = TimeSpan.FromSeconds(0);
                }
            }
            if (CreateShot.PauseImage.Visibility.Equals(Visibility.Visible))
            {

                CreateShot.PlayImage.Visibility = Visibility.Hidden;
                CreateShot.PauseImage.Visibility = Visibility.Visible;
                /*   this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>

                    {



                    }));*/

                imagerotator();

                sb.Resume();
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            sb.Stop();



            if (CreateShot.fpsTextbox.Text == "1") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "2") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "3") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "4") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "5") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "6") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "7") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "8") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "9") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "10") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "11") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "12") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "13") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "14") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "15") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "16") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "17") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "18") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "19") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "20") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "21") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "22") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "23") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "24") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "25") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "26") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "27") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "28") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "29") { fadein.Duration = TimeSpan.FromSeconds(0); }
            if (CreateShot.fpsTextbox.Text == "30") { fadein.Duration = TimeSpan.FromSeconds(0); }
            else
            {
                fadein.Duration = TimeSpan.FromSeconds(0);
            }
            CreateShot.PauseImage.Visibility = Visibility.Hidden;
            CreateShot.PlayImage.Visibility = Visibility.Visible;
        }

    }
}
