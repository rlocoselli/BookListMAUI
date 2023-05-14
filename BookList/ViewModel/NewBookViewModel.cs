using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using BookList.Models;

namespace BookList.ViewModel
{
    public partial class NewBookViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;

        public event PropertyChangedEventHandler PropertyChanged;

        public String Title { get; set; }

        public Command CreateBookBtn { get; }

        public NewBookViewModel(INavigation navigation)
        {
            this._navigation = navigation;
            this.CreateBookBtn = new Command(BookAddBtnTappedAsync);
        }

        private async void BookAddBtnTappedAsync (object obj)
        {
            try
            {
                BookBO book = new BookBO();

                book.CreateNarratif(this.Title);
                await App.Current.MainPage.DisplayAlert("Alert", "Book created successfully", "OK");

                await this._navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

    }
}
