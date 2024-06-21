namespace PrototipoMejoraContinua2.Resources.raw;

public partial class Registro : ContentPage
{
	public Registro()
	{
		InitializeComponent();
	}

    private async void showPassword(object sender, EventArgs e)
    {
        if (entryPassword.IsPassword == true)
        {
            eyeImage.Source = "eyeenabled.png";
        }
        else
        {
            eyeImage.Source = "eyedisabled.png";
        }

        if (entryPassword.IsPassword == true)
        {
            entryPassword.IsPassword = false;
        }
        else
        {
            entryPassword.IsPassword = true;
        }
    }

    private async void btnRegistro(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ConfiguracionPerfil());
    }
}