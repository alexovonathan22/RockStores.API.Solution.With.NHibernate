using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Models
{
    public class Product
    {
        public Product()
        {
        }


        public virtual int? ID { get; set; }


        public virtual string Name { get; set; }


        public virtual string Description { get; set; }

    }
}
