using Core.Entites;
using Core.Entites.Payments;
using Core.Entites.Shipping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Media
{
    public interface IPaymentRepo : IGenericRepo<PaymentMethods>
    {
        List<PaymentMethods> getAllPaymentMethodsAsync();
    }
}
