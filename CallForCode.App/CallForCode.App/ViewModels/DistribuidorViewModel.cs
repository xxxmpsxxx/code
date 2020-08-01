using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CallForCode.App.ViewModels
{
    public class DistribuidorViewModel : BaseViewModel
    {
        public DistribuidorViewModel()
        {
            IsBusy = false;
            Task.Run(async () => await this.GetDistribuidor());
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

        private Models.Distribuidor selectedDistribuidor;
        public Models.Distribuidor SelectedDistribuidor
        {
            get { return selectedDistribuidor; }
            set
            {
                if (value == null) return;

                selectedDistribuidor = value;
                OnPropertyChanged(nameof(SelectedDistribuidor));

                MessagingCenter.Send<Models.Distribuidor>(selectedDistribuidor, "DistribuidorSelected");
            }
        }


        public ObservableCollection<Models.Distribuidor> ListDistribuidor { get; private set; }

        public async Task GetDistribuidor()
        {
            var lstDistribuidor = new ObservableCollection<Models.Distribuidor>();

            try
            {
                if (!IsBusy)
                {
                    IsBusy = true;

                    var client = new Clients.IBMClient();
                    var result = await client.FindAllDistribuidor();

                    foreach (var item in result)
                    {
                        lstDistribuidor.Add(item);
                    }

                    if (this.ListDistribuidor == null)
                        this.ListDistribuidor = new ObservableCollection<Models.Distribuidor>();

                    this.ListDistribuidor = lstDistribuidor;

                    this.DataExists = this.ListDistribuidor.Count > default(int);

                    OnPropertyChanged(nameof(this.ListDistribuidor));

                    IsBusy = false;
                }
            }
            catch (Clients.ClientResponseException cEx)
            {
                MessagingCenter.Send<Models.AppException>(new Models.AppException(cEx.Message), "GetDistribuidorFail");
            }
            catch (Exception)
            {
                MessagingCenter.Send<Models.AppException>(new Models.AppException("Ocorreu um erro de comunicação com o servidor"), "GetDistribuidorFail");
            }
        }
    }
}
