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
using System.IO;

namespace Brickfilm_Studio
{
    /// <summary>
    /// Interaction logic for AddStoryboard.xaml
    /// </summary>
    public partial class AddStoryboard : Window
    {
        public AddStoryboard()
        {
            InitializeComponent();
             string name = StoryboardTextbox.Text;
            StoryboardTextbox.Text = "Storyboard" + NumericCounter.StoryboardNumber.Value.ToString();
            StoryboardTextbox.Focus();
            StoryboardTextbox.SelectAll();

        }

        private void ScriptTextbox_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
       // public static string pathStoryboard = @"C:\Users\" + Environment.UserName + @"\Documents\BrickFilm Studio\Projects" + @"\" + textStoryboard + @"\" + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header + @"\" + @"Storyboards" + @"\" + main.image;

        public static CreateScene scene = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is CreateScene) as CreateScene;
        public static MainWindow main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
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
            
        public static TreeViewItem ScriptName;
        public static Grid grid;
        public static Border border3;
        public static ScrollViewer storyboardScroll;
        public static DockPanel storyboardDockPanel;
        public static WrapPanel storyboardWrapPanel;


        public void OKButton_Click(object sender, RoutedEventArgs e)
        {
            NumericCounter.StoryboardNumber.UpButton();

            ScriptName = new TreeViewItem() { Header = StoryboardTextbox.Text };

            // string sceneFolder = scene.SceneTextbox.Text;
            string name = StoryboardTextbox.Text;
            string path = @"C:\Users\" + Environment.UserName + @"\Documents\BrickFilm Studio\Projects" + @"\" + textStoryboard + @"\" + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header + @"\" + @"Storyboards" + @"\" + name;


            if (!Directory.Exists(path))
            {

                
                Directory.CreateDirectory(path);
                

                    grid = new Grid();
                    border3 = new Border() { BorderBrush = Brushes.Black, Background = Brushes.White, BorderThickness = new Thickness(1), Height = 589, Margin = new Thickness(4, 81, 304, 127) };
                    storyboardScroll = new ScrollViewer() { Margin = new Thickness(0, 2, 0, 6), CanContentScroll = true, BorderBrush = Brushes.Black };
                    storyboardDockPanel = new DockPanel() { Margin = new Thickness(-14, -4, 6, -2) };

                    storyboardWrapPanel = new WrapPanel();
                    main.StoryboardButton.IsEnabled = true;
                    AddScene.Storyboards.Items.Add(ScriptName);
                    AddScene.Storyboards.IsExpanded = true;
                    main.StoryboardArea.Visibility = Visibility.Visible;
                    main.ScriptArea.Visibility = Visibility.Hidden;
                    main.StoryboardArea.Children.Add(grid);
                    grid.Children.Add(border3);
                    border3.Child = storyboardScroll;
                    storyboardScroll.Content = storyboardDockPanel;
                    storyboardDockPanel.Children.Add(storyboardWrapPanel);


                    Close();
                 
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Storyboard Already Exists! Use a Different Name.", "Storyboard File", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                StoryboardTextbox.Focus();
                StoryboardTextbox.SelectAll();

            }


        }

        public void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
