using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using GongSolutions.Wpf.DragDrop;


namespace Brickfilm_Studio
{
    /// <summary>
    /// Interaction logic for CreateShot.xaml
    /// </summary>
    public partial class CreateShot : Window
    {
        
        public CreateShot()
        {
             
            InitializeComponent();
             StoryboardTextbox.Text = "Shot" + NumericCounter.ShotNumber.Value.ToString();
            StoryboardTextbox.SelectAll();
            StoryboardTextbox.Focus();
           // fpsTextbox.Text = fpsSlider.Value.ToString();

        }

        public static CreateScene scene = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is CreateScene) as CreateScene;
        public static MainWindow main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
        Brickfilm_Studio.SnapShot snap = new SnapShot();


        public static string textStoryboard = CreateProject.Project.Header.ToString();

        /*
        public static void getParent(object sender)
            {
            main.ProjectTreeView = (TreeView)sender;
            AddScene.Scripts = (TreeViewItem)main.ProjectTreeView.SelectedItem;
            if(AddScene.Scripts.Parent.GetType() == typeof(TreeViewItem))
            {
                AddScene.Scene = (TreeViewItem)AddScene.Scripts.Parent;
                string text = AddScene.Scene.Header.ToString();

            }
            }*/


        private Point _startPoint;
        private DragAdorner _adorner;
        private AdornerLayer _layer;
        private bool _dragIsOutOfScope = false;




        public static TreeViewItem ShotName;
        public static TabControl CaptureTabControl;
        public static TabItem CaptureTabItem;
        public static StackPanel stackpanel1;
        public static Border border1;
        public static StackPanel stackpanel2;
        public static Border border2;
        public static DockPanel dockpanel1;
        public static BrushConverter bc;
        public static Image imgVideo;
        public static Image imgCapture;
        public static TextBox textBox;
        public static DockPanel dockpanel2;
        public static DockPanel dockpanel3;
        public static Border border3;
        public static ScrollViewer FrameScroll;
        public static WrapPanel FrameView;
        public static DataTemplate data;
        public static ListBox FrameList;
        public static FormattedSlider fpsSlider;
        public static DigitBox fpsTextbox;
        public static ToggleButton PlayPauseButton;
        public static StackPanel PlayPausePanel;
        public static Image PlayImage;
        public static Image PauseImage;
        public static Button StopButton;
        public static StackPanel StopPanel;
        public static Image StopImage;
        public static CheckBox PlayButtonCheckbox;

