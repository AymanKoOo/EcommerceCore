using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Catalog
{
    public interface IDealRepo : IGenericRepo<Deal>
    {
        Deal geBySlug(string slug);
        Task AddPicture(int dealID,int PicID);
        Deal geById(int id);
        Task AddDealDiscount(DealDiscount dealDiscount);
    }
}
