using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGURIDAD
{
    public class TechnicalController
    {
        //GitHub update
        public static int PageCounterMenuCapsulas = 0;
        public static int PageCounterMenuRecetas = 0;
        public static List<BE.Capsula> lsCapsulas { get; set; } = new List<BE.Capsula>();
        public static List<BE.Receta> lsRecetas { get; set; } = new List<BE.Receta>();
        public static List<BE.Usuario> lsUsuariosAlterados { get; set; } = new List<BE.Usuario>();
        public static List<BE.Capsula> lsCapsulasAlteradas { get; set; } = new List<BE.Capsula>();
        public static string msgTablasAlteradas { get; set; } = "La tabla ";
        public static bool IntegridadCorrupta { get; set; } = false;

        public static void New()
        {
            PageCounterMenuCapsulas = 0;
            PageCounterMenuRecetas = 0;
            lsCapsulas = new List<BE.Capsula>();
            lsRecetas = new List<BE.Receta>();
        }

        public static void End()
        {
            lsUsuariosAlterados = new List<BE.Usuario>();
            lsCapsulasAlteradas = new List<BE.Capsula>();
            msgTablasAlteradas = "La tabla ";
        }
    }
}
