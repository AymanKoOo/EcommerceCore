using Core.Entites;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repo
{
    public interface IAdminRepo : IGenericRepo<ApplicationUser>
    {
        void AddUser(ApplicationUser model);

        void DeleteUser(ApplicationUser model);

        void EditUser(ApplicationUser model);

        IEnumerable<ApplicationUser> GetAllUsers();
    }
}
