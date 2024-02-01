using Practica2Ev.Database;
using System.Diagnostics;

namespace Practica2Ev;

public partial class App : Application
{
    public static Repository Repository { get; set; }
    public static int userId { get; set; }

    public App(Repository repository)
    {
        Repository = repository;

        InitializeComponent();

		MainPage = new AppShell();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Launcher.OpenAsync("https://www.linkedin.com/in/daniel-monz%C3%B3n-programador-multiplataforma/");
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {

    }
}
