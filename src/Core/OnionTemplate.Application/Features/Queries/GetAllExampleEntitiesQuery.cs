using AutoMapper;
using MediatR;
using OnionTemplate.Application.Dto;
using OnionTemplate.Application.Interfaces.Repositories;
using OnionTemplate.Application.Wrappers;


namespace OnionTemplate.Application.Features.Queries;

public class GetAllExampleEntitiesQuery : IRequest<ServiceResponse<List<ExampleEntityDto>>>
{
    public class GetAllExampleEntitiesQueryHandler : IRequestHandler<GetAllExampleEntitiesQuery, ServiceResponse<List<ExampleEntityDto>>>
    {
        private readonly IExampleEntityRepository _exampleEntityRepository;
        private readonly IMapper _mapper;

        public GetAllExampleEntitiesQueryHandler(IExampleEntityRepository exampleEntityRepository, IMapper mapper)
        {
            _exampleEntityRepository = exampleEntityRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<ExampleEntityDto>>> Handle(GetAllExampleEntitiesQuery request, CancellationToken cancellationToken)
        {
            var result = await _exampleEntityRepository.GetAllAsync();
            var mapResult = _mapper.Map<List<ExampleEntityDto>>(result);

            return ServiceResponse<List<ExampleEntityDto>>.Success(mapResult);
        }
    }
}
