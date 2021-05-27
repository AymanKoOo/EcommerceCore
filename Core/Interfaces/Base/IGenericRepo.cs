using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {

        IEnumerable<T> GetAll();

        void Add(T model);

        bool Delete(T model);

        void Update(T model);

        ///////
    }
}
