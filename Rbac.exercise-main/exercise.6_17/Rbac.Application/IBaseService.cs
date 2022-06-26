using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application
{
    public interface IBaseService<T,TDto>
        where T : class,new()
        where TDto : class,new()
    {
        bool Add(TDto dto);
        bool Delete(int id);
        bool UpDate(TDto dto);
        TDto GetDtoById(int id);
        List<TDto> GetAll();
        T GetDtoByWhere(Expression<Func<T, bool>> predicate);
    }
}
