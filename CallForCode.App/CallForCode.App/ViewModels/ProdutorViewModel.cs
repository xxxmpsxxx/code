using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CallForCode.App.ViewModels
{
    public class ProdutorViewModel : BaseViewModel
    {
        public ProdutorViewModel()
        {
            IsBusy = false;
            Task.Run(async () => await this.GetProdutor());           
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

        private Models.Produtor selectedProdutor;
        public Models.Produtor SelectedProdutor
        {
            get { return selectedProdutor; }
            set 
            {
                if (value == null) return;

                selectedProdutor = value;
                OnPropertyChanged(nameof(SelectedProdutor));

                MessagingCenter.Send<Models.Produtor>(selectedProdutor, "ProdutorSelected");
            }
        }


        public ObservableCollection<Models.Produtor> ListProdutor { get; private set; }

        public async Task GetProdutor()
        {
            var lstProdutor = new ObservableCollection<Models.Produtor>();

            try
            {
                if (!IsBusy)
                {
                    IsBusy = true;

                    var client = new Clients.IBMClient();
                    var result = await client.FindAllProdutor();

                    foreach (var item in result)
                    {
                        lstProdutor.Add(item);
                    }

                    if (this.ListProdutor == null)
                        this.ListProdutor = new ObservableCollection<Models.Produtor>();

                    this.ListProdutor = lstProdutor;

                    this.DataExists = this.ListProdutor.Count > default(int);

                    OnPropertyChanged(nameof(this.ListProdutor));

                    IsBusy = false;
                }
            }
            catch (Clients.ClientResponseException cEx)
            {
                MessagingCenter.Send<Models.AppException>(new Models.AppException(cEx.Message), "GetProdutorFail");
            }
            catch (Exception)
            {
                MessagingCenter.Send<Models.AppException>(new Models.AppException("Ocorreu um erro de comunicação com o servidor"), "GetProdutorFail");
            }
        }
    }
}
