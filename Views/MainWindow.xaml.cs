using System;
using System.Windows;

namespace WPF_DotNet_Test.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainPage _mainPage;
        private readonly SearchPage _searchPage;
        private bool _isDarkTheme = true;

        public MainWindow(MainPage mainPage, SearchPage searchPage)
        {
            InitializeComponent();

            _mainPage = mainPage;
            _searchPage = searchPage;

            MainFrame.Navigate(_mainPage);
        }

        private void Home_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(_mainPage);

        private void Search_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(_searchPage);

        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
        {
            _isDarkTheme = !_isDarkTheme;
            var themeUri = _isDarkTheme ? "/Themes/DarkTheme.xaml" : "/Themes/LightTheme.xaml";

            Application.Current.Resources.MergedDictionaries[0] = new ResourceDictionary
            {
                Source = new Uri(themeUri, UriKind.Relative)
            };
        }
    }
}
