using System.Collections.Generic;
using Core.Entites.Base;


namespace Core.Entites.Payments { 

    public class PaymentMethods : EntityBase
    {
        public string SystemName { get; set; }
     
        public bool Refund { get; set; }

        public bool IsActive { get; set; }
    }
}