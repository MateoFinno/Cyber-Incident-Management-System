using System;
using System.Collections.Generic;
using System.Text;

namespace dominio
{
    public class Ramsomware : Incidente
    {
        public bool DatosEncriptados { get; set; }
        public bool HuboExfiltracion { get; set; }

        public Ramsomware()
        {

        }

        public Ramsomware(DateTime fechaDeReporte, Activo activoAfectado, string descripcion, int impacto, Estado estado, int probabilidad, bool datosEncriptados, bool huboExfiltacion) : base(fechaDeReporte, activoAfectado, descripcion, impacto, estado, probabilidad)
        {
            DatosEncriptados = datosEncriptados;
            HuboExfiltracion = huboExfiltacion;
        }

        public override string ToString()
        {
            return
            $"===== INCIDENTE RANSOMWARE =====\n" +
            $"{base.ToString()}\n" +
            $"Encriptados     : {(DatosEncriptados ? "SI" : "NO")}\n" +
            $"Exfiltración    : {(HuboExfiltracion ? "SI" : "NO")}";

        }

        public override int CalcularSeveridad()
        {
            int severidad = CalcularBase();

            if (DatosEncriptados)
            {
                severidad += 20;
            }

            if (HuboExfiltracion)
            {
                severidad += 25;
            }

            if (ActivoAfectado.Backup)
            {
                severidad -= 15;
            }

            if (severidad > 100)
            {
                severidad = 100;
            }

            if (severidad < 0)
            {
                severidad = 0;
            }

            return severidad;
        }

    }
}
