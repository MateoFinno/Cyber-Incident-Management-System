using System;
using System.Collections.Generic;
using System.Text;

namespace dominio
{
    public class Persona : Ivalidable
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public Rol Rol { get; set; }
        public string Contraseña { get; set; }

        

        public Persona()
        {

        }

        public Persona(string cedula, string nombre, string email, int telefono, Rol rol,string contraseña)
        {
            Cedula = cedula;
            Nombre = nombre;    
            Email = email;
            Telefono = telefono;
            Rol = rol;
            Contraseña = contraseña;

        }

        public override string ToString()
        {
            return
            $"Cédula: {Cedula}\n" +
            $"Nombre : {Nombre}\n" +
            $"Email  : {Email}\n" +
            $"Tel.   : {Telefono}";

        }
        public void Validar()
        {
            ValidarCedula();
            ValidarEmail();
            ValidarNombre();
            ValidarTelefono();
        }

        private void ValidarCedula()
        {
            if (string.IsNullOrEmpty(Cedula))
            {
                throw new Exception("La cedula no puede quedar vacia, ingrese una.");

            }
        }
            

        public override bool Equals (object obj)
        {
            Persona persona = (Persona) obj;
            return Cedula == persona.Cedula;
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede quedar vacio. Ingrese un nombre.");
            }
        }

        private void ValidarEmail()
        {
            if (string.IsNullOrEmpty(Email) || !Email.Contains("@"))
            {
                throw new Exception("El correo electrónico debe contener '@'.");
            }
        }

        public void ValidarTelefono()
        {
            if (Telefono <= 0)
            {
                throw new Exception("El telefono no puede quedar vacio. Ingrese un telefono.");
            }
        }

    }
}
