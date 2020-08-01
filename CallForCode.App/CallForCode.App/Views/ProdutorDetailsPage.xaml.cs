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
    public partial class ProdutorDetailsPage : ContentPage
    {
        public ProdutorDetailsPage(Models.Produtor produtor)
        {
            InitializeComponent();
            this.BindingContext = new ProdutorDetailsViewModel(produtor);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Models.Produtor>(this, "CancelClick", (x) =>
            {
                Navigation.PopModalAsync();
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Models.Produtor>(this, "CancelClick");
        }
    }
}