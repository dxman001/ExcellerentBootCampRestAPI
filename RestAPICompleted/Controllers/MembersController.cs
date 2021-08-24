using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPICompleted.Dtos;
using RestAPICompleted.Helper;
using RestAPICompleted.Interfaces;
using RestAPICompleted.Models;


namespace RestAPICompleted.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MembersController : ControllerBase
    {
        private readonly IMembersService _membersService;
        private readonly IJwtAuth _jwtAuth;
        public MembersController(IMembersService membersService, IJwtAuth jwtAuth)
        {
            _membersService = membersService;
            _jwtAuth = jwtAuth;
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

        [AllowAnonymous]
        [HttpPost("Authentication")]
        public IActionResult Authentication([FromBody] UserCredential userCredential)
        {
            var member=_membersService.AuthenticateUser(userCredential.Username, userCredential.Password);
            return member == null ? Unauthorized() : Ok(_jwtAuth.Authentication(member));
    
        }
    }
}
