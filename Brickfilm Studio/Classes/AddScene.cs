using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using static System.Windows.Controls.TreeViewEx;



namespace Brickfilm_Studio
{
     class AddScene
    {
        public static CreateProject create = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is CreateProject) as CreateProject;
        public static CreateScene scene = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is CreateScene) as CreateScene;
        public static MainWindow main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;

        public static TreeViewItem Scene;
         
        public static TreeViewItem Scripts;
        public static TreeViewItem Storyboards;
        public static TreeViewItem Storyboard;
        public static TreeViewItem VoiceOvers;
        public static TreeViewItem Shots;
        public static TreeViewItem SoundFX;
        public static TreeViewItem Music;
        public static TreeViewItem Overlay;
        public static TreeViewItem Edit;


        public static ContextMenu SceneMenu;
        public static ContextMenu ScriptMenu;
        public static ContextMenu StoryboardMenu;
        public static ContextMenu VoiceMenu;
        public static ContextMenu ShotMenu;
        public static ContextMenu SoundMenu;
        public static ContextMenu MusicMenu;
        public static ContextMenu OverlayMenu;
        public static ContextMenu EditMenu;

        
        // public static ContextMenu VoiceMenu;
        public static void SceneTreeview ()
        {
            Scene = new TreeViewItem() { ContextMenu = AddScene.SceneMenu};
           // Scene.Header = scene.SceneTextbox.Text;
               Scripts = new TreeViewItem() { Header = "Scripts", ContextMenu = ScriptMenu };
            
              Storyboards = new TreeViewItem() { Header = "Storyboards", ContextMenu = StoryboardMenu };
              VoiceOvers = new TreeViewItem() { Header = "Voice Recordings", ContextMenu = VoiceMenu };
              Shots = new TreeViewItem() { Header = "Animation Shots", ContextMenu = ShotMenu };
              SoundFX = new TreeViewItem() { Header = "Sound Effects", ContextMenu = SoundMenu };
              Music = new TreeViewItem() { Header = "Music", ContextMenu = MusicMenu };
              Overlay = new TreeViewItem() { Header = "Overlays", ContextMenu = OverlayMenu };
              Edit = new TreeViewItem() { Header = "Editing", ContextMenu = EditMenu };
            //  TreeViewItem Library = new TreeViewItem() { Header = "Library" };

            SceneMenu = new ContextMenu() ;
            MenuItem NewScene = new MenuItem() { Header = "New Scene" };
            MenuItem DeleteScene = new MenuItem() { Header = "Delete " + scene.SceneTextbox.Text };
            NewScene.Click += NewScene_Click;
           DeleteScene.Click += scene.DeleteScene_Click;

            SceneMenu.Items.Add(NewScene);
            SceneMenu.Items.Add(DeleteScene);


              ScriptMenu = new ContextMenu() { };
            MenuItem NewScript = new MenuItem() { Header = "New Script" };
            MenuItem DeleteScript = new MenuItem() { Header = "Delete  Script", IsEnabled = false };
            ScriptMenu.Items.Add(NewScript);
            ScriptMenu.Items.Add(DeleteScript);
            NewScript.Click += NewScript_Click;
            DeleteScript.Click += scene.DeleteScript_Click;


              StoryboardMenu = new ContextMenu() { };
            MenuItem NewStoryboard = new MenuItem() { Header = "New Storyboard" };
            MenuItem DeleteStoryboard = new MenuItem() { Header = "Delete  Storyboard", IsEnabled = false };
            StoryboardMenu.Items.Add(NewStoryboard);
            StoryboardMenu.Items.Add(DeleteStoryboard);
            NewStoryboard.Click += NewStoryboard_Click;
            DeleteStoryboard.Click += scene.DeleteStoryboard_Click;


             VoiceMenu = new ContextMenu() { };
            MenuItem NewVoice = new MenuItem() { Header = "New Voice Recording" };
            MenuItem DeleteVoice = new MenuItem() { Header = "Delete  Voice Recording", IsEnabled = false };
            VoiceMenu.Items.Add(NewVoice);
            VoiceMenu.Items.Add(DeleteVoice);
            NewVoice.Click += NewVoice_Click;
            DeleteVoice.Click += scene.DeleteVoice_Click;




              ShotMenu = new ContextMenu() { };
            MenuItem NewShot = new MenuItem() { Header = "New Shot" };
            MenuItem DeleteShot = new MenuItem() { Header = "Delete Shot" };
            ShotMenu.Items.Add(NewShot);
            ShotMenu.Items.Add(DeleteShot);
            NewShot.Click += NewShot_Click;
            DeleteShot.Click += scene.DeleteShot_Click;

              SoundMenu = new ContextMenu() { };
            MenuItem NewSound = new MenuItem() { Header = "New Sound Effect" };
            MenuItem DeleteSound = new MenuItem() { Header = "Delete Sound Effect" };
            SoundMenu.Items.Add(NewSound);
            SoundMenu.Items.Add(DeleteSound);


              MusicMenu = new ContextMenu() { };
            MenuItem NewMusic = new MenuItem() { Header = "New Music File" };
            MenuItem DeleteMusic = new MenuItem() { Header = "Delete Music File" };
            MusicMenu.Items.Add(NewMusic);
            MusicMenu.Items.Add(DeleteMusic);


              OverlayMenu = new ContextMenu() { };
            MenuItem NewOverlay = new MenuItem() { Header = "New Overlay" };
            MenuItem DeleteOverlay = new MenuItem() { Header = "Delete Overlay" };
            OverlayMenu.Items.Add(NewOverlay);
            OverlayMenu.Items.Add(DeleteOverlay);



              EditMenu = new ContextMenu() { };
            MenuItem NewEdit = new MenuItem() { Header = "New Edit File" };
            MenuItem DeleteEdit = new MenuItem() { Header = "Delete Edit File" };
            EditMenu.Items.Add(NewEdit);
            EditMenu.Items.Add(DeleteEdit);

             
            Scene.Items.Add(Scripts);
            Scene.Items.Add(Storyboards);
            Scene.Items.Add(VoiceOvers);
            Scene.Items.Add(Shots);
            Scene.Items.Add(SoundFX);
            Scene.Items.Add(Music);
            Scene.Items.Add(Overlay);
            Scene.Items.Add(Edit);

           //  scene.Close();
        }

        private static void NewShot_Click(object sender, RoutedEventArgs e)
        {
            CreateShot shot = new CreateShot();
            shot.Show();
            shot.Owner = main;
            if (shot.Visibility == Visibility.Visible)
            {
                AddScene.Scene.IsSelected = true;
            }
        }

        private static void NewVoice_Click(object sender, RoutedEventArgs e)
        {
            CreateVoice voice = new CreateVoice();
            voice.Show();
            voice.Owner = main;
            if (voice.Visibility == Visibility.Visible)
            {
                AddScene.Scene.IsSelected = true;
            }
        }

        private static void NewStoryboard_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
            AddStoryboard story = new AddStoryboard();
            story.Show();
            story.Owner = main;
            if (story.Visibility == Visibility.Visible)
            {
                AddScene.Scene.IsSelected = true;
            }
            
        }

        private static void NewScript_Click(object sender, RoutedEventArgs e)
        {
            //   throw new NotImplementedException();

            CreateScript script = new CreateScript();
            script.Show();
            script.Owner = main;
            if(script.Visibility == Visibility.Visible)
            {
                AddScene.Scene.IsSelected = true;
            }
            
            
        }

        private static void NewScene_Click(object sender, RoutedEventArgs e)
        {
            CreateScene scene = new CreateScene();
           
            scene.Owner = main;
            scene.Show();
        }
        
        
    }
}
