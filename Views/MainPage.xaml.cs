using System.Windows.Controls;
using WPF_DotNet_Test.ViewModels;

namespace WPF_DotNet_Test.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
