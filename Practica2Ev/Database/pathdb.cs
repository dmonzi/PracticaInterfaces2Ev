using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2Ev.Database
{
    public class pathdb
    {
        public static String devolverRuta(String nombre)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, nombre);
        }
    }
}
