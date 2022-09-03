using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ISlugService
    {
        public string createSlug(string text);
        public string RemoveReservedUrlCharacter(string text);
        public string RemoveDiacritics(string text);

    }
}
