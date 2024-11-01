using UTS_MAUI.Pages;
namespace UTS_MAUI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("courseDetail", typeof(CoursesCatalogPage));
    }
}
