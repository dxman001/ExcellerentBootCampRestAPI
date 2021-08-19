using Microsoft.AspNetCore.Mvc;
using RestAPICompleted.Dtos;
using RestAPICompleted.Interfaces;
using RestAPICompleted.Models;


namespace RestAPICompleted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersService _membersService;
        public MembersController(IMembersService membersService)
        {
            _membersService = membersService;
        }
        [HttpGet]
        public ResponseDto<Member> Get(int? id)
        {
           return _membersService.Get(id);       
        }
        [HttpPost]
        public ResponseDto<Member> Add(Member member)
        {
           return _membersService.Add(member);          
        }
        [HttpPut]
        public ResponseDto<Member> Update(Member member)
        {
            return _membersService.Update(member);
        }
        [HttpDelete]
        public ResponseDto<Member> Remove(int id)
        {
            return _membersService.Remove(id);
        }
    }
}
