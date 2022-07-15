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
using TreeTab;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Brickfilm_Studio
{
    /// <summary>
    /// Interaction logic for CreateScript.xaml
    /// </summary>
    public partial class CreateScript : Window
    {
        public static TreeViewItem ScriptName;
        public static RichTextBox Script;
        public static Border scriptBorder;
        public static Grid scriptGrid;
        public static Paragraph Paragraph1;
        public static  TabControl ScriptTab = new  TabControl(); 
        public static TabItem ScriptTabItem;
        public static MainWindow main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
        public CreateScript()
        {
            InitializeComponent();
            ScriptTextbox.Text = "Script" + NumericCounter.ScriptNumber.Value.ToString();



            
                 

        }

         

        public static CreateScene scene = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is CreateScene) as CreateScene;
       
public  string text = CreateProject.Project.Header.ToString();

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

            private static void Children()
        {

        }
       
        public void OKButton_Click(object sender, RoutedEventArgs e)
        {
            ScriptTextbox.SelectAll();
            ScriptTextbox.Focus();
            

           

            NumericCounter.ScriptNumber.UpButton();

            string name = ScriptTextbox.Text + ".docx";
            string path = @"C:\Users\" + Environment.UserName + @"\Documents\BrickFilm Studio\Projects" + @"\" + text + @"\" + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header + @"\" + @"Scripts" + @"\" + name;
            FileStream fs = null;
            if (!File.Exists(path))
            {
                using (fs = File.Create(path))
                {
                    
                }
              

                Script = new RichTextBox() { UndoLimit = 1000, AutoWordSelection = true, HorizontalScrollBarVisibility = ScrollBarVisibility.Auto, VerticalScrollBarVisibility = ScrollBarVisibility.Visible, Margin = new Thickness(0, 2, -9, 10) };


                Paragraph1 = new Paragraph() { };

                scriptBorder = new Border() { Child = Script };

                scriptGrid = new Grid() { };
               

               ScriptTabItem = new TabItem();


               
               

               

                ScriptTab.Margin = new Thickness(-640, 2, -9, 10);
                ScriptTab.HorizontalAlignment = HorizontalAlignment.Stretch;
                ScriptTab.VerticalAlignment = VerticalAlignment.Stretch;

               
               
                


                 
                ScriptName = new TreeViewItem() { Header = ScriptTextbox.Text };

                AddScene.Scripts.Items.Add(ScriptName);
                // string sceneFolder = scene.SceneTextbox.Text;


                main.ScriptButton.IsEnabled = true;
                main.ScriptArea.Visibility = Visibility.Visible;
                main.CaptureArea.Visibility = Visibility.Hidden;
                ScriptName.IsSelected = true;
                AddScene.Scripts.IsExpanded = true;
                ScriptTabItem.Header = ScriptName.Header;

                //  scriptGrid.Children.Add(ScriptTab);
                ScriptTab.Items.Add(ScriptTabItem);
                ScriptTabItem.Content = scriptBorder;
                scriptBorder.Child = Script;

                Script.SelectionChanged += main.Script_SelectionChanged;
                Close();

                MessageBox.Show("" + ScriptTabItem.Header); 


            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Script Already Exists! Use a Different Name.", "Script File", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                ScriptTextbox.SelectAll();
                ScriptTextbox.Focus();
            }
            
            
        }

        public   void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Loaded"  );
            main.ScriptArea.Children.Add(ScriptTab);

        }
    }
}
