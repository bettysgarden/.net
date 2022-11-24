using System.Linq.Expressions;
using Otvetmailru.Entities.Models;

namespace Otvetmailru.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(Guid id);
        T Save(T obj);
        void Delete(T obj);
    }
}