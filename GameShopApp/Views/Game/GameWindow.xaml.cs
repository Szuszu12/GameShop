using GameShopApiClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GameShopApp
{
    public partial class GameWindow : Window
    {
        private const string ApiBaseUrl = "https://localhost:7183/api/Game";
        private HttpClient httpClient;

        public GameDto SelectedGame { get; set; }

        public GameWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            DataContext = this;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadGames();
        }

        private async Task LoadGames()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(ApiBaseUrl);
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                List<GameDto> games = JsonConvert.DeserializeObject<List<GameDto>>(content);
                gamesListBox.ItemsSource = games;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading games: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private AddGameWindow addGameWindow;

        private async void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            addGameWindow = new AddGameWindow();
            addGameWindow.Owner = this;
            addGameWindow.ShowDialog();

            await LoadGames();
        }

        private async void EditGameButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedGame = (GameDto)gamesListBox.SelectedItem;

            if (SelectedGame != null)
            {
                EditGameWindow editGameWindow = new EditGameWindow(SelectedGame);
                editGameWindow.Owner = this;
                editGameWindow.ShowDialog();

                await LoadGames();
            }
            else
            {
                MessageBox.Show("Proszę wybrać grę do edytowania.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void DeleteGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameDto selectedGame = (GameDto)gamesListBox.SelectedItem;

            if (selectedGame != null)
            {
                try
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"{ApiBaseUrl}/{selectedGame.Id}");
                    response.EnsureSuccessStatusCode();

                    await LoadGames();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Podczas usuwania gry wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Proszę wybrać grę do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
