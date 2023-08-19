using AutoMapper;
using OnionTemplate.Application.Features.Commands;


namespace OnionTemplate.Application.Mapping;

public class ExampleMapping : Profile
{
    public ExampleMapping()
    {
        CreateMap<Domain.ExampleEntity, Dto.ExampleEntityDto>()
            .ReverseMap();

        CreateMap<Domain.ExampleEntity, CreateExampleEntityCommand>()
            .ReverseMap();
        
        CreateMap<Domain.ExampleEntity, Dto.ExampleEntityViewModel>()
            .ReverseMap();
    }
}
