using System.Collections.ObjectModel;
using Practica2Ev.ViewModel;

namespace Practica2Ev.Views;

public partial class View1 : ContentPage
{
	public View1()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        ObservableCollection<String> list = new ObservableCollection<String>();
        list = Validator.erroresInicio;

        if (list.Count() != 0)
        {
            await DisplayAlert("Error al inciar sesi�n", "El usuario o la contrase�a son INCORRECTOS", "ok");
        }
    }
}