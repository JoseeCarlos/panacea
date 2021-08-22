using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Usuario
    {

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string PriApellido { get; set; }
        public string SeguApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Position { get; set; }
        public byte Foto { get; set; }
        public byte Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int UserId { get; set; }

        public byte PrimerInicio { get; set; }



        public Usuario(int idusuario, string nombre,string priApellido,string seguApellido,DateTime fechaNacimiento,string genero,string email,string nombreUsuario,string password,string role,string position,byte foto,byte estado,DateTime fechacreacion,DateTime fechaactualizacion,int iduser,byte primerInicio)
        {
            this.IdUsuario = idusuario;
            this.Nombre = nombre;
            this.PriApellido = priApellido;
            this.SeguApellido = seguApellido;
            this.FechaNacimiento = fechaNacimiento;
            this.Genero = genero;
            this.Email = email;
            this.NombreUsuario = nombreUsuario;
            this.Password = password;
            this.Role = role;
            this.Position = position;
            this.Foto = foto;
            this.Estado = estado;
            this.FechaCreacion = fechacreacion;
            this.FechaActualizacion = fechaactualizacion;
            this.UserId = iduser;
            this.PrimerInicio = primerInicio;

        }
        public Usuario( string nombre, string priApellido, string seguApellido, DateTime fechaNacimiento, string genero, string email, string nombreUsuario, string password, string role,byte foto, int iduser)
        {
          
            this.Nombre = nombre;
            this.PriApellido = priApellido;
            this.SeguApellido = seguApellido;
            this.FechaNacimiento = fechaNacimiento;
            this.Genero = genero;
            this.Email = email;
            this.NombreUsuario = nombreUsuario;
            this.Password = password;
            this.Role = role;
            this.Foto = foto;
            this.UserId = iduser;

        }
        public Usuario(int usuarioid,string nombre, string priApellido, string seguApellido, DateTime fechaNacimiento, string genero, string email, string role, DateTime fechacreacion, DateTime fechaactualizacion,  int iduser)
        {
            this.IdUsuario = usuarioid;
            this.Nombre = nombre;
            this.PriApellido = priApellido;
            this.SeguApellido = seguApellido;
            this.FechaNacimiento = fechaNacimiento;
            this.Genero = genero;
            this.Email = email;
            this.Role = role;
            this.FechaCreacion=fechacreacion;
            this.FechaActualizacion=fechaactualizacion;
            
            this.UserId = iduser;

        }
        public Usuario(int usuarioid, string nombre, string priApellido, string seguApellido, DateTime fechaNacimiento, string genero, string email, string role, DateTime fechaactualizacion, int iduser)
        {
            this.IdUsuario = usuarioid;
            this.Nombre = nombre;
            this.PriApellido = priApellido;
            this.SeguApellido = seguApellido;
            this.FechaNacimiento = fechaNacimiento;
            this.Genero = genero;
            this.Email = email;
            this.Role = role;  
            this.FechaActualizacion = fechaactualizacion;
            this.UserId = iduser;

        }
        public Usuario(int usuarioid, string nombre, string priApellido, string seguApellido, DateTime fechaNacimiento, string genero, string email, string role, int iduser)
        {
            this.IdUsuario = usuarioid;
            this.Nombre = nombre;
            this.PriApellido = priApellido;
            this.SeguApellido = seguApellido;
            this.FechaNacimiento = fechaNacimiento;
            this.Genero = genero;
            this.Email = email;
            this.Role = role;
            this.UserId = iduser;

        }

        public Usuario(int usuarioid)
        {
            this.IdUsuario = usuarioid;
            

        }
        public Usuario(string password,byte primerInicio)
        {
            this.Password = password;
            this.PrimerInicio = primerInicio;

        }
        public Usuario(string password)
        {
            this.Password = password;
           

        }

    }
}
