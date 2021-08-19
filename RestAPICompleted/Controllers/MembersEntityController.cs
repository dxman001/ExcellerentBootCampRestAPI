using Microsoft.AspNetCore.Mvc;
using RestAPICompleted.Dtos;
using RestAPICompleted.Interfaces;
using RestAPICompleted.Models;
using System.Threading.Tasks;

namespace RestAPICompleted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersEntityController : ControllerBase
    {
        private readonly IMembersEntityService _membersService;
        public MembersEntityController(IMembersEntityService membersService)
        {
            _membersService = membersService;
        }

        [HttpGet]
        public async Task<ResponseDto<MemberDto>> Get(int? id,string searchKey,int? pageindex,int? pageSize)
        {
            return await _membersService.GetWithPredicate(id,searchKey, pageindex, pageSize);
           
        }
        [HttpPost]
        public async Task<ResponseDto<MemberDto>> Add(MemberDto member)
        {
            return await _membersService.Create(member);
        }
        [HttpPut]
        public ResponseDto<MemberDto> Edit(MemberDto member)
        {
            return  _membersService.Update(member);
        }
        [HttpDelete]
        public ResponseDto<MemberDto> Remove(int id)
        {
            return _membersService.Delete(id);
        }
    }
}
