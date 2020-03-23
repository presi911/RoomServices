using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
<<<<<<< HEAD:ServiciosRoomServices/CapaDatos/IGestionInformacion/ILogueoUsuario.cs
    public interface ILogueoUsuario
=======
    class Class1
>>>>>>> aeae7213c1db04e69c003ee40a392639831bc9ba:APIRoomServices/ControlRepository/Class1.cs
    {
        CuentasUsuarios logueoDatos(string email, string contrasena);
        Arrendatarios verificarArrendador(string cedula);
        Arrendadores verificarArrendatario(string cedula);
        Administradores verificarAdministrador(string cedula);
        Usuarios mostrarPerfil(String cedula);
    }
}
