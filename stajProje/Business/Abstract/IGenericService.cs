using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public interface IGenericService<T> where T : class
    {
        Task<T> TGetByIdAsync(int id);
        Task<IEnumerable<T>> TGetAllAsync();
        Task<bool> TCreateAsync(T entity);
        Task<bool> TUpdateAsync(T entity);
        Task<bool> TDeleteAsync(int id);
    }
}
