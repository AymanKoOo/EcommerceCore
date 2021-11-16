using Core.Entites;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repo
{
    public class CustomerRepo : GenericRepo<ApplicationUser>, ICustomerRepo
    {
        private readonly DataContext _dataContext;

        public CustomerRepo(DataContext dataContext):base(dataContext)
        {
            _dataContext = dataContext;
        }


        //Add user
        //Remove user
        public IQueryable<CustomerWithRole> GetAllCustomers()
        {
            var customers = from ur in _dataContext.UserRoles
            join u in _dataContext.Users on ur.UserId equals u.Id
            join a in _dataContext.Roles on ur.RoleId equals a.Id
            select new CustomerWithRole
            {
                UserId = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                Role = a.Name
            };
            return customers;
        }

        public ApplicationUser GetCustomerById(string customerID)
        {
            var customer = _dataContext.Users.FirstOrDefault(x => x.Id == customerID);
            return customer;
        }

        public CustomerWithRole GetCustomerAndRoleById(string customerID)
        {
            var customers = (from ur in _dataContext.UserRoles
                             join u in _dataContext.Users on ur.UserId equals u.Id
                             join a in _dataContext.Roles on ur.RoleId equals a.Id
                             where customerID == u.Id
                             select new CustomerWithRole
                             {
                                 UserId = u.Id,
                                 UserName = u.UserName,
                                 Email = u.Email,
                                 Role = a.Name
                             }).FirstOrDefault();

            var roles = _dataContext.Roles.ToList();

            customers.roles = roles;

            return customers;
        }

        public ApplicationRole GetRole(string RoleID)
        {
            return _dataContext.Roles.FirstOrDefault(x => x.Id == RoleID);
        }
    }
}
