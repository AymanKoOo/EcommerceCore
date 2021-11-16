using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IProductRepo:IGenericRepo<Product>
    {
        IEnumerable<Product> GetProductsByCatgory(int catgoryID);

        IEnumerable<Product> GetAllProducts();

        Product GetProduct(int productId);
        //void AddProduct(Product product);
        //void EditProduct(Product product);
        //void DeleteProduct(Product product);

        
        //IEnumerable<Price> GetPricesOfProduct(int productId);
        //void EditProductPrice(Price price);
        //Price GetCurrentPrice(int productId);
        //Price GetSalePrice(int productId);
        //void AddPriceToProduct(Price price);


    }
}
