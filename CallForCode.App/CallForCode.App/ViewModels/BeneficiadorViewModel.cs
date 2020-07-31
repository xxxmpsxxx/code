using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CallForCode.App.ViewModels
{
    public class BeneficiadorViewModel : BaseViewModel
    {
        public BeneficiadorViewModel()
        {
            IsBusy = false;
            Task.Run(async () => await this.GetBeneficiador());
        }

        private bool dataExists = false;
        public bool DataExists
        {
            get { return dataExists; }
            set
            {
                dataExists = value;
                OnPropertyChanged(nameof(DataExists));
            }
        }

        private Models.Beneficiador selectedBeneficiador;
        public Models.Beneficiador SelectedBeneficiador
        {
            get { return selectedBeneficiador; }
            set
            {
                if (value == null) return;

                selectedBeneficiador = value;
                OnPropertyChanged(nameof(SelectedBeneficiador));

                MessagingCenter.Send<Models.Beneficiador>(selectedBeneficiador, "BeneficiadorSelected");
            }
        }


        public ObservableCollection<Models.Beneficiador> ListBeneficiador { get; private set; }

        public async Task GetBeneficiador()
        {
            var lstBeneficiador = new ObservableCollection<Models.Beneficiador>();

            try
            {
                if (!IsBusy)
                {
                    IsBusy = true;

                    var client = new Clients.IBMClient();
                    var result = await client.FindAllBeneficiador();

                    foreach (var item in result)
                    {
                        lstBeneficiador.Add(item);
                    }

                    if (this.ListBeneficiador == null)
                        this.ListBeneficiador = new ObservableCollection<Models.Beneficiador>();

                    this.ListBeneficiador = lstBeneficiador;

                    this.DataExists = this.ListBeneficiador.Count > default(int);

                    OnPropertyChanged(nameof(this.ListBeneficiador));

                    IsBusy = false;
                }
            }
            catch (Clients.ClientResponseException cEx)
            {
                MessagingCenter.Send<Models.AppException>(new Models.AppException(cEx.Message), "GetBeneficiadorFail");
            }
            catch (Exception)
            {
                MessagingCenter.Send<Models.AppException>(new Models.AppException("Ocorreu um erro de comunicação com o servidor"), "GetBeneficiadorFail");
            }
        }
    }
}
