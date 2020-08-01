using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CallForCode.App.ViewModels
{
    public class ProdutorDetailsViewModel : BaseViewModel
    {
        public Models.Produtor ProdutorSelected { get; set; }

        public ProdutorDetailsViewModel(Models.Produtor produtor)
        {
            this.ProdutorSelected = produtor;

            this.CancelCommand = new Command(async () =>
            {
                MessagingCenter.Send<Models.Produtor>(new Models.Produtor(), "CancelClick");
            });
        }

        public ICommand CancelCommand { get; set; }
    }
}
