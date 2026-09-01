using System;
using System.Collections.Generic;
using System.Text;

namespace dominio
{
   
    public class Activo : Ivalidable
    {
        private static int proximoCodigo = 1;

        public string CodigoAutoincremental { get; set; }
        public string Nombre { get; set; }
        public TipoActivo TipoActivo { get; set; }
        public int Criticidad { get; set; }
        public Cuenta CuentaResponsable { get; set; }
        public bool Backup { get; set; }

        public Activo()
        {

        }

        public Activo(string nombre, TipoActivo tipoActivo, int criticidad, Cuenta cuentaResponsable, bool backup)
        {
            Nombre = nombre;
            TipoActivo = tipoActivo;
            Criticidad = criticidad;
            CuentaResponsable = cuentaResponsable;
            Backup = backup;
            CodigoAutoincremental = CrearCodigo();
            proximoCodigo++;

        }

        public override string ToString()
        {
            return
            $"Código          : {CodigoAutoincremental}\n" +
            $"Nombre          : {Nombre}\n" +
            $"Tipo            : {TipoActivo}\n" +
            $"Criticidad      : {Criticidad}\n" +
            $"Responsable     : {CuentaResponsable.CodigoAutoincremental}\n" +
            $"Backup          : {(Backup ? "SI" : "NO")}";
        }

        

        public override bool Equals(object? obj)
        {
            Activo a = (Activo)obj;
            return this.CodigoAutoincremental == a.CodigoAutoincremental;

        }

        public void Validar()
        {
            ValidarNombre();
            ValidarCriticidad();
            ValidarCuentaResp();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre de activo no puede quedar vacio.");
            }
            
        }


        private void ValidarCriticidad()
        {
            if(Criticidad < 1 || Criticidad > 5)
            {
                throw new Exception("La criticidad debe ser un numero del 1 al 5");
            }
        }

        private void ValidarCuentaResp()
        {
            if (CuentaResponsable == null)
            {
                throw new Exception("El activo debe tener una cuenta asociada");
            }
        }


        private string CrearCodigo()
        {
            string nuevoCodigo = "";

            if (proximoCodigo <= 9)
            {
                nuevoCodigo = $"{this.TipoActivo}" + "000" + $"{proximoCodigo}";
            }
            else if (proximoCodigo > 9 && proximoCodigo < 100)
            {
                nuevoCodigo = $"{this.TipoActivo}" + "00" + $"{proximoCodigo}";
            }
            else if (proximoCodigo > 99 && proximoCodigo < 1000)
            {
                nuevoCodigo = $"{this.TipoActivo}" + "0" + $"{proximoCodigo}";
            }
            else if (proximoCodigo > 999 && proximoCodigo < 10000)
            {
                nuevoCodigo = $"{this.TipoActivo}" + $"{proximoCodigo}";
            }
            return nuevoCodigo;
        }
    }
}
