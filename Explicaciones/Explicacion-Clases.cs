using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExplicaciónClases
{
    class Coche
    {
        // Atributos = variables
        private string matricula;
        private int annoMatriculacion;
        private bool diesel;

        // Constructor = función especial que inicializa el objeto
        public Coche(string mat, int anno, bool die)
        {
            if (mat.Length == 7)
            {
                matricula = mat.ToUpper();
            }
            else
            {
                throw new Exception("La matrícula debe tener 7 caracteres");
            }

            annoMatriculacion = anno;
            diesel = die;
        }

        public Coche() { }

        // Métodos = funciones
        public int Antiguedad()
        {
            int annoActual = DateTime.Today.Year;
            int ant = annoActual - annoMatriculacion;
            return ant;
        }

        // Propiedades = híbrido de variable y función
        public int ITVCadaAnnos
        {
            // GET sirve para leer el valor de la propiedad
            // Necesita un return
            get
            {
                int ant = Antiguedad();

                if (ant < 4)
                {
                    return 4;
                }
                else
                {
                    if (ant < 10)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }

            // SET sirve para cambiar el valor de la propiedad
            // La función set puede no estar definida
            // En ese caso la propiedad es de solo lectura
            //set
            //{
            //}
        }

        public string Matricula
        {
            get
            {
                return matricula;
            }

            // SET: Tiene un parámetro oculto que se llama value.
            //      Es como si llamáramos a la función así:
            //      set(string value)
            set
            {
                if (value.Length == 7)
                {
                    matricula = value.ToUpper();
                }
                else
                {
                    throw new Exception("La matrícula debe tener 7 caracteres");
                }
            }
        }

        public int AnnoMatriculacion
        {
            get
            {
                return annoMatriculacion;
            }
        }

        public bool Diesel
        {
            get
            {
                return diesel;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //// tipo de datos: variable
            //int a;

            //// POO> clase: objeto

            //string s;
            //StreamReader sr;
            //Random r;
            //List<int> l;

            Coche c = new Coche();
            c.Matricula = "9348PPP";
            c.annoMatriculacion = 2005;
            c.diesel = true;

            

            //Coche c2 = new Coche();
            //c2.matricula = "8458MMM";
            //c2.annoMatriculacion = 2010;
            //c2.diesel = false;

            Coche c2 = new Coche("1238mmm", 2010, false);

            Console.WriteLine(c.Matricula + " = " + c.Antiguedad());
            Console.WriteLine(c2.Matricula + " = " + c2.Antiguedad());

            Console.WriteLine(c2.ITVCadaAnnos);

            // Nivel de protección
            // PUBLIC: se puede usar el atributo, método o 
            //         propiedad desde el programa principal
            // PRIVATE: no se puede usar el atributo, método o
            //          propiedad desde fuera, sólo dentro de la
            //          clase

            c.Matricula = "3498LLL";

            Console.ReadKey();

        }
    }
}
