using GameShopApiClient;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace GameShopApp
{
    public partial class AddOrderWindow : Window
    {
        private const string ApiBaseUrl = "https://localhost:7183/api/Order";
        private HttpClient httpClient;

        public AddOrderWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private async void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                OrderDto newOrder = new OrderDto
                {
                    OrderNumber = orderNumberTextBox.Text.Trim(),
                    OrderCost = double.Parse(orderCostTextBox.Text.Trim().Replace(',', '.'), CultureInfo.InvariantCulture) + 9.99,
                };

                string json = JsonConvert.SerializeObject(newOrder);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(ApiBaseUrl, content);
                response.EnsureSuccessStatusCode();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Podczas dodawania zamówienia pojawił się błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}