using Core.Entites;
using Core.Entites.Common;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repo
{
    public class AdminRepo : GenericRepo<ApplicationUser>, IAdminRepo
    {
        private readonly DataContext _dbcontext;

        public AdminRepo(DataContext dbcontext) : base(dbcontext)
        {
            this._dbcontext = dbcontext;
        }
       
        public void AddUser(ApplicationUser model)
        {
        }

        public void DeleteUser(ApplicationUser model)
        {
            throw new NotImplementedException();
        }

        public void EditUser(ApplicationUser model)
        {
            _dbcontext.Users.Update(model);
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return  _dbcontext.Users.ToList();
        }

        public async Task<ApplicationUser> GetUser(string email)
        {
            return await _dbcontext.Users.FirstOrDefaultAsync(x=>x.Email==email);
        }
        public async Task<ApplicationUser> GetUserAndAddress(string email)
        {
            return await _dbcontext.Users.Include(x=>x.ShippingAddress).FirstOrDefaultAsync(x => x.Email == email);
        }
        public  IQueryable<Address> GetUserShippingAddress(string email)
        {
            return  _dbcontext.Users.Include(x => x.ShippingAddress).Where(x => x.Email == email).Select(x => x.ShippingAddress);
        }
        public async Task<ApplicationUser> GetUserID(string id)
        {
            return await _dbcontext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
