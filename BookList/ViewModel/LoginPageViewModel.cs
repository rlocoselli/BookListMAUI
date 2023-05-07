using Firebase.Auth.Providers;
using Firebase.Auth;
using Microsoft.Extensions.Configuration;
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
        
        public String UserName { get; set; }

        public String UserPassword { get; set; }

        private INavigation _navigation;
        public Command RegisterBtn { get; }
        public Command LoginBtn { get; }

        private IConfiguration _configuration;

        public LoginPageViewModel(INavigation navigation, IConfiguration config)
        {
            this._navigation = navigation;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAsync);
            _configuration = config;
        }

        private async void LoginBtnTappedAsync(object obj)
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


            try
            {

                UserCredential auth = await client.SignInWithEmailAndPasswordAsync(UserName, UserPassword);
            
                if (auth.User == null)
                {
                    await App.Current.MainPage.DisplayAlert("Info", "Authentication failed", "OK");
                }
                else
                {
                    await this._navigation.PushAsync(new MainPage());
                }
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Info", ex.Message, "OK");
            }
        }

        private void RegisterBtnTappedAsync (object obj)
        {
            this._navigation.PushAsync(new RegisterPage(_configuration));
        }

    }
}
