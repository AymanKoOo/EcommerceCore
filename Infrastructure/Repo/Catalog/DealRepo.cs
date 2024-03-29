﻿using Core.Entites.Catalog;
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
            dp.DisplayOrder = 1;
            await _dbcontext.dealPictures.AddAsync(dp);
        }
        public string MakeDealSlugUnique(string Slug)
        {
            int i = 0;
            while (_dbcontext.deals.Any(x => x.Slug == Slug))
            {
                Slug = $"{Slug}-{i++}";
            }
            return Slug;
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


        public async Task<List<Deal>> GetForSmallbanner()
        {
            return await _dbcontext.deals.Where(x => x.ShowOnSmallBanner == true).Take(8).OrderBy(x => x.Id).Include(x=>x.dealPictures).ThenInclude(e=>e.picture).ToListAsync();
        }
        public async Task<List<Deal>> GetForBigbanner()
        {
            return await _dbcontext.deals.Where(x=>x.ShowOnBigBanner==true).Take(8).OrderBy(x => x.Id).Include(x => x.dealPictures).ThenInclude(e => e.picture).ToListAsync();
        }
        public IEnumerable<Deal> getallDeals()
        {
            return _dbcontext.deals.ToList();
        }
    }
}
