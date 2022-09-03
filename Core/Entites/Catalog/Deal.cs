using Core.Entites.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entites.Catalog
{
    public class Deal: EntityBase
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

        public bool ShowOnBigBanner { get; set; }
        public bool ShowOnSmallBanner { get; set; }
        public int PictureId { get; set; }
        public List<DealPictures> dealPictures { get; set; }
        public virtual ICollection<DealDiscount> DealDiscounts { get; set; }
    }
}
