using Core.Entites.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.ViewModels.Discounts
{
    public class DiscountVM
    {
        public string Name { get; set; }

        //Admin Comment
        public string AdminComment { get; set; }

        ///Type of discount
        public int DiscountTypeId { get; set; }

        /// Gets or sets a value indicating whether to use percentage

        public bool UsePercentage { get; set; }

        /// Gets or sets the discount percentage

        public decimal DiscountPercentage { get; set; }

        /// Gets or sets the discount amount
        public decimal DiscountAmount { get; set; }

        /// Gets or sets the maximum discount amount (used with "UsePercentage")
        public decimal? MaximumDiscountAmount { get; set; }

        /// Gets or sets the discount start date and time
        public DateTime? StartDateUtc { get; set; }

        /// Gets or sets the discount end date and time
        public DateTime? EndDateUtc { get; set; }

        /// Gets or sets use copuon
        public bool RequiresCouponCode { get; set; }

        public string CouponCode { get; set; }

        public List<DiscountType> discountTypes { get; set; }
    }         
}
