using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Orders
{
    public class OrderNotes:EntityBase
    {
        public int OrderId { get; set; }
        public Order order { get; set; }

        /// <summary>
        /// 	Order placed
        /// 	Order paid	
        /// 	Order shipped	
        /// 	Order delivered	
        /// </summary>
        public string Note { get; set; }

        public DateTime CreatedOnUtc { get; set; }
    }
}
