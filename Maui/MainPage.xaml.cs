using PrototipoMejoraContinua2.Resources.raw;

namespace PrototipoMejoraContinua2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnInicioSesion(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InicioSesion());
        }
        private async void btnRegistro(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }
    }

}
