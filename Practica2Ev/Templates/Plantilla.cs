namespace Practica2Ev.Templates;

public class Plantilla : ContentPage
{
    public Plantilla()
    {
        var platilla = Application.Current.Resources["plantilla"] as ControlTemplate;
        ControlTemplate = platilla;
    }
}
