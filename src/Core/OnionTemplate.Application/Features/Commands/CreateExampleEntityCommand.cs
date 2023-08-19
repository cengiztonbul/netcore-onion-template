using AutoMapper;
using MediatR;
using OnionTemplate.Application.Dto;
using OnionTemplate.Application.Interfaces.Repositories;
using OnionTemplate.Application.Wrappers;
using OnionTemplate.Domain;

namespace OnionTemplate.Application.Features.Commands;

public class CreateExampleEntityCommand : IRequest<ServiceResponse<ExampleEntityDto>>
{
    public string? Name { get; set; }
    public string? SensitiveData { get; set; }

    public class CreateExampleEntityCommandHandler : IRequestHandler<CreateExampleEntityCommand, ServiceResponse<ExampleEntityDto>>
    {
        private readonly IExampleEntityRepository _repository;
        private readonly IMapper _mapper;

        public CreateExampleEntityCommandHandler(IExampleEntityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ExampleEntityDto>> Handle(CreateExampleEntityCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                return ServiceResponse<ExampleEntityDto>.Failure("Name cannot be null");
            }

            var entity = _mapper.Map<ExampleEntity>(request);

            await _repository.CreateAsync(entity);
            var dto = _mapper.Map<ExampleEntityDto>(entity);

            return ServiceResponse<ExampleEntityDto>.Success(dto);
        }
    }
}
