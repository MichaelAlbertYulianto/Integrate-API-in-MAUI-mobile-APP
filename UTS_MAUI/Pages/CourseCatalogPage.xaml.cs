using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using UTS_MAUI.Data;

namespace UTS_MAUI.Pages
{
    public partial class CoursesCatalogPage : ContentPage
    {
        private readonly APIManager _service;
        public ObservableCollection<Course> Courses { get; set; }

        public CoursesCatalogPage()
        {
            InitializeComponent();
            _service = new APIManager(new HttpClient());
            Courses = new ObservableCollection<Course>();
            CoursesCollectionView.ItemsSource = Courses;
            LoadCourses();
        }

        private async void LoadCourses()
        {
            try
            {
                var courses = await _service.GetCoursesAsync();
                Courses.Clear();

                if (courses != null)
                {
                    foreach (var course in courses)
                    {
                        Courses.Add(course);
                    }
                }
                else
                {
                    await DisplayAlert("Info", "No courses available", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load courses: {ex.Message}", "OK");
            }
        }

    }
}




