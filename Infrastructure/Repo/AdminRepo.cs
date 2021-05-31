using Core.Entites;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return  _dbcontext.Users.ToList();
        }
    }
}
