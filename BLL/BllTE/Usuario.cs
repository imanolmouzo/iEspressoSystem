using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Usuario
    {
        public event InformarEventHandler Informar;
        public delegate void InformarEventHandler(string mensaje);
        DAL.Usuario mp = new DAL.Usuario();
        SEGURIDAD.SecurityManager SM = new SEGURIDAD.SecurityManager();
        BE.Bitacora BITACORA = new BE.Bitacora();
        Bitacora gestorBitacora = new Bitacora();

        public void Login(BE.Usuario u)
        {
            BE.Usuario UsuarioBD;

            UsuarioBD = mp.Login(u);

            if (UsuarioBD != null)
            {
                string HashBD = SM.GenerarHash(UsuarioBD.Password);

                if (SM.Verificar(u.Password, HashBD) == true)
                {
                    SEGURIDAD.Sesion.Login(UsuarioBD);
                    
                    BITACORA.Fecha = DateTime.Now;
                    BITACORA.Usuario = UsuarioBD;
                    BITACORA.Evento = "Login";
                }
            }
            else
            {
                BITACORA.Fecha = DateTime.Now;
                BITACORA.Usuario = u;
                BITACORA.Evento = "Inicio de sesion fallido";
            }
                gestorBitacora.RegistrarBitacora(BITACORA);
        }

        public void Logout()
        {
            BITACORA.Fecha = DateTime.Now;
            BITACORA.Usuario = SEGURIDAD.Sesion._Instance.UsuarioEnSesion;
            BITACORA.Evento = "Logout";
            gestorBitacora.RegistrarBitacora(BITACORA);
            SEGURIDAD.Sesion.Logout();
        }

        public List<BE.Usuario> Listar()
        {
            return mp.Listar();
        }

        public bool Registrar(BE.Usuario usuario)
        {
            usuario.ID = DAL.MapperID.ObtenerNuevoID("USUARIO");
            usuario.DVH = SM.GenerarHash(usuario.ID + usuario.Username + usuario.Password + usuario.Permiso + usuario.Estado);
            int r = mp.Registrar(usuario);
            if (r == -1)
            {
                Informar?.Invoke("Ya existe un usuario registrado con esos datos.");
                return false;
            }
            else
            {
                BITACORA.Fecha = DateTime.Now;
                BITACORA.Evento = "Usuario registrado en el sistema.";
                BITACORA.Usuario = usuario;
                gestorBitacora.RegistrarBitacora(BITACORA);
                Informar?.Invoke("Usuario registrado exitosamente. Inicie sesion.");
                return true;
            }
        }
    }
}
