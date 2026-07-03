using System.Windows;

namespace WPF_DotNet_Test.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainPage mainPage)
        {
            InitializeComponent();
            MainFrame.Navigate(mainPage);
        }
    }
}
