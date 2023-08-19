using AutoMapper;
using MediatR;
using OnionTemplate.Application.Dto;
using OnionTemplate.Application.Interfaces.Repositories;
using OnionTemplate.Application.Wrappers;


namespace OnionTemplate.Application.Features.Queries;

public class GetSingleExampleEntityQuery : IRequest<ServiceResponse<ExampleEntityViewModel>>
{
    public Guid Id { get; set; }
    
    public GetSingleExampleEntityQuery(Guid id)
    {
        Id = id;
    }

    public class GetExampleEntityQueryHandler : IRequestHandler<GetSingleExampleEntityQuery, ServiceResponse<ExampleEntityViewModel>>
    {
        private readonly IExampleEntityRepository _exampleEntityRepository;
        private readonly IMapper _mapper;

        public GetExampleEntityQueryHandler(IExampleEntityRepository exampleEntityRepository, IMapper mapper)
        {
            _exampleEntityRepository = exampleEntityRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ExampleEntityViewModel>> Handle(GetSingleExampleEntityQuery request, CancellationToken cancellationToken)
        {
            var result = await _exampleEntityRepository.GetByIdAsync(request.Id);
            if (result == null || result.Id == Guid.Empty)
            {
				return ServiceResponse<ExampleEntityViewModel>.Failure("No entry was found.");
            }

            var mapResult = _mapper.Map<ExampleEntityViewModel>(result);
            return ServiceResponse<ExampleEntityViewModel>.Success(mapResult);
        }
    }
}
