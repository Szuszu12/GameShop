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
    /// Interaction logic for EditProducerWindow.xaml
    /// </summary>
    public partial class EditProducerWindow : Window
    {
        private const string ApiBaseUrl = "https://localhost:7183/api/Producer";
        private HttpClient httpClient;
        private int producerId;

        public EditProducerWindow(ProducerDto selectedProducer)
        {
            InitializeComponent();
            producerId = selectedProducer.Id;
            httpClient = new HttpClient();
            LoadProducerData();
        }

        private async void LoadProducerData()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{ApiBaseUrl}/{producerId}");
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                ProducerDto producer = JsonConvert.DeserializeObject<ProducerDto>(json);

                producerNameTextBox.Text = producer.ProducerName;
                producerDescripTextBox.Text = producer.ProducerDescrip;
                producerCountryTextBox.Text = producer.ProducerCountry;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Podczas ładowania danych producenta pojawił się błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void UpdateProducerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProducerDto updatedProducer = new ProducerDto
                {
                    Id = producerId,
                    ProducerName = producerNameTextBox.Text.Trim(),
                    ProducerDescrip = producerDescripTextBox.Text.Trim(),
                    ProducerCountry = producerCountryTextBox.Text.Trim()
                };

                string json = JsonConvert.SerializeObject(updatedProducer);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PutAsync($"{ApiBaseUrl}/{producerId}", content);
                response.EnsureSuccessStatusCode();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Podczas zapisywania zmian pojawił się błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}