using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace ProjAula.Models
{
    public class Estado
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }        
        public string Nome { get; set; }


    }
}
