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
    /// Interaction logic for EditCategoryWindow.xaml
    /// </summary>
    public partial class EditCategoryWindow : Window
    {
        private const string ApiBaseUrl = "https://localhost:7183/api/Category";
        private HttpClient httpClient;
        public CategoryDto SelectedCategory { get; set; }

        public EditCategoryWindow(CategoryDto selectedCategory)
        {
            InitializeComponent();
            httpClient = new HttpClient();
            SelectedCategory = selectedCategory;

            if (SelectedCategory != null)
            {
                categoryNameTextBox.Text = SelectedCategory.CategoryName;
            }
        }

        private async void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCategory != null)
            {
                try
                {
                    SelectedCategory.CategoryName = categoryNameTextBox.Text.Trim();

                    string json = JsonConvert.SerializeObject(SelectedCategory);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PutAsync($"{ApiBaseUrl}/{SelectedCategory.Id}", content);
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