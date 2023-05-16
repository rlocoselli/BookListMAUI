using BookList.Entities;
using BookList.ViewModel;

namespace BookList;

public partial class NewBook : ContentPage
{
	public NewBook()
	{
		BindingContext = new NewBookViewModel(Navigation);

        InitializeComponent();
	}
    public NewBook(BookBase book)
    {
        var viewModel = new NewBookViewModel(Navigation);

        viewModel.Title = book.BookName;

        BindingContext = viewModel;

        InitializeComponent();
    }
}