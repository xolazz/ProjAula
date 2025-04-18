
using ProjAula.Models;

namespace ProjAula
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnInserir_Clicked(object sender, EventArgs e)
        {
            Estado est = new Estado();
            est.Nome = txtNome.Text;

            App.Db.Insert(est);
            DisplayAlert("Sucesso!", "Registro inserido.", "OK");
        }
    }

}
