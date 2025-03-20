using System.Linq.Expressions;

namespace SHL.Application.Interfaces
{
    public interface IGenericService<T, TCreateDto, TUpdateDto, TReadDto>
    {
        Task<IEnumerable<TReadDto>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
        Task<TReadDto?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<TReadDto> GetByIdAsync(Guid id);
        Task<T> AddAsync(TCreateDto createDto);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<TCreateDto> createDtos);
        Task UpdateAsync(Guid id, TUpdateDto updateDto);
        Task DeleteAsync(Guid id);
    }
}
