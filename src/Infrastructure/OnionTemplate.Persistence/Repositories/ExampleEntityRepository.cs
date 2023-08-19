using OnionTemplate.Application.Interfaces.Repositories;
using OnionTemplate.Domain;
using OnionTemplate.Persistence.Context;

namespace OnionTemplate.Persistence;

public class ExampleEntityRepository : BaseRepository<ExampleEntity>, IExampleEntityRepository
{
    public ExampleEntityRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
