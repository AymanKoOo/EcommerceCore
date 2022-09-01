using Core.Entites.Base;
using Core.Entites.Discounts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Core.Entites
{
    public class Discount: EntityBase
    {
        //Set Name for discount
        public string Name { get; set; }

        public string slug { get; set; }
        
        //Admin Comment
        public string AdminComment { get; set; }

        ///Type of discount
        public int DiscountTypeId { get; set; }
        
        /// Gets or sets a value indicating whether to use percentage

        public bool UsePercentage { get; set; }

        /// Gets or sets the discount percentage

        public decimal DiscountPercentage { get; set; }

        /// Gets or sets the discount amount
        public decimal DiscountAmount { get; set; }

        /// Gets or sets the maximum discount amount (used with "UsePercentage")
        public decimal? MaximumDiscountAmount { get; set; }

        /// Gets or sets the discount start date and time
        public DateTime? StartDateUtc { get; set; }
        
        /// Gets or sets the discount end date and time
        public DateTime? EndDateUtc { get; set; }

        /// Gets or sets use copuon
        public bool RequiresCouponCode { get; set; }

        public string CouponCode { get; set; }

        //public bool IsCumulative { get; set; }
        public string PictureName { get; set; }

        //public int DiscountLimitationId { get; set; }

        //public int LimitationTimes { get; set; }

        //public int? MaximumDiscountedQuantity { get; set; }

        //public bool AppliedToSubCategories { get; set; }

        public virtual ICollection<DiscountProduct> Discounts { get; set; }
        //public virtual DiscountType DiscountType { get; set; }
        public virtual ICollection<DiscountCategory> DiscountCategory { get; set; }
        public int pictureId { get; set; }
        public Picture picture { get; set; }



        public static string CreateDiscountslug(string slug)
        {

            slug = slug?.ToLowerInvariant().Replace(
                " ", "-", StringComparison.OrdinalIgnoreCase) ?? string.Empty;
            slug = RemoveDiacritics(slug);
            slug = RemoveReservedUrlCharacters(slug);

            return slug.ToLowerInvariant();
        }
        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        private static string RemoveReservedUrlCharacters(string text)
        {
            var reservedCharacters = new List<string> { "!", "#", "$", "&", "'", "(", ")", "*", ",", "/", ":", ";", "=", "?", "@", "[", "]", "\"", "%", ".", "<", ">", "\\", "^", "_", "'", "{", "}", "|", "~", "`", "+" };

            foreach (var chr in reservedCharacters)
            {
                text = text.Replace(chr, string.Empty, StringComparison.OrdinalIgnoreCase);
            }

            return text;
        }
    }
}
