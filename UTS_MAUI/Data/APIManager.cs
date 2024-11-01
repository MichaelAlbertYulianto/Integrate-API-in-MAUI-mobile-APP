using System.Text;
using System.Net.Http.Json;
using System.Text.Json;

namespace UTS_MAUI.Data
{
    public class APIManager
    {
        private readonly HttpClient _httpClient;
        private const string CoursesEndpoint = "api/Courses";
        private const string CategoriesEndpoint = "api/v1/Categories";

        public APIManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://actualbackendapp.azurewebsites.net/");
        }

        // Course Services
        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            var response = await _httpClient.GetAsync(CoursesEndpoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Course>>();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{CoursesEndpoint}/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Course>(content);
        }

        public async Task AddCourseAsync(Course course)
        {
            var content = new StringContent(JsonSerializer.Serialize(course), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(CoursesEndpoint, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            var content = new StringContent(JsonSerializer.Serialize(course), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{CoursesEndpoint}/{course.courseId}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCourseAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{CoursesEndpoint}/{id}");
            response.EnsureSuccessStatusCode();
        }

        // Category Services
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetAsync(CategoriesEndpoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Category>>();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{CategoriesEndpoint}/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Category>(content);
        }

        public async Task AddCategoryAsync(Category category)
        {
            var content = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(CategoriesEndpoint, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var content = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{CategoriesEndpoint}/{category.CategoryId}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{CategoriesEndpoint}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}