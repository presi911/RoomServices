using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using Dominio.EntidadesDelDominio.Entidades;
using Negocio.ControlRepository;

using APIRest.IServices;
using Newtonsoft.Json.Linq;
using APIRest.ExcepcionesAPIRestService;

namespace APIRest.APIRestService
{
    public class ControlTomarAlquilerAlojamiento : IControlTomarAlquilerAlojamiento
    {
        readonly Negocio.ILogicaNegocio.IControlAlquilerAlojamiento control;
        readonly Negocio.ILogicaNegocio.IControlBuscarAlojamiento control1;

        public ControlTomarAlquilerAlojamiento()
        {
            control = new Negocio.ControlRepository.ControlTomarAlquilerAlojamiento();

        }

        /// <summary>
        /// Consulta y obtiene un obtiene  el estado del alojamiento
        /// </summary>
        /// <param name="idAlojamiento">Parámetro númerico con el id de la habitación a consultar en la base de datos</param>
        /// <param name="estado">Parámetro númerico del estado del alojamiento a consultar en la base de datos</param>
        /// <returns>Un valor numerico si 1 esta Disponible y 0 Ocupada</returns>

        public int estadoAlojamiento(int idAlojamiento, int estado)
        {
           return control.estadoAlojamiento(idAlojamiento,estado);
        }

        /// <summary>
        /// Consulta y retorna un objeto tipo alojamiento proporcionando como criterio de consulta su ID.
        /// </summary>
        /// <param name="idAlojamiento">Entero, identificador de alojamiento en la base de datos.</param>
        /// <returns>Objeto tipo alojamiento con todo sus atributos, titulo, precio, descripción...</returns>

        public Alojamiento listaAlojamiento(int idAlojamiento)
        {
           return control.listaAlojamiento(idAlojamiento);
        }

        /// <summary>
        /// Consulta y retorna un objeto tipo Arrendador, proporcionando como parámetro el su cédula
        /// </summary>
        /// <param name="cedula">Cadena, cédula del arrendador a consultar</param>
        /// <returns>Objeto tipo arrendador con todos sus atributos: cédula,nombre,apellidos,edad...</returns>
        public Arrendador listaArredandor(string cedula)
        {
            return control.listaArredandor(cedula);
        }

        /// <summary>
        /// Consulta y retorna un objeto tipo Arrendador, proporcionando como parámetro el su cédula
        /// </summary>
        /// <param name="cedula">Cadena, cédula del arrendador a consultar</param>
        /// <returns>Objeto tipo arrendador con todos sus atributos: cédula,nombre,apellidos,edad...</returns>
        public Arrendatario listaArrendatario(string cedula)
        {
           return control.listaArrendatario(cedula);
        }

        /// <summary>
        /// Consulta y retorna un objeto tipo Alquiler, proporcionando como parámetro el idAlojamiento
        /// </summary>
        /// <param name="idAlojamiento">int, idAlojamiento del alojamiento a consultar</param>
        /// <returns>Objeto tipo alquiler con todos sus atributos: numeroContrato,pagoMensual,.....</returns>
        public Alquiler listaAlquiler(int idAlojamiento)
        {
            return control.listaAlquiler(idAlojamiento);
        }

        /// <summary>
        /// Consulta y retorna la información completa  en formato JSON (JSONObject) con diferentes parametros 
        /// como parámetro su idAlojamiento,CedulaArrendador,CedulaArrendatario 
        /// </summary>
        /// <param name="idAlojamiento">Entero, identificador de alojamiento al cual deseo consultar la información</param>
        /// <param name="arrendador"></param>
        /// <param name="arrendatario"></param>
        /// <returns>Objeto JSON(JObject) con los datos de alojamiento, arrendador, arrendatario y alquiler </returns>

