using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2Ev.Model
{
    [Table("Chistes")]
    public class Chiste
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }
        public bool Error { get; set; }
        public String Category { get; set; }
        public String Type { get; set; }
        public String Setup { get; set; }
        public String Delivery { get; set; }
        public int userId { get; set; }
    }
}
