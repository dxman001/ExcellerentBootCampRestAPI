using RestAPICompleted.Dtos;
using RestAPICompleted.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPICompleted.Interfaces
{
    public interface IMembersEntityService
    {
        Task<ResponseDto<MemberDto>> Get(int? id);
        Task<ResponseDto<MemberDto>> GetWithPredicate(int? id,string searchKey,int? pageIndex, int? pageSize);
        Task<ResponseDto<MemberDto>> Create(MemberDto member);
        ResponseDto<MemberDto> Update(MemberDto member);
        ResponseDto<MemberDto> Delete(int id);
    }
}
