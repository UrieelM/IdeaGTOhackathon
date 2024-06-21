namespace PrototipoMejoraContinua2;

public partial class InicioSesion : ContentPage
{
	public InicioSesion()
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
}