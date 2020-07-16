using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPITest.Models;

namespace WebAPITest.Services
{
    public interface ISightseenService
    {
        public void CreateSight(Sightseen item);
        public void CreateListSights(List<Sightseen> entitiesToInsert);
        public Sightseen FindSightById(int id);
        public IEnumerable<Sightseen> GetSights();
        public IEnumerable<Sightseen> GetSightsByCondition(Func<Sightseen, bool> predicate);
        public void RemoveSight(Sightseen item);
        public void UpdateSight(Sightseen item);
        public void UpdateListSights(List<Sightseen> entitiesToUpdate);

        public Sightseen FindSightByIdWithEverything(int id);

        public IEnumerable<Sightseen> GetSightsWithEverything();

        public IEnumerable<Sightseen> GetSightsWithEverythingByCondition(Expression<Func<Sightseen, bool>> expression);
    }
}
