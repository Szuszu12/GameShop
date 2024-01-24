using GameShopApiClient;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace GameShopApp
{
    public partial class EditGameWindow : Window
    {
        private const string ApiBaseUrl = "https://localhost:7183/api/Game";
        private HttpClient httpClient;
        public GameDto SelectedGame { get; set; }

        public EditGameWindow(GameDto selectedGame)
        {
            InitializeComponent();
            httpClient = new HttpClient();
            SelectedGame = selectedGame;

            if (SelectedGame != null)
            {
                titleTextBox.Text = SelectedGame.Title;
                platformTextBox.Text = SelectedGame.Platform;
                languageTextBox.Text = SelectedGame.Language;
                priceTextBox.Text = SelectedGame.Price.ToString();
                pegiTextBox.Text = SelectedGame.Pegi;
            }
        }

        private async void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGame != null)
            {
                try
                {
                    SelectedGame.Title = titleTextBox.Text.Trim();
                    SelectedGame.Platform = platformTextBox.Text.Trim();
                    SelectedGame.Language = languageTextBox.Text.Trim();
                    SelectedGame.Price = (double)decimal.Parse(priceTextBox.Text.Trim());
                    SelectedGame.Pegi = pegiTextBox.Text.Trim();

                    string json = JsonConvert.SerializeObject(SelectedGame);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PutAsync($"{ApiBaseUrl}/{SelectedGame.Id}", content);
                    response.EnsureSuccessStatusCode();

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving changes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
