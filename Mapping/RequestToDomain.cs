using AutoMapper;
using NoteAPI.Domain;
using NoteAPI.DTOs.Collections;
using NoteAPI.DTOs.Notes;

namespace NoteAPI.Mapping;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {

        CreateMap<CreateNoteRequest, Note>()
            .ForMember(dest => dest.Id, m => m.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.CreatedDate, m => m.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, m => m.MapFrom(_ => DateTime.UtcNow));

        CreateMap<UpdateNoteRequest, Note>();
            





        CreateMap<UpdateCollectionRequest, Collection>();


        CreateMap<CreateCollectionRequest, Collection>()
            .ForMember(dest => dest.Id, m => m.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.CreatedDate, m => m.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedDate, m => m.MapFrom(_ => DateTime.UtcNow));
    }
}





