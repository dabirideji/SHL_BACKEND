using System.Linq.Expressions;
using AutoMapper;
using SHL.Application.Interfaces;
using SHL.Application.Interfaces.GenericRepositoryPattern;

namespace InventoryManagement.Application.Services.Customer
{
    public class GenericService<T, TCreateDto, TUpdateDto, TReadDto>
        : IGenericService<T, TCreateDto, TUpdateDto, TReadDto>
        where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<T> _repository;

        public GenericService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = null;// _unitOfWork.GetRepository<T>();
        }

        public virtual async Task<IEnumerable<TReadDto>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
        {
            var entities = await _repository.GetAllAsync(predicate);
            return _mapper.Map<IEnumerable<TReadDto>>(entities);
        }

        public virtual async Task<TReadDto?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            var entity = await _repository.GetAsync(predicate);
            return entity == null ? default : _mapper.Map<TReadDto>(entity);
        }

        public virtual async Task<TReadDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TReadDto>(entity);
        }

        public virtual async Task<T> AddAsync(TCreateDto createDto)
        {
           try
           {
             var entity = _mapper.Map<T>(createDto);
             await _repository.AddAsync(entity);
             await _unitOfWork.SaveChangesAsync();
             return entity;
           }
           catch (System.Exception x)
           {
            Console.WriteLine(x);
            throw;
           }
        }

        public virtual async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<TCreateDto> createDtos)
        {
           try
           {
             var entities = _mapper.Map<List<T>>(createDtos);
             await _repository.AddRangeAsync(entities);
             await _unitOfWork.SaveChangesAsync();
             return entities;
           }
           catch (System.Exception x)
           {
            Console.WriteLine(x);
            throw;
           }
        }

        public virtual async Task UpdateAsync(Guid id, TUpdateDto updateDto)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                _mapper.Map(updateDto, entity);
                await _repository.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
