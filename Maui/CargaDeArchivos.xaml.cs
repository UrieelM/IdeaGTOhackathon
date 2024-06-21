using System.IO;

namespace PrototipoMejoraContinua2;

public partial class CargaDeArchivos : ContentPage
{
    MemoryStream memoryStream;
    public CargaDeArchivos()
	{
		InitializeComponent();
	}

    private async void OnSelectFileButtonClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Pdf,
                PickerTitle = "Seleccione un archivo PDF"
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                // Liberar recursos si ya existe un MemoryStream
                if (memoryStream != null)
                {
                    memoryStream.Dispose();
                    memoryStream = null;
                }

                memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                stream.Close();

                // Ocultar imagen predeterminada
                placeholderImage.IsVisible = false;

                // Convertir a base64
                var base64 = Convert.ToBase64String(memoryStream.ToArray());
                var base64PDF = $"data:application/pdf;base64,{base64}";

                // Mostrar PDF en WebView
                pdfWebView.Source = new HtmlWebViewSource
                {
                    Html = $"<html><body style='margin:0;padding:0'><embed src='{base64PDF}' type='application/pdf' width='100%' height='100%'></embed></body></html>"
                };

                pdfWebView.IsVisible = true;
                removeFileButton.IsEnabled = true; // Habilitar el botón de eliminar
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
    }

    private void OnRemoveFileButtonClicked(object sender, EventArgs e)
    {
        // Mostrar imagen predeterminada y ocultar WebView
        placeholderImage.IsVisible = true;
        pdfWebView.Source = null; // Limpiar el contenido de WebView
        pdfWebView.IsVisible = false;

        // Liberar recursos de memoria
        if (memoryStream != null)
        {
            memoryStream.Dispose();
            memoryStream = null;
        }

        removeFileButton.IsEnabled = false; // Deshabilitar el botón de eliminar
    }

    private async void btnCargaDeArchivos(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Tramites());
    }
}