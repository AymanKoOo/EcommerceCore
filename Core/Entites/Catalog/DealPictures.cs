using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Catalog
{
    public class DealPictures
    {
        public int DealID { get; set; }
        public Deal deal { get; set; }

        public int PictureId { get; set; }
        public Picture picture { get; set; }

        public int DisplayOrder { get; set; }

    }
}
