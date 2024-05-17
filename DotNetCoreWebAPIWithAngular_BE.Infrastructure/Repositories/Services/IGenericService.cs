using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
