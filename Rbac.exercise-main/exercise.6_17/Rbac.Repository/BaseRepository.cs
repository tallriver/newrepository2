using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository
{

    //使用泛型进行基础操作
    public class BaseRepository<T, TKey> : IBaseRepository<T, TKey> where T : class
        where TKey : struct
    {
        protected MyDbContext DbContext;

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Add(T t)
        {
            DbContext.Set<T>().Add(t);
            return DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool AddAll(List<T> t)
        {
            foreach (var item in t)
            {
                DbContext.Set<T>().Add(item);
            }
            return DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Del(TKey key)
        {
            var list = DbContext.Set<T>().Find(key);
            DbContext.Remove(list);
            return DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DelAll(Expression<Func<T, bool>> predicate)
        {
            var list = DbContext.Set<T>().Where(predicate);
            DbContext.Remove(list);
            return DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Upd(T t)
        {
            DbContext.Entry<T>(t).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public List<T> GetInfoAll()
        {
            var list = DbContext.Set<T>().ToList();
            return list;
        }

        /// <summary>
        /// 根据主键获取单条数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T GetByWhere(TKey key)
        {
            var list = DbContext.Set<T>().Find(key);
            return list;
        }

        /// <summary>
        /// 根据条件获取单条数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T GetByWhere(Expression<Func<T, bool>> predicate)
        {
            var list = DbContext.Set<T>().Where(predicate).FirstOrDefault();
            return list;
        }

        /// <summary>
        /// 根据条件获取全部数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<T> GetByWhereAll(Expression<Func<T, bool>> predicate)
        {
            var list = DbContext.Set<T>().Where(predicate).ToList();
            return list;
        }

        /// <summary>
        /// 根据条件获取全部数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate)
        {
            var list = DbContext.Set<T>().Where(predicate);
            return list;
        }

    }
}
