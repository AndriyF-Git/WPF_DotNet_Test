using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WPF_DotNet_Test.Services;
using WPF_DotNet_Test.ViewModels;
using WPF_DotNet_Test.Views;

// Required NuGet packages:
// - Microsoft.Extensions.DependencyInjection (v10.0.0)
// - Microsoft.Extensions.Http (v10.0.0)
// - CommunityToolkit.Mvvm (v8.2.2)

namespace WPF_DotNet_Test
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        /// Exposed so pages created with a runtime parameter (e.g. DetailPage(coinId))
        /// can resolve services without a dedicated navigation/DI abstraction.
        public static IServiceProvider Services { get; private set; } = null!;

        public App()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.local.json")
                .Build();

            var apiKey = config["CoinGeckoApiKey"];

            var services = new ServiceCollection();

            services.AddHttpClient("CoinGecko", client =>
            {
                client.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");
                client.DefaultRequestHeaders.Add("x-cg-demo-api-key", apiKey);
            });

            services.AddTransient<CoinGeckoService>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<MainPage>();
            services.AddTransient<SearchViewModel>();
            services.AddTransient<SearchPage>();
            services.AddTransient<MainWindow>();

            _serviceProvider = services.BuildServiceProvider();
            Services = _serviceProvider;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}