        public JObject InformacionAlojamientoGeneral(int idAlojamiento, String arrendador, String arrendatario)
        {

            Alojamiento Alojamiento = this.listaAlojamiento(idAlojamiento);
            Arrendador Arrendador = this.listaArredandor(arrendador);
            Arrendatario Arrendatario = this.listaArrendatario(arrendatario);
            

            if(this.estadoAlojamiento(Alojamiento.IdAlojamiento,Alojamiento.Estado)==1)
            {
                Alquiler Alquiler = this.listaAlquiler(idAlojamiento);
                List<Calificacion> a = control1.RetornarCalificacionesAlojamiento(idAlojamiento);
                
                return this.InformacionAlquilado(Alojamiento, Arrendador, Arrendatario, Alquiler);
            }
            else
            {
                return TomarAlquilerAlojamientoException.ArmarJSONInformacionException("Lo sentimos el alojamiento No Disponible");
            }
            

        }

        /// <summary>
        /// Construye un objeto JSON con la información proporcionada y lo retorna, la información recibida es null retorna un JSON informando
        /// la excepción ocurrida.
        /// </summary>
        /// <param name="alojamiento"></param>
        /// <param name="arrendador"></param>
        /// <param name="arrendatario"></param>
        /// <param name="alquiler"></param>
        /// <returns>Se obtiene un JSON</returns>
        public JObject InformacionAlquilado(Alojamiento alojamiento, Arrendador arrendador, 
                                            Arrendatario arrendatario, Alquiler alquiler)
        {
            
                return JObject.FromObject(new
                {
                    alojamiento= new Alojamiento()
                    {
                        IdAlojamiento=alojamiento.IdAlojamiento,
                        Titulo=alojamiento.Titulo,
                        TipoAlojamiento=alojamiento.TipoAlojamiento,
                        Precio= alojamiento.Precio,
                        Estado= alojamiento.Estado,
                        DescripcionAlojamiento= alojamiento.DescripcionAlojamiento,
                        CedulaArrendador = arrendador.Cedula,
                        Arrendatario =arrendatario
                      
                        
                    },
                    arrendador = new Arrendador()
                    {
                        IdArrendador= arrendador.IdArrendador,
                        Cedula= arrendador.Cedula,
                        Nombre=arrendador.Nombre,
                        Apellido= arrendador.Apellido,
                        Nacionalidad=arrendador.Nacionalidad,
                        Genero = arrendador.Genero,
                        Fecha= arrendador.Fecha
                        
                    },
                   /*arrendatario = new Arrendatario()
                    {
                        IdArrendatario = arrendatario.IdArrendatario,
                        Cedula= arrendatario.Cedula,
                        Nombre= arrendatario.Nombre,
                        Apellido= arrendatario.Apellido,
                        Fecha= arrendatario.Fecha,
                        Genero= arrendatario.Genero,
                        TipoArrendador= arrendatario.TipoArrendador,
                        Nacionalidad= arrendatario.Nacionalidad
                                             
                    },*/
                     alquiler = new Alquiler ()
                    {
                         NumeroContrato=alquiler.NumeroContrato,
                         NumeroMeses= (byte)alquiler.numeroMeses,
                         PagoMensual = alquiler.PagoMensual,
                                                                      
                    } 
                    });     

        }

        /// <summary>
        /// Permite ingresar información con los datos faltantes en alquileAlojamiento como requisito
        /// </summary>
        /// <param name="numeroContrato">entero, datos faltantes en alquiler</param>
        /// <param name="numeroMeses">entero, datos faltantes en alquiler</param>
        /// <param name="pagoMensual">decimal, datos faltantes en alquiler</param>
        /// <param name="fechaAlquiler">DateTime, datos faltantes en alquiler</param>
        ///<param name="idAlojamiento">entero, datos faltantes en alquiler</param>
        /// <returns>Se obtiene un TRUE diciendo que los datos se ingresaron o False que alojamiento no esta disponible</returns>
        ///
        public Boolean ingresarDatosFaltantes(int numeroContrato, int numeroMeses, decimal pagoMensual, string fechaAlquiler, int idAlojamiento)
        {
            return control.ingresarDatosFaltantes(numeroContrato,numeroMeses,pagoMensual,fechaAlquiler,idAlojamiento);
           
        }

        
    }
}