using LinqKit;
using RestAPICompleted.Dtos;
using RestAPICompleted.Interfaces;
using RestAPICompleted.Mapping;
using RestAPICompleted.Models;
using RestAPICompleted.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPICompleted.Services
{
    public class MembersEntityService : IMembersEntityService
    {
        private readonly IRepository<MemberEntity> _repositoryMember;
        public MembersEntityService(IRepository<MemberEntity> repositoryMember)
        {
            _repositoryMember = repositoryMember;
        }
        public async Task<ResponseDto<MemberDto>> Get(int? id)
        {
            return (id == null ? (await GetAll()) : (await GetById(id??-1)));
        }
        public async Task<ResponseDto<MemberDto>> GetWithPredicate(int? id,string searchKey,int? pageIndex,int? pageSize)
        {
            var predicate = PredicateBuilder.True<MemberEntity>();
            if(id!=null)
                predicate= predicate.And(p => p.Id == id);
            else
            predicate = string.IsNullOrEmpty(searchKey)? null 
                       : predicate.And
                        (
                            p => p.FullName.Contains(searchKey) || 
                            p.Role.Contains(searchKey) || 
                            p.Grade.Contains(searchKey)
                        );
            return new ResponseDto<MemberDto>
                (
                    (await _repositoryMember.GetWithPredicateAsync(predicate, pageIndex??0,pageSize??2))
                    .Select(x=>x.ToDto()
                    ).ToList()
                );
        }
        private async Task<ResponseDto<MemberDto>> GetAll()
        {
            return new ResponseDto<MemberDto>((await _repositoryMember.GetAllAsync()).Select(x=>x.ToDto()).ToList());
        }
        private async Task<ResponseDto<MemberDto>> GetById(int id)
        {
            return new ResponseDto<MemberDto>((await _repositoryMember.GetByIdAsync(id)).ToDto());
        }
        public async Task<ResponseDto<MemberDto>> Create(MemberDto member)
        {
            return new ResponseDto<MemberDto>((await _repositoryMember.CreateAsync(member.ToEntity())).ToDto(),true,"Member Created Successfully");
        }
        public ResponseDto<MemberDto> Update(MemberDto member)
        {
            return new ResponseDto<MemberDto>(member,_repositoryMember.Update(member.ToEntity()),"Member Updated Successfully");
        }
        public ResponseDto<MemberDto> Delete(int id)
        {
            return new ResponseDto<MemberDto>(_repositoryMember.Delete(id),"Member Deleted Successfully");
        }
    }
}
