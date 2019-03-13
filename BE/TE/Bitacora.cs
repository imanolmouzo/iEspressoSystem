using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Evento { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();
    }
}
