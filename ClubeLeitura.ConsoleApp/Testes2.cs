using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp
{
    public class Testes2
    {
        static void Main2(string[] args)
        {
            ImprimirNumeros("1", "2", "3");

            ImprimirNumeros("1", "2");

            ImprimirNumeros("1");

            
        }

        private static void ImprimirNumeros(params object[] vs)
        {
            foreach (var item in vs)
            {
                Console.WriteLine(item);
            }
        }

        //private static void ImprimirNumeros(object[] vs)
        //{
        //    foreach (var item in vs)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}

        //private static void ImprimirNumeros(string v1)
        //{
        //    Console.WriteLine(v1);
        //}

        //private static void ImprimirNumeros(string v1, string v2)
        //{
        //    Console.WriteLine(v1);
        //    Console.WriteLine(v2);
        //}

        //private static void ImprimirNumeros(string v1, string v2, string v3)
        //{
        //    Console.WriteLine(v1);
        //    Console.WriteLine(v2);
        //    Console.WriteLine(v3);
        //}

    }
}
