using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.DTOs
{
    public class IndexDTO
    {
        public List<ProductDTO> productDTOs { get; set; }

        public ProductDTO productDTO { get; set; }

        public List<CategoryDTO> categoryDTOs { get; set; }

        public UserData userData { get; set; }

    }
}
