using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper;
        

        public GenericManager(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> TCreateAsync(T entity)
        {
           return await _repository.CreateAsync(entity);
        }

        public async Task<bool> TDeleteAsync(int id)
        {
           return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> TGetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> TGetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> TUpdateAsync(T entity)
        {
           return await _repository.UpdateAsync(entity);
        }
    }
}
