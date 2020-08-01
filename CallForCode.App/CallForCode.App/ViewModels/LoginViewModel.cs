using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CallForCode.App.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {            
            this.GoogleSigninCommand = new Command(() =>
            {
                MessagingCenter.Send<Models.Login>(new Models.Login(), "LoginSuccess");
            });

            this.FacebookSigninCommand = new Command(() =>
            {
                MessagingCenter.Send<Models.Login>(new Models.Login(), "LoginSuccess");
            });

            this.GIPESigninCommand = new Command(() =>
            {
                MessagingCenter.Send<Models.Login>(new Models.Login(), "LoginSuccess");
            });
        }

        public ICommand GoogleSigninCommand { get; set; }
        public ICommand FacebookSigninCommand { get; set; }
        public ICommand GIPESigninCommand { get; set; }
                      
    }
}
