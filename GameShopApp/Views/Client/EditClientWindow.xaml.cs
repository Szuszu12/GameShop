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
    public partial class EditClientWindow : Window
    {
        private const string ApiBaseUrl = "https://localhost:7183/api/Client";
        private HttpClient httpClient;
        public ClientDto SelectedClient { get; set; }

        public EditClientWindow(ClientDto selectedClient)
        {
            InitializeComponent();
            httpClient = new HttpClient();
            SelectedClient = selectedClient;

            if (SelectedClient != null)
            {
                nameTextBox.Text = SelectedClient.Name;
                phoneNumberTextBox.Text = SelectedClient.PhoneNumber;
                emailTextBox.Text = SelectedClient.Email;
                addressTextBox.Text = SelectedClient.Address;
                postalCodeTextBox.Text = SelectedClient.PostalCode;
                cityTextBox.Text = SelectedClient.City;
                regionTextBox.Text = SelectedClient.Region;
                countryTextBox.Text = SelectedClient.Country;
            }
        }

        private async void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedClient != null)
            {
                try
                {
                    SelectedClient.Name = nameTextBox.Text.Trim();
                    SelectedClient.PhoneNumber = phoneNumberTextBox.Text.Trim();
                    SelectedClient.Email = emailTextBox.Text.Trim();
                    SelectedClient.Address = addressTextBox.Text.Trim();
                    SelectedClient.PostalCode = postalCodeTextBox.Text.Trim();
                    SelectedClient.City = cityTextBox.Text.Trim();
                    SelectedClient.Region = regionTextBox.Text.Trim();
                    SelectedClient.Country = countryTextBox.Text.Trim();

                    string json = JsonConvert.SerializeObject(SelectedClient);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PutAsync($"{ApiBaseUrl}/{SelectedClient.Id}", content);
                    response.EnsureSuccessStatusCode();

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Podczas zapisywania zmian wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}