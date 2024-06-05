using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserciziLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            List<int> list1 = new List<int>()
            {
               0, 1, 2, 3, 4, 5, 6, 7, 8, 9 ,10 
            };
            var query1 = from numero in list1 where numero % 2 == 0 select numero;
            Console.WriteLine($"I numeri che producono il resto 0 sono:");
            foreach (var item in query1)
            {
                Console.Write($"{item} ");
            }
            //2
            List<int> list2 = new List<int>()
            {
               0, 1, 3, 6, 9 ,10, 44, 112, 12, -11,-23,-2
            };
            var query2 = from numero2 in list2 where numero2 > 0 where numero2 < 11 select numero2;
            Console.WriteLine($"\nNumeri tra 1 e 11:");
            foreach (var item in query2)
            {
                Console.Write($"{item} ");
                
            }
            //3
            Console.Write("\n");
            int[] quadrati = { 9, 8, 6, 5 };
            var query3 = from numero3 in quadrati select new { Numero = numero3,sqrNo = numero3*numero3 };
            foreach (var item in query3)
            {
                    Console.WriteLine("Numero = {0},SqrNo = {1}", item.Numero, item.sqrNo);
            }
            //4
            Console.WriteLine("Inserisci il numero di membri membri dell' elenco: ");
            int n = int.Parse(Console.ReadLine());
            int[] membri = new int[n];
            Console.WriteLine("Inserisci i membri dell' elenco: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Membro {i}: ");
                membri[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Inserisci il valore delimitante");
            int limite = int.Parse(Console.ReadLine());
            var query4 = from membro in membri where membro > limite select membro;
            Console.WriteLine($"Maggiori di {limite}");
            foreach (var item in query4)
            {
                Console.WriteLine($"{item}");
            }
            //5

            //6
            List<string> files = new List<string>()
            {
                 "aaa.frx", "bbb.TXT", "xyz.dbf", "abc.pdf", "aaaa.PDF","xyz.frt", "abc.xml", "ccc.txt","zzz.txt"
            };
            var filegruppi = files.GroupBy(f => f.Substring(f.LastIndexOf('.')).ToLower())
                .Select(p => new { Extension = p.Key, Count = p.Count() }).OrderBy(p => p.Extension);
            foreach (var file in filegruppi)
            {
                Console.WriteLine($"File con estensione: {file.Extension} => {file.Count}");
            }
            //7
            List<String> lettere = new List<String>()
            {
              "x","y","z"
            };
            List<int> numeri = new List<int>()
            {
                1,2,3
            };
            var query5 = lettere.SelectMany(l => numeri, (l, num) => new { Lettere = l, Numeri = num });
            foreach (var item in query5)
            {
                Console.WriteLine($"lettere: {item.Lettere}, numeri: {item.Numeri}");
            }

            string[] nomi = {"AMSTERDAM","ZURIGO", "ROMA", "LONDRA","PARIGI", "ABU DHABI", "CALIFORNIA", "NAIROBI"};
            var sortNomi = nomi.OrderBy(citta => citta.Length).ThenBy(citta =>citta);
            foreach (var item2 in sortNomi)
            {
                Console.WriteLine($"{item2}");
            }
            Console.ReadLine(); 
        }
    }
}
