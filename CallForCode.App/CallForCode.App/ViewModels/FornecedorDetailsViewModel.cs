using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CallForCode.App.ViewModels
{
    public class FornecedorDetailsViewModel : BaseViewModel
    {
        public Models.Fornecedor FornecedorSelected { get; set; }

        public FornecedorDetailsViewModel(Models.Fornecedor fornecedor)
        {
            this.FornecedorSelected = fornecedor;

            this.CancelCommand = new Command(async () =>
            {
                MessagingCenter.Send<Models.Fornecedor>(new Models.Fornecedor(), "CancelClick");
            });
        }

        public ICommand CancelCommand { get; private set; }
    }
}
