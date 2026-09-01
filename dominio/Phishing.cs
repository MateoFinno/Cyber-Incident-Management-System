using System;
using System.Collections.Generic;
using System.Text;

namespace dominio
{
    public class Phishing : Incidente
    {
        public string CanalUtilizado { get; set; }
        public bool EntregoCredenciales { get; set; }
        public bool HuboTransDatos { get; set; }

        public Phishing()
        {

        }

        public Phishing(DateTime fechaDeReporte,Activo activoAfectado,string descripcion,int impacto,Estado estado,int probabilidad,string canalUtilizado,bool entregoCredenciales,bool huboTransDatos): base(fechaDeReporte, activoAfectado, descripcion, impacto, estado, probabilidad)
        {
            CanalUtilizado = canalUtilizado;
            EntregoCredenciales = entregoCredenciales;
            HuboTransDatos = huboTransDatos;
        }

        public override string ToString()
        {
            return
            $"====== INCIDENTE PHISHING ======\n" +
            $"{base.ToString()}\n" +
            $"Canal           : {CanalUtilizado}\n" +
            $"Credenciales    : {(EntregoCredenciales ? "SI" : "NO")}\n" +
            $"Transferencia   : {(HuboTransDatos ? "SI" : "NO")}";

        }

        public override int CalcularSeveridad()
        {
            int severidad = CalcularBase();

            if (severidad > 100) severidad = 100;

            return severidad;
        }

        public override void Validar()
        {
            base.Validar();
            ValidarCanal();
        }

        private void ValidarCanal()
        {
            if (string.IsNullOrEmpty(CanalUtilizado))
            {
                throw new Exception("Debe ingresar un canal valido");

            }
        }

        
    }
}
