using Microsoft.EntityFrameworkCore;
using RestAPICompleted.DBContext;
using RestAPICompleted.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RestAPICompleted.Repository
{
    public class RepositoryMember : IRepository<MemberEntity>
    {
        ApplicationDbContext _dbContext;
        public RepositoryMember(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<MemberEntity> CreateAsync(MemberEntity _member)
        {
            var member = await _dbContext.Member.AddAsync(_member);
            _dbContext.SaveChanges();
            return member.Entity;
        }
        public bool Update(MemberEntity _member)
        {
            _dbContext.Update(_member);
            _dbContext.SaveChanges();
            return true;
        }
        public async Task<IEnumerable<MemberEntity>> GetAllAsync()
        {
            return await _dbContext.Member.ToListAsync();
        }
        public async Task<IEnumerable<MemberEntity>> GetWithPredicateAsync(Expression<Func<MemberEntity, Boolean>> predicate,int pageIndex,int pageSize)
        {           
            return predicate==null? (await _dbContext.Member.Skip(pageIndex*pageSize).Take(pageSize).ToListAsync())
                :(await _dbContext.Member.Where(predicate).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync());
        }
        public async Task<MemberEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Member.FindAsync(id);
        }
        public bool Delete(int id)
        {
            _dbContext.Member.Remove(_dbContext.Member.Find(id));
            _dbContext.SaveChanges();
            return true;
        }

    }
}
