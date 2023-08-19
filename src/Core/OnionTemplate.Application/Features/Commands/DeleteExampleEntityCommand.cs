using AutoMapper;
using MediatR;
using OnionTemplate.Application.Dto;
using OnionTemplate.Application.Interfaces.Repositories;
using OnionTemplate.Application.Wrappers;
using OnionTemplate.Domain;

namespace OnionTemplate.Application.Features.Commands;

public class DeleteExampleEntityCommand : IRequest<ServiceResponse<ExampleEntityDto>>
{
    public Guid Id { get; set; }

    public class DeleteExampleEntityCommandHandler : IRequestHandler<DeleteExampleEntityCommand, ServiceResponse<ExampleEntityDto>>
    {
        private readonly IExampleEntityRepository _repository;
        private readonly IMapper _mapper;

        public DeleteExampleEntityCommandHandler(IExampleEntityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ExampleEntityDto>> Handle(DeleteExampleEntityCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteAsync(request.Id);
            if (result == null || result.Id == Guid.Empty)
            {
                return ServiceResponse<ExampleEntityDto>.Failure("No entry was found.");
            }

            var dto = _mapper.Map<ExampleEntityDto>(result);
            return ServiceResponse<ExampleEntityDto>.Success(dto);
        }
    }
}
