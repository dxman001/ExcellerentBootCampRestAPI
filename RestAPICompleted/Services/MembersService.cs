using RestAPICompleted.Dtos;
using RestAPICompleted.Interfaces;
using RestAPICompleted.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestAPICompleted.Services
{
    public class MembersService: IMembersService
    {
        private readonly List<Member> _members;
        public MembersService()
        {
            _members = new List<Member>();
            _members.AddRange
                (
                    new List<Member>()
                    {
                        new Member
                        {
                            Id=1,
                            FullName="Ashenafi Fiseha",
                            Role="Developer",
                            Grade="Dev III",
                            Username="ashu001",
                            Password="1234",
                            Email="ashu@excellerent.com"
                        },
                        new Member
                        {
                            Id=2,
                            FullName="Kaftamu Kagnewe",
                            Role="Team Leader",
                            Grade="Seniour Dev I",
                             Username="kaftu001",
                            Password="4321",
                            Email="Kaftamu@excellerent.com"
                        }
                        ,
                        new Member
                        {
                            Id=2,
                            FullName="Dagnachew Tsegaye",
                            Role="Tech Lead",
                            Grade="Seniour Dev III",
                            Username="dagnu001",
                            Password="1234",
                            Email="Dagnachew@excellerent.com"
                        }
                    }
                );
        }
        public ResponseDto<Member> Get(int? id=-1)
        {
               return id==null ? new ResponseDto<Member>(_members)
                :_members.Where(x => x.Id == id).Any()?new ResponseDto<Member>(_members.Where(x => x.Id == id).ToList())
                : new ResponseDto<Member>(null,$"Unable To find the Member with Id : {id} Provided");              
        }
        public ResponseDto<Member> Add(Member member)
        {
            if (member == null || member.Id==-1) return new ResponseDto<Member>(null, "Unable To Create Member,Invalid Argument Exception");
            _members.Add(member);
            return new ResponseDto<Member>(member,true,"Member Added Successfully");
        }
        public ResponseDto<Member> Update(Member member)
        {
            if (member == null || member.Id == -1) return new ResponseDto<Member>(null, "Invalid Argument Exception");
            Member toBeEdited = _members.Find(x => x.Id == member.Id);
            if (toBeEdited == null) return new ResponseDto<Member>(null, "Unable to find the member requested to be edited");
            toBeEdited.FullName = member.FullName;
            toBeEdited.Role = member.Role;
            toBeEdited.Grade = member.Grade;
            return new ResponseDto<Member>(member,true,"Member Successfully Updated");
        }
        public ResponseDto<Member> Remove(int id)
        {
            if (id == -1) return new ResponseDto<Member>(null, "Invalid Argument Exception,Wrong Id number");
            Member toBeDeleted = _members.Find(x => x.Id == id);
            if (toBeDeleted == null) return new ResponseDto<Member>(null, "Unable to find the member requested to be deleted");
            _members.Remove(toBeDeleted);
            return new ResponseDto<Member>(true,"Member Removed Successfully");
        }
        public Member AuthenticateUser(string username,string password)
        {
            return _members.Where(x => x.Username.ToLower().Equals(username) && x.Password.Equals(password))?.FirstOrDefault() ?? null;
        }
    }
}
