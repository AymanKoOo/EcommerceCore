using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Catalog
{
    public  class ProductPicture
    {
        public int ProductId { get; set; }
        public Product product { get; set; }

        public int PictureId { get; set; }
        public Picture picture { get; set; }
        public int DisplayOrder { get; set; }
    }
}
