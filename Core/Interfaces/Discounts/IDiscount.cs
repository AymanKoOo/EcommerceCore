using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interfaces.Discounts
{
    public interface IDiscount:IGenericRepo<Discount>
    {
        //create , update , delete
        public List<Discount> GetAll();
        public Discount GetByID(int id);
    }
}
