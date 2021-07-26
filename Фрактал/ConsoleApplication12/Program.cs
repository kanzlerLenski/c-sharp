using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication12
{
    class Program
    {
        struct complexNumber
        {
            public double realPart;
            public double imaginaryPart;

            public double Modulus()
            {
                return (Math.Sqrt(Math.Pow(realPart, 2) + Math.Pow(imaginaryPart, 2)));
            }
        }

        static complexNumber Add(complexNumber z1, complexNumber z2)
        {
            complexNumber returnValue2;
            returnValue2.realPart = z1.realPart + z2.realPart;
            returnValue2.imaginaryPart = z1.imaginaryPart + z2.imaginaryPart;
            return returnValue2;
        }

        static complexNumber Multiply(complexNumber z1, complexNumber z2)
        {
            complexNumber returnValue4;
            returnValue4.realPart = z1.realPart * z2.realPart - z1.imaginaryPart * z2.imaginaryPart;
            returnValue4.imaginaryPart = z1.realPart * z2.imaginaryPart + z1.imaginaryPart * z2.realPart;
            return returnValue4;

        }

        static void Main(string[] args)
        {
            complexNumber z, w;

            //25
            //80
            double imaginaryPartLimit = 0.7;
            double imaginaryPartLimit2 = 0.3;
            double realPartLimit = -0.8;
            double realPartLimit2 = -0.4;
            double step = (imaginaryPartLimit - imaginaryPartLimit2)/60;
            double step2 = (realPartLimit2 - realPartLimit)/78;


            for (z.imaginaryPart = imaginaryPartLimit; z.imaginaryPart >= imaginaryPartLimit2; z.imaginaryPart -= step)
            {
                for (z.realPart = realPartLimit; z.realPart <= realPartLimit2; z.realPart += step2)
                {
                    w = z;
                    int iterations = 0;

                    while ((w.Modulus() < 2) && (iterations < 40))
                    {
                        w = Add(Multiply(w, w), z);
                        iterations += 1;
                    }

                    if (iterations < 40)
                        Console.Write(" ");
                    else
                        Console.Write("@");
 
                }
                Console.WriteLine("");

            }
            Console.ReadKey();

        }
    }

}