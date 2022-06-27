using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Rbac.Repository
{
    //泛型类--接口
    public interface IBaseRepository<T, TKey>
        where T : class
        where TKey : struct
    {
        bool Add(T t);
        bool AddAll(List<T> t);
        bool Del(TKey key);
        bool DelAll(Expression<Func<T, bool>> predicate);
        List<T> GetInfoAll();
        T GetByWhere(Expression<Func<T, bool>> predicate);
        T GetByWhere(TKey key);
        List<T> GetByWhereAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate);
        bool Upd(T t);
    }
}