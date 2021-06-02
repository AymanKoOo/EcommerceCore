using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        [NotMapped]
        public bool selected { get; set; }

    }
}
