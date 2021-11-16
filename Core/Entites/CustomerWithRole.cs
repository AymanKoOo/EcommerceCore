using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites
{
    public class CustomerWithRole
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<ApplicationRole> roles { get; set; }
    }
}
