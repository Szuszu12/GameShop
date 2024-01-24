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

namespace GameShopApp.Views.Category
{
    /// <summary>
    /// Interaction logic for AddCategoryWindow.xaml
    /// </summary>
    public partial class AddCategoryWindow : Window
    {
        private const string ApiBaseUrl = "https://localhost:7183/api/Category";
        private readonly HttpClient httpClient;

        public AddCategoryWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private async void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CategoryDto newCategory = new CategoryDto
                {
                    CategoryName = categoryNameTextBox.Text.Trim()
                };

                string json = JsonConvert.SerializeObject(newCategory);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(ApiBaseUrl, content);
                response.EnsureSuccessStatusCode();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Podczas dodawania kategorii pojawił się błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}