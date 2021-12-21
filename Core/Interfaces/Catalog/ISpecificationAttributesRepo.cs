using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Catalog
{
    public interface ISpecificationAttributesRepo : IGenericRepo<SpecificationAttribute>
    {

        void AddSpecificationAttributeGroup(SpecificationAttributeGroup model);
        Task<IEnumerable<SpecificationAttributeGroup>> GetAllSpecificationAttributeGroup();

        Task CreateSpecificationAttribute(SpecificationAttribute model);
        Task CreateSpecificationAttributeOption(SpecificationAttributeOption model);
        Task<IEnumerable<SpecificationAttributeOption>> GetAllSpecificationAttributeOption();
        Task<IEnumerable<SpecificationAttribute>> GetAllSpecificationAttributes();
    }
}
