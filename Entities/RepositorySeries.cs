using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleListSeries.Interfaces;

namespace ConsoleListSeries.Entities
{
    class RepositorySeries : IRepository<Serie>
    {
        private List<Serie> Series = new List<Serie>();
        public List<Serie> List()
        {
            return Series;
        }
        public void UpdateEntity(int id, Serie entity)
        {
            Series[id] = entity;
        }
        public void Insert(Serie entity)
        {
            Series.Add(entity);
        }


        public int NextId()
        {
            return Series.Count;
        }


        public Serie SearchById(int id)
        {
            return Series[id];
        }

        public void Remove(int id)
        {
            Series[id].Delete();
        }
    }
}
