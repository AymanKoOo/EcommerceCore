using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SlugService : ISlugService
    {
        public string createSlug(string text)
        {
            string slug = "";
            slug = text?.ToLowerInvariant().Replace(
               " ", "-", StringComparison.OrdinalIgnoreCase) ?? string.Empty;
            slug = RemoveDiacritics(slug);
            slug = RemoveReservedUrlCharacter(slug);

            return slug.ToLowerInvariant();

        }
        public string RemoveDiacritics(string text)
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

        public string RemoveReservedUrlCharacter(string text)
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
