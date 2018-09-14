using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumeriPrimi
{
    class Program
    {
        //stampa un elenco di numeri primi
        static void Main(string[] args)
        {
            int inputNumber = 21;

            var startDate = new DateTime();
            startDate = DateTime.Now;
            var listaNumeriPrimi = new List<int>();

            //cicla in parallelo su tutti i numeri dispari fino ad inputNumber
            Parallel.For(5, inputNumber + 1, i =>
            //for (int i = 5; i <= inputNumber; i++)
            {
                if (i % 2 == 1)
                {
                    int resto = 1;
                    int divisore = 2;
                    while (resto > 0 && divisore < i)
                    {
                        resto = i % divisore;
                        divisore++;
                    }
                    //se il ciclo while è durato fino alla fine, aggiunge i alla lista dei numeri primi:
                    if (divisore == i) listaNumeriPrimi.Add(i);
                }
            });

            //stampa la lista dei numeri primi
            foreach(int numeroPrimo in listaNumeriPrimi.OrderBy(n => n))
            {
                Console.Write("{0}\t", numeroPrimo);
            }

            //stampa il tempo trascorso
            TimeSpan intervallo = DateTime.Now - startDate;
            Console.WriteLine($"\n\nTrovati {listaNumeriPrimi.Count} numeri primi in {intervallo.Minutes * 60 + intervallo.Seconds}.{intervallo.Milliseconds} secondi");
            Console.ReadLine();
        }
    }
}
