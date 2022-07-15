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
    /// Interaction logic for CreateVoice.xaml
    /// </summary>
    public partial class CreateVoice : Window
    {
        public CreateVoice()
        {
            InitializeComponent();
            StoryboardTextbox.Text = "Voice" + NumericCounter.VoiceNumber.Value.ToString();
            StoryboardTextbox.SelectAll();
            StoryboardTextbox.Focus();

        }
        public static CreateScene scene = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is CreateScene) as CreateScene;
        public static MainWindow main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
        public string text = CreateProject.Project.Header.ToString();
        
        public static TreeViewItem VoiceName;
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            NumericCounter.VoiceNumber.UpButton();

            VoiceName = new TreeViewItem() { Header = StoryboardTextbox.Text };
            AddScene.VoiceOvers.Items.Add(VoiceName);
            // string sceneFolder = scene.SceneTextbox.Text;
            string name = StoryboardTextbox.Text;


            string path = @"C:\Users\" + Environment.UserName + @"\Documents\BrickFilm Studio\Projects" + @"\" + text + @"\" + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header + @"\" + @"Voice Recordings" + @"\" + name;
            FileStream fs = null;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                    main.VoiceButton.IsEnabled = true;
                main.VoiceOverArea.Visibility = Visibility.Visible;
                main.ScriptArea.Visibility = Visibility.Hidden;
                main.StoryboardArea.Visibility = Visibility.Hidden;
                main.EditArea.Visibility = Visibility.Hidden;
                main.CaptureArea.Visibility = Visibility.Hidden;

            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Voice Recording File Already Exists! Use a Different Name.", "Voice File", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                StoryboardTextbox.SelectAll();
                StoryboardTextbox.Focus();
            }

            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
