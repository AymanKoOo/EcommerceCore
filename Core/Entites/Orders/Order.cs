using Core.Entites.Base;
using Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entites.Orders
{
    public class Order:EntityBase
    {
        public Guid OrderGuid { get; set; }
        public string CustomerCurrencyCode { get; set; }

        public string PaymentMethodSystemName { get; set; }

        /// //////////////////
        /// 
        public int OrderStatusId { get; set; }
        public int PaymentStatusId { get; set; }
        public int ShippingStatusId { get; set; }
        public decimal OrderSubtotalInclTax { get; set; }

        public decimal OrderSubtotalExclTax { get; set; }

        public decimal OrderSubTotalDiscountInclTax { get; set; }
        
        public decimal OrderSubTotalDiscountExclTax { get; set; }

        public decimal OrderShippingInclTax { get; set; }

        public decimal OrderShippingExclTax { get; set; }

        public decimal PaymentMethodAdditionalFeeInclTax { get; set; }

        public decimal PaymentMethodAdditionalFeeExclTax { get; set; }

        public decimal OrderTax { get; set; }

        public decimal OrderDiscount { get; set; }

        public decimal OrderTotal { get; set; }

        public decimal RefundedAmount { get; set; }


        /////////////////////

        public DateTime? PaidDateUtc { get; set; }

        public string ShippingMethod { get; set; }

        public DateTime CreatedOnUtc { get; set; }
          


        public string customerId { get; set; }
        public ApplicationUser customer { get; set; }

        public int ShippingAddressId { get; set; }
        public Address ShippingAddress { get; set; }

        public IEnumerable<OrderNotes> orderNotes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public List<OrderItem> orderItems { get; set; }
    }
}
