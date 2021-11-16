using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interfaces
{
    public interface ICustomerRepo : IGenericRepo<ApplicationUser>
    {
        IQueryable<CustomerWithRole> GetAllCustomers();
        CustomerWithRole GetCustomerAndRoleById(string cutomerID);

        ApplicationUser GetCustomerById(string cutomerID);
        ApplicationRole GetRole(string RoleID);
    }
}

