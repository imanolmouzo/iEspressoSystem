using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Permiso { get; set; }
        public int Estado { get; set; }
        public string DVH { get; set; }
        public Carrito Carrito { get; set; } = new Carrito();
        public override string ToString()
        {
            return Username;
        }
    }
}
