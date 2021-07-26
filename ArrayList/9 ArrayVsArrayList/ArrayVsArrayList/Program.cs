using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace ArrayVsArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animalArray = new Animal[2];
            Cow myCow1 = new Cow("Deirdre");
            animalArray[0] = myCow1;
            animalArray[1] = new Chicken("Ken");
            foreach (Animal myAnimal in animalArray)
            {
                Console.WriteLine("New {0} object added to Array collection, Name = {1}", myAnimal.ToString(), myAnimal.Name);
            }
            Console.WriteLine("Array collection contains {0} objects.",animalArray.Length);
            animalArray[0].Feed();
            ((Chicken)animalArray[1]).LayEgg();
            Console.WriteLine();
            
            ArrayList animalArrayList = new ArrayList();
            Cow myCow2 = new Cow("Hayley");
            animalArrayList.Add(myCow2);
            animalArrayList.Add(new Chicken("Roy"));
            foreach (object myAnimal in animalArrayList)
            {
                Console.WriteLine("New {0} object added to ArrayList collection, Name = {1}", 
                    myAnimal.ToString(), ((Animal)myAnimal).Name);
            }
            Console.WriteLine("ArrayList collection contains {0} objects.", animalArrayList.Count);
            ((Animal)animalArrayList[0]).Feed();
            ((Chicken)animalArrayList[1]).LayEgg();
            Console.WriteLine();

            Console.WriteLine("Additional manipulation of ArrayList:");
            animalArrayList.RemoveAt(0);
            ((Animal)animalArrayList[0]).Feed();
            animalArrayList.AddRange(animalArray);
            ((Chicken)animalArrayList[2]).LayEgg();
            Console.WriteLine("The animal called {0} is at index {1}.", myCow1.Name, animalArrayList.IndexOf(myCow1));
            myCow1.Name = "Janice";
            Console.WriteLine("The animal is now called {0}.", ((Animal)animalArrayList[1]).Name);
            Console.ReadKey();
        }
    }
}
