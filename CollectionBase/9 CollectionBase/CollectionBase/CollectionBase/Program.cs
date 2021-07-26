using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace CollectionBaseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Animals animalCollection = new Animals();
            animalCollection.Add(new Cow("Jack"));
            animalCollection.Add(new Chicken("Vera"));
            //animalCollection.Add(new Flower("Rose"));
            IList InterfaceList = animalCollection;
            InterfaceList.Add(new Flower("Rose"));
            ((Flower)InterfaceList[2]).Feed();
            ((Animal)animalCollection[1]).Feed();
            /*foreach (Animal myAnimal in animalCollection)
            {
                myAnimal.Feed();
            }*/
            Console.ReadKey();
        }
    }

}
