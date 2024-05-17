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
        Task<ApiResult<T>> GetById(int id);
        Task<ApiResult<List<T>>> GetAll();
        Task<ApiResult<string>> Create(T entity);
        Task<ApiResult<string>> Update(T entity);
        Task<ApiResult<string>> Delete(T entity);
    }
}
