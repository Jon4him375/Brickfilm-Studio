using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for CreateScene.xaml
    /// </summary>
    public partial class CreateScene : Window
    {
        public CreateScene()
        {
            InitializeComponent();
             SceneTextbox.Text = "Scene" + NumericCounter.SceneNumber.Value.ToString();
            SceneTextbox.SelectAll();
            SceneTextbox.Focus();

        }
        public static MainWindow main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;

        private void textBox_Loaded(object sender, RoutedEventArgs e)
        {
           // SceneTextbox.SelectAll();
        }

        public void OKButton_Click(object sender, RoutedEventArgs e)
        {
            NumericCounter.SceneNumber.UpButton();

            AddScene.SceneTreeview();
            AddScene.Scene.ContextMenu = AddScene.SceneMenu;
            AddScene.Scripts.ContextMenu = AddScene.ScriptMenu;
            AddScene.Storyboards.ContextMenu = AddScene.StoryboardMenu;
            AddScene.VoiceOvers.ContextMenu = AddScene.VoiceMenu;
            AddScene.Shots.ContextMenu = AddScene.ShotMenu;
            AddScene.SoundFX.ContextMenu = AddScene.SoundMenu;
            AddScene.Music.ContextMenu = AddScene.MusicMenu;
            AddScene.Overlay.ContextMenu = AddScene.OverlayMenu;
            AddScene.Edit.ContextMenu = AddScene.EditMenu;

            var create = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is CreateProject) as CreateProject;
            var main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
         
            AddScene.Scene.Header = SceneTextbox.Text;
           // string filename = create.New.Text + ".bfs";
            string sceneFolder = SceneTextbox.Text;
            string scriptFolder = @"\Scripts\Deleted Scripts";
            string storyboardFolder = @"\Storyboards\Deleted Storyboards";
            string voiceOverFolder = @"\Voice Recordings\Deleted Voice Recordings";
            string shotFolder = @"\Shots\Deleted Shots";
            string soundFolder = @"\Sound Effects\Deleted Sound Effects";
            string musicFolder = @"\Music\Deleted Music";
            string overlayFolder = @"\Overlays\Deleted Overlays";
            string editFolder = @"\Edits\Deleted Edits";

            //    string path = System.IO.Path.Combine(@"C:\Users\" + Environment.UserName + @"\Documents\BrickFilm Studio\Projects\" + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header);

            // System.IO.Path.GetPathRoot("");
             string scene = @"C:\Users\" + Environment.UserName + @"\Documents\BrickFilm Studio\Projects"  + @"\" + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header + @"\" + sceneFolder;
            string root = System.IO.Path.Combine (scene);
             string subdir1 = scene + scriptFolder;
            string subdir2 = scene + storyboardFolder;
            string subdir3 = scene + voiceOverFolder;
            string subdir4 = scene + shotFolder;
            string subdir5 = scene + soundFolder;
            string subdir6 = scene + musicFolder;
            string subdir7 = scene + overlayFolder;
            string subdir8 = scene + editFolder;
            if(!Directory.Exists(scene))
            {
                Directory.CreateDirectory(scene);
                Directory.CreateDirectory(subdir1);
                Directory.CreateDirectory(subdir2);
                Directory.CreateDirectory(subdir3);
                Directory.CreateDirectory(subdir4);
                Directory.CreateDirectory(subdir5);
                Directory.CreateDirectory(subdir6);
                Directory.CreateDirectory(subdir7);
                Directory.CreateDirectory(subdir8);
                AddScene.Scene.IsSelected = true;
                AddScene.Scene.IsExpanded = true;
                CreateProject.Project.Items.Add(AddScene.Scene);

                Close();
            }
              
            else
            {
                MessageBox.Show("Scene Already Exists! Choose a different name", "Scene File" , MessageBoxButton.OK, MessageBoxImage.Exclamation);
                SceneTextbox.SelectAll();
                SceneTextbox.Focus();
            }

               /*  MessageBoxResult result = MessageBox.Show("Would you like to create a Scene for " + New.Text + "?", "Scene", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    CreateScene s = new CreateScene();
                    s.Show();
                    s.Owner = Application.Current.MainWindow;

                    break;
                case MessageBoxResult.No:

                    break;
            }*/

            
            
        }

        internal void DeleteShot_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void DeleteVoice_Click(object sender, RoutedEventArgs e)
        {
            //    throw new NotImplementedException();
            MessageBoxResult delete = MessageBox.Show("Are you sure you want to delete " + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header + "?", "Delete Voice Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (delete)
            {
                case MessageBoxResult.Yes:
                    var main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
                    main.ProjectTreeView.Items.Remove(main.ProjectTreeView.SelectedItem);
                    break;
            }
        }

        internal void DeleteStoryboard_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            MessageBoxResult delete = MessageBox.Show("Are you sure you want to delete " + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header + "?", "Delete Storyboard Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (delete)
            {
                case MessageBoxResult.Yes:
                    var main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
                    main.ProjectTreeView.Items.Remove(main.ProjectTreeView.SelectedItem);
                    break;
            }
        }

        internal void DeleteScript_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
            MessageBoxResult delete = MessageBox.Show("Are you sure you want to delete " + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header + "?", "Delete Script Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (delete)
            {
                case MessageBoxResult.Yes:
                    var main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
                    main.ProjectTreeView.Items.Remove(main.ProjectTreeView.SelectedItem);
                    break;
            }
        }

        internal void DeleteScene_Click(object sender, RoutedEventArgs e)
        {
          //  throw new NotImplementedException();
            MessageBoxResult delete = MessageBox.Show("Are you sure you want to delete " + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header + "?", "Delete Scene Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (delete)
            {
                case MessageBoxResult.Yes:
                    var main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
                    main.ProjectTreeView.Items.Remove(main.ProjectTreeView.SelectedItem);
                    break;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
