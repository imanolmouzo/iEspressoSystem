using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Receta
    {
        DAL.Receta mp = new DAL.Receta();

        public List<BE.Receta> ListarTodas()
        {
            return mp.Listar("TODAS");
        }

        public List<BE.Receta> ListarDisponibles()
        {
            return mp.Listar("DISPONIBLES");
        }

        public BE.Receta Obtener(int id)
        {
            return mp.Obtener(id);
        }
    }
}
