using Core.Entites;
using Core.Interfaces.Discounts;
using Core.Interfaces.Media;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repo.Media
{
    public class PictureRepo:GenericRepo<Picture>,IPictureRepo
    {
        private readonly DataContext _dbcontext;
        public PictureRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public Task<Picture> getPicByName(string name)
        {
            return _dbcontext.pictures.FirstOrDefaultAsync(x => x.MimeType == name);
        }
    }
}
