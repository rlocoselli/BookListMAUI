using BookList.ViewModel;
using Microsoft.Extensions.Configuration;

namespace BookList;

public partial class LoginPage : ContentPage
{
    IConfiguration configuration;

    public LoginPage(IConfiguration config)
	{
		InitializeComponent();
        BindingContext = new LoginPageViewModel(Navigation, config);
        configuration = config;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Shell.SetTabBarIsVisible(this, false);
        Shell.SetNavBarIsVisible(this, false);

        var settings = configuration.GetRequiredSection("Settings").Get<Settings>();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Shell.SetTabBarIsVisible(this, true);
        Shell.SetNavBarIsVisible(this, true);
    }
}