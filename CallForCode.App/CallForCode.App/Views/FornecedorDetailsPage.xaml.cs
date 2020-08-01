using CallForCode.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CallForCode.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FornecedorDetailsPage : ContentPage
    {
        public FornecedorDetailsPage(Models.Fornecedor fornecedor)
        {
            InitializeComponent();
            this.BindingContext = new FornecedorDetailsViewModel(fornecedor);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Models.Fornecedor>(this, "CancelClick", (x) =>
            {
                Navigation.PopModalAsync();
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Models.Fornecedor>(this, "CancelClick");
        }
    }
}