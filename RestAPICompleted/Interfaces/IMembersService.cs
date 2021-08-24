using RestAPICompleted.Dtos;
using RestAPICompleted.Models;


namespace RestAPICompleted.Interfaces
{
    public interface IMembersService
    {
        ResponseDto<Member> Get(int? id);
        ResponseDto<Member> Add(Member member);
        ResponseDto<Member> Update(Member member);
        ResponseDto<Member> Remove(int id);
        Member AuthenticateUser(string username, string password);
    }
}
