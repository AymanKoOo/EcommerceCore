using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Catalog
{
    public class CategoryPicture
    {
        public int categoryID { get; set; }
        public Category category { get; set; }

        public int PictureId { get; set; }
        public Picture picture { get; set; }
    }
}
