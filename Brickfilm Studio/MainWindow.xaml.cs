using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Ribbon;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.DataGrid;
using Microsoft.Win32;
using System.IO;
using WebCam_Capture;
using System.Windows.Threading;
using GongSolutions.Wpf.DragDrop;
using System.Collections.ObjectModel;
using System.Collections;

namespace Brickfilm_Studio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
       

        AdornerLayer aLayer;

        bool _isDown;
        bool _isDragging;
        bool selected = false;
        UIElement selectedElement = null;

        Point _startPoint;
        private double _originalLeft;
        private double _originalTop;
        
        public MainWindow()
        {
            InitializeComponent();
            FontSizeComboBox.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            FontStyleComboBox.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            // ScriptArea.Children.Add(CreateScript.ScriptTab);
            DataContext = new FrameModel();

        }
        WebCam webcam;
        public static MainWindow main = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
        public static CreateProject create = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is CreateProject) as CreateProject;
        public static CreateScene scene = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is CreateScene) as CreateScene;
        public static CreateScript script = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is CreateScript) as CreateScript;
        public static CreateShot shot = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is CreateShot) as CreateShot;

        private void CapturePlayButton_Click(object sender, EventArgs e)
        {
            CapturePlayButton.Visibility = System.Windows.Visibility.Hidden;
            CapturePauseButton.Visibility = System.Windows.Visibility.Visible;
        }
        private void CapturePauseButton_Click(object sender, EventArgs e)
        {
            CapturePlayButton.Visibility = System.Windows.Visibility.Visible;
            CapturePauseButton.Visibility = System.Windows.Visibility.Hidden;
        }


        private void CaptureRewindButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CaptureForwardButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LeftToolbarScriptButton_Click(object sender, RoutedEventArgs e)
        {

            //Test.Visibility = System.Windows.Visibility.Visible;
        }

        private void Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void ScriptButton_MouseEnter(object sender, MouseEventArgs e)
        {
            //   FrameArea.Visibility = Visibility.Collapsed;
            // CaptureArea.Visibility = Visibility.Collapsed;
            //PlayButtons.Visibility = Visibility.Collapsed;

        }

        private void FontBiggerButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // MessageBox.Show("hi");
        }


        private void richTextBox_Loaded(object sender, RoutedEventArgs e)
        {
        }



        private void ScriptSaveLibrary_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ScriptBoldButton_Checked(object sender, System.EventArgs e)
        {
            //ScriptTextbox.FontWeight = FontWeights.Bold;
            //ScriptTextbox.FontWeight

        }

        private void ScriptBoldButton_Unchecked(object sender, RoutedEventArgs e)
        {
            //ScriptTextbox.FontWeight = FontWeights.Normal;
        }

        private void ScriptItalicButton_Unchecked(object sender, RoutedEventArgs e)
        {
            // ScriptTextbox.FontStyle = FontStyles.Normal;
        }

        private void ScriptItalicButton_Checked(object sender, RoutedEventArgs e)
        {
            // ScriptTextbox.FontStyle = FontStyles.Italic;
        }





        private void Border_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }



        private void ScriptTextbox_Loaded(object sender, RoutedEventArgs e)
        {

            //  FontStyleComboBox.SelectedItem = ScriptTextbox.FontFamily;
        }




        #region SideBar Buttons 
        private void AnimateButton_Click(object sender, RoutedEventArgs e)
        {
            CaptureArea.Visibility = Visibility.Visible;
            VoiceOverArea.Visibility = Visibility.Hidden;
            //OverlayArea.Visibility = Visibility.Hidden;
            StoryboardArea.Visibility = Visibility.Hidden;
            EditArea.Visibility = Visibility.Hidden;

            ScriptArea.Visibility = Visibility.Hidden;
        }

        

        private void StoryboardButton_Click(object sender, RoutedEventArgs e)
        {
            CaptureArea.Visibility = Visibility.Hidden;
            VoiceOverArea.Visibility = Visibility.Hidden;
            // OverlayArea.Visibility = Visibility.Hidden;
            StoryboardArea.Visibility = Visibility.Visible;
            EditArea.Visibility = Visibility.Hidden;
            RibbonWin.SelectedItem = StoryboardTab;
            ScriptArea.Visibility = Visibility.Hidden;
        }
        private void ScriptButton_Click(object sender, RoutedEventArgs e)
        {
            CaptureArea.Visibility = Visibility.Hidden;
            VoiceOverArea.Visibility = Visibility.Hidden;
            //  OverlayArea.Visibility = Visibility.Hidden;
            StoryboardArea.Visibility = Visibility.Hidden;
            EditArea.Visibility = Visibility.Hidden;
            RibbonWin.SelectedItem = ScriptTab;
            ScriptArea.Visibility = Visibility.Visible;

        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            CaptureArea.Visibility = Visibility.Hidden;
            VoiceOverArea.Visibility = Visibility.Hidden;
            //   OverlayArea.Visibility = Visibility.Hidden;
            StoryboardArea.Visibility = Visibility.Hidden;

            ScriptArea.Visibility = Visibility.Hidden;
            EditArea.Visibility = Visibility.Visible;

        }
        #endregion SideBar Buttons

        #region RibbonButtons
        #region ScriptButtons

        #region FontControls

        // Change Script Font Size
        private void FontSizeComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (FontSizeComboBox.SelectedItem != null)
            {
                ScriptTextbox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, FontSizeComboBox.SelectedItem);
                ScriptTextbox.Focus();

            }

        }
        // Make Font Bigger by clicking a button
        private void FontBiggerButton_Click(object sender, RoutedEventArgs e)
        {
            FontSizeComboBox.Items.MoveCurrentToNext();
        }

        // Make Font Smaller by clicking a button
        private void FontSmallerRibbonButton_Click(object sender, RoutedEventArgs e)
        {
            FontSizeComboBox.Items.MoveCurrentToPrevious();

        }

        // Change Font Family
        private void FontStyleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontStyleComboBox.SelectedItem != null)
            {
                ScriptTextbox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, FontStyleComboBox.SelectedItem);

                //FontStyleComboBox.SelectedItem.Equals(ScriptTextbox.FontFamily);
                ScriptTextbox.Focus();
            }

        }

        internal void Script_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = ScriptTextbox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            ScriptBoldButton.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = ScriptTextbox.Selection.GetPropertyValue(Inline.FontStyleProperty);
            ScriptItalicButton.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = ScriptTextbox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            ScriptUnderlineButton.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));
            temp = ScriptTextbox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            StrikethroughRibbonButton.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Strikethrough));
            temp = ScriptTextbox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            FontStyleComboBox.SelectedItem = temp;
            temp = ScriptTextbox.Selection.GetPropertyValue(Inline.FontSizeProperty);
            FontSizeComboBox.SelectedItem = temp.ToString();

        }
        #endregion FontControls

        #region File
        // Open Script
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = " Microsoft Word (*.docx) | *.docx| Libre Writer (*.odt) | *.odt| Html Document (*.html) | *.html|Rich Text Format (*.rtf) | *.rtf|Text File (*.txt) | *.txt| All files (*.*)| *.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(ScriptTextbox.Document.ContentStart, ScriptTextbox.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);

            }
        }
        // Save Script
        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Brickfilm Studio  (*.bfs) | *.bfs| Microsoft Word (*.docx) | *.docx| Libre Writer (*.odt) | *.odt| Html Document (*.html) | *.html|Rich Text Format (*.rtf) | *.rtf|Text File (*.txt) | *.txt| All files (*.*)| *.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(ScriptTextbox.Document.ContentStart, ScriptTextbox.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }

        #endregion File

        #region ColorDialog
        private void ColorPicker1_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            ScriptTextbox.Foreground = new SolidColorBrush(ColorPicker1.SelectedColor);
            ScriptTextbox.Focus();
        }
        #endregion ColorDialog_Script

        #region Insert

        #region InsertPicture
        // public Canvas myCanvas = new Canvas();

        public void ScriptInsertPicture_Click(object sender, RoutedEventArgs e)
        {

            //Image image = new Image();
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select an Image";
            op.InitialDirectory = System.Environment.SpecialFolder.MyPictures.ToString();
            op.Filter = "All supported Images| *.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg) | *.jpg;*.jpeg|" +
                "Portable Network Graphics (*.png) |*.png";
            //  dialog.Title = Properties.Resources.SelectImage;



            if (op.ShowDialog() == true)
            {

                Canvas canvas = new Canvas();

                ContentControl content = new ContentControl() { Height = 230, Width = 230, Name = "ImageContent" };
                Canvas.SetLeft(content, 400);
                Canvas.SetTop(content, 150);
                //Paragraph1.Inlines.Add(canvas);
                Style style = this.FindResource("DesignerItemStyle") as Style;
                content.Style = style;

                content.SetValue(Selector.IsSelectedProperty, true);
                Image ScriptImage = new Image();
                ScriptImage.IsHitTestVisible = false;
                ScriptImage.Stretch = Stretch.Fill;
                //ScriptImage.Parent.Equals(ImageContent);
                canvas.Children.Add(content);
                content.Content = ScriptImage;

                ScriptImage.Source = new BitmapImage(new Uri(op.FileName));

                // Paragraph.Inlines.Add(canvas);
                //  ScriptImage.LayoutTransform = new ScaleTransform();

                // myCanvas.Children.Add(ScriptImage);

            }

        }

        /*   public class MoveThumb : Thumb
           {
               public MoveThumb()
               {
                   DragDelta += new DragDeltaEventHandler(this.MoveThumb_DragDelta);
               }
               private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
               {
                   Control item = this.DataContext as Control;
                   if(item!=null)
                   {
                       double left = Canvas.GetLeft(item);
                       double top = Canvas.GetTop(item);

                       Canvas.SetLeft(item, left + e.HorizontalChange);
                       Canvas.SetTop(item, top + e.VerticalChange);
                   }
               }
           }*/
        #endregion InsertPicture
        private void ScriptInsertLink_Click(object sender, RoutedEventArgs e)
        {
            AddHyperlink link = new AddHyperlink();
            link.Show();
        }

        #endregion Insert




        #endregion ScriptButtons
        #region StoryboardButtons
        // Add Storyboard to Panel
        public static Border border1;
        public static Border border2;
        public static StackPanel tool;
        public void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            Column column = new Column() { Width = 200 };
              tool = new StackPanel() { Width = 120, Height = 24, };
              border2 = new Border() { Width = 120, Height = 25, Margin = new Thickness(0, 73, 0, 0), BorderThickness = new Thickness(0, 1, 0, 0), BorderBrush = Brushes.Gray, HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch };
            border1 = new Border() { Name = "Storyboard", Width = 120, Height = 120, Background = Brushes.White, BorderThickness = new Thickness(1), Margin = new Thickness(36, 43, 0, 0), HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top };
            border1.Child = border2;
            border2.Child = tool;
            border1.MouseDown += border1_Click;
            // StoryboardPanel.Children.Add(column);
            AddStoryboard.storyboardWrapPanel.Children.Add(border1);

        }
        public void border1_Click(object sender, MouseButtonEventArgs e)
        {


        }
        private void StoryboardSaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
        public static AddStoryboard story = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is AddStoryboard) as AddStoryboard;


        internal static OpenFileDialog dlg;

        private void StoryboardOpenButton_Click(object sender, RoutedEventArgs e)
        {
            

          



              dlg = new OpenFileDialog();
            dlg.Filter = "JPG (*.jpg) | *.jpg| PNG (*.png) | *.png| BMP (*.bmp) | *.bmp| TIFF (*.tiff) | *.tiff| GIF (*.gif) | *.gif| All Images (*.jpg, *.png, *.bmp, *.tiff, *.gif )| *.*";
            dlg.Multiselect = true;
            
            if (dlg.ShowDialog() == true)
            {
                // FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
               Image storyboard = new Image() {Stretch = Stretch.Fill };
                tool = new StackPanel() { Width = 120, Height = 24, };
                border2 = new Border() { Width = 120, Height = 25, Margin = new Thickness(0, 73, 0, 0), BorderThickness = new Thickness(0, 1, 0, 0), BorderBrush = Brushes.Gray, HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch };
                border1 = new Border() { Name = "Storyboard", Width = 120, Height = 120, BorderBrush = Brushes.Black, Background = Brushes.White, BorderThickness = new Thickness(1), Margin = new Thickness(36, 43, 0, 0), HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top };
                border1.Child = storyboard;
                border2.Child = tool;
                border1.MouseDown += border1_Click;
                storyboard.MouseDown += border1_Click;
                storyboard.Source = new BitmapImage(new Uri(dlg.FileName));
                AddStoryboard.storyboardWrapPanel.Children.Add(border1);
                //  FFileStream fs = null;
               
                //   storyboard.Load(fileStream, DataFormats.Bitmap);
              //  string name = "Frame";
                //string path = @"C:\Users\" + Environment.UserName + @"\Documents\BrickFilm Studio\Projects" + @"\" + AddStoryboard.textStoryboard + @"\" + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header + @"\" + @"Storyboards" + @"\" + name;
              //  string copyImageDir = path;
              //  string image = dlg.FileName.ToString();
             //  string imagePath = System.IO.Path.Combine(copyImageDir, image);
             //   File.Copy(dlg.FileName, copyImageDir);
            }
        }
        #endregion StoryboardButtons


        #endregion RibbonButtons
        #region Capture
        public static Image frameImage;
        internal void imgCapture_Loaded(object sender, RoutedEventArgs e)
        {

            // TODO: Add event handler implementation here.

            webcam = new WebCam();
            webcam.InitializeWebCam(ref CreateShot.imgCapture);
            webcam.Start();
        }
        public static FrameworkElementFactory frame;

        public object Center { get; private set; }

        public void Snap_Click(object sender, RoutedEventArgs e)
        {

           
            CreateShot.imgCapture.Source = CreateShot.imgCapture.Source;
          
            Helper.SaveImageCapture((BitmapSource)CreateShot.imgCapture.Source);
            NumericCounter.FrameNumber.UpButton();

            /* Border border1 = new Border() {BorderBrush = Brushes.Black, BorderThickness =  new Thickness(1), Height = 192, Margin = new Thickness(0, 0, 721, -191) };
               StackPanel stackpanel1 = new StackPanel() { };
               Border border2 = new Border() { BorderBrush = Brushes.Black, BorderThickness = new Thickness(0, 1, 0, 1), Margin = new Thickness(0, 0, 0, 161), Background = Brushes.DarkOrange };
               StackPanel stackpanel2 = new StackPanel();
               Label framelabel = new Label() { Content = "Frame1", Margin = new Thickness(4, 0, 134, 0) };
               FrameView.Children.Add(border1);
               border1.Child.Equals(stackpanel1);
               stackpanel1.Children.Add(border2);
               border2.Child.Equals(stackpanel2);
               stackpanel2.Children.Add(framelabel);*/
            CreateShot.data = new DataTemplate();
            NumericCounter.FrameText.UpButton();
             frame = new FrameworkElementFactory(typeof(Border));
           CreateShot.data.VisualTree = frame;
            // CreateShot.FrameList.Items.Add(MainWindow.frame);
            frame.SetValue(Border.HeightProperty, 150.0);
            frame.SetValue(Border.WidthProperty, 170.0);
            frame.SetValue(Border.BorderBrushProperty, Brushes.Black);
            frame.SetValue(Border.BorderThicknessProperty, new Thickness(1,1,1,1));




            FrameworkElementFactory frameNameBorder = new FrameworkElementFactory(typeof(Border));
             
            frameNameBorder.SetValue(Border.HeightProperty, 30.0);
            frameNameBorder.SetValue(Border.WidthProperty, 170.0);
            frameNameBorder.SetValue(Border.BorderBrushProperty, Brushes.Black);
            frameNameBorder.SetValue(Border.BackgroundProperty, Brushes.Orange);
            frameNameBorder.SetValue(Border.BorderThicknessProperty, new Thickness(1, 1, 1, 1));

            frameNameBorder.SetValue(Border.VerticalAlignmentProperty, VerticalAlignment.Top);
            Brickfilm_Studio.FrameModel frameModel = new FrameModel();
            Binding bind = new Binding();
            
            bind.Path = new PropertyPath("Name");


            FrameworkElementFactory frameName = new FrameworkElementFactory(typeof(Label));
             

                frameName.SetValue(ContentProperty,SetBinding(NameProperty, bind));
                frameName.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Center);
                frameName.SetValue(VerticalAlignmentProperty, VerticalAlignment.Center );


            FrameworkElementFactory frameImage = new FrameworkElementFactory(typeof(Image));
           
            frameImage.SetValue(WidthProperty, 170.0);
            frameImage.SetValue(HeightProperty, 140.0);
            frameImage.SetValue(Image.SourceProperty, CreateShot.imgCapture.Source);


            FrameworkElementFactory framePanel = new FrameworkElementFactory(typeof(WrapPanel));



            AddScene.Scene.IsSelected = true;
            frameNameBorder.AppendChild(frameName);
            frame.AppendChild(framePanel);
            framePanel.AppendChild(frameNameBorder);
            framePanel.AppendChild(frameImage);

        

            // string sceneFolder = scene.SceneTextbox.Text;

            CreateShot.FrameScroll.ScrollToRightEnd();


            CreateShot.imgCapture.Visibility = Visibility.Visible;
            CreateShot.imgVideo.Visibility = Visibility.Hidden;

        



        }

       
 

        public void PlayButton_Click(object sender, RoutedEventArgs e)

        {
            CreateShot.imgCapture.Visibility = Visibility.Hidden;
            CreateShot.imgVideo.Visibility = Visibility.Visible;
            CreateShot.imgVideo.Source = frameImage.Source;
        }

         
         
     
          
        public void Settings_Click(object sender, RoutedEventArgs e)
        {


            webcam.AdvanceSetting();
                         
        }



        private void ToggleViewButton_Click(object sender, RoutedEventArgs e)
        {
           

        }
        #endregion CaptureArea



        #region ProjectInterface
        // Create New Scene
        private void NewScene_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Windows.MessageBox.Show("hi");
        }
        // Show Project Window
        private void NewProjectMenuButton_Click(object sender, RoutedEventArgs e)
        {
            CreateProject project = new CreateProject();
            project.Show();
            project.Owner = this;
         

        }
        // Create new Project
        private void button_Click_1(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            TreeViewItem item = new TreeViewItem() { Header = textBox.Text };
            ProjectTreeView.Items.Add(item);
        }

        private void SaveProjectButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Brickfilm Studio Project  (*.bfs) | *.bfs";


            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(ScriptTextbox.Document.ContentStart, ScriptTextbox.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }







        #endregion ProjectInterface



        private void RibbonWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*MessageBoxResult result = System.Windows.MessageBox.Show("Would you like to save your project(s)?", "Save Project", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    e.Cancel = false;
                    break;
                case MessageBoxResult.No:
                    e.Cancel = true;
                    break;
            }*/
        }


        private void UnorderedlistButton_Checked(object sender, RoutedEventArgs e)
        {
            OrderedlistButton.IsChecked = false;
        }

        private void OrderedlistButton_Checked(object sender, RoutedEventArgs e)
        {
            UnorderedlistButton.IsChecked = false;

        }

        private void ScriptZoom_Click(object sender, RoutedEventArgs e)
        {

        }



 

        public void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {

            //main.Title = ProjectTreeView.SelectedItem + " - BrickFilm Studio";
            ScriptArea.Visibility = Visibility.Hidden;
            StoryboardArea.Visibility = Visibility.Hidden;
            VoiceOverArea.Visibility = Visibility.Hidden;
            CaptureArea.Visibility = Visibility.Hidden;
            EditArea.Visibility = Visibility.Hidden;
            CaptureArea.Loaded += CaptureArea_Loaded;

            
        }

        public void CaptureArea_Loaded(object sender, RoutedEventArgs e)
        {
              
            //add 2 jpg files to Resources directory of your project
 
         
    }

        private void ProjectTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
          /*  //main.ProjectStatus.Content = "Project: " + ((TreeViewItem)main.ProjectTreeView.SelectedItem).Header;
            int index = 0;
            if(ProjectTreeView.Items.Count >= 0)
            {
                var tree = sender as TreeView;
                if(tree.SelectedValue != null)
                {
                    index++;
                    TreeViewItem item = tree.SelectedItem as TreeViewItem;
                    ItemsControl parent = ItemsControl.ItemsControlFromItemContainer(item);
                    while(item != null && parent.GetType()== typeof(TreeViewItem))
                        {
                        index++;
                        parent = ItemsControl.ItemsControlFromItemContainer(parent);
                       
                    }
                    ProjectStatus.Content = "Project: " + item.Header;

                }

               
            }*/
        
         
            
         }


       
    }
    
}



