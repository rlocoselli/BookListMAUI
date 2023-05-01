using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList.ViewModel
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _username;
        [ObservableProperty]
        private string _password;
        private INavigation _navigation;

        public Command RegisterBtn { get; }

        public LoginPageViewModel(INavigation navigation)
        {
            this._navigation = navigation;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
        }

        private void RegisterBtnTappedAsync (object obj)
        {
            this._navigation.PushAsync(new RegisterPage());
        }

    }
}
