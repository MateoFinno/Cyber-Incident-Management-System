using System;
using System.Collections.Generic;
using System.Text;

namespace dominio
{
    public class Cuenta
    {
        private static int proximoCodigo = 1;

        public int CodigoAutoincremental { get; set; }
        public DateTime FechaCambioPass { get; set; }

        public bool MultiFactor { get; set; }

        public Persona Titular {  get; set; }

        
        

        public Cuenta()
        {

        }

        public Cuenta(DateTime fechaCambioPass, bool multiFactor, Persona titular)
        {
            FechaCambioPass = fechaCambioPass;
            MultiFactor = multiFactor;
            CodigoAutoincremental = proximoCodigo++;
            Titular = titular;
        }

        public override string ToString()
        {
            return
            $"Cuenta N°      : {CodigoAutoincremental}\n" +
            $"Último Cambio  : {FechaCambioPass.ToShortDateString()}";
        }

        public override bool Equals(object? obj)
        {
            Cuenta cuenta = (Cuenta)obj;
            return CodigoAutoincremental == cuenta.CodigoAutoincremental;
        }

    }
}
