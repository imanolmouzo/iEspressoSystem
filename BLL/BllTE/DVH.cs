using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DVH
    {
        public void VerificarIntegridad()
        {
            SEGURIDAD.SecurityManager GestorHash = new SEGURIDAD.SecurityManager();
            string registro = "";
            Usuario gestorUsuario = new Usuario();
            Capsula gestorCapsula = new Capsula();
            List<BE.Usuario> lsUsuarios = gestorUsuario.Listar();
            List<BE.Capsula> lsCapsulas = gestorCapsula.Listar();

            if (lsUsuarios.Count > 0)
            {
                foreach (BE.Usuario u in lsUsuarios)
                {
                    registro = u.ID + u.Username + u.Password + u.Permiso + u.Estado;
                    if (GestorHash.Verificar(registro, u.DVH))
                    {
                        registro = null;
                    }
                    else
                    {
                        SEGURIDAD.TechnicalController.lsUsuariosAlterados.Add(u);
                        registro = null;
                    }
                }
            }

            if (lsCapsulas.Count > 0)
            {
                foreach (BE.Capsula c in lsCapsulas)
                {
                    registro = c.ID + c.Nombre + c.Intensidad + c.Descripcion + c.Tipo + c.Precio + c.Stock;
                    if (GestorHash.Verificar(registro, c.DVH))
                    {
                        registro = null;
                    }
                    else
                    {
                        SEGURIDAD.TechnicalController.lsCapsulasAlteradas.Add(c);
                        registro = null;
                    }
                }
            }
        }
    }
}
