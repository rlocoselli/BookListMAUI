using BookList.Entities;
using BookList.Models;
using BookList.ViewModel;
using System.Collections.ObjectModel;

namespace BookList;

public partial class NarratifPage : ContentPage
{
	public NarratifPage()
	{
		InitializeComponent();
		LoadBooks();
		lstBooks.ItemsSource = this.Books;
		this.BindingContext = new BookViewModel(Navigation);
	}

	public ObservableCollection<BookBase> Books { get; set; } 

	private void LoadBooks()
	{
		BookBO bookBO = new BookBO();

		
		this.Books = bookBO.GetNarratif();
	}
}

