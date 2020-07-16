using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WebAPITest.Repository
{
    public class CommonRepositoryInclude<T> where T: class
    {
        private readonly WebAPIContext _context;
        private readonly Func<IQueryable<T>, IQueryable<T>> _includeFunc;

        public CommonRepositoryInclude(WebAPIContext context,
            Func<IQueryable<T>, IQueryable<T>> includeFunc)
        {
            _context = context;
            _includeFunc = includeFunc;
        }

        private IQueryable<T> includeEntities() {
            return _includeFunc(_context.Set<T>()).AsNoTracking();
        }

        public IQueryable<T> GetAll()
        {
            return includeEntities();
        }

        public T GetById(Expression<Func<T, bool>> expression) {
            return includeEntities().AsNoTracking().FirstOrDefault(expression);
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return includeEntities().AsNoTracking().Where(expression);
        }
    }
}
