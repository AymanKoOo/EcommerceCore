﻿using Core.Entites.Catalog;
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
        string MakeDealSlugUnique(string Slug);
        IEnumerable<Deal> getallDeals();
        Task<List<Deal>> GetForSmallbanner();
        Task<List<Deal>> GetForBigbanner();
        Task AddDealDiscount(DealDiscount dealDiscount);
    }
}
