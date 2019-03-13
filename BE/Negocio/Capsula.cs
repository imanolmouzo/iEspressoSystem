using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Capsula : Producto
    {
        public int Intensidad { get; set; }
        public string Tipo { get; set; }
        public int Stock { get; set; }
    }
}
