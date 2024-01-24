using GameShopApiClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameShopApp
{
    public partial class AddGameWindow : Window
    {
        private const string ApiBaseUrl = "https://localhost:7183/api/Game";
        private HttpClient httpClient;

        public AddGameWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private async void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GameDto newGame = new GameDto
                {
                    Title = titleTextBox.Text.Trim(),
                    Platform = platformTextBox.Text.Trim(),
                    Language = languageTextBox.Text.Trim(),
                    Price = (double)decimal.Parse(priceTextBox.Text.Trim()),
                    Pegi = pegiTextBox.Text.Trim(),
                };

                string json = JsonConvert.SerializeObject(newGame);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(ApiBaseUrl, content);
                response.EnsureSuccessStatusCode();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding a game: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}