using Practica2Ev.Model;
using System.Diagnostics;

namespace Practica2Ev.Templates;

public partial class ChisteFav : ContentView
{
	public ChisteFav()
	{
        InitializeComponent();
	}

    private void delFavoritos(object sender, EventArgs e)
    {
        App.Repository.deleteFav(int.Parse(myId.Text));
        Button btn = (Button)sender;
        btn.IsEnabled = false;
    }
}