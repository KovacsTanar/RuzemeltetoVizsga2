using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.CodeDom.Compiler;

namespace RuzemeltetoVizsga
{
    class Program
    {
        static List<Tagallam> lista = new List<Tagallam>();

        static void Main(string[] args)
        {
            Beolvas();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Feladat8();

            Console.ReadKey();
        }

        static void Beolvas()
        {
            FileStream fs = new FileStream(@"EUcsatlakozas.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            while (!sr.EndOfStream)
            {
                Tagallam tAllam = new Tagallam(sr.ReadLine());
                lista.Add(tAllam);

            }
        }

        static void Feladat3()
        {
            Console.Write("3. feladat: EU tagállamainak száma: {0} db", lista.Count);
        }

        static void Feladat4()
        {
            int db = 0;

            foreach (var item in lista)
            {
                if (item.Csatlakozas.Year == 2007)
                {
                    db++;
                }
            }
            Console.WriteLine("\n4. feladat: 2007-ben {0} ország csatlakozott.", db);
        }

        static void Feladat5()
        {
            foreach (var item in lista)
            {
                if (item.Nev == "Magyarország")
                    Console.WriteLine("5. feladat: Magyarország csatlakozásának dátuma: {0}",
                       item.Csatlakozas.ToString("yyyy.MM.dd"));

                //Console.WriteLine("Magyarország csatlakozásának dátuma: {0}.{1}.{2}",
                //    item.Csatlakozas.Year,
                //    item.Csatlakozas.Month,
                //    item.Csatlakozas.Day);

            }
        }

        static void Feladat6()
        {

            int index = 0;

            while (index < lista.Count && lista[index].Csatlakozas.Month != 5)
            {
                index++;
            }
            if (index > lista.Count)
                Console.WriteLine("6. feladat: Májusban NEM volt csatlakozás!");
            else
                Console.WriteLine("6. feladat: Májusban volt csatlakozás!", lista[index].Nev, lista[index].Csatlakozas);

            //VAGY

            //int db = 0;

            //foreach (var item in lista)
            //{
            //    if (item.Csatlakozas.Month == 5)
            //        db++;

            //}

            //if (db != 0)
            //    Console.WriteLine("6. feladat: Májusban volt csatlakozás!");
            //else
            //    Console.WriteLine("6. feladat: Májusban NEM volt csatlakozás!");


        }

        static void Feladat7()
        {
            //DateTime maxDT = new DateTime(1900, 01, 01);
            int maxIndex = 0;
            int max = int.MinValue;

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Csatlakozas.Year > max)
                {
                    max = lista[i].Csatlakozas.Year;
                    maxIndex = i;
                }

                //VAGY

                //if (lista[i].Csatlakozas > maxDT)
                //{
                //    maxDT = lista[i].Csatlakozas;
                //    maxIndex = i;

                //}
            }

            Console.WriteLine("7. feladat: Legutoljára csatlakozott ország: {0}",lista[maxIndex].Nev);
        }

        static void Feladat8()
        {
            Console.WriteLine("8. feladat: Statisztika");

            List<int> evekListaja = new List<int>();
            
            foreach (var item in lista)
            {
                if (!evekListaja.Contains(item.Csatlakozas.Year))
                    evekListaja.Add(item.Csatlakozas.Year);

            }
            int[] dbokListaja = new int[evekListaja.Count];
            for (int i = 0; i < lista.Count; i++)
            {
                int feltoltIndex = evekListaja.IndexOf(lista[i].Csatlakozas.Year);
                dbokListaja[feltoltIndex]++;
            }

            for (int i = 0; i < evekListaja.Count; i++)
            {
                Console.WriteLine("\t{0} - {1} ország",evekListaja[i],dbokListaja[i]);
            }
        }
    }
}
