using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionBaseExample
{
    public class Flower
    {
        protected string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Flower()
        {
            name = "The flower with no name";
        }

        public Flower(string newName)
        {
            name = newName;
        }

        public void Feed()
        {
            Console.WriteLine("{0} has been watered.", name);
        }
    }
}
