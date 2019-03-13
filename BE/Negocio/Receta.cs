using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Receta : Producto
    {
        public Capsula Capsula { get; set; } = new Capsula();
        public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
        public string Dificultad { get; set; }
        public string TiempoPreparacion { get; set; }
        public int Estado { get; set; }
    }
}
