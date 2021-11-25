using Core.Entites;
using Core.Interfaces.Discounts;
using Infrastructure.Data;
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

        public Discount GetByID(int id)
        {
            return _dbcontext.discounts.FirstOrDefault(x => x.Id == id);
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
