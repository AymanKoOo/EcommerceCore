using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Media
{
    public interface IPictureRepo:IGenericRepo<Picture>
    {
        public Task<Picture> getPicByName(string name);
    }
}
