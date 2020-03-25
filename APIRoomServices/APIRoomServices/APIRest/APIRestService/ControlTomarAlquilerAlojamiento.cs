using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using Dominio.EntidadesDelDominio.Entidades;
using Negocio.ControlRepository;

using APIRest.IServices;
using Newtonsoft.Json.Linq;

namespace APIRest.APIRestService
{
    public class ControlTomarAlquilerAlojamiento : IControlTomarAlquilerAlojamiento
    {
        readonly Negocio.ILogicaNegocio.IControlAlquilerAlojamiento control;

        public ControlTomarAlquilerAlojamiento()
        {
            control = new Negocio.ControlRepository.ControlTomarAlquilerAlojamiento();

        }


        public int estadoAlojamiento(int idAlojamiento, int estado)
        {
           return control.estadoAlojamiento(idAlojamiento,estado);
        }

        

        public Alojamiento listaAlojamiento(int idAlojamoiento)
        {
           return control.listaAlojamiento(idAlojamoiento);
        }

        public Arrendador listaArredandor(string cedula)
        {
            return control.listaArredandor(cedula);
        }

        public Arrendatario listaArrendatario(string cedula)
        {
           return control.listaArrendatario(cedula);
        }
        public JObject InformacionAlojamientoGeneral(int idAlojamiento, String arrendador, String arrendatario)
        {
            Alojamiento Alojamiento = this.listaAlojamiento(idAlojamiento);
            Arrendador Arrendador =this.listaArredandor(arrendador);
            Arrendatario Arrendatario = this.listaArrendatario(arrendatario);
            return this.InformacionAlquilado(Alojamiento,Arrendador,Arrendatario);

        }
        public JObject InformacionAlquilado(Alojamiento alojamiento, Arrendador arrendador, Arrendatario arrendatario)
        {
            if(this.estadoAlojamiento(alojamiento.IdAlojamiento, alojamiento.Estado)==1)
            {
                return JObject.FromObject(new
                {
                    alojamiento= new
                    {
                        idAlojamiento=alojamiento.IdAlojamiento,
                        titulo=alojamiento.Titulo,
                        tipoAlojamiento=alojamiento.TipoAlojamiento,
                        precio= alojamiento.Precio,
                        estado= alojamiento.Estado
                    },
                    arrendador =new
                    {
                        idArredandor= arrendador.IdArrendador,
                        cedulaArrendador= arrendador.Cedula,
                        nombreArrendador=arrendador.Nombre,
                        apellidoArrendador= arrendador.Apellido
                    },
                    arrendatario = new
                    {
                        idArrendatario = arrendatario.IdArrendatario,
                        cedulaArrendatario= arrendatario.Cedula,
                        nombrearrendatario= arrendatario.Nombre,
                        apellidoArrendatario= arrendatario.Apellido,
                        fechaArrendatario= arrendatario.Fecha,
                        generoArrendatario= arrendatario.Genero
                     
                    }

                });
                
            }
            else
            {
                return JObject.FromObject(new
                {
                    error = new
                    {
                        tipoError = 404,
                        descripcion = "El alojamiento solicitado no existe o ya no se encuentra disponible :("
                    }
                });

            }

        }

        public Boolean ingresarDatosFaltantes(int numeroContrato, int numeroMeses, decimal pagoMensual, string fechaAlquiler, int idAlojamiento)
        {
            return control.ingresarDatosFaltantes(numeroContrato,numeroMeses,pagoMensual,fechaAlquiler,idAlojamiento);
           
        }


    }
}