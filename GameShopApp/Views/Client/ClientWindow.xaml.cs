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
    public partial class ClientWindow : Window
    {
        private const string ApiBaseUrl = "https://localhost:7183/api/Client";
        private HttpClient httpClient;

        public ClientDto SelectedClient { get; set; }

        public ClientWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            DataContext = this;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadClients();
        }

        private async Task LoadClients()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(ApiBaseUrl);
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                List<ClientDto> clients = JsonConvert.DeserializeObject<List<ClientDto>>(content);
                clientsListBox.ItemsSource = clients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Podczas ładowania klientów pojawił się błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private AddClientWindow addClientWindow;

        private async void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            addClientWindow = new AddClientWindow();
            addClientWindow.Owner = this;
            addClientWindow.ShowDialog();

            await LoadClients();
        }

        private async void DeleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            ClientDto selectedClient = (ClientDto)clientsListBox.SelectedItem;

            if (selectedClient != null)
            {
                try
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"{ApiBaseUrl}/{selectedClient.Id}");
                    response.EnsureSuccessStatusCode();

                    await LoadClients();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Podczas usuwania klienta pojawił się błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Proszę wybrać klienta do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void EditClientButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedClient = (ClientDto)clientsListBox.SelectedItem;

            if (SelectedClient != null)
            {
                EditClientWindow editClientWindow = new EditClientWindow(SelectedClient);
                editClientWindow.Owner = this;
                editClientWindow.ShowDialog();

                await LoadClients();
            }
            else
            {
                MessageBox.Show("Proszę wybrać klienta do edytowania.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
