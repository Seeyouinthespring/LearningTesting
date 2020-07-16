using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebAPITest.Models;
using WebAPITest.Repository;
using System.Linq.Expressions;

namespace WebAPITest.Services
{
    public class SightseenService : ISightseenService
    {
        private readonly CommonRepository<Sightseen> commonRepository;
        private readonly CommonRepositoryInclude<Sightseen> commonRepositoryInclude;

        public SightseenService(WebAPIContext context)
        {
            this.commonRepository = new CommonRepository<Sightseen>(context);
            this.commonRepositoryInclude = new CommonRepositoryInclude<Sightseen>(context,getEntities);
        }

        public IQueryable<Sightseen> getEntities(IQueryable<Sightseen> query) {
            return query.Include(x => x.city).ThenInclude(z => z.country);
        }
        public void CreateListSights(List<Sightseen> entitiesToInsert)
        {
            commonRepository.CreateAll(entitiesToInsert);
        }

        public void CreateSight(Sightseen item)
        {
            commonRepository.Create(item);
        }

        public Sightseen FindSightById(int id)
        {
            return commonRepository.FindById(id);
        }

        public IEnumerable<Sightseen> GetSights()
        {
            return commonRepository.Get();
        }

        public IEnumerable<Sightseen> GetSightsByCondition(Func<Sightseen, bool> predicate)
        {
            return commonRepository.GetByCondition(predicate);
        }

        public void RemoveSight(Sightseen item)
        {
            commonRepository.Remove(item);
        }

        public void UpdateListSights(List<Sightseen> entitiesToUpdate)
        {
            commonRepository.UpdateAll(entitiesToUpdate);
        }

        public void UpdateSight(Sightseen item)
        {
            commonRepository.Update(item);
        }

        public Sightseen FindSightByIdWithEverything(int id)
        {
            return commonRepositoryInclude.GetById(x=> x.id == id);
        }

        public IEnumerable<Sightseen> GetSightsWithEverything()
        {
            return commonRepositoryInclude.GetAll();
        }

        public IEnumerable<Sightseen> GetSightsWithEverythingByCondition(Expression<Func<Sightseen, bool>> expression)
        {
            return commonRepositoryInclude.GetByCondition(expression);
        }

        public async Task<Sightseen> GetSightByIdAsync(int id)
        {
            return await commonRepository.FindByIdAsync<Sightseen>(id);
        }

        public async Task<Sightseen> GetSightByConditionAsyncNoTracking(Expression<Func<Sightseen, bool>> expression)
        {
            return await commonRepository.FindByConditionAsyncNoTracking<Sightseen>(expression);
        }
    }
}
