using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Primes primes = new Primes(2, 100);
            foreach (long i in primes) Console.WriteLine(i);
            Console.ReadKey();

            primes = new Primes(2, 1000000);
            foreach (long i in primes) Console.WriteLine(i);
            Console.ReadKey();
        }
    }
}
