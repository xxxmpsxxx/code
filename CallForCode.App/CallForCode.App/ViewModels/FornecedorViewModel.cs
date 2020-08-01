using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CallForCode.App.ViewModels
{
    public class FornecedorViewModel : BaseViewModel
    {
        public FornecedorViewModel()
        {
            IsBusy = false;
            Task.Run(async () => await this.GetFornecedor());
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

        private Models.Fornecedor selectedFornecedor;
        public Models.Fornecedor SelectedFornecedor
        {
            get { return selectedFornecedor; }
            set
            {
                if (value == null) return;

                selectedFornecedor = value;
                OnPropertyChanged(nameof(SelectedFornecedor));

                MessagingCenter.Send<Models.Fornecedor>(selectedFornecedor, "FornecedorSelected");
            }
        }


        public ObservableCollection<Models.Fornecedor> ListFornecedor { get; private set; }

        public async Task GetFornecedor()
        {
            var lstFornecedor = new ObservableCollection<Models.Fornecedor>();

            try
            {
                if (!IsBusy)
                {
                    IsBusy = true;

                    var client = new Clients.IBMClient();
                    var result = await client.FindAllFornecedor();

                    foreach (var item in result)
                    {
                        lstFornecedor.Add(item);
                    }

                    if (this.ListFornecedor == null)
                        this.ListFornecedor = new ObservableCollection<Models.Fornecedor>();

                    this.ListFornecedor = lstFornecedor;

                    this.DataExists = this.ListFornecedor.Count > default(int);

                    OnPropertyChanged(nameof(this.ListFornecedor));

                    IsBusy = false;
                }
            }
            catch (Clients.ClientResponseException cEx)
            {
                MessagingCenter.Send<Models.AppException>(new Models.AppException(cEx.Message), "GetFornecedorFail");
            }
            catch (Exception)
            {
                MessagingCenter.Send<Models.AppException>(new Models.AppException("Ocorreu um erro de comunicação com o servidor"), "GetFornecedorFail");
            }
        }
    }
}
