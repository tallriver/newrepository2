using AutoMapper;
using Rbac.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application
{
    //泛型类--具体实现
    public class BaseService<T, TDto> : IBaseService<T, TDto>
        where T : class, new()
        where TDto : class, new()
    {
        public BaseService(IBaseRepository<T, int> repository,IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public IBaseRepository<T, int> Repository { get; }
        public IMapper Mapper { get; }

        public bool Add(TDto dto)
        {
            return Repository.Add(Mapper.Map<T>(dto));
        }

        public bool Delete(int id)
        {
            return Repository.Del(id);
        }

        public List<TDto> GetAll()
        {
            return Mapper.Map<List<TDto>>(Repository.GetInfoAll());
        }

        public TDto GetDtoById(int id)
        {
            return Mapper.Map<TDto>(Repository.GetByWhere(id));
        }

        public bool UpDate(TDto dto)
        {
            return Repository.Upd(Mapper.Map<T>(dto));
        }

        public T GetDtoByWhere(Expression<Func<T, bool>> predicate)
        {
            return Repository.GetByWhere(predicate);
        }
    }
}
