using System.Collections.ObjectModel;
using ProjAula.Models;

namespace ProjAula
{
    public partial class MainPage : ContentPage
    {        

        ObservableCollection<Estado> lista = new ObservableCollection<Estado>();

        public MainPage()
        {
            InitializeComponent();

            ListEstado.ItemsSource = lista;
            
        }

        protected override async void OnAppearing()
        {
            await carregarListaEstados();
        }

        private async Task carregarListaEstados()
        {
            List<Estado> tmp = await App.Db.GetAll();

            lista.Clear();

            foreach (Estado estado in tmp)
            {
                lista.Add(estado);
            }
        }

        private async void btnInserir_Clicked(object sender, EventArgs e)
        {
            Estado est = new Estado();
            est.Nome = txtNome.Text;

            await App.Db.Insert(est);
            await DisplayAlert("Sucesso!", "Registro inserido.", "OK");

            await carregarListaEstados();
        }

        private async void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string q = e.NewTextValue;

            lista.Clear();

            List<Estado> tmp = await App.Db.Search(q);

            foreach (Estado estado in tmp)
            {
                lista.Add(estado);
            }
        }
    }

}
