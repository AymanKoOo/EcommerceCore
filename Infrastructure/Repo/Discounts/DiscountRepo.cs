using Core.Entites;
using Core.Interfaces.Discounts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo.Discounts
{
    public class DiscountRepo:GenericRepo<Discount>,IDiscount
    {
        private readonly DataContext _dbcontext;

        public DiscountRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public void AddProductsToDiscount(IEnumerable<int> ids)
        {
            //var productDiscount = new DiscountProduct();
            //productDiscount.ProductsId=
            //foreach(var id in ids)
            //{
            //    _dbcontext.discountProducts.Add()

            //}


        }

        public List<Discount> GetAll()
        {
            return _dbcontext.discounts.ToList();
        }

        public Task<List<Discount>> GetForbanner()
        {
            return _dbcontext.discounts.Take(8).OrderBy(x=>x.DiscountTypeId).Include(x=>x.picture).ToListAsync();
        }

        public Discount GetByID(int id)
        {
            return _dbcontext.discounts.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveDiscountsFromCategoriesProducts(int discountId)
        {
            int discountTypeID = _dbcontext.discounts.FirstOrDefault(x => x.Id == discountId).DiscountTypeId;

            if (discountTypeID == 1)
            {
                var discountCategories = _dbcontext.discountCategories.Where(x => x.DiscountsId == discountId).Include(x => x.Category).ToList();

                foreach (var category in discountCategories)
                {
                    var c = _dbcontext.Categories.FirstOrDefault(x => x.Id == category.CategoryId);
                    c.HasDiscountsApplied = false;
                    _dbcontext.Categories.Update(c);
                }
            }
            else if (discountTypeID == 2)
            {
                var discountProducts = _dbcontext.discountProducts.Where(x => x.DiscountsId == discountId).Include(x => x.products).ToList();
               
                foreach (var product in discountProducts)
                {
                    var p = _dbcontext.products.FirstOrDefault(x => x.Id == product.products.Id);
                    p.HasDiscountsApplied = false;
                    _dbcontext.products.Update(p);
                }
            }
        }

        public Discount AddProductToDiscount(int id)
        {
            return _dbcontext.discounts.FirstOrDefault(x => x.Id == id);
        }
        public void RemoveProductToDiscount(Product product)
        {
            var discountProduct = _dbcontext.discountProducts.FirstOrDefault(x => x.ProductsId == product.Id);
          
            if (discountProduct!=null)
             _dbcontext.discountProducts.Remove(discountProduct);
        }
        public void RemoveCategoryToDiscount(Category category)
        {
            var discountCategory = _dbcontext.discountCategories.FirstOrDefault(x => x.CategoryId == category.Id);

            if (discountCategory != null)
                _dbcontext.discountCategories.Remove(discountCategory);
        }
        public async Task<IList<Discount>> GetAppliedDiscountsOnProductAsync(Product product)
        {
            var products = _dbcontext.products.Where(x => x.HasDiscountsApplied);
            //
            var discounts = await (from dp in _dbcontext.discountProducts 
                           join dpm in _dbcontext.discounts on dp.DiscountsId equals dpm.Id
                           where dp.ProductsId == product.Id
                           select dpm).ToListAsync();
            return discounts;
        }

        public virtual List<Discount> GetPreferredDiscount(IList<Discount> discounts,
          decimal amount, out decimal discountAmount)
        {
            if (discounts == null)
                throw new ArgumentNullException(nameof(discounts));

            var result = new List<Discount>();
            discountAmount = decimal.Zero;
            if (!discounts.Any())
                return result;

            //first we check simple discounts
            foreach (var discount in discounts)
            {
                var currentDiscountValue = GetDiscountAmount(discount, amount);
                if (currentDiscountValue <= discountAmount)
                    continue;

                discountAmount = currentDiscountValue;

                result.Clear();
                result.Add(discount);
            }
            //now let's check cumulative discounts
            //right now we calculate discount values based on the original amount value
            //please keep it in mind if you're going to use discounts with "percentage"
            var cumulativeDiscounts = discounts.ToList();
            if (cumulativeDiscounts.Count <= 1)
                return result;

            var cumulativeDiscountAmount = cumulativeDiscounts.Sum(d => GetDiscountAmount(d, amount));
            if (cumulativeDiscountAmount <= discountAmount)
                return result;

            discountAmount = cumulativeDiscountAmount;

            result.Clear();
            result.AddRange(cumulativeDiscounts);

            return result;
        }

        public virtual decimal GetDiscountAmount(Discount discount, decimal amount)
        {
            if (discount == null)
                throw new ArgumentNullException(nameof(discount));

            //calculate discount amount
            decimal result;
            if (discount.UsePercentage)
                result = (decimal)((float)amount * (float)discount.DiscountPercentage / 100f);
            else
                result = discount.DiscountAmount;

            //validate maximum discount amount
            if (discount.UsePercentage &&
                discount.MaximumDiscountAmount.HasValue &&
                result > discount.MaximumDiscountAmount.Value)
                result = discount.MaximumDiscountAmount.Value;

            if (result < decimal.Zero)
                result = decimal.Zero;

            return result;
        }


        //public Discount GetProductsByDiscount(int id)
        //{
        //    var customers = (from ur in _dbcontext.discountProducts
        //                     join u in _dbcontext.discounts on ur.DiscountsId equals u.Id
        //                     join a in _dbcontext.products on ur.ProductsId equals a.Id
        //                     select new CustomerWithRole
        //                     {
        //                         UserId = u.Id,
        //                         UserName = u.UserName,
        //                         Email = u.Email,
        //                         Role = a.Name
        //                     }).FirstOrDefault();

        //    var roles = _dataContext.Roles.ToList();

        //    customers.roles = roles;
        //}
    }
}
