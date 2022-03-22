using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_01
{
    class Program
    {
        static int Suma(int a, int b)
        {
            return a + b;
        }

        static int Resta(int a, int b)
        {
            return a - b;
        }

        static int Multiplicacion(int a, int b)
        {
            return a * b;
        }
        static int Division(int a, int b)
        {
            return a / b;
        }

        static void Raiz()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("La raiz cuadrada de {0} es: {1}", i, Math.Sqrt(i));
            }
        }

        static void Primos()
        {
            int contador = 0;

            for (int i = 2; i <= 30; i++)
            {  //apertura del primer for
                for (int j = 1; j <= i; j++)
                {   //apertura segundo for

                    if (i % j == 0)
                    {
                        contador = contador + 1;
                    }

                }

                if (contador <= 2)
                {
                    Console.WriteLine(i);
                }

                contador = 0;

            }
        }

        static int C(int c)
        {
            int form1 = (5 * (c - 32) / 9);
            return form1;
        }
        static int F(int f)
        {
            int form2 = ((9 * f) / 5) + 32;
            return form2;
        }

        static void Main(string[] args)
        {
            Console.Title = "Procedimientos y funciones";
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("[1] Suma de dos números");
                Console.WriteLine("[2] Resta de dos números");
                Console.WriteLine("[3] Multiplicación de dos números");
                Console.WriteLine("[4] Division de dos números");
                Console.WriteLine("[5] Imprimir los 10 primeros números primos");
                Console.WriteLine("[6] Imprimir la raíz cuadrada de los 10 primeros números enteros");
                Console.WriteLine("[7] Convertir de °F a °C");
                Console.WriteLine("[8] Convertir de °C a °F");
                Console.WriteLine("[0] Salir");
                Console.WriteLine("Ingrese una opción y presione ENTER");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Ingrese el primer número");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        int b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La suma de {0} y {1} es {2}", a, b, Suma(a, b));
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.WriteLine("Ingrese el primer número");
                        int c = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        int d = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La Resta de {0} y {1} es {2}", c, d, Resta(c, d));
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Ingrese el primer número");
                        int e = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        int f = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La Multiplicacion de {0} y {1} es {2}", e, f, Multiplicacion(e, f));
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Ingrese el primer número");
                        int g = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo número");
                        int h = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La Division de {0} y {1} es {2}", g, h, Division(g, h));
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.WriteLine("Calculando...");
                        Primos();
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.WriteLine("Calculando...");
                        Raiz();
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.WriteLine("Ingrese la temperatura en °F:");
                        int cel = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La conversion es {1}°C", cel, C(cel));
                        Console.ReadKey();
                        break;
                    case "8":
                        Console.WriteLine("Ingrese la temperatura en °C:");
                        int far = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La conversion es {1}°F", far, F(far));
                        Console.ReadKey();
                        break;
                }
            } while (!opcion.Equals("0"));

        }
    }
}
