using System;
using System.Collections.Generic;

namespace CSprojectP3
{
    public class Customer
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
       
        public List<Order> OrderList { get; set; }

    }
}
