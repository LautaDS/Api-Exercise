using System.Linq.Expressions;
namespace UnitOfWork.Repository
{
    public interface IRepository <T>
    {
        public IEnumerable<T> GetAll();
        T findId(Object Id);
        
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
      
    }
}
