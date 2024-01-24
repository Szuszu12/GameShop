using GameShopApiClient;
using GameShopApp.Views.Category;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameShopApp
{
    public partial class CategoryWindow : Window
    {
        private const string ApiBaseUrl = "https://localhost:7183/api/Category";
        private readonly HttpClient httpClient;

        public CategoryDto SelectedCategory { get; set; }

        public CategoryWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            DataContext = this;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadCategories();
        }

        private async Task LoadCategories()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(ApiBaseUrl);
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                List<CategoryDto> categories = JsonConvert.DeserializeObject<List<CategoryDto>>(content);
                categoriesListBox.ItemsSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Podczas ładowania kategorii pojawił się błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            AddCategoryWindow addCategoryWindow = new AddCategoryWindow();
            addCategoryWindow.Owner = this;
            addCategoryWindow.ShowDialog();

            await LoadCategories();
        }

        private async void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryDto selectedCategory = (CategoryDto)categoriesListBox.SelectedItem;

            if (selectedCategory != null)
            {
                try
                {
                    HttpResponseMessage response = await httpClient.DeleteAsync($"{ApiBaseUrl}/{selectedCategory.Id}");
                    response.EnsureSuccessStatusCode();

                    await LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Podczas usuwania kategorii pojawił się błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Proszę wybrać kategorię do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void EditCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedCategory = (CategoryDto)categoriesListBox.SelectedItem;

            if (SelectedCategory != null)
            {
                EditCategoryWindow editCategoryWindow = new EditCategoryWindow(SelectedCategory);
                editCategoryWindow.Owner = this;
                editCategoryWindow.ShowDialog();

                await LoadCategories();
            }
            else
            {
                MessageBox.Show("Proszę wybrać kategorię do edytowania.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}