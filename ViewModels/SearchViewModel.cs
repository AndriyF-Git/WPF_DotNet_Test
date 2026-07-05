using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF_DotNet_Test.Models;
using WPF_DotNet_Test.Services;

namespace WPF_DotNet_Test.ViewModels
{
    public partial class SearchViewModel : ObservableObject
    {
        private readonly CoinGeckoService _coinGeckoService;

        [ObservableProperty]
        private string searchQuery = string.Empty;

        [ObservableProperty]
        private ObservableCollection<SearchCoin> results = new();

        [ObservableProperty]
        private string statusMessage = string.Empty;

        [ObservableProperty]
        private bool hasStatusMessage;

        [ObservableProperty]
        private bool isLoading;

        /// Raised when a search result is clicked; the View owns navigation, the ViewModel just reports the selection.
        public event Action<string>? CoinSelected;

        public SearchViewModel(CoinGeckoService coinGeckoService)
        {
            _coinGeckoService = coinGeckoService;
        }

        [RelayCommand]
        private async Task Search()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                Results.Clear();
                return;
            }

            try
            {
                IsLoading = true;
                HasStatusMessage = false;
                Results.Clear();

                var result = await _coinGeckoService.SearchCoinsAsync(SearchQuery);

                foreach (var coin in result)
                    Results.Add(coin);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                HasStatusMessage = true;
            }
            finally
            {
                IsLoading = false;
            }
        }

        [RelayCommand]
        private void SelectResult(SearchCoin coin)
        {
            if (coin?.Id is null)
                return;

            CoinSelected?.Invoke(coin.Id);
        }
    }
}
