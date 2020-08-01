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
    public partial class DistribuidorDetailsPage : ContentPage
    {
        public DistribuidorDetailsPage(Models.Distribuidor distribuidor)
        {
            InitializeComponent();
            this.BindingContext = new DistribuidorDetailsViewModel(distribuidor);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Models.Distribuidor>(this, "CancelClick", (x) =>
            {
                Navigation.PopModalAsync();
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Models.Distribuidor>(this, "CancelClick");
        }
    }
}