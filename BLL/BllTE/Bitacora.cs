using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Bitacora
    {
        public event InformarEventHandler Informar;
        public delegate void InformarEventHandler(string mensaje);
        DAL.Bitacora mp = new DAL.Bitacora();

        public List<BE.Bitacora> ListarBitacora()
        {
            return mp.ListarBitacora();
        }

        public void RegistrarBitacora(BE.Bitacora BITACORA)
        {
            BITACORA.ID = DAL.MapperID.ObtenerNuevoID("BITACORA");
            int r = mp.RegistrarBitacora(BITACORA);
            if (r == -1 || r == 0)
                Informar?.Invoke("No se pudo registrar en bitacora.");
            else
            {
                DVV gestorDVV = new DVV();
                gestorDVV.ActualizarDVV();
            }
        }

        public List<BE.Bitacora> FiltrarBitacora(string fecha, string evento, BE.Usuario usuario)
        {
            try
            {
                return mp.FiltrarBitacora(fecha, evento, usuario);
            }
            catch (Exception)
            {
                Informar?.Invoke("Error al intentar filtrar.");
                return null;
            }
        }

        public List<BE.Bitacora> Filtrar(string desde, string hasta)
        {
            try
            {
                return mp.Filtrar(desde, hasta);
            }
            catch (Exception)
            {
                Informar?.Invoke("Error al intentar filtrar.");
                return null;
            }
        }
    }
}
