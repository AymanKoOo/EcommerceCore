using Core.Entites.Catalog;
using Core.Interfaces.Catalog;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repo.Catalog
{
    public class DealRepo : GenericRepo<Deal>, IDealRepo
    {
        private readonly DataContext _dbcontext;
        public DealRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public async Task AddPicture(int dealID, int PicID)
        {
            var dp = new DealPictures();
            dp.DealID = dealID;
            dp.PictureId = PicID;
            await _dbcontext.dealPictures.AddAsync(dp);
        }
      
        public Deal geBySlug(string slug)
        {
           return  _dbcontext.deals.Where(x => x.Slug == slug).Include(x=>x.DealDiscounts).ThenInclude(x=>x.discount).ThenInclude(x=>x.picture)
                 .FirstOrDefault();
        }

        public Deal geById(int id)
        {
            return _dbcontext.deals.Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task AddDealDiscount(DealDiscount dealDiscount)
        {
            var dp = new DealDiscount();
            dp.dealID = dealDiscount.dealID;
            dp.discountID = dealDiscount.discountID;
            await _dbcontext.dealDiscounts.AddAsync(dp);
        }


        public async Task<List<Deal>> GetForbanner()
        {
            return await _dbcontext.deals.Take(8).OrderBy(x => x.Id).Include(x=>x.dealPictures).ThenInclude(e=>e.picture).ToListAsync();
        }

        public IEnumerable<Deal> getallDeals()
        {
            return _dbcontext.deals.ToList();
        }
    }
}
