namespace PrototipoMejoraContinua2;

public partial class ConfiguracionPerfil : ContentPage
{
	public ConfiguracionPerfil()
	{
		InitializeComponent();
	}

    private async void btnContinuar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CargaDeArchivos());
    }
}