using System;
using System.Linq;
using Microsoft.Maui.Controls;
using UTS_MAUI.Data;

namespace UTS_MAUI.Pages
{
    public partial class CategoryCatalogPage : ContentPage
    {
        private readonly APIManager _apiManager;

        public CategoryCatalogPage()
        {
            InitializeComponent();
            _apiManager = new APIManager(new HttpClient());
            LoadCategories();
        }

        private async void LoadCategories()
        {
            try
            {
                // Fetch categories from API
                var categories = await _apiManager.GetCategoriesAsync();
                // Bind categories to ListView
                CategoryListView.ItemsSource = categories.ToList();
            }
            catch (Exception ex)
            {
                // Handle any errors, for instance, show an alert
                await DisplayAlert("Error", $"Failed to load categories: {ex.Message}", "OK");
            }
        }
    }
}
