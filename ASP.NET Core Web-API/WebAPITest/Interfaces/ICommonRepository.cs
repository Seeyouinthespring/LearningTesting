using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPITest.Interfaces
{
    public interface ICommonRepository<T> where T: class
    {
        public void Create(T item);
        public void CreateAll(List<T> entitiesToInsert);
        public T FindById(int id);
        public IEnumerable<T> Get();
        public IEnumerable<T> GetByCondition(Func<T, bool> predicate);
        public void Remove(T item);
        public void Update(T item);
        public void UpdateAll(List<T> entitiesToUpdate);
        public IQueryable<T> GetWithInclude(params  Expression<Func<T, object>>[] includeProperties);
    }
}
