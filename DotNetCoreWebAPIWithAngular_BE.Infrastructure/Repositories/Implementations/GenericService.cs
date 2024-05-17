using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Common.ResponseNotifications;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.DBContext;
using DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreWebAPIWithAngular_BE.Infrastructure.Repositories.Implementations
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private WebAPIWithAngularDemoContext _context;

        public GenericService(WebAPIWithAngularDemoContext context)
        {
            this._context = context;
        }

        public async Task<ApiResult<List<T>>> GetAll()
        {
            try
            {
                var data = _context.Set<T>().ToList();
                return new ApiSuccessResult<List<T>>(data);
            }
            catch
            {
                return new ApiErrorResult<List<T>>("Lỗi hệ thống!");
            }
        }

        public async Task<ApiResult<T>> GetById(int id)
        {
            try
            {
                var data = await _context.Set<T>().FindAsync(id);
                return new ApiSuccessResult<T>(data);
            }
            catch
            {
                return new ApiErrorResult<T>("Lỗi hệ thống!");
            }
        }

        public async Task<ApiResult<string>> Create(T entity)
        {
            try
            {
                _context.Add(entity);
                return new ApiSuccessResult<string>();
            }
            catch 
            {
                return new ApiErrorResult<string>("Lỗi hệ thống!");
            }
        }

        public async Task<ApiResult<string>> Delete(T entity)
        {
            try
            {
                _context.Remove(entity);
                return new ApiSuccessResult<string>();
            }
            catch
            {
                return new ApiErrorResult<string>("Lỗi hệ thống!");
            }
        }

        public async Task<ApiResult<string>> Update(T entity)
        {
            try
            {
                _context.Update(entity);
                return new ApiSuccessResult<string>();
            }
            catch
            {
                return new ApiErrorResult<string>("Lỗi hệ thống!");
            }
        }
    }
}
