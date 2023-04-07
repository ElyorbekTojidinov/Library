using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrostructure.Infrostructure
{
    public interface IRepository<T> where T : class
    {
        public Task<bool> Insert(T entity);
        public Task<bool> Update(T entity);
        public Task DeleteById(int id);
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);
    }
}
