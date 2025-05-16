using System.Windows;

namespace MyWpfApp
{
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // File Menu Handlers
     private void NewFile_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of NewFileControl
            var NewFileControl = new NewFileControl();

            // Set the content of the ContentControl to the NewFileControl's content
            MainContent.Content = NewFileControl.Content;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open File clicked!");
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save File clicked!");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Edit Menu Handlers
        private void Undo_Click(object sender, RoutedEventArgs e)
        {
             SalesRegister salesRegisterWindow = new SalesRegister();
             salesRegisterWindow.Show();
            // MainContentArea.Content = new SalesRegister(); // For UserControl
            //MessageBox.Show("Undo clicked!");
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
             SalesTemplate SalesTemplateWindow = new SalesTemplate();
             SalesTemplateWindow.Show();
            // MessageBox.Show("Redo clicked!");
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cut clicked!");
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Copy clicked!");
        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Paste clicked!");
        }

        // View Menu Handlers
        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Zoom In clicked!");
        }

        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Zoom Out clicked!");
        }

        private void FullScreen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Full Screen clicked!");
        }
    }
}