using Core.Entites.Base;
using Core.Entites.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites
{
    public class Picture : EntityBase
    {
        public string MimeType { get; set; }

        public string SeoFilename { get; set; }

        public string AltAttribute { get; set; }

        public string TitleAttribute { get; set; }

        public bool IsNew { get; set; }
        public List<DealPictures> dealPictures { get; set; }

        public List<CategoryPicture> categoryPictures { get; set; }
        public List<ProductPicture> productPictures { get; set; }
    }
}
