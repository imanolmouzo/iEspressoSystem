using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Carrito
    {
        public List<Producto> lsProductos { get; set; } = new List<Producto>();
        public float Total { get; set; }
    }
}
