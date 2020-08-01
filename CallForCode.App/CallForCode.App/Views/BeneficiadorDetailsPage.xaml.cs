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
    public partial class BeneficiadorDetailsPage : ContentPage
    {
        public BeneficiadorDetailsPage(Models.Beneficiador beneficiador)
        {
            InitializeComponent();
            this.BindingContext = new BeneficiadorDetailsViewModel(beneficiador);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Models.Beneficiador>(this, "CancelClick", (x) =>
            {
                Navigation.PopModalAsync();
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Models.Beneficiador>(this, "CancelClick");
        }
    }
}