using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Venta
    {
        public int ID { get; set; }
        public Usuario Cliente { get; set; } = new Usuario();
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
    }
}
