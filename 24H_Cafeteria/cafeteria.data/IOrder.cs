using System;
using System.Collections.Generic;

namespace cafeteria.data
{
    public interface IOrder : IIdentity
    {
        string Orderer { get; set; }
        DateTime OrderTimeStamp { get; set; }
        Dictionary<IProduct, int> Products { get; set; }
        string Comment { get; set; }
        bool? IsFinished { get; set; }
    }
}
