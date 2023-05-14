using BookList.ViewModel;

namespace BookList;

public partial class NewBook : ContentPage
{
	public NewBook()
	{
		BindingContext = new NewBookViewModel(Navigation);

        InitializeComponent();
	}
}