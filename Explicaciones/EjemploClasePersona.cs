using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploClasePersona
{
    class Persona
    {
        // Atributos
        private string dni;
        private string nombre;
        private string apellido1;
        private string apellido2;
        private DateTime fechaNacimiento;
        private bool tieneSegundoApellido;

        // Constructores
        public Persona(string dni, string nombre,
                       string apellido1, string apellido2,
                       DateTime fechaNacimiento)
        {
            if (DNICorrecto(dni))
            {
                this.Dni = dni;
            }
            else
            {
                throw new Exception("Formato del DNI incorrecto");
            }
            this.Nombre = nombre;
            this.Apellido1 = apellido1;
            this.Apellido2 = apellido2;
            this.FechaNacimiento = fechaNacimiento;
            this.tieneSegundoApellido = true;
        }

        public Persona(string dni, string nombre,
                       string apellido1, DateTime fechaNacimiento)
        {
            if (DNICorrecto(dni))
            {
                this.Dni = dni;
            }
            else
            {
                throw new Exception("Formato del DNI incorrecto");
            }
            this.Nombre = nombre;
            this.Apellido1 = apellido1;
            this.FechaNacimiento = fechaNacimiento;
            this.tieneSegundoApellido = false;
        }

        // Método
        public override string ToString()
        {
            if (this.tieneSegundoApellido)
            {
                return this.Dni + " - " + this.Nombre + " " +
                    this.Apellido1 + " " + this.Apellido2 + " - " +
                    this.FechaNacimiento.ToShortDateString();
            }
            else
            {
                return this.Dni + " - " + this.Nombre + " " +
                    this.Apellido1 + " - " +
                    this.FechaNacimiento.ToShortDateString();
            }

        }

        private bool DNICorrecto(string dni)
        {
            if (dni.Length == 9)
            {
                int i;
                int numeros = 0;

                for (i = 0; i < 8; i++)
                {
                    if (char.IsDigit(dni[i]))
                    {
                        numeros++;
                    }
                }

                if (numeros == 8)
                {
                    if (char.IsLetter(dni[8]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // Propiedades
        public string DNI
        {
            get
            {
                return this.dni;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellidos
        {
            get
            {
                if (this.tieneSegundoApellido)
                {
                    return this.apellido1 + " " + this.apellido2;
                }
                else
                {
                    return this.apellido1;
                }
            }
        }

        public DateTime FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona("12346781A", "José",
                "Martínez", "Fernández", 
                new DateTime(2017, 03, 15));

            Persona p2 = new Persona("98948599B", "Abdelkader",
                "Belbachir", DateTime.Today);

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Console.ReadKey();
        }
    }
}
