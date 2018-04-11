using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface  IBaseRepository<T>
    {
        T GetById(int Id);
        List<T> GetAll();
        T AddOrUpdate(T entity);
        void Delete(int Id);
    }
}
