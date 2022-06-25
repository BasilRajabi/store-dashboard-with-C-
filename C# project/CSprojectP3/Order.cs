using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSprojectP3
{
    public enum OrderStatus { InProgress,Pending,delivered}
    public class Order 
    {
        public int ID { get; set; }
        public DateTime Date1 {get;set;}

        public OrderStatus status { get; set; }

        [NotMapped]
        public float Final_Cost { get; set; }

        public ICollection<TransactionItem> TItems { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }


        public float calfinalcost(Order p)
        {
            Final_Cost = 0;
            foreach (TransactionItem a in p.TItems)
                Final_Cost += a.CostPerItem * a.quantity;
            return Final_Cost;
        }

    }
}
