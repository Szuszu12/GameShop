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
    public partial class AddClientWindow : Window
    {
        private const string ApiBaseUrl = "https://localhost:7183/api/Client";
        private HttpClient httpClient;

        public AddClientWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private async void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClientDto newClient = new ClientDto
                {
                    Name = nameTextBox.Text.Trim(),
                    PhoneNumber = phoneNumberTextBox.Text.Trim(),
                    Email = emailTextBox.Text.Trim(),
                    Address = addressTextBox.Text.Trim(),
                    PostalCode = postalCodeTextBox.Text.Trim(),
                    City = cityTextBox.Text.Trim(),
                    Region = regionTextBox.Text.Trim(),
                    Country = countryTextBox.Text.Trim()
                };

                string json = JsonConvert.SerializeObject(newClient);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(ApiBaseUrl, content);
                response.EnsureSuccessStatusCode();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Podczas dodawania klienta pojawił się błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}