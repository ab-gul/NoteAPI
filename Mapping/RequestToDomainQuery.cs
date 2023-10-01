using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NoteAPI.Domain;

namespace NoteAPI.Mapping
{
    public class RequestToDomainQuery: Profile
    {
        public RequestToDomainQuery()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
        }

    }
}
