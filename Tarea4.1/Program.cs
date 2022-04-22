using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            long invitado;
            Console.Write("Ingresa tu nombre: ");
            string nombreCliente = Console.ReadLine();
            Console.Clear();
            Console.Write("Cuentas con tarjeta de invitado especial: ");
            string ie = Console.ReadLine();
            ie = ie.ToLower();
            if (ie == "si")
            {
                Console.Clear();
                Console.Write("Ingresa tu numero de invitado especial: ");
                invitado = long.Parse(Console.ReadLine());
                InvitadoEspecial guest = new InvitadoEspecial(nombreCliente, invitado); //Creacion de objeto clase derivada InvitadoEspecial, enviando parametros
                Console.Clear();
                guest.Menu();  //LLamada al metodo menu clase base
                Console.Clear();
                guest.Seleccion();  //LLamada al metodo seleccion clase base
                float total = guest.Total();  //Llamada al metodo total de la clase derivada, mediante polimorfismo
                Console.Clear();
                guest.Desplegar();  //Llamada al metodo desplegar de la clase derivada, mediante polimorfismo
                Console.WriteLine($"El total es {total}.\nTus puntos IE son: {total * .18}\n\n¡¡¡QUE DISFRUTES LA PELICULA !!!");
            }
            else
            {
                if (ie == "no")
                {
                    Console.Clear();
                    CineTec cine = new CineTec(nombreCliente);//Creacion de objeto clase base CineTec, enviando parametros
                    Console.Clear();
                    cine.Menu();   //LLamada al metodo menu clase base
                    Console.Clear();
                    cine.Seleccion();      //LLamada al metodo seleccion clase base
                    float total = cine.Total();      //Llamada al metodo total de la clase base, mediante polimorfismo
                    Console.Clear();
                    cine.Desplegar();       //Llamada al metodo desplegar de la clase base, mediante polimorfismo
                    Console.WriteLine($"El total es {total}.\n\n¡¡¡QUE DISFRUTES LA PELICULA !!!");
                }
            }
        }

    }
    class CineTec
    {
        public int opc;
        string nombreCliente;
        public string combo;
        float precio;
        string[] saborP, saborB;
        int cantidad;

        public CineTec()
        {

        }

        public CineTec(string nombreCliente)
        {
            this.nombreCliente = nombreCliente;
        }

        public void Menu()
        {
            Console.WriteLine("Selecciona el numero de combo correspondiente: ");
            Console.WriteLine("(1) Combo 1: 1 palomitas grandes, 1 soda grande y un chocolate    ......    $195");
            Console.WriteLine("(2) Combo 2: 1 palomitas grandes, 2 soda grandes y un chocolate   ......    $225");
            Console.WriteLine("(3) Combo 3: 1 palomitas grandes, 2 soda grandes y unos nachos    ......    $255");
            Console.WriteLine("(4) Combo 4: 1 palomitas grandes, 2 soda grandes y dos hot dogs   ......    $285");
            Console.WriteLine("(5) Combo 5: 1 palomitas grandes, 2 ICEE grandes y un chocolate   ......    $255");
            Console.WriteLine("(6) Combo 6: 2 palomitas grandes, 4 soda grandes y dos chocolates ......    $350");
            opc = int.Parse(Console.ReadLine());
            switch (opc)
            {
                case 1: combo = "Haz elegido el Combo 1"; break;
                case 2: combo = "Haz elegido el Combo 2"; break;
                case 3: combo = "Haz elegido el Combo 3"; break;
                case 4: combo = "Haz elegido el Combo 4"; break;
                case 5: combo = "Haz elegido el Combo 5"; break;
                case 6: combo = "Haz elegido el Combo 6"; break;
                default: Console.WriteLine("Error en la seleccion"); break;
            }
        }
        public virtual float Total()
        {
            switch (opc)
            {
                case 1: precio = 195; break;
                case 2: precio = 225; break;
                case 3: precio = 255; break;
                case 4: precio = 285; break;
                case 5: precio = 255; break;
                case 6: precio = 350; break;
                default: Console.WriteLine("Error en la seleccion"); break;
            }
            return precio;
        }
        public void Seleccion()
        {
            cantidad = 0;
            if (opc == 6)
            {
                cantidad = 2;
            }
            else
            {
                if (opc == 1 || opc == 2 || opc == 3 || opc == 4 || opc == 5)
                {
                    cantidad = 1;
                }
            }
            saborP = new string[cantidad];
            for (int i = 0; i < saborP.Length; i++)
            {
                Console.WriteLine($"Elige el sabor de las palomitas: ");
                saborP[i] = Console.ReadLine();
            }
            cantidad = 0;
            if (opc == 6)
            {
                cantidad = 4;
            }
            else
            {
                if (opc == 2 || opc == 3 || opc == 4 || opc == 5)
                {
                    cantidad = 2;
                }
                else if (opc == 1)
                {
                    cantidad = 1;
                }
            }
            saborB = new string[cantidad];
            for (int i = 0; i < saborB.Length; i++)
            {
                Console.Clear();
                Console.WriteLine($"Elige el sabor de las bebidas: ");
                saborB[i] = Console.ReadLine();
            }
        }
        public virtual void Desplegar()
        {
            Console.WriteLine($"Nombre del cliente: {nombreCliente}. \n{combo}");
            if (opc == 6)
            {
                cantidad = 2;
            }
            else
            {
                if (opc == 1 || opc == 2 || opc == 3 || opc == 4 || opc == 5)
                {
                    cantidad = 1;
                }
            }
            for (int i = 0; i < saborP.Length; i++)
            {
                Console.WriteLine($"Palomitas {i + 1} sabor {saborP[i]}");

            }
            for (int i = 0; i < saborB.Length; i++)
            {
                Console.WriteLine($"Bebidas {i + 1} sabor {saborB[i]}");
            }
        }
        ~CineTec()
        {
            Console.WriteLine($"Memoria Liberada Objeto {this.nombreCliente}\nClase Base");
        }
    }
    class InvitadoEspecial : CineTec
    {
        string nombreCliente;
        float precio;
        long invitado;
        int cantidad;
        string[] saborP, saborB;
        public InvitadoEspecial()
        {

        }
        public InvitadoEspecial(string nombreCliente, long invitado) : base(nombreCliente)
        {
            this.nombreCliente = nombreCliente;
            this.invitado = invitado;
        }
        public override float Total()
        {
            switch (opc)
            {
                case 1: precio = (float)(195 - (195 * .15)); break;
                case 2: precio = (float)(225 - (225 * .15)); break;
                case 3: precio = (float)(255 - (255 * .15)); break;
                case 4: precio = (float)(285 - (285 * .15)); break;
                case 5: precio = (float)(255 - (255 * .15)); break;
                case 6: precio = (float)(350 - (350 * .15)); break;
                default: Console.WriteLine("Error en la seleccion"); break;
            }
            return precio;
        }
        new public void Seleccion()
        {
            cantidad = 0;
            if (opc == 6)
            {
                cantidad = 2;
            }
            else
            {
                if (opc == 1 || opc == 2 || opc == 3 || opc == 4 || opc == 5)
                {
                    cantidad = 1;
                }
            }
            saborP = new string[cantidad];
            for (int i = 0; i < saborP.Length; i++)
            {
                Console.WriteLine($"Elige el sabor de las palomitas: ");
                saborP[i] = Console.ReadLine();
            }

            cantidad = 0;
            if (opc == 6)
            {
                cantidad = 4;
            }
            else
            {
                if (opc == 2 || opc == 3 || opc == 4 || opc == 5)
                {
                    cantidad = 2;
                }
                else if (opc == 1)
                {
                    cantidad = 1;
                }
            }
            Console.Clear();
            saborB = new string[cantidad];
            for (int i = 0; i < saborB.Length; i++)
            {

                Console.WriteLine($"Elige el sabor de las bebidas: ");
                saborB[i] = Console.ReadLine();
            }
        }
        public override void Desplegar()
        {
            Console.WriteLine($"Nombre del cliente: {nombreCliente}. \n{combo}");
            if (opc == 6)
            {
                cantidad = 2;
            }
            else
            {
                if (opc == 1 || opc == 2 || opc == 3 || opc == 4 || opc == 5)
                {
                    cantidad = 1;
                }
            }
            for (int i = 0; i < saborP.Length; i++)
            {
                Console.WriteLine($"Palomitas {i + 1} sabor {saborP[i]}");

            }
            for (int i = 0; i < saborB.Length; i++)
            {
                Console.WriteLine($"Bebidas {i + 1} sabor {saborB[i]}");
            }
        }
        ~InvitadoEspecial()
        {
            Console.WriteLine($"Memoria Liberada Objeto {this.nombreCliente}, no. Invitado {this.invitado}.\nClase Derivada");
        }
    }
}
