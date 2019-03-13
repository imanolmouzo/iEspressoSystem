using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Ingrediente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public float Stock { get; set; }
        public float Cantidad { get; set; }
        public string DVH { get; set; }
    }
}
