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
 
using Microsoft.Win32;
 
using Button = System.Windows.Controls.Button;



namespace Brickfilm_Studio
{
    /// <summary>
    /// Interaction logic for CreateProject.xaml
    /// </summary>
    public partial class CreateProject : Window
    {
        public CreateProject()
        {
            InitializeComponent();
            //AddScene add = new AddScene();
            //    main.ProjectStatus.Content = "Project: " + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header;

            New.Text = "Project" + NumericCounter.ProjectNumber.Value.ToString();
            New.SelectAll();
            New.Focus();
        }
        // public static TreeView treeView;
        //   public TreeViewItem Project = new TreeViewItem();

        public string CurrentDirectoryPath
        {
            get
            {
                return Environment.CurrentDirectory;
            }
        }
        public static MainWindow main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;

     
        internal static TreeViewItem Project;

  
        public void  OKButtonClick(object sender, RoutedEventArgs e)
        {
            NumericCounter.ProjectNumber.UpButton();
                
            if(New.Text =="")
            {
                MessageBox.Show("Fill out Project Name", "Confirm", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                  
            }
            else if(ProjectLoc.Text =="")
            {
                MessageBox.Show("Fill out Project Location", "Confirm", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (New.Text == "" && ProjectLoc.Text == "")
            {
                MessageBox.Show("Fill out Project Name and Location", "Confirm", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

            else
            {


                // var scene = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is CreateScene) as CreateScene;
                Project = new TreeViewItem();

                //   CreateScene scene = Owner as CreateScene;
                var treeView = main.ProjectTreeView;
                ContextMenu SceneMenu = new ContextMenu() ;
                ContextMenu ProjectMenu = new ContextMenu();
                MenuItem AddProject = new MenuItem() { Header = "New Scene" };
                MenuItem NewProject = new MenuItem() {Header = "New Project"  };
                MenuItem DeleteProject = new MenuItem() { Header = "Delete Project" };
                MenuItem NewScene = new MenuItem() { Header = "New Project"};
                MenuItem DeleteScene = new MenuItem() {Header = "Delete " + NewScene.Header };
                NewProject.Click += NewProject_Click;
                AddProject.Click += AddProject_Click;



                DeleteProject.Click += DeleteProject_Click;
                Project.MouseRightButtonDown += ProjectTreeView_MouseRightButtonDown;
             
                Project.Header = New.Text;
             //   Project.Selected += StatuesBar.Project_Selected;

                //  TreeViewItem Scene = new TreeViewItem();
                // Scene.Header = "Scenes";
                /*  TreeViewItem Script = new TreeViewItem();
                  Script.Header = "Scripts";
                  TreeViewItem Audio = new TreeViewItem();
                  Audio.Header = "Audio";
                  TreeViewItem VoiceOver = new TreeViewItem();
                  VoiceOver.Header = "Voice Overs";
                  TreeViewItem SoundEffects = new TreeViewItem();
                  SoundEffects.Header = "Sound Effects";
                  TreeViewItem Music = new TreeViewItem();
                  Music.Header = "Music";
                  TreeViewItem Overlay = new TreeViewItem();
                  Overlay.Header = "Overlays";*/
                // Scene.ContextMenu = SceneMenu;
                SceneMenu.Items.Add(NewScene );
                SceneMenu.Items.Add(DeleteScene);
                Project.IsSelected = true;
                Project.IsExpanded = true;
                Project.ContextMenu = ProjectMenu;
                 ProjectMenu.Items.Add(AddProject);
                ProjectMenu.Items.Add(NewProject);
                ProjectMenu.Items.Add(DeleteProject);
                 //Project.Items.Add(AddScene.Scene);
                treeView.Items.Add(Project);

                /*   var path1 = Environment.SpecialFolder.MyDocuments.ToString();

                   var path2 = System.IO.Path.Combine(path1, "BrickFilm Studio");
                   if (!Directory.Exists(path2))
                   {
                       Directory.CreateDirectory(path2);

                   }
                   else
                   {

                   }*/
                string filename = New.Text + ".bfs";
                string folder = New.Text;
                string path = System.IO.Path.Combine(ProjectLoc.Text, folder);

                if (Directory.Exists(ProjectLoc.Text))
                    {
                    Directory.CreateDirectory(path);
                  
                    Close();
                    MessageBox.Show(New.Text + " was successfully created in " + ProjectLoc.Text, "Project", MessageBoxButton.OK, MessageBoxImage.Information);

                    MessageBoxResult result = MessageBox.Show("Would you like to create a Scene for " + New.Text + "?", "Scene", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    Project.IsSelected = true;
                    switch(result)
                    {
                        case MessageBoxResult.Yes:
                            CreateScene s = new CreateScene();
                              s.Show();
                            s.Owner = Application.Current.MainWindow;
                            
                            break;
                        case MessageBoxResult.No:
                            
                            break;
                    }

                }
                else
                {
                    MessageBox.Show(ProjectLoc.Text + " does not exist", "Confirm Directory", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }

                //   File.Create(filename);




            }
            
                          
            /* TreeViewItem Project = new TreeViewItem() { Header =New.Text };
            TreeViewItem Scene = new TreeViewItem() { Header = "Scene1" };
            Project.Items.Add(Scene);
            mainWindow.ProjectTreeView.Items.Add(Project);*/
        }

        private void Project_Selected(object sender, RoutedEventArgs e)
        {
            
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            FolderDialog.folderDialog();
            
          

        }
        
        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            CreateProject Create = new CreateProject();
            Create.Show();
            Create.Owner = main;
        }
        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            CreateScene scene = new CreateScene();
            scene.Show();
            scene.Owner = main;
        }
        private void ProjectTreeView_MouseRightButtonDown (object sender, MouseEventArgs e)
        {
           // var main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
          //  Project.IsSelected = true;         
        }

        public void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete " + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header + "?" , "Delete Project Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question );
            switch(result)
            {
                case MessageBoxResult.Yes:
                    var main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
                    main.ProjectTreeView.Items.Remove(main.ProjectTreeView.SelectedItem);
                    break;
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ProjectLoc_Loaded(object sender, RoutedEventArgs e)
        {
            ProjectLoc.Text = @"C:\Users\" + Environment.UserName+ @"\Documents\BrickFilm Studio\Projects";
        }
        
    }
}
