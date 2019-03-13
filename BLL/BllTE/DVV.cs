using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DVV
    {
        DAL.DVV mp = new DAL.DVV();
        SEGURIDAD.SecurityManager GestorHash = new SEGURIDAD.SecurityManager();
        Usuario gestorUsuario = new Usuario();
        Capsula gestorCapsula = new Capsula();

        public List<BE.DVV> Listar()
        {
            return mp.Listar();
        }

        public void Insertar(BE.DVV dvv)
        {
            try
            {
                mp.Insertar(dvv);
            }
            catch (Exception) { }
        }
        
        public void VerificarIntegridad()
        {
            List<BE.DVV> lsDVV = this.Listar();
            List<BE.Usuario> lsUsuarios = gestorUsuario.Listar();
            List<BE.Capsula> lsCapsulas = gestorCapsula.Listar();
            string DVV = "";
            int ErrorDeIntegridad = 0;
            int TablasEliminadas = 0;

            foreach (BE.DVV registro in lsDVV)
            {
                if (registro.Tabla == "USUARIO")
                {
                    if(lsUsuarios.Count > 0)
                    {
                        foreach(BE.Usuario u in lsUsuarios)
                        {
                            DVV = DVV + u.DVH;
                        }
                        if (GestorHash.Verificar(DVV, registro.Digito))
                        {
                            ErrorDeIntegridad += 0;
                        }
                        else
                        {
                            SEGURIDAD.TechnicalController.msgTablasAlteradas += "Usuario, ";
                            ErrorDeIntegridad += 1;
                        }
                        DVV = null;
                    }
                    else
                    {
                        SEGURIDAD.TechnicalController.msgTablasAlteradas += "Usuario, ";
                        TablasEliminadas += 1;
                    }
                }

                if (registro.Tabla == "CAPSULA")
                {
                    if (lsCapsulas.Count > 0)
                    {
                        foreach (BE.Capsula c in lsCapsulas)
                        {
                            DVV = DVV + c.DVH;
                        }
                        if (GestorHash.Verificar(DVV, registro.Digito))
                        {
                            ErrorDeIntegridad += 0;
                        }
                        else
                        {
                            SEGURIDAD.TechnicalController.msgTablasAlteradas += "Capsula, ";
                            ErrorDeIntegridad += 1;
                        }
                        DVV = null;
                    }
                    else
                    {
                        SEGURIDAD.TechnicalController.msgTablasAlteradas += "Capsula, ";
                        TablasEliminadas += 1;
                    }
                }
            }

            if (TablasEliminadas > 0)
            {
                SEGURIDAD.TechnicalController.msgTablasAlteradas += "se encuentra vacia o ha sido eliminada.";
                SEGURIDAD.TechnicalController.IntegridadCorrupta = true;
            }
                
            if (ErrorDeIntegridad > 0)
            {
                SEGURIDAD.TechnicalController.msgTablasAlteradas += "sufrio un borrado de registros.";
                SEGURIDAD.TechnicalController.IntegridadCorrupta = true;
            }
        }
        
        public void ActualizarDVV()
        {
            List<BE.DVV> lsDVV = this.Listar();
            List<BE.Usuario> lsUsuarios = gestorUsuario.Listar();
            List<BE.Capsula> lsCapsulas = gestorCapsula.Listar();

            foreach (BE.DVV dvv in lsDVV)
            {
                if(dvv.Tabla == "USUARIO")
                {
                    BE.DVV nuevoDVV = new BE.DVV();
                    nuevoDVV.Tabla = dvv.Tabla;
                    if(lsUsuarios.Count > 0)
                    {
                        foreach(BE.Usuario u in lsUsuarios)
                        {
                            nuevoDVV.Digito = nuevoDVV.Digito + u.DVH;
                        }
                        nuevoDVV.Digito = GestorHash.GenerarHash(nuevoDVV.Digito);
                        this.Insertar(nuevoDVV);
                        nuevoDVV = null;
                    }
                }

                if (dvv.Tabla == "CAPSULA")
                {
                    BE.DVV nuevoDVV = new BE.DVV();
                    nuevoDVV.Tabla = dvv.Tabla;
                    if (lsCapsulas.Count > 0)
                    {
                        foreach (BE.Capsula c in lsCapsulas)
                        {
                            nuevoDVV.Digito = nuevoDVV.Digito + c.DVH;
                        }
                        nuevoDVV.Digito = GestorHash.GenerarHash(nuevoDVV.Digito);
                        this.Insertar(nuevoDVV);
                        nuevoDVV = null;
                    }
                }
            }
        }

    }
}
