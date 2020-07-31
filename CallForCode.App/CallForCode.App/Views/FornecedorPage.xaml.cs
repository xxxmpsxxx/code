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
    public partial class FornecedorPage : ContentPage
    {
        public FornecedorPage()
        {
            InitializeComponent();

            this.BindingContext = new ViewModels.FornecedorViewModel();

            this.ListViewFornecedor.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                if (e.SelectedItem == null) return;
                Task.Delay(500);
                if (sender is ListView lv) lv.SelectedItem = null;
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Models.AppException>(this, "GetFornecedorFail", async (x) =>
            {
                await DisplayAlert("Atenção", x.Message, "OK");
            });

            MessagingCenter.Subscribe<Models.Fornecedor>(this, "FornecedorSelected", async (x) =>
            {
                await Navigation.PushModalAsync(new FornecedorDetailsPage(x));
            });
        }
    }
}