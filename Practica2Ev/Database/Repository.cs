using Practica2Ev.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2Ev.Database
{
    public class Repository
    {
        private String _ruta;

        private SQLite.SQLiteConnection conexion;

        /*
         * Constructor para iniciar la conexión a la base de datos SQLite
         */
        public Repository(String ruta)
        {
            this._ruta = ruta;
            conexion = new SQLite.SQLiteConnection(ruta);
            System.Diagnostics.Debug.Write($"La ruta de la base de datos es: {_ruta}s");

            if (!conexion.TableMappings.Any(e => e.MappedType.Name == "Usuario"))
            {
                conexion.CreateTable<Usuario>();
                conexion.CreateTable<Chiste>();
            }
        }

        /*
         * Añadir un usuario a la base de datos
         * @param Usuario Usuario a introducir
         * @return int Valor 0 o 1 dependiendo del resultado de la consulta
         */
        public int addUsuario(Usuario user)
        {
            return conexion.Insert(user);
        }

        /*
         * Obtener unalista con todos los usuarios de la base de datos
         * @param none
         * @return List<Usuario> Listado que contiene todos los usuarios
         */
        public ObservableCollection<Usuario> getUsuarios()
        {
            List<Usuario> lista = conexion.Table<Usuario>().ToList();
            ObservableCollection<Usuario> listado = new ObservableCollection<Usuario>(lista);
            return listado;
        }

        /*
         * Eliminar un usuario de la base de datos
         * @param Usuario Objeto del usuario a eliminar
         * @return int Valor 0 o 1 dependiendo del resultado de la consulta
         */
        public int deleteUser(Usuario user)
        {
            return conexion.Delete(user);
        }

        
        public List<Usuario> listUser() 
        { 
            return conexion.Table<Usuario>().ToList();
        }

        /*
         * Añadir un chiste a la base de datos en la tabla de favoritos
         * @param Chiste Chiste a introducir
         * @return int Valor 0 o 1 dependiendo del resultado de la consulta
         */
        public int addFav(Chiste chiste)
        {
            return conexion.Insert(chiste);
        }

        /*
         * Obtener una lista con todos los chistes favoritos de la base de datos
         * @param none
         * @return List<Chiste> Listado que contiene todos los chistes favoritos
         */
        public ObservableCollection<Chiste> getFavs()
        {
            //List<Chiste> lista = conexion.Table<Chiste>().ToList();
            List<Chiste> lista = conexion.Table<Chiste>().Where(chiste => chiste.userId == App.userId).ToList();
            ObservableCollection<Chiste> listado = new ObservableCollection<Chiste>(lista);
            return listado;
        }

        /*
         * Eliminar un chiste de la base de datos en la tabla de favoritos
         * @param Chiste Objeto del chiste a eliminar
         * @return int Valor 0 o 1 dependiendo del resultado de la consulta
         */
        public int deleteFav(int id)
        {
            return conexion.Table<Chiste>().Where(chiste => chiste.userId == App.userId && chiste.Id == id).Delete();
        }
    }


}