        public void OKButton_Click(object sender, RoutedEventArgs e)
        {
            NumericCounter.ShotNumber.UpButton();
            
            
            ShotName = new TreeViewItem() { Header = StoryboardTextbox.Text };

            // string sceneFolder = scene.SceneTextbox.Text;
            string name = StoryboardTextbox.Text;
            string path = @"C:\Users\" + Environment.UserName + @"\Documents\BrickFilm Studio\Projects" + @"\" + textStoryboard + @"\" + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header + @"\" + @"Shots" + @"\" + name + @"\";


            if (!Directory.Exists(path))
            {

                 
                Directory.CreateDirectory(path);

                CaptureTabControl = new TabControl() {Background = null, BorderBrush = null };
                CaptureTabItem = new TabItem() {Header=StoryboardTextbox.Text};
                stackpanel1 = new StackPanel() { };
                border1 = new Border() { BorderBrush = Brushes.Black, Background = Brushes.White, BorderThickness = new Thickness(1), Height = 396, Margin = new Thickness(1, 0, 305, 0) };
                stackpanel2 = new StackPanel();
                border2 = new Border() { BorderBrush = Brushes.Black, Background = Brushes.White, BorderThickness = new Thickness(1),   Margin = new Thickness(9, 9, 9, 90) };
                dockpanel1 = new DockPanel() { Height = 313};
                imgCapture = new Image() {Visibility = Visibility.Hidden, Height = 312, Margin = new Thickness (1, 0, 0, -10), Stretch = Stretch.Fill };
                imgCapture.Loaded  += main.imgCapture_Loaded;

                ContextMenu context = new ContextMenu() ;
                MenuItem contextitem = new MenuItem() {Header = "TEST for stop motion video" };
                context.Items.Add(contextitem);

                imgVideo = new Image() { Visibility = Visibility.Visible, Height = 312,  Margin = new Thickness(1, 0, 0, 0), Stretch = Stretch.Fill, ContextMenu = context };
              //  imgVideo.Source = new BitmapImage(new Uri(@"C:\Users\Jonathan\Documents\Visual Studio 2015\Projects\Brickfilm Studio\Brickfilm Studio\Resources\Frame1.jpg"));
                imgVideo.Loaded += ImgVideo_Loaded;
               

                dockpanel2 = new DockPanel() { Height = 96, RenderTransformOrigin = new Point(0.5, 0.5), Margin = new Thickness (0, -87, 0, 0) };
                //Timeline
                dockpanel3 = new DockPanel() {  };
                border3 = new Border() { BorderBrush = Brushes.Black, Background = Brushes.White, Height = 169, BorderThickness = new Thickness(1), Margin = new Thickness(0, 3, 0, 0), VerticalAlignment = VerticalAlignment.Center };
                FrameScroll = new ScrollViewer() {HorizontalScrollBarVisibility = ScrollBarVisibility.Visible, VerticalScrollBarVisibility = ScrollBarVisibility.Disabled, Margin = new Thickness(0, 2, 6, 6), VerticalAlignment = VerticalAlignment.Bottom };

                FrameView = new WrapPanel() {Margin = new Thickness(0, 0, -5, 0) };
              
                FrameList = new ListBox() { SelectionMode = SelectionMode.Extended, HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, ItemTemplate = data  };
                Binding frameBind = new Binding();
                frameBind.Path = new PropertyPath("MSPCollection");
                FrameList.SetBinding(ListBox.ItemsSourceProperty, frameBind);
                 
                    GongSolutions.Wpf.DragDrop.DragDrop.SetIsDragSource(FrameList, true);
                GongSolutions.Wpf.DragDrop.DragDrop.SetIsDropTarget(FrameList, true);


 




                Button SnapButton = new Button() { Content = "Snap", Margin = new Thickness(58, 15, 481, 0), VerticalAlignment = VerticalAlignment.Top  };
                SnapButton.Click += main.Snap_Click;
                ToggleButton ToggleButton = new ToggleButton() {
                    Style = Resources["GlassToggleButton"] as Style, Margin = new Thickness(-436, 15, 444, 0), VerticalAlignment = VerticalAlignment.Top, Height=51, Width = 53};

                ToggleButton.Click += ToggleButton_Click;
           
                         

                Button Settings = new Button() { Content = "Settings", Margin = new Thickness(-58, -41, 0, 0), VerticalAlignment = VerticalAlignment.Top };
                Settings.Click += main.Settings_Click;
                main.CaptureArea.Children.Add(stackpanel1);

                  fpsSlider = new FormattedSlider() { TickPlacement = TickPlacement.BottomRight, IsSnapToTickEnabled = true, Width=179,Margin = new Thickness(-350, 15, 444, 0), Maximum = 30, Minimum=1, SmallChange= 1, Value = 15 };
                fpsSlider.ValueChanged += FpsSlider_ValueChanged;

               
                var Binding = new Binding("Value");
                Binding.Source = fpsSlider;

                var Binding2 = new Binding("Text");
                Binding.Source = fpsTextbox;
                fpsSlider.SetBinding(Slider.ValueProperty, Binding2);

                fpsTextbox = new DigitBox()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,   Height = 22, Margin = new Thickness(-350, 15, 100, 0), TextWrapping =  TextWrapping.Wrap,   VerticalAlignment = VerticalAlignment.Top, Width = 54,   
                };

                fpsTextbox.TextChanged += FpsTextbox_TextChanged;
                fpsTextbox.SetBinding(TextBox.TextProperty, Binding);
                

                PlayPauseButton = new ToggleButton() {Height=51, Content = "Play", Margin = new Thickness(-350, 15, 300, 0), Visibility = Visibility.Hidden
            };
                PlayPauseButton.Background = Brushes.White;
                PlayPauseButton.MouseEnter += PlayPauseButton_MouseEnter;
               
                
                PlayPauseButton.Checked += PlayPauseButton_Checked;
                PlayPauseButton.Unchecked += PlayPauseButton_Unchecked;
                PlayPausePanel = new StackPanel() { };
                PlayImage = new Image() {Margin = new Thickness(-350, 15, 300, 0) };
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                PlayImage.Source = new BitmapImage(new Uri(projectDirectory + @"\Brickfilm Studio\Resources\Play.png"));

                PlayImage.MouseUp += PlayImage_MouseUp;

                PauseImage = new Image() {Margin =  PlayImage.Margin, Visibility = Visibility.Hidden};

                 PauseImage.Source = new BitmapImage(new Uri(projectDirectory + @"\Brickfilm Studio\Resources\Pause.png"));

                StopButton = new Button() { };
                StopPanel = new StackPanel() { };
                StopImage = new Image() {Margin = new Thickness(0, 6, 1, 0), Height = 41 };
                 StopImage.Source = new BitmapImage(new Uri(projectDirectory + @"\Brickfilm Studio\Resources\Stop.png"));

                CaptureTabControl.Items.Add(CaptureTabItem);
                CaptureTabItem.Content = stackpanel1;
                stackpanel1.Children.Add(border1);
                border1.Child = stackpanel2;
                stackpanel2.Children.Add(border2);
                border2.Child = dockpanel1;
                dockpanel1.Children.Add(imgVideo);
                dockpanel1.Children.Add(imgCapture);
                stackpanel1.Children.Add(dockpanel2);
                dockpanel2.Children.Add(SnapButton);
                dockpanel2.Children.Add(ToggleButton);
                dockpanel2.Children.Add(Settings);
                dockpanel2.Children.Add(fpsSlider);
                

            

                dockpanel2.Children.Add(fpsTextbox);
                dockpanel2.Children.Add(PlayImage);
                dockpanel2.Children.Add(PauseImage);
                PlayPauseButton.Content = PlayPausePanel;
                PauseImage.MouseUp += PauseImage_MouseUp;

                dockpanel2.Children.Add(StopButton);
                StopButton.Content = StopPanel;
                StopPanel.Children.Add(StopImage);

                stackpanel1.Children.Add(dockpanel3);
                dockpanel3.Children.Add(border3);
                border3.Child = FrameScroll;
                FrameScroll.Content = FrameView;
                FrameView.Children.Add(FrameList);
               

                ShotName.Selected += ShotName_Selected;

                main.AnimateButton.IsEnabled = true;
                AddScene.Shots.Items.Add(ShotName);
                AddScene.Shots.IsExpanded = true;
              //  ShotName.Selected += SelectShotName();
                main.CaptureArea.Visibility = Visibility.Visible;
                main.ScriptArea.Visibility = Visibility.Hidden;
                main.VoiceOverArea.Visibility = Visibility.Hidden;
                main.StoryboardArea.Visibility = Visibility.Hidden;
                main.EditArea.Visibility = Visibility.Hidden;
                

                Close();

            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Shot Already Exists! Use a Different Name.", "Storyboard File", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                StoryboardTextbox.SelectAll();
                StoryboardTextbox.Focus();
            }


        }

      







        private void FpsTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }

        private void PauseImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PauseImage.Visibility = Visibility.Hidden;
            PlayImage.Visibility = Visibility.Visible;
            sb.Pause(this);


            fadein.Duration = TimeSpan.FromSeconds(0);
        }

        private void PlayImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PauseImage.Visibility = Visibility.Visible;
            PlayImage.Visibility = Visibility.Hidden;

            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>

            {

                imagerotator();
                

            }));
            sb.Resume();
        }

        private void PlayPauseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            PlayPauseButton.Background = Brushes.White;
        }

        private void PlayPauseButton_Unchecked(object sender, RoutedEventArgs e)
        {
            
        }

        private void PlayPauseButton_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
             
        }

        private void ImgVideo_Loaded(object sender, RoutedEventArgs e)
        {
            SnapShot snap = new SnapShot();
            
        }

        private void FpsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
             
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            imgCapture.Visibility = Visibility.Hidden;
            imgVideo.Visibility = Visibility.Visible;
        }

        public void ShotName_Selected(object sender, RoutedEventArgs e)
        {
             
             if(ShotName.IsSelected == true) {

                if(CaptureTabItem.Header.Equals(ShotName.Header))
                {
                    CaptureTabItem.IsSelected = true;
                }
            }
                

            
        }

        public void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        #region Video
        System.Windows.Media.Animation.Storyboard sb;
        // Helper to search up the VisualTree

        private void Window_Loaded(object sender, RoutedEventArgs e)

        {

            //add 2 jpg files to Resources directory of your project

            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>

            {

                imagerotator();

            }));




        }




        int i = 2;

        int speedRatio = 5;
        Storyboard Story = new Storyboard();
        DoubleAnimation fadein;


        private void imagerotator()

        {

            

            System.Windows.Media.Animation.Storyboard myStoryboard2 = new System.Windows.Media.Animation.Storyboard();

            myStoryboard2.SpeedRatio = speedRatio;

            fadein = new DoubleAnimation()

            {

                From = 1,

                To = 1,

              //   Duration = TimeSpan.FromSeconds(.041),

            };
            if (CreateShot.fpsSlider.Value == 1) { fadein.Duration = TimeSpan.FromSeconds(1); }
            if (CreateShot.fpsSlider.Value == 2) { fadein.Duration = TimeSpan.FromSeconds(.5); }
            if (CreateShot.fpsSlider.Value == 3) { fadein.Duration = TimeSpan.FromSeconds(.375); }
            if (CreateShot.fpsSlider.Value == 4) { fadein.Duration = TimeSpan.FromSeconds(.25); }
            if (CreateShot.fpsSlider.Value == 5) { fadein.Duration = TimeSpan.FromSeconds(.0648); }
            if (CreateShot.fpsSlider.Value == 6) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 7) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 8) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 9) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 10) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 11) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 12) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 13) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 14) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 15) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 16) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 17) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 18) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 19) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 20) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 21) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 22) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 23) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 24) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 25) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 26) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 27) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 28) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 29) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); }
            if (CreateShot.fpsSlider.Value == 30) { fadein.Duration = TimeSpan.FromSeconds(.5 / fpsSlider.Value); } 

            System.Windows.Media.Animation.Storyboard.SetTarget(fadein, imgVideo);

            System.Windows.Media.Animation.Storyboard.SetTargetProperty(fadein, new PropertyPath(Image.OpacityProperty));

            sb = new System.Windows.Media.Animation.Storyboard();

            sb.Children.Add(fadein);

            sb.Completed += new EventHandler(sb_Completed0);

            sb.Begin(this, true);

        }




        private void sb_Completed0(object sender, EventArgs e)

        {

            System.Windows.Media.Animation.Storyboard myStoryboard2 = new System.Windows.Media.Animation.Storyboard();

            myStoryboard2.SpeedRatio = speedRatio;

            fadein = new DoubleAnimation()

            {

                From = 1,

                To = 1,

                Duration = TimeSpan.FromSeconds(.001),

            };

            System.Windows.Media.Animation.Storyboard.SetTarget(fadein, imgVideo);

            System.Windows.Media.Animation.Storyboard.SetTargetProperty(fadein, new PropertyPath(Image.OpacityProperty));

            sb = new System.Windows.Media.Animation.Storyboard();

            sb.Children.Add(fadein);

            sb.Completed += new EventHandler(sb_Completed);

            sb.Begin(this, true);

        }




        private void sb_Completed(object sender, EventArgs e)

        {

            string strUri2 = String.Format(@"C:\Users\Jonathan\Documents\Visual Studio 2015\Projects\Brickfilm Studio\Brickfilm Studio\Resources\Frame{0}.jpg", i.ToString());//change TheSolution with your own project name

            i++;

            if (i > 24)//number of pictures =2

            {

                i = 1;

            }

            imgVideo.Source = new BitmapImage(new Uri(strUri2));

            System.Windows.Media.Animation.Storyboard myStoryboard2 = new System.Windows.Media.Animation.Storyboard();

            myStoryboard2.SpeedRatio = speedRatio;

            fadein = new DoubleAnimation()

            {

                From = 0,

                To = 1,

                Duration = TimeSpan.FromSeconds(.01),

            };

            System.Windows.Media.Animation.Storyboard.SetTarget(fadein, imgVideo);

            System.Windows.Media.Animation.Storyboard.SetTargetProperty(fadein, new PropertyPath(Image.OpacityProperty));

            sb = new System.Windows.Media.Animation.Storyboard();


            sb.Children.Add(fadein);

            //  sb.Begin( );

            imagerotator();



        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            sb.Resume(this);

        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {


            sb.Pause(this);


            fadein.Duration = TimeSpan.FromSeconds(0);
            //  fadein.BeginTime = null;

        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            sb.Stop();

            fadein.Duration = TimeSpan.FromSeconds(0);

        }
        #endregion

    }
}
