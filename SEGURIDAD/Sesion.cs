namespace SEGURIDAD
{
    public sealed class Sesion
    {
        public static Sesion _Instance = null;
        private static readonly object _Sync = new object();
        public static int Intentos = 0;

        public BE.Usuario UsuarioEnSesion { get; set; }

        private Sesion() { }

        public static Sesion Login(BE.Usuario usuario)
        {
            if (_Instance == null)
            {
                lock (_Sync)
                {
                    if (_Instance == null)
                    {
                        _Instance = new Sesion();
                        _Instance.UsuarioEnSesion = usuario;
                    }
                }
            }
            return _Instance;
        }

        public static void Logout()
        {
            _Instance = null;
        }

    }
}
