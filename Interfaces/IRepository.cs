using System.Collections.Generic;

namespace ConsoleListSeries.Interfaces
{
    interface IRepository<T>
    {
        List<T> List();
        T SearchById(int id);
        void Insert(T entity);
        void Remove(int id);
        void UpdateEntity(int id, T entity);
        int NextId();

    }
}
