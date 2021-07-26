using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectStore
{
    [Serializable]
    public class Product
    {
        public long Id;
        public string Name;
        public double Price;
        

        //[NonSerialized]
        private string notes;

        public string Notes //{get; set;}
    {

    
        get
                {
                    return notes;
                }

                set
                {
    notes = value;
}
}

        public Product(long id, string name, double price, string notes)
        {
            Id = id;
            Name = name;
            Price = price;
            Notes = notes;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}, {2:F2} р. ({3})", Id, Name, Price, Notes);
        }
    }
}
