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

            public complexNumber Inverse()
            {
                complexNumber returnValue1;

                returnValue1.realPart = realPart / (Math.Pow(realPart, 2) + Math.Pow(imaginaryPart, 2));
                returnValue1.imaginaryPart = - imaginaryPart / (Math.Pow(realPart, 2) + Math.Pow(imaginaryPart, 2));
                return returnValue1;

            }

        }

        static complexNumber Add(complexNumber z1, complexNumber z2)
        {
            complexNumber returnValue2;
            returnValue2.realPart = z1.realPart + z2.realPart;
            returnValue2.imaginaryPart = z1.imaginaryPart + z2.imaginaryPart;
            return returnValue2;
        }

        static complexNumber Substract(complexNumber z1, complexNumber z2)
        {
            complexNumber returnValue3;
            returnValue3.realPart = z1.realPart - z2.realPart;
            returnValue3.imaginaryPart = z1.imaginaryPart - z2.imaginaryPart;
            return returnValue3;
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
            Console.WriteLine("Enter two numbers separated by a comma:");
            string s = Console.ReadLine();
            string s1 = s.Substring(0, s.IndexOf(","));
            string s2 = s.Substring(s.IndexOf(",") + 1);
            complexNumber z1;
            z1.realPart = Convert.ToDouble(s1);
            z1.imaginaryPart = Convert.ToDouble(s2);
            Console.WriteLine("Enter other two numbers separated by a comma:");
            string ss = Console.ReadLine();
            string ss1 = ss.Substring(0, ss.IndexOf(","));
            string ss2 = ss.Substring(ss.IndexOf(",") + 1);
            complexNumber z2;
            z2.realPart = Convert.ToDouble(ss1);
            z2.imaginaryPart = Convert.ToDouble(ss2);

            Console.WriteLine("z1 = {0} + i{1}", s1, s2);
            Console.WriteLine("The Modulus of z1 is: {0}.", z1.Modulus());
            Console.WriteLine("The Inverse of z1 is: {0}.", z1.Inverse().realPart.ToString("f2") + " + i*" + z1.Inverse().imaginaryPart.ToString("f2"));
            Console.WriteLine("z2 = {0} + i{1}", ss1, ss2);
            Console.WriteLine("The Modulus of z2 is: {0}.", z2.Modulus());
            Console.WriteLine("The Inverse of z2 is: {0}.", z2.Inverse().realPart.ToString("f2") + " + i*" + z2.Inverse().imaginaryPart.ToString("f2"));
            Console.WriteLine("The Sum of z1 and z2 is: {0}.", Add(z1, z2).realPart.ToString("f2") + " + i*" + (Add(z1, z2).imaginaryPart.ToString("f2")));
            Console.WriteLine("The Substract of z1-z2 is: {0}.", Substract(z1, z2).realPart.ToString("f2") + " + i*" + Substract(z1, z2).imaginaryPart.ToString("f2"));
            Console.WriteLine("The Multiply of z1*z2 is: {0}.", Multiply(z1, z2).realPart.ToString("f2") + " + i*" + Multiply(z1, z2).imaginaryPart.ToString("f2"));
            Console.WriteLine("The Division of z1/z2 is: {0}.", Multiply(z1, z2.Inverse()).realPart.ToString("f2") + " + i*" + Multiply(z1, z2.Inverse()).imaginaryPart.ToString("f2"));
            Console.WriteLine("The Division of z2/z1 is: {0}.", Multiply(z2, z1.Inverse()).realPart.ToString("f2") + " + i*" + Multiply(z2, z1.Inverse()).imaginaryPart.ToString("f2"));
            Console.ReadKey();
        }

    }
}
