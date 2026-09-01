using System;
using System.Collections.Generic;
using System.Text;

namespace dominio
{
    public abstract class Incidente : Ivalidable, IComparable<Incidente>
    {
        private static int proximoID = 1;

        public int IdAutonumerico { get; set; }
        public DateTime FechaDeReporte { get; set; }
        public Activo ActivoAfectado { get; set; }
        public string Descripcion { get; set; }
        public int Impacto { get; set; }
        public Estado Estado { get; set; }
        public int Probabilidad { get; set; }

        public abstract int CalcularSeveridad();

        protected int CalcularBase()
        {
            return (Impacto * 12) + (Probabilidad * 8);
        }

        public int CompareTo(Incidente? otroIncidente)
        {
            if (otroIncidente == null) return 1;

            return otroIncidente.CalcularSeveridad().CompareTo(this.CalcularSeveridad());
        }

        public Incidente()
        {

        }

        public Incidente(DateTime fechaDeReporte, Activo activoAfectado, string descripcion, int impacto, Estado estado, int probabilidad)
        {
            FechaDeReporte = fechaDeReporte;
            ActivoAfectado = activoAfectado;
            Descripcion = descripcion;
            Impacto = impacto;
            Estado = estado;
            Probabilidad = probabilidad;
            IdAutonumerico = proximoID++;
        }

        public override string ToString()
        {
            return
           $"ID              : {IdAutonumerico}\n" +
           $"Fecha           : {FechaDeReporte.ToShortDateString()}\n" +
           $"Activo          : {ActivoAfectado.Nombre}\n" +
           $"Estado          : {Estado}\n" +
           $"Impacto         : {Impacto}\n" +
           $"Probabilidad    : {Probabilidad}\n" +
           $"Severidad       : {CalcularSeveridad()}\n" +
           $"Descripción     : {Descripcion}";

        }

        public override bool Equals(object? obj)
        {
            Incidente i = (Incidente)obj;
            return this.IdAutonumerico == i.IdAutonumerico;
        }

        public virtual void Validar()
        {
            ValidarActivoAf();
            ValidarDescripcion();
            ValidarImpacto();
            ValidarProbabilidad();
        }


        private void ValidarActivoAf()
        {
            if(ActivoAfectado == null)
            {
                throw new Exception("Debe seleccionar un activo afectado");
            }

        }

        private void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("La descripción no puede ser vacía");
            }

        }

        private void ValidarImpacto()
        {
            if (Impacto < 1 || Impacto > 5)
            {
                throw new Exception("El impacto debe ser un número entre 1 y 5");
            }

        }

        private void ValidarProbabilidad()
        {
            if (Probabilidad < 1 || Probabilidad > 5)
            {
                throw new Exception("La probabilidad debe ser un número entre 1 y 5");
            }
        }

    }
}
