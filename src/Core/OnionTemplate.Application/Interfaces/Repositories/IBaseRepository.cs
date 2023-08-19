using OnionTemplate.Domain;
namespace OnionTemplate.Application.Interfaces.Repositories;

public interface IBaseRepository<T> where T: BaseEntity
{
    Task<List<T>> GetAllAsync();
    
    Task<T> GetByIdAsync(Guid id);
    
    Task<T> CreateAsync(T entity);

    Task<T> DeleteAsync(Guid id);
}
