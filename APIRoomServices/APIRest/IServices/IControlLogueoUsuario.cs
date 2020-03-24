
﻿using Dominio.EntidadesDelDominio.Entidades;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIRest.IServices
{
    public interface IControlLogueoUsuario
    {


        JObject informacionLogueUsuario(String email, String contrasena);
        bool permisoIngreso(String email, String contrasena);

        Arrendador mostarArrendador(String email, String contrasena);

        Arrendatario mostarArrendatario(String email, String contrasena);
        Administrador mostarAdministrador(String email, String contrasena);

    }
}