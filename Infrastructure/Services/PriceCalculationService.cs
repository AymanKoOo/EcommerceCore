using Core.Entites;
using Infrastructure.Repo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PriceCalculationService : IPriceCalculationService
    {
        private readonly UnitOfWork unitOfWork;

        public PriceCalculationService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<(decimal priceWithoutDiscounts, decimal finalPrice, decimal appliedDiscountAmount, List<Discount> appliedDiscounts)> GetFinalPriceAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
          
                var discounts = new List<Discount>();
                var appliedDiscountAmount = decimal.Zero;

                //initial price
                var price = product.UnitPrice;

              
                var priceWithoutDiscount = price;
                
                //if has discount
             
                    //discount
                    var (tmpDiscountAmount, tmpAppliedDiscounts) = await GetDiscountAmountAsync(product,price);
                    price -= tmpDiscountAmount;
                   
                    if (tmpAppliedDiscounts?.Any() ?? false)
                    {
                        discounts.AddRange(tmpAppliedDiscounts);
                        appliedDiscountAmount = tmpDiscountAmount;
                    }
              

                if (price < decimal.Zero)
                    price = decimal.Zero;

                if (priceWithoutDiscount < decimal.Zero)
                    priceWithoutDiscount = decimal.Zero;

                return (priceWithoutDiscount, price, appliedDiscountAmount, discounts);
        }
        
        protected virtual async Task<(decimal, List<Discount>)> GetDiscountAmountAsync(Product product,
             decimal productPriceWithoutDiscount)
          {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var appliedDiscounts = new List<Discount>();
            var appliedDiscountAmount = decimal.Zero;
        
            var allowedDiscounts = await GetAllowedDiscountsAsync(product);

            //no discounts
            if (!allowedDiscounts.Any())
                return (appliedDiscountAmount, appliedDiscounts);

            appliedDiscounts = unitOfWork.discount.GetPreferredDiscount(allowedDiscounts, productPriceWithoutDiscount, out appliedDiscountAmount);

            return (appliedDiscountAmount, appliedDiscounts);
        }

        protected virtual async Task<IList<Discount>> GetAllowedDiscountsAsync(Product product)
        {
            var allowedDiscounts = new List<Discount>();

            //discounts applied to products
            foreach (var discount in await GetAllowedDiscountsAppliedToProductAsync(product))
                    allowedDiscounts.Add(discount);

            return allowedDiscounts;
        }
        protected virtual async Task<IList<Discount>> GetAllowedDiscountsAppliedToProductAsync(Product product)
        {
            var allowedDiscounts = new List<Discount>();

            if (!product.HasDiscountsApplied)
                return allowedDiscounts;

            //we use this property ("HasDiscountsApplied") for performance optimization to async Task unnecessary database calls
            foreach (var discount in await unitOfWork.discount.GetAppliedDiscountsOnProductAsync(product))
                    allowedDiscounts.Add(discount);

            return allowedDiscounts;
        }
    }
}
