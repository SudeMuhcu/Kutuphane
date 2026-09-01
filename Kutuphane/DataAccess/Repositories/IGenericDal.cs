using System.Linq.Expressions;

namespace Kutuphane.DataAccess.Repositories
{//Ne Yapılacak
    public interface IGenericDal<T> where T : class
    {
        List<T> GetList();
        List<T> GetList(params Expression<Func<T, object>>[] include);
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
