using Practica2Ev.Model;
using Practica2Ev.Templates;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Practica2Ev.Views;

public partial class Favoritos : Plantilla
{
    private static int op = -1;
    private static ObservableCollection<Chiste> listado = new ObservableCollection<Chiste>();

    public Favoritos()
	{
		InitializeComponent();
        listado = App.Repository.getFavs();
        listadoChistes.ItemsSource = listado;
    }

    private async void chngPrincipal(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(Views.ListView));
    }

    private async void chngFav(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(Views.Favoritos));
    }

    private async void cerrar(object sender, EventArgs e)
    {
        App.userId = -1;
        await AppShell.Current.GoToAsync(nameof(Views.View1));
    }

    private void buscador_SearchButtonPressed(object sender, EventArgs e)
    {
        List<Chiste> lista = new List<Chiste>();
        //listado.Where(cadena => cadena.Delivery.Contains(buscador.Text)).ToList();
        switch (op)
        { 
            case 0:
                lista = listado.Where(cadena => cadena.Setup.Contains(buscador.Text)).ToList();
                break;
            case 1:
                lista = listado.Where(cadena => cadena.Delivery.Contains(buscador.Text)).ToList();
                break;
            default:
                lista = listado.Where(cadena => cadena.Delivery.Contains(buscador.Text) || cadena.Setup.Contains(buscador.Text)).ToList();
                break;
        }
        listadoChistes.ItemsSource = lista;
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        Picker picker = (Picker)sender;
        op = picker.SelectedIndex;
    }
}