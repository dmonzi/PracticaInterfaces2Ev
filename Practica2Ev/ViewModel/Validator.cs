using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Practica2Ev.Model;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Practica2Ev.Views;

namespace Practica2Ev.ViewModel
{
    public partial class Validator : ObservableValidator
    {
        public static ObservableCollection<string> errores { get; set; } = new ObservableCollection<string>();
        public static ObservableCollection<string> erroresInicio { get; set; } = new ObservableCollection<string>();

        private String nombre;
        [Required(ErrorMessage = "El nombre no puede estar vacio")]
        [MaxLength(25, ErrorMessage = "La longuitud maxima del nombre es 25")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El nombre debe contener únicamente caracteres alfabéticos")]
        public String Nombre
        {
            get => nombre;
            set => SetProperty(ref nombre, value);
        }

        private String nombreUsuario;
        public String NombreUsuario
        {
            get => nombreUsuario;
            set => SetProperty(ref nombreUsuario, value);
        }

        private string password;

        [RegularExpression(@"^.{5,}$", ErrorMessage = "La contraseña debe tener al menos 5 caracteres")]
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private string confirmacionContrasena;

        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmacionContrasena
        {
            get => confirmacionContrasena;
            set => SetProperty(ref confirmacionContrasena, value);
        }

        private string edad;
        [RegularExpression(@"^(?:[1-9][0-9]?|100)$", ErrorMessage = "La edad debe ser un número entero válido entre 1 y 100")]
        public string Edad
        {
            get => edad;
            set => SetProperty(ref edad, value);
        }


        [RelayCommand]
        public async void validar()
        {
            errores.Clear();
            ValidateAllProperties();
            GetErrors(nameof(Nombre)).ToList().ForEach(f => errores.Add(f.ErrorMessage));
            GetErrors(nameof(NombreUsuario)).ToList().ForEach(f => errores.Add(f.ErrorMessage));
            GetErrors(nameof(Password)).ToList().ForEach(f => errores.Add(f.ErrorMessage));
            GetErrors(nameof(Edad)).ToList().ForEach(f => errores.Add(f.ErrorMessage));

            if (comprobarRegistro())
            {
                errores.Add("El nombre de usuario ya existe ");
            } 

            if (!comprobarContraseñas()) {
                errores.Add("Las contraseñas no coinciden ");
            }

            if (errores.Count == 0)
            {
                App.Repository.addUsuario(new Usuario { User = NombreUsuario, Nombre = Nombre, Contrasena = Password, Edad = int.Parse(Edad) });
                NombreUsuario = string.Empty;
                Password = string.Empty;
                Nombre = string.Empty;
                Edad = string.Empty;
                ConfirmacionContrasena = string.Empty;
            }
        }

        /*
         * Método usado para combiar la vista a la vista de registo
         * @param none
         * @return none
         */
        [RelayCommand]
        public async void cambiaraAVistaRegistro() {
            await AppShell.Current.GoToAsync(nameof(Views.VistaRegistro));
        }

        /*
         * Método usado para cambiar de vista a la vista de login
         * @param none
         * @return none
         */
        [RelayCommand]
        public async void cambiaraAVistaLogin()
        {
            await AppShell.Current.GoToAsync(nameof(Views.View1));
        }

        /*
         * Método usado en el inicio de sesión, para validar los datos introducidos por el usuario y cambiar de vista
         * @param none
         * @return none
         */
        [RelayCommand]
        public async void iniciarSesion()
        {
            bool encontrado = false;
            foreach (Usuario validado in App.Repository.listUser())
            {
                if (validado.User.Equals(NombreUsuario) && validado.Contrasena.Equals(Password))
                {
                    App.userId = validado.Id;
                    encontrado = true;
                }
            }
            if (encontrado)
            {
                await AppShell.Current.GoToAsync(nameof(Views.ListView));
            }
            else
            {
                erroresInicio.Add("El usuario o la contraseña son INCORRECTOS");
            }
        }

        

        /*
         * Busca en la base de datos si el usuario ya existe
         * @param none
         * @return bool true si encuentra el usuario en la base de datos
         */
        public bool comprobarRegistro()
        {
            bool encontrado = false;
            foreach (var validado in App.Repository.listUser())
            {
                if (validado.User.Equals(NombreUsuario))
                   
                {
                    encontrado = true;
                }
            }
            return encontrado;
        }

        /*
         * Comprueba si las dos contraseñas introducidas en los campos de entrada son la misma
         * @param none
         * @return bool true si las dos contraseñas son la misma
         */
        public bool comprobarContraseñas()
        {
            bool esIgual = false;
            if (Password != null && ConfirmacionContrasena!= null)
            {
                if (Password.Equals(ConfirmacionContrasena)) { 
                esIgual = true;
                }
            }
            return esIgual;
        }
    }
}
