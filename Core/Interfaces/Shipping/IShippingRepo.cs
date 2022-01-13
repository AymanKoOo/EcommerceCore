using Core.Entites;
using Core.Entites.Shipping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Media
{
    public interface IShippingRepo : IGenericRepo<ShippingMethods>
    {
        List<ShippingMethods> getAllShippingMethods();
    }
}
