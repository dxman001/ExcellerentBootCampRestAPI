using RestAPICompleted.Dtos;
using RestAPICompleted.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPICompleted.Mapping
{
    public static class MemberMapping
    {
      public static MemberDto ToDto(this MemberEntity entity)
      {
            return new MemberDto
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Role = entity.Role,
                Grade = entity.Grade
            };
      }
        public static MemberEntity ToEntity(this MemberDto dto)
        {
            return new MemberEntity
            {
                Id=dto.Id,
                FullName = dto.FullName,
                Role = dto.Role,
                Grade = dto.Grade
            };
        }

    }
}
