using BookList.ViewModel;
using Microsoft.Extensions.Configuration;

namespace BookList;

public partial class RegisterPage : ContentPage
{
	IConfiguration configuration;
	public RegisterPage(IConfiguration config)
	{
		InitializeComponent();
		configuration = config;
		BindingContext = new RegistrationViewModel(Navigation, config);
	}
}