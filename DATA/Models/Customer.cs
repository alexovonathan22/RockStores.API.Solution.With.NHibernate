using System;
using System.Collections.Generic;
using System.Text;
//using Iesi.Collections.Generic;

namespace DATA.Models
{
    public class Customer
    {
        public Customer()
        {
        }

      
        public virtual int ID { get; set; }

       
        public virtual string Name { get; set; } = "[New Customer]";

      
        public virtual IList<Orders> Orders { get; set; } = new List<Orders>();
    }
}
