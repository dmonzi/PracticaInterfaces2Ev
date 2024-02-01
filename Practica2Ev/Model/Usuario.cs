using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2Ev.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }

        public String User { get; set; }

        public String Nombre { get; set; }

        public int Edad { get; set; }

        public String Contrasena { get; set; }
    }
}
