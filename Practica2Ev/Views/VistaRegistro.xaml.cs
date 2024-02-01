using System.Collections.ObjectModel;
using System.Diagnostics;
using Practica2Ev.ViewModel;

namespace Practica2Ev.Views;

public partial class VistaRegistro : ContentPage
{
    private bool porta = false;

	public VistaRegistro()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        ObservableCollection<String> list = new ObservableCollection<String>();
        list = Validator.errores;

        if (list.Count() != 0)
        {
            String temp = "";
            foreach (var item in list.ToList())
            {
                temp += (item + "\n");
            }
            await DisplayAlert("Error al crear la cuenta", temp, "ok");
        }
    }

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        Label valor = (Label)sender;
        String valorTexto = valor.Text;

        if (porta)
        {
            switch (valorTexto)
            {
                case "Nombre":
                    Nombre.Text += await Clipboard.GetTextAsync();
                    break;
                case "Nombre Usuario":
                    NombreUsuario.Text += await Clipboard.GetTextAsync();
                    break;
                case "Contraseña":
                    Password.Text += await Clipboard.GetTextAsync();
                    break;
                case "Confirmar Contraseña":
                    ConfirmacionContraseña.Text += await Clipboard.GetTextAsync();
                    break;
                case "Edad":
                    Edad.Text += await Clipboard.GetTextAsync();
                    break;
            }
            porta = false;
        }
        else
        {
            switch (valorTexto)
            {
                case "Nombre":
                    Clipboard.SetTextAsync(Nombre.Text);
                    break;
                case "Nombre Usuario":
                    Clipboard.SetTextAsync(NombreUsuario.Text);
                    break;
                case "Contraseña":
                    Clipboard.SetTextAsync(Password.Text);
                    break;
                case "Confirmar Contraseña":
                    Clipboard.SetTextAsync(ConfirmacionContraseña.Text);
                    break;
                case "Edad":
                    Clipboard.SetTextAsync(Edad.Text);
                    break;
            }
            porta = true;
        }
    }
}