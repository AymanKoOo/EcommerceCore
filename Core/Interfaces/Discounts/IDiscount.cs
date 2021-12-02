using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Discounts
{
    public interface IDiscount : IGenericRepo<Discount>
    {
        //create , update , delete
        public List<Discount> GetAll();
        public Task<List<Discount>> GetForbanner();
        public Discount GetByID(int id);
        public void RemoveProductToDiscount(Product product);
        public Task<IList<Discount>> GetAppliedDiscountsOnProductAsync(Product product);
        public void AddProductsToDiscount(IEnumerable<int> id);
        public  List<Discount> GetPreferredDiscount(IList<Discount> discounts,
        decimal amount, out decimal discountAmount);
        public decimal GetDiscountAmount(Discount discount, decimal amount);


    }
}
