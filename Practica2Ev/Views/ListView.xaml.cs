using Newtonsoft.Json;
using Practica2Ev.Model;
using Practica2Ev.Templates;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Practica2Ev.Database;

namespace Practica2Ev.Views;

public partial class ListView : Plantilla
{
    public Chiste Chiste { get; set; }  

	public ListView()
	{
		InitializeComponent();
        httpConsulta();
    }

    private async void httpConsulta()
    {
        ObservableCollection<Chiste> listado = new ObservableCollection<Chiste>();

        Chiste chiste = new Chiste();

        String host = "https://v2.jokeapi.dev/joke/Any?blacklistFlags=racist,sexist,explicit&type=twopart";

        HttpClient httpClient = new HttpClient();

        string respuesta = await httpClient.GetStringAsync(host);

        chiste = JsonConvert.DeserializeObject<Chiste>(respuesta);

        Debug.WriteLine(respuesta);

        listado.Add(chiste);

        listadoChistes.ItemsSource = listado;

        chiste.userId = App.userId;

        this.Chiste = chiste;
    }

    private void siguiente(object sender, EventArgs e)
    {
        if (favorito.Text.Equals("♥"))
        {
            favorito.Text = "♡";
            App.Repository.addFav(Chiste);
        }
        httpConsulta();
    }

    private void addFavoritos(object sender, EventArgs e)
    {
        //Añadir chiste a la lista de favoritos
        if (favorito.Text.Equals("♡"))
        {
            favorito.Text = "♥";
        }
        else
        {
            favorito.Text = "♡";
        }
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
}