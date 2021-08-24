using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPICompleted.Dtos;
using RestAPICompleted.Helper;
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
        private readonly IJwtAuth _jwtAuth;
        public MembersEntityController(IMembersEntityService membersService, IJwtAuth jwtAuth)
        {
            _membersService = membersService;
            _jwtAuth = jwtAuth;
        }

        [HttpGet]
        [Authorize]
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

        //[AllowAnonymous]
        //[HttpPost("Authentication")]
        //public IActionResult Authentication([FromBody] UserCredential userCredential)
        //{
        //    var user = _membersService.AuthenticateUser(member.Username, member.Password);
        //    if (user == null) return Unauthorized();
        //    var token = _jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
        //    if (token == null)
        //        return Unauthorized();
        //    return Ok(token);
        //}
    }
}
