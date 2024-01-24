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
    public partial class ProducerWindow : Window
    {
        private const string ApiBaseUrl = "https://localhost:7183/api/Producer";
        private HttpClient httpClient;

        public ProducerDto SelectedProducer { get; set; }

        public ProducerWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            DataContext = this;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadProducers();
        }

        private async Task LoadProducers()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(ApiBaseUrl);
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                List<ProducerDto> producers = JsonConvert.DeserializeObject<List<ProducerDto>>(content);
                producersListBox.ItemsSource = producers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Podczas ładowania producentów pojawił się błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private AddProducerWindow addProducerWindow;

        private async void AddProducerButton_Click(object sender, RoutedEventArgs e)
        {
            addProducerWindow = new AddProducerWindow();
            addProducerWindow.Owner = this;
            addProducerWindow.ShowDialog();

            await LoadProducers();
        }

        private async void DeleteProducerButton_Click(object sender, RoutedEventArgs e)
        {
            ProducerDto selectedProducer = (ProducerDto)producersListBox.SelectedItem;

            if (selectedProducer != null)
            {
                try
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"{ApiBaseUrl}/{selectedProducer.Id}");
                    response.EnsureSuccessStatusCode();

                    await LoadProducers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Podczas usuwania producenta pojawił się błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Proszę wybrać producenta do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void EditProducerButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedProducer = (ProducerDto)producersListBox.SelectedItem;

            if (SelectedProducer != null)
            {
                EditProducerWindow editProducerWindow = new EditProducerWindow(SelectedProducer);
                editProducerWindow.Owner = this;
                editProducerWindow.ShowDialog();

                await LoadProducers();
            }
            else
            {
                MessageBox.Show("Proszę wybrać producenta do edytowania.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}