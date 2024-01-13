using DataAccessLayer.Abstract;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public async Task<T> GetById(int id)
        {
            using (var c = new AppDbContext())
            {
                return await c.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> GetListAll()
        {
            using (var c = new AppDbContext())
            {
                return await c.Set<T>().ToListAsync();
            }
        }

        public async Task<List<T>> GetListAll(Expression<Func<T, bool>> filter)
        {
            using (var c = new AppDbContext())
            {
                return await c.Set<T>().Where(filter).ToListAsync();
            }
        }

        public void Create(T entity)
        {
            using var c = new AppDbContext();
            c.Set<T>().Add(entity);
            c.SaveChanges();
        }

        public void Insert(T t)
        {
            using var c = new AppDbContext();
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using var c = new AppDbContext();
            c.Update(t);
            c.SaveChanges();
        }

        public void Delete(T t)
        {
            using var c = new AppDbContext();
            c.Remove(t);
            c.SaveChanges();
        }
    }
}
