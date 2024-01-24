using GameShopApiClient;
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

        public CategoryWindow()
        {
            InitializeComponent();
            httpClient = new HttpClient();
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
                MessageBox.Show($"Wystąpił błąd podczas pobierania kategorii: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

                await LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas dodawania kategorii: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
                    MessageBox.Show($"Wystąpił błąd podczas usuwania kategorii: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć kategorię do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void EditCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryDto selectedCategory = (CategoryDto)categoriesListBox.SelectedItem;

            if (selectedCategory != null)
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"{ApiBaseUrl}/{selectedCategory.Id}");
                    response.EnsureSuccessStatusCode();
                    string content = await response.Content.ReadAsStringAsync();
                    CategoryDto updatedCategory = JsonConvert.DeserializeObject<CategoryDto>(content);

                    categoryNameTextBox.Text = updatedCategory.CategoryName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas pobierania danych kategorii do edycji: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć kategorię do edycji.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void UpdateCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryDto selectedCategory = (CategoryDto)categoriesListBox.SelectedItem;

            if (selectedCategory != null)
            {
                try
                {
                    CategoryDto updatedCategory = new CategoryDto
                    {
                        Id = selectedCategory.Id,
                        CategoryName = categoryNameTextBox.Text.Trim()
                    };

                    string json = JsonConvert.SerializeObject(updatedCategory);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PutAsync($"{ApiBaseUrl}/{updatedCategory.Id}", content);
                    response.EnsureSuccessStatusCode();

                    await LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas aktualizowania kategorii: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć kategorię do aktualizacji.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
