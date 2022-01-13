using Core.Entites;
using Core.Entites.Payments;
using Core.Entites.Shipping;
using Infrastructure.Data;
using Infrastructure.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Media
{
    public class PaymentRepo : GenericRepo<PaymentMethods>, IPaymentRepo
    {
        private readonly DataContext _dbcontext;
        public PaymentRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public List<PaymentMethods> getAllPaymentMethodsAsync()
        {
            return _dbcontext.paymentMethods.ToList();
        }
    }
}
