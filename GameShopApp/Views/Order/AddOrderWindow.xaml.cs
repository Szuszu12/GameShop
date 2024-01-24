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
                //int clientId = int.Parse(clientIdTextBox.Text.Trim());

                OrderDto newOrder = new OrderDto
                {
                    OrderNumber = orderNumberTextBox.Text.Trim(),
                    OrderCost = double.Parse(orderCostTextBox.Text.Trim().Replace(',', '.'), CultureInfo.InvariantCulture) + 9.99,
                    //ClientId = clientId
                };

                string json = JsonConvert.SerializeObject(newOrder);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(ApiBaseUrl, content);
                response.EnsureSuccessStatusCode();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding an order: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}