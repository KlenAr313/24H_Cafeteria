using cafeteria.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace cafeteria.service.models
{
    public class Order : IOrder
    {
        public int Id { get; set; }
        public string Orderer { get; set; }
        public DateTime OrderTimeStamp { get; set; }
        public Dictionary<IProduct, int> Products { get; set; }
        public string Comment { get; set; }
        public bool? IsFinished { get; set; }

        public Order()
        { }

        public int PriceSummary()
        {
            int sum = 0;
            foreach (var i in Products)
            {
                sum += i.Value * i.Key.Price;
            }
            return sum;
        }
    }
}
