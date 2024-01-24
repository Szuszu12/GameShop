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
    public partial class OrderWindow : Window
    {
        private const string ApiBaseUrl = "https://localhost:7183/api/Order";
        private HttpClient httpClient;

        public OrderDto SelectedOrder { get; set; }

        public OrderWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            DataContext = this;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadOrders();
        }

        private async Task LoadOrders()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(ApiBaseUrl);
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                List<OrderDto> orders = JsonConvert.DeserializeObject<List<OrderDto>>(content);
                ordersListBox.ItemsSource = orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading orders: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private AddOrderWindow addOrderWindow;
        private async void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            addOrderWindow = new AddOrderWindow();
            addOrderWindow.Owner = this;
            addOrderWindow.ShowDialog();
            await LoadOrders();
        }

        private async void EditOrderButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedOrder = (OrderDto)ordersListBox.SelectedItem;

            if (SelectedOrder != null)
            {
                EditOrderWindow editOrderWindow = new EditOrderWindow(SelectedOrder);
                editOrderWindow.Owner = this;
                editOrderWindow.ShowDialog();

                await LoadOrders();
            }
            else
            {
                MessageBox.Show("Please select a client to edit.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            OrderDto selectedOrder = (OrderDto)ordersListBox.SelectedItem;

            if (selectedOrder != null)
            {
                try
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"{ApiBaseUrl}/{selectedOrder.Id}");
                    response.EnsureSuccessStatusCode();

                    await LoadOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting a game: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a game to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}