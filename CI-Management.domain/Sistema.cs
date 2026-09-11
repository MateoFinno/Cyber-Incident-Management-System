using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace dominio
{
    public class Sistema
    {
        private List<Persona> ListaPersonas { get; set; } = new List<Persona>();
        private List<Cuenta> ListaCuentas { get; set; } = new List<Cuenta>();
        private List<Activo> ListaActivos { get; set; } = new List<Activo>();
        private List<Incidente> ListaIncidentes { get; set; } = new List<Incidente>();
        public static Sistema Instancia;

        public Sistema()
        {
            PrecargarDatos();
        }

        public static Sistema ObtenerInstancia()
        {
            if(Instancia == null)
            {
                Instancia= new Sistema();
            }
            return Instancia;
        }
            public void PrecargarDatos()
        {
            // =========================
            // PERSONAS
            // =========================

            Persona p1 = new Persona("52345678", "Juan Perez", "juan@gmail.com", 099111111, Rol.ADMIN, "password");
            Persona p2 = new Persona("51234567", "Maria Gomez", "maria@gmail.com", 099222222, Rol.OPERADOR, "password");
            Persona p3 = new Persona("49876543", "Lucia Fernandez", "lucia@gmail.com", 099333333, Rol.OPERADOR, "password");
            Persona p4 = new Persona("47654321", "Pedro Rodriguez", "pedro@gmail.com", 099444444, Rol.OPERADOR, "password");
            Persona p5 = new Persona("46789123", "Ana Silva", "ana@gmail.com", 099555555, Rol.OPERADOR, "password");
            Persona p6 = new Persona("45678912", "Martin Lopez", "martin@gmail.com", 099666666, Rol.OPERADOR, "password");
            Persona p7 = new Persona("44567891", "Carla Diaz", "carla@gmail.com", 099777777, Rol.OPERADOR, "password");
            Persona p8 = new Persona("43456789", "Sofia Torres", "sofia@gmail.com", 099888888, Rol.OPERADOR, "password");
            Persona p9 = new Persona("42345678", "Diego Castro", "diego@gmail.com", 099999999, Rol.OPERADOR, "password");
            Persona p10 = new Persona("41234567", "Valentina Ruiz", "valentina@gmail.com", 099101010, Rol.OPERADOR, "password");

            AltaPersona(p1);
            AltaPersona(p2);
            AltaPersona(p3);
            AltaPersona(p4);
            AltaPersona(p5);
            AltaPersona(p6);
            AltaPersona(p7);
            AltaPersona(p8);
            AltaPersona(p9);
            AltaPersona(p10);



            // =========================
            // CUENTAS
            // =========================

            Cuenta c1 = new Cuenta(DateTime.Now.AddMonths(-2), true , p1);
            Cuenta c2 = new Cuenta(DateTime.Now.AddMonths(-1), false, p2);
            Cuenta c3 = new Cuenta(DateTime.Now.AddMonths(-5), true, p3);
            Cuenta c4 = new Cuenta(DateTime.Now.AddMonths(-7), false, p4);
            Cuenta c5 = new Cuenta(DateTime.Now.AddMonths(-3), true, p5);
            Cuenta c6 = new Cuenta(DateTime.Now.AddMonths(-4), true, p6);
            Cuenta c7 = new Cuenta(DateTime.Now.AddMonths(-8), false, p7);
            Cuenta c8 = new Cuenta(DateTime.Now.AddMonths(-6), true, p8);
            Cuenta c9 = new Cuenta(DateTime.Now.AddMonths(-9), false, p9);
            Cuenta c10 = new Cuenta(DateTime.Now.AddMonths(-10), true, p10);
            Cuenta c11 = new Cuenta(DateTime.Now.AddMonths(-11), false, p1);
            Cuenta c12 = new Cuenta(DateTime.Now.AddMonths(-12), true, p10);

            AltaCuenta(c1);
            AltaCuenta(c2);
            AltaCuenta(c3);
            AltaCuenta(c4);
            AltaCuenta(c5);
            AltaCuenta(c6);
            AltaCuenta(c7);
            AltaCuenta(c8);
            AltaCuenta(c9);
            AltaCuenta(c10);
            AltaCuenta(c11);
            AltaCuenta(c12);


            // =========================
            // ACTIVOS
            // =========================

            Activo a1 = new Activo("PC Finanzas", TipoActivo.PC, 5, c1, true);
            Activo a2 = new Activo("Servidor Principal", TipoActivo.SERVER, 5, c2, true);
            Activo a3 = new Activo("Laptop Gerencia", TipoActivo.PC, 4, c3, false);
            Activo a4 = new Activo("Servidor Backup", TipoActivo.SERVER, 4, c4, true);
            Activo a5 = new Activo("Celular Ventas", TipoActivo.MOVIL, 2, c5, false);
            Activo a6 = new Activo("PC RRHH", TipoActivo.PC, 3, c6, true);
            Activo a7 = new Activo("Servidor Web", TipoActivo.SERVER, 5, c7, false);
            Activo a8 = new Activo("Laptop Soporte", TipoActivo.PC, 3, c8, true);
            Activo a9 = new Activo("Tablet Administración", TipoActivo.MOVIL, 2, c9, false);
            Activo a10 = new Activo("Servidor BD", TipoActivo.SERVER, 5, c10, true);
            Activo a11 = new Activo("PC Marketing", TipoActivo.PC, 2, c11, false);
            Activo a12 = new Activo("Celular CEO", TipoActivo.MOVIL, 5, c12, true);
            Activo a13 = new Activo("PC Desarrollo", TipoActivo.PC, 4, c1, true);
            Activo a14 = new Activo("Servidor QA", TipoActivo.SERVER, 3, c2, false);
            Activo a15 = new Activo("Laptop Diseño", TipoActivo.PC, 2, c3, true);

            AltaActivo(a1);
            AltaActivo(a2);
            AltaActivo(a3);
            AltaActivo(a4);
            AltaActivo(a5);
            AltaActivo(a6);
            AltaActivo(a7);
            AltaActivo(a8);
            AltaActivo(a9);
            AltaActivo(a10);
            AltaActivo(a11);
            AltaActivo(a12);
            AltaActivo(a13);
            AltaActivo(a14);
            AltaActivo(a15);

            // =========================
            // INCIDENTES
            // =========================

            Incidente i1 = new Phishing(DateTime.Now.AddDays(-1), a1, "Correo falso bancario", 4, Estado.ABIERTO, 5, "Email", true, true);
            Incidente i2 = new Phishing(DateTime.Now.AddDays(-2), a2, "Mensaje sospechoso", 3, Estado.EN_ANALISIS, 4, "WhatsApp", false, false);
            Incidente i3 = new Phishing(DateTime.Now.AddDays(-3), a3, "Suplantación de identidad", 5, Estado.CONTENIDO, 5, "Email", true, false);
            Incidente i4 = new Phishing(DateTime.Now.AddDays(-4), a4, "Link malicioso", 2, Estado.CERRADO, 2, "Redes Sociales", false, false);
            Incidente i5 = new Phishing(DateTime.Now.AddDays(-5), a5, "Intento de robo de credenciales", 4, Estado.ABIERTO, 4, "SMS", true, true);
            Incidente i6 = new Ramsomware(DateTime.Now.AddDays(-6), a6, "Archivos encriptados", 5, Estado.EN_ANALISIS, 5, true, true);
            Incidente i7 = new Ramsomware(DateTime.Now.AddDays(-7), a7, "Ataque ransomware", 5, Estado.CONTENIDO, 4, true, false);
            Incidente i8 = new Ramsomware(DateTime.Now.AddDays(-8), a8, "Secuestro de información", 4, Estado.ABIERTO, 5, true, true);
            Incidente i9 = new Ramsomware(DateTime.Now.AddDays(-9), a9, "Bloqueo de sistema", 3, Estado.CERRADO, 3, false, false);
            Incidente i10 = new Ramsomware(DateTime.Now.AddDays(-10), a10, "Exfiltración detectada", 5, Estado.EN_ANALISIS, 5, true, true);
            Incidente i11 = new Phishing(DateTime.Now.AddDays(-11), a11, "Correo fraudulento RRHH", 2, Estado.CERRADO, 2, "Email", false, false);
            Incidente i12 = new Phishing(DateTime.Now.AddDays(-12), a12, "Intento de acceso falso", 3, Estado.EN_ANALISIS, 3, "SMS", true, false);
            Incidente i13 = new Phishing(DateTime.Now.AddDays(-13), a13, "Suplantacion de Microsoft", 4, Estado.ABIERTO, 5, "Email", true, true);
            Incidente i14 = new Phishing(DateTime.Now.AddDays(-14), a14, "Link sospechoso recibido", 1, Estado.CERRADO, 1, "WhatsApp", false, false);
            Incidente i15 = new Phishing(DateTime.Now.AddDays(-15), a15, "Pagina falsa de autenticacion", 5, Estado.CONTENIDO, 5, "Redes Sociales", true, true);
            Incidente i16 = new Ramsomware(DateTime.Now.AddDays(-16), a1, "Equipo bloqueado por ransomware", 4, Estado.EN_ANALISIS, 4, true, false);
            Incidente i17 = new Ramsomware(DateTime.Now.AddDays(-17), a2, "Archivos cifrados", 5, Estado.ABIERTO, 5, true, true);
            Incidente i18 = new Ramsomware(DateTime.Now.AddDays(-18), a3, "Ataque detectado en laptop", 3, Estado.CONTENIDO, 3, false, false);
            Incidente i19 = new Ramsomware(DateTime.Now.AddDays(-19), a4, "Servidor comprometido", 5, Estado.EN_ANALISIS, 5, true, true);
            Incidente i20 = new Ramsomware(DateTime.Now.AddDays(-20), a5, "Intento de cifrado detenido", 2, Estado.CERRADO, 2, false, false);
            Incidente i21 = new Phishing(DateTime.Now.AddDays(-21), a6, "Mensaje falso de soporte", 2, Estado.ABIERTO, 2, "Telegram", false, false);
            Incidente i22 = new Phishing(DateTime.Now.AddDays(-22), a7, "Correo con archivo malicioso", 4, Estado.EN_ANALISIS, 4, "Email", true, false);
            Incidente i23 = new Phishing(DateTime.Now.AddDays(-23), a8, "Intento de robo de contraseña", 3, Estado.CONTENIDO, 3, "SMS", true, true);
            Incidente i24 = new Ramsomware(DateTime.Now.AddDays(-24), a9, "Disco cifrado parcialmente", 3, Estado.ABIERTO, 4, false, false);
            Incidente i25 = new Ramsomware(DateTime.Now.AddDays(-25), a10, "Secuestro de archivos críticos", 5, Estado.EN_ANALISIS, 5, true, true);
            Incidente i26 = new Phishing(DateTime.Now.AddDays(-26), a11, "Correo falso de banco", 2, Estado.CERRADO, 2, "Email", false, false);
            Incidente i27 = new Ramsomware(DateTime.Now.AddDays(-27), a12, "Ransomware propagado en red", 5, Estado.CONTENIDO, 5, true, true);
            Incidente i28 = new Phishing(DateTime.Now.AddDays(-28), a13, "Sitio web clonado", 4, Estado.ABIERTO, 4, "Redes Sociales", true, false);
            Incidente i29 = new Ramsomware(DateTime.Now.AddDays(-29), a14, "Equipo inutilizado", 3, Estado.EN_ANALISIS, 4, true, false);
            Incidente i30 = new Phishing(DateTime.Now.AddDays(-30), a15, "Mensaje fraudulento interno", 5, Estado.CERRADO, 1, "Telegram", false, false);

            AltaIncidente(i1);
            AltaIncidente(i2);
            AltaIncidente(i3);
            AltaIncidente(i4);
            AltaIncidente(i5);
            AltaIncidente(i6);
            AltaIncidente(i7);
            AltaIncidente(i8);
            AltaIncidente(i9);
            AltaIncidente(i10);
            AltaIncidente(i11);
            AltaIncidente(i12);
            AltaIncidente(i13);
            AltaIncidente(i14);
            AltaIncidente(i15);
            AltaIncidente(i16);
            AltaIncidente(i17);
            AltaIncidente(i18);
            AltaIncidente(i19);
            AltaIncidente(i20);
            AltaIncidente(i21);
            AltaIncidente(i22);
            AltaIncidente(i23);
            AltaIncidente(i24);
            AltaIncidente(i25);
            AltaIncidente(i26);
            AltaIncidente(i27);
            AltaIncidente(i28);
            AltaIncidente(i29);
            AltaIncidente(i30);

        }
        

        public void ValidarExistenciaPersona(Persona p)
        {
            if (ListaPersonas.Contains(p))
            {
                throw new Exception("La persona que esta intentando crear ya existe.");
            }
        }

        public void ValidarExistenciaCuenta(Cuenta c)
        {
            if (ListaCuentas.Contains(c))
            {
                throw new Exception("La cuenta que esta intentando crear ya existe.");
            }
        }

        public void ValidarExistenciaActivo(Activo a)
        {
            if (ListaActivos.Contains(a))
            {
                throw new Exception("el activo que esta intentando crear ya existe.");
            }
        }

        public void ValidarExistenciaIncidente(Incidente i)
        {
            if (ListaIncidentes.Contains(i))
            {
                throw new Exception("el activo que esta intentando crear ya existe.");
            }
        }

        public void AltaPersona(Persona p)
        {
            p.Validar();
            ValidarExistenciaPersona(p);
            ListaPersonas.Add(p);
        }

        public void AltaCuenta(Cuenta c)
        {
            ValidarExistenciaCuenta(c);
            ListaCuentas.Add(c);
        }

        public void AltaActivo(Activo a)
        {
            a.Validar();
            ValidarExistenciaActivo(a);
            ListaActivos.Add(a);
        }

        public void AltaIncidente(Incidente i)
        {
            i.Validar();
            ValidarExistenciaIncidente(i);
            ListaIncidentes.Add(i);
        }

        public List<Activo> ListarActivosSinBackup()
        {
            List<Activo> Resultado = new List<Activo>();

            foreach(Activo a in ListaActivos)
            {
                if (!a.Backup)
                {
                    Resultado.Add(a);
                }
            }
            return Resultado;
        }


        public List<Incidente> ObtenerIncidentesOrdenadosPorSeveridad()
        {
            List<Incidente> copiaLista = new List<Incidente>(ListaIncidentes);

            copiaLista.Sort(); 

            return copiaLista;
        }


        public List<Persona> ObtenerPersonas()
        {
            List<Persona> Resultado = new List<Persona>();

            foreach(Persona p in ListaPersonas)
            {
                Resultado.Add(p);
            }
            return Resultado;
        }

        public List<Incidente> ObtenerIncidentePorPersona(Persona p)
        { 
            List<Incidente> resultado = new List<Incidente>();

            foreach(Incidente i in ListaIncidentes)
            {
                if(i.ActivoAfectado.CuentaResponsable.Titular == p)
                {
                    resultado.Add(i);
                }
            }
            return resultado;
        }


        public List<Activo> ObtenerActivoPorPersona(Persona p)
        {
            List<Activo> resultado = new List<Activo>();

            foreach(Activo a in ListaActivos)
            {
                if(a.CuentaResponsable.Titular == p)
                {
                    resultado.Add(a);
                    resultado = resultado.OrderBy(a => a.CodigoAutoincremental).ToList();
                }
            }
            return resultado;
        }


        public Persona BuscarPersonaPorCedula(string cedula)
        {
            Persona persona = null;
            bool personaEncontrada = false;
            foreach (Persona p in ListaPersonas)
            {
                if (p.Cedula == cedula)
                {
                    persona = p;
                    personaEncontrada = true;
                    
                }
            }
            if (!personaEncontrada)
            {
                throw new Exception("La persona ingrsada no existe en el sistema");
            }

            return persona;
        }

        public Persona BuscarPersonaPorEmailYContraseña(string email, string contra)
        {
            Persona persona = null;
            bool personaEncontrada = false;
            foreach(Persona p in ListaPersonas)
            {
                if(p.Email == email && p.Contraseña == contra)
                {
                    persona = p;
                    personaEncontrada = true;
                }
            }
            if (!personaEncontrada)
            {
                throw new Exception("El Email o contraseña son incorrectos");
            }
            return persona;
        }

        public List<Cuenta> BuscarCuentasPorPersona(Persona p)
        {
            List<Cuenta> Resultado = new List<Cuenta>();
            foreach (Cuenta c in ListaCuentas)
            {
                if(c.Titular == p)
                {
                    Resultado.Add(c);
                }
            }
            return Resultado;
        }
        
        public List<Activo> ListarActivosPorCodCuenta(int Cod)
        {
            List<Activo> Resultado = new List<Activo>();
            foreach (Activo a in ListaActivos)
            {
                if(a.CuentaResponsable.CodigoAutoincremental == Cod)
                {
                    Resultado.Add((Activo)a);
                }
            }
            return Resultado ;
        }

        public Cuenta BuscarCuentaPorCodigo(int codigo)
        {
            Cuenta cuenta = null;
            bool cuentaEncontrada = false;
            foreach (Cuenta c in ListaCuentas)
            {
                if(c.CodigoAutoincremental == codigo)
                {
                    cuenta = c;
                    cuentaEncontrada = true;
                }
            }
            if(!cuentaEncontrada)
            {
                throw new Exception("La cuenta que esta intentando buscar no existe");
            }
            return cuenta;
        }

        public Activo BuscarActivoPorCodigo(string codigo)
        {
            Activo activo = null;
            bool ActivoEncontrado = false;
            foreach(Activo a in ListaActivos)
            {
                if(a.CodigoAutoincremental == codigo)
                {
                    activo = a;
                    ActivoEncontrado = true;
                }
                
            }
            if (!ActivoEncontrado)
            {
                throw new Exception("El Activo no existe");
            }
            return activo;
        }

        public void EliminarActivoPorCodigo(string codigoActivo)
        {
            Activo activo = BuscarActivoPorCodigo(codigoActivo);
            ListaActivos.Remove(activo);
        }
    }
}
