using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CallForCode.App.ViewModels
{
    public class BeneficiadorDetailsViewModel : BaseViewModel
    {
        public Models.Beneficiador BeneficiadorSelected { get; set; }

        public BeneficiadorDetailsViewModel(Models.Beneficiador beneficiador)
        {
            this.BeneficiadorSelected = beneficiador;

            this.CancelCommand = new Command(async () =>
            {
                MessagingCenter.Send<Models.Beneficiador>(new Models.Beneficiador(), "CancelClick");
            });
        }

        public ICommand CancelCommand { get; set; }
    }
}
