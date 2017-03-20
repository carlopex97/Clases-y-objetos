using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relacion1Clases
{
    //oro, copas, espadas, bastos
    class Carta
    {
        private int numero;
        private int palo;

        public Carta(int numero, int palo)
        {
            if (numero < 1 || numero > 10)
            {
                throw new Exception("La carta tiene que estar entre 1 y 10");
            }
            else
            {
                this.numero = numero;
            }
            if (palo < 0 || palo > 3)
            {
                throw new Exception("El palo tiene que estar entre 0 y 3");
            }
            else
            {
                this.palo = palo;
            }
        }
        public Carta(int id)
        {
            if (id < 1 || id > 40)
            {
                throw new Exception("La carta tiene que estar entre 1 y 40");
            }
            else
            {
                if (id < 11)
                {
                    palo = 0;
                    numero = id;
                }
                else
                {
                    if (id < 21)
                    {
                        palo = 1;
                        numero = id - 10;
                    }
                    else
                    {
                        if (id < 31)
                        {
                            palo = 2;
                            numero = id - 20;
                        }
                        else
                        {
                            if (id < 41)
                            {
                                palo = 3;
                                numero = id - 30;
                            }
                        }
                    }
                }
            }
        }
        public int Numero
        {
            get
            {
                return this.numero;
            }
        }
        public int Palo
        {
            get
            {
                return this.palo;
            }
        }
        public string NombreNumero
        {
            get
            {
                switch (numero)
                {
                    case 1: return "As";
                    case 2: return "Dos";
                    case 3: return "Tres";
                    case 4: return "Cuatro";
                    case 5: return "Cinco";
                    case 6: return "Seis";
                    case 7: return "Siete";
                    case 8: return "Sota";
                    case 9: return "Caballo";
                    case 10: return "Rey";
                    default: return "";
                }

            }

        }
        public string NombrePalo
        {
            get
            {
                switch (palo)
                {
                    case 0: return "oros";
                    case 1: return "copas";
                    case 2: return "espadas";
                    case 3: return "bastos";
                    default: return "";
                }
            }
        }
        public string NombreCarta
        {
            get
            {
                return NombreNumero + " de " + NombrePalo;
            }
        }
        public int ValorTute
        {
            get
            {
                switch (numero)
                {
                    case 1: return 11;
                    case 2: return 0;
                    case 3: return 10;
                    case 4: return 0;
                    case 5: return 0;
                    case 6: return 0;
                    case 7: return 0;
                    case 8: return 2;
                    case 9: return 3;
                    case 10: return 4;
                    default: return 0;
                }
            }
        }
        public int ValorMus
        {
            get
            {
                switch (numero)
                {
                    case 1: return 1;
                    case 2: return 1;
                    case 3: return 10;
                    case 4: return 4;
                    case 5: return 5;
                    case 6: return 6;
                    case 7: return 7;
                    case 8: return 8;
                    case 9: return 10;
                    case 10: return 10;
                    default: return 10;
                }
            }
        }
        //¿Por que double y no decimal?
        public double Valor7ymedia
        {
            get
            {
                switch (numero)
                {
                    case 1: return 1;
                    case 2: return 2;
                    case 3: return 3;
                    case 4: return 4;
                    case 5: return 5;
                    case 6: return 6;
                    case 7: return 7;
                    case 8: return 0.5;
                    case 9: return 0.5;
                    case 10: return 0.5;
                    default: return 0;
                }

            }

        }

    }
    class Baraja
    {
        private List<int> lista_cartas = new List<int>();
        //Constructores
        public Baraja() { }
        public Baraja(int tipobaraja)
        {
            switch (tipobaraja)
            {
                case 1:
                    {
                        for (int i = 1; i < 41; i++)
                        {
                            lista_cartas.Add(i);
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = 1; i < 81; i++)
                        {
                            lista_cartas.Add(i);
                        }
                        break;
                    }
                default: break;
            }
        }
        public Baraja(int tipobaraja, bool barajar)
        {

        }
        //Metodos
        public void Barajar()
        {

            List<int> aux = new List<int>() { };
            aux.AddRange(lista_cartas);
            lista_cartas.Clear();
            Random r = new Random();
            int i;
            int n;
            for (i = 0; aux.Count > 0; i++)
            {
                n = r.Next(aux.Count);
                lista_cartas.Add(aux[n]);
                aux.RemoveAt(n);
            }
        }
        public void Cortar(int posicion)
        {
            List<int> aux = new List<int>() { };
            aux.AddRange(lista_cartas);
            lista_cartas.Clear();
            for (int i = posicion; i < aux.Count; i++)
            {
                lista_cartas.Add(aux[i]);
            }
            for (int i = 0; i < posicion; i++)
            {
                lista_cartas.Add(aux[i]);
            }
        }
        public Carta Robar()
        {
            Carta c = new Carta(lista_cartas[0]);
            lista_cartas.RemoveAt(0);
            return c;
        }
        public void InsertaCartaFinal(int id_carta)
        {
            lista_cartas.Add(id_carta);
        }
        public void InsertaCartaPrincipio(int id_carta)
        {
            lista_cartas.Insert(0, id_carta);
        }


        //Propiedades
        public int NumeroCartas
        {
            get
            {
                return lista_cartas.Count();
            }
        }
        public bool Vacia
        {
            get
            {
                if (lista_cartas.Count != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        class Program
        {
            static void EscribeLista(List<int> lista)
            {
                int i;
                Console.Write("< ");
                for (i = 0; i < lista.Count; i++)
                {
                    Console.Write(lista[i] + " ");
                }
                Console.WriteLine(">");
            }
            static void Main(string[] args)

            {

                Baraja baraja = new Baraja(1);
                baraja.Barajar();
                bool nuevacarta = true;
                bool jugadorsigue = true;
                bool iasigue = true;
                int numerocarta = 1;
                int numerocartaia = 1;
                string aux;
                double cont = 0;
                double contia = 0;
                Carta c = new Carta(25);
                string carta;
                double num = 7.5;
                while (nuevacarta == true)
                {
                    //Jugador
                    if (jugadorsigue == true)
                    {
                        baraja.Barajar();
                        c = baraja.Robar();
                        carta = c.NombreCarta;
                        Console.Write("La carta nº " + numerocarta + " es:  ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(carta);
                        numerocarta++;
                        cont = cont + c.Valor7ymedia;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Llevas: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(cont + " puntos");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (cont > num)
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            if (cont == num)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Write("¿Quieres otra carta? ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("si");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write(" o ");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("no");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                aux = Console.ReadLine();
                                if (aux == "si")
                                {
                                    jugadorsigue = true;
                                }
                                else
                                {
                                    jugadorsigue = false;
                                }
                                Console.Clear();
                            }
                        }
                    }
                    else
                    {
                        Console.Write("La puntuación total del jugador es ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(cont);
                    }
                    //IA


                    if (iasigue == true)
                    {
                        baraja.Barajar();
                        c = baraja.Robar();
                        carta = c.NombreCarta;
                        Console.Write("La carta nº " + numerocartaia + " es:  ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(carta);
                        numerocartaia++;
                        contia = contia + c.Valor7ymedia;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Llevas: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(contia + " puntos");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (contia > num)
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            if (contia == num)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Write("¿Quieres otra carta? ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("si");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write(" o ");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("no");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                aux = Console.ReadLine();
                                if (aux == "si")
                                {
                                    iasigue = true;
                                }
                                else
                                {
                                    iasigue = false;
                                }
                                Console.Clear();
                            }
                        }
                    }
                    else
                    {
                        Console.Write("La puntuación total de la IA es ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(contia);
                    }
                    if (jugadorsigue == true || iasigue == false)
                    {
                        nuevacarta = true;
                    }
                    else
                    {
                        nuevacarta = false;
                    }
                }
                Console.Write("Tu puntuación total es ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(cont);

                if (cont == num)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enhorabuena Jugador has ganado, ere un fiera");
                }
                else
                {
                    if (cont > num)
                    {
                        num = cont - num;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Jugador, te has pasado " + num + " puntos de las 7 y media");
                    }
                    else
                    {
                        if (cont < num)
                        {
                            num = num - cont;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Juagdor te has quedado a " + num + " puntos de las 7 y media");
                        }
                    }
                }
                if (contia == num)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enhorabuena IA has ganado, ere una fiera");
                }
                else
                {
                    if (contia > num)
                    {
                        num = contia - num;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("La IA se ha pasado " + num + " puntos de las 7 y media");
                    }
                    else
                    {
                        if (contia < num)
                        {
                            num = num - contia;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("La IA se ha quedado a " + num + " puntos de las 7 y media");
                        }
                    }
                }

                Console.ReadKey();
            }
        }
    }
}