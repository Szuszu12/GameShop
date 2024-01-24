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
    /// <summary>
    /// Interaction logic for AddProducerWindow.xaml
    /// </summary>
    public partial class AddProducerWindow : Window
    {
        private const string ApiBaseUrl = "https://localhost:7183/api/Producer";
        private HttpClient httpClient;

        public AddProducerWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private async void AddProducerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProducerDto newProducer = new ProducerDto
                {
                    ProducerName = producerNameTextBox.Text.Trim(),
                    ProducerDescrip = producerDescripTextBox.Text.Trim(),
                    ProducerCountry = producerCountryTextBox.Text.Trim()
                };

                string json = JsonConvert.SerializeObject(newProducer);
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