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

namespace BookList.ViewModel
{
    public partial class RegistrationViewModel : INotifyPropertyChanged
    {
        public string Email { get => email; 
            set
            {
                email = value;
                RaisePropertyChanged("EMail");
            }
        }
        public string Password { get => password; set => password = value; }

        private string email;
        private string password;

        private INavigation _navigation;

        public event PropertyChangedEventHandler PropertyChanged;

        public Command RegisterUser { get; }

        private IConfiguration _configuration;

        public RegistrationViewModel(INavigation navigation, IConfiguration config)
        {
            this._navigation = navigation;
            RegisterUser = new Command(RegisterUserBtnTappedAsync);
            _configuration = config;
        }

        private void RaisePropertyChanged(string v) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));

        private async void RegisterUserBtnTappedAsync (object obj)
        {
            try
            {
                var settings = _configuration.GetRequiredSection("Settings").Get<Settings>();

                var config = new FirebaseAuthConfig
                {
                    ApiKey = settings.ApiKey,
                    AuthDomain = settings.AuthDomain,
                    Providers = new FirebaseAuthProvider[]
                    {
                        new EmailProvider()                        
                    },
                };

                var client = new FirebaseAuthClient(config);

                var auth = await client.CreateUserWithEmailAndPasswordAsync(this.Email, this.Password);

                await App.Current.MainPage.DisplayAlert("Info", "User registered successfully", "OK");

                await this._navigation.PushAsync(new LoginPage(_configuration));
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

    }
}
