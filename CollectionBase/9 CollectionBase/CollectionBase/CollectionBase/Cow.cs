﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionBaseExample
{
    public class Cow : Animal
    {
        public void Milk()
        {
            Console.WriteLine("{0} has been milked.", name);
        }

        public Cow(string newName) : base(newName)
        {
        }
    }
}
