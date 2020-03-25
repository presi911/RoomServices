using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using Dominio.EntidadesDelDominio.Entidades;
using Newtonsoft.Json.Linq;


namespace APIRest.IServices
{
    public interface IControlTomarAlquilerAlojamiento
    {
        int estadoAlojamiento(int idAlojamiento, int estado);

        Alojamiento listaAlojamiento(int idAlojamoiento);
        Arrendador listaArredandor(string cedula);
        Arrendatario listaArrendatario(string cedula);
        
        JObject InformacionAlojamientoGeneral(int alojamiento, string arrendador, string arrendatario);
        Boolean ingresarDatosFaltantes(int numeroContrato, int numeroMeses, Decimal pagoMensual, string fechaAlquiler, int idAlojamiento);

        Alquiler listaAlquiler(int idAlojamiento);
    }
}