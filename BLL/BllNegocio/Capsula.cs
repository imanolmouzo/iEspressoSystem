using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Capsula
    {
        DAL.Capsula mp = new DAL.Capsula();

        public List<BE.Capsula> Listar()
        {
            return mp.Listar();
        }

        public BE.Capsula Obtener(int id)
        {
            return mp.Obtener(id);
        }

        public void ActualizarStock(List<BE.Capsula> lsCapsulas)
        {
            SEGURIDAD.SecurityManager gestorHash = new SEGURIDAD.SecurityManager();

            foreach (BE.Capsula c in lsCapsulas)
            {
                c.DVH = gestorHash.GenerarHash(c.ID + c.Nombre + c.Intensidad + c.Descripcion + c.Tipo + c.Precio + c.Stock);
                mp.ActualizarStock(c);
            }

            DVV gestorDVV = new DVV();
            gestorDVV.ActualizarDVV();
        }


    }
}
