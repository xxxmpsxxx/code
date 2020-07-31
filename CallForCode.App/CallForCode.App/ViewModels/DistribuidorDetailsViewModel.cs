using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CallForCode.App.ViewModels
{
    public class DistribuidorDetailsViewModel : BaseViewModel
    {
        public Models.Distribuidor DistribuidorSelected { get; set; }

        public DistribuidorDetailsViewModel(Models.Distribuidor distribuidor)
        {
            this.DistribuidorSelected = distribuidor;

            this.CancelCommand = new Command(async () =>
            {
                MessagingCenter.Send<Models.Distribuidor>(new Models.Distribuidor(), "CancelClick");
            });
        }

        public ICommand CancelCommand { get; set; }
    }
}
