using AutoMapper;
using NoteAPI.Domain;
using NoteAPI.DTOs.Collections;
using NoteAPI.DTOs.Notes;

namespace NoteAPI.Mapping
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {

            CreateMap<Note, GetNoteResponse>()
                .ForCtorParam(nameof(GetNoteResponse.Id), opt => opt.MapFrom(src => src.Id))
                .ForCtorParam(nameof(GetNoteResponse.CollectionId), opt => opt.MapFrom(src => src.CollectionId))
                .ForCtorParam(nameof(GetNoteResponse.Title), opt => opt.MapFrom(src => src.Title))
                .ForCtorParam(nameof(GetNoteResponse.Description), opt => opt.MapFrom(src => src.Description))
                .ForCtorParam(nameof(GetNoteResponse.UpdatedAt), opt => opt.MapFrom(src => src.UpdatedDate))
                .ForCtorParam(nameof(GetNoteResponse.CreatedDate), opt => opt.MapFrom(src => src.CreatedDate));

            CreateMap<Note, CreateNoteResponse>()
                .ForCtorParam(nameof(CreateNoteResponse.Id), opt => opt.MapFrom(src => src.Id))
                .ForCtorParam(nameof(CreateNoteResponse.CollectionId), opt => opt.MapFrom(src => src.CollectionId))
                .ForCtorParam(nameof(CreateNoteResponse.Title), opt => opt.MapFrom(src => src.Title))
                .ForCtorParam(nameof(CreateNoteResponse.Description), opt => opt.MapFrom(src => src.Description))
                .ForCtorParam(nameof(CreateNoteResponse.UpdatedAt), opt => opt.MapFrom(src => src.UpdatedDate))
                .ForCtorParam(nameof(CreateNoteResponse.CreatedDate), opt => opt.MapFrom(src => src.CreatedDate));


            CreateMap<Collection, CreateCollectionResponse>()
                .ForCtorParam(nameof(CreateCollectionResponse.Id), opt => opt.MapFrom(src => src.Id))
                .ForCtorParam(nameof(CreateCollectionResponse.Title), opt => opt.MapFrom(src => src.Title))
                .ForCtorParam(nameof(CreateCollectionResponse.CreatedDate), opt => opt.MapFrom(src => src.CreatedDate));

            CreateMap<Collection, GetCollectionResponse>()
                .ForCtorParam(nameof(GetCollectionResponse.Id), opt => opt.MapFrom(src => src.Id))
                .ForCtorParam(nameof(GetCollectionResponse.Description), opt => opt.MapFrom(src => src.Description))
                .ForCtorParam(nameof(GetCollectionResponse.Title), opt => opt.MapFrom(src => src.Title))
                .ForCtorParam(nameof(GetCollectionResponse.CreatedDate), opt => opt.MapFrom(src => src.CreatedDate))
                .ForCtorParam(nameof(GetCollectionResponse.UpdatedDate), opt => opt.MapFrom(src => src.UpdatedDate));

            CreateMap<Collection, UpdateCollectionResponse>()
                .ForCtorParam(nameof(UpdateCollectionResponse.Id), opt => opt.MapFrom(src => src.Id))
                .ForCtorParam(nameof(UpdateCollectionResponse.Title), opt => opt.MapFrom(src => src.Title))
                .ForCtorParam(nameof(UpdateCollectionResponse.UpdatedDate), opt => opt.MapFrom(src => src.UpdatedDate))
                .ForCtorParam(nameof(UpdateCollectionResponse.CreatedDate), opt => opt.MapFrom(src => src.CreatedDate))
                .ForCtorParam(nameof(UpdateCollectionResponse.Description), opt => opt.MapFrom(src => src.Description));



        }
    }
}
