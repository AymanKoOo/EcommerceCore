using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Catalog
{
    public interface IProductAttributesRepo : IGenericRepo<ProductAttribute>
    {
        Task<ProductAttribute> GetProductAttrByID(int id);

        Task CreateProductAttributeOption(ProductAttributeOption model);
        Task<IEnumerable<ProductAttributeOption>> GetAllProductAttributeOption();
        Task<IEnumerable<ProductAttribute>> GetAllProductAttributes();
        Task<ProductAttributeOption> GetProductAttrOptionByName(string name);
        Task<ProductAttributeOption> GetProductAttrOptionByID(int id);
        IEnumerable<int>  GetProductAttributeOptionUsedByProduct(int productID);
        Task<ProductAttribute> GetProductAttrByOptionID(int id);
        void DeleteProductOptionById(int optionId);
        public decimal getAttributePrices(List<int> optionsIds);

        public  Task<List<ProductAttributeOption>> GetListProductAttrOptionByID(List<int> ids);

    }
}
