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
    public partial class EditOrderWindow : Window
    {
        private const string ApiBaseUrl = "https://localhost:7183/api/Order";
        private HttpClient httpClient;
        public OrderDto SelectedOrder { get; set; }

        public EditOrderWindow(OrderDto selectedOrder)
        {
            InitializeComponent();
            httpClient = new HttpClient();
            SelectedOrder = selectedOrder;

            // Fill TextBoxes with order data
            if (SelectedOrder != null)
            {
                orderNumberTextBox.Text = SelectedOrder.OrderNumber;
                orderCostTextBox.Text = SelectedOrder.OrderCost.ToString();
                //clientIdTextBox.Text = SelectedOrder.ClientId.ToString();
                //gameIdTextBox.Text = SelectedOrder.GameId.ToString();
            }
        }

        private async void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedOrder != null)
            {
                try
                {
                    SelectedOrder.OrderNumber = orderNumberTextBox.Text.Trim();
                    SelectedOrder.OrderCost = double.Parse(orderCostTextBox.Text.Trim());
                    //SelectedOrder.ClientId = int.Parse(clientIdTextBox.Text.Trim());
                    //SelectedOrder.GameId = int.Parse(gameIdTextBox.Text.Trim());

                    string json = JsonConvert.SerializeObject(SelectedOrder);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PutAsync($"{ApiBaseUrl}/{SelectedOrder.Id}", content);
                    response.EnsureSuccessStatusCode();

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving changes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
