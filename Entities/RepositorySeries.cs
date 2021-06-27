using System.Collections.Generic;
using ConsoleListSeries.Interfaces;

namespace ConsoleListSeries.Entities
{
    class RepositorySeries : IRepository<Series>
    {
        private List<Series> Series = new List<Series>();

        public List<Series> List()
        {
            return Series;
        }
        public void UpdateEntity(int id, Series entity)
        {
            Series[id] = entity;
        }
        public void Insert(Series entity)
        {
            Series.Add(entity);
        }
        public int NextId()
        {
            return Series.Count;
        }
        public Series SearchById(int id)
        {
            return Series[id];
        }
        public void Remove(int id)
        {
            Series[id].Delete();
        }
    }
}
