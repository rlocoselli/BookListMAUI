using BookList.ViewModel;

namespace BookList;

public partial class MainPage : TabbedPage
{
	public MainPage()
	{
		BindingContext = new BookViewModel(Navigation);
		InitializeComponent();
	}
}
