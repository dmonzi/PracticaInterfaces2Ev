namespace Practica2Ev;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.VistaRegistro), typeof(Views.VistaRegistro));
        Routing.RegisterRoute(nameof(Views.ListView), typeof(Views.ListView));
        Routing.RegisterRoute(nameof(Views.View1), typeof(Views.View1));
        Routing.RegisterRoute(nameof(Views.Favoritos), typeof(Views.Favoritos));
    }
}
