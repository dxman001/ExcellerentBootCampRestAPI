using RestAPICompleted.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RestAPICompleted.Repository
{
    public interface IRepository<T>
    {
        public Task<T> CreateAsync(T _object);
        public bool Update(T _object);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public bool Delete(int id);
        public Task<IEnumerable<T>> GetWithPredicateAsync(Expression<Func<MemberEntity, Boolean>> predicate, int pageIndex, int pageSize);
    }
}
