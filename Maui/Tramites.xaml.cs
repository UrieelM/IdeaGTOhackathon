namespace PrototipoMejoraContinua2;

public partial class Tramites : ContentPage
{
	public Tramites()
	{
		InitializeComponent();
	}
    private async void btnTramite(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProcesoDeTramite());
    }
}