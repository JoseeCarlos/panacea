using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Enfermedad
    {
        #region Properties
        public int Idenfermedad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ramamedica { get; set; }
        public byte Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int Userid { get; set; }
        #endregion

        #region Constructs

        /// <summary>
        /// GET Constructor
        /// </summary>
        /// <param name="idenfermedad"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="ramamedica"></param>
        /// <param name="estado"></param>
        /// <param name="fechacreacion"></param>
        /// <param name="fechaactu"></param>


        public Enfermedad(int idenfermedad, string nombre, string descripcion, string ramamedica, byte estado, DateTime fechacreacion, DateTime fechaactu,int userid)
        {
            this.Idenfermedad = idenfermedad;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Ramamedica = ramamedica;
            this.Estado = estado;
            this.FechaCreacion = fechacreacion;
            this.FechaActualizacion = fechaactu;
            this.Userid = userid;
        }
        #endregion

        public Enfermedad( string nombre, string descripcion, string ramamedica, int userid)
        {
            
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Ramamedica = ramamedica;
            this.Userid = userid;
        }

        public Enfermedad(int idenfermedad,string nombre, string descripcion, string ramamedica, int userid)
        {
            this.Idenfermedad = idenfermedad;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Ramamedica = ramamedica;
            this.Userid = userid;
        }
        public Enfermedad(int idenfermedad)
        {
            this.Idenfermedad = idenfermedad;
           
        }


    }
}
