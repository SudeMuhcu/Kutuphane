
using Kutuphane.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kutuphane.DataAccess.Repositories
{// Nasıl Yapılacak
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly LibraryContext _context;
        public GenericRepository(LibraryContext context)
        {
            _context = context;
        }
        //consructor 
        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }


        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }


        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public List<T> GetList(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();


            foreach (var include in includes) 
            {
                query = query.Include(include);
            }
            return query.ToList();

        }
    }
}
