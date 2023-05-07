namespace BookList;

public partial class App : Application
{
	public App(LoginPage page)
	{
		InitializeComponent();

		MainPage = new NavigationPage(page);
	}
}
