using bulkey.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bulkey.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db )
        {
            _db = db;
            //_db.ShoppingCarts.AsNoTracking();
            //_db.ShoppingCarts.Include(u => u.Product).Include(u => u.CoverType);
            this.dbSet =_db.Set<T>();
        }
        public void Add(T entity)
        {
            
            dbSet.Add(entity); 
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null, string? includeProperties = null)
        {
           IQueryable<T> query = dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }
           
            if (includeProperties != null)
            {
                foreach(var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>filter , string? includeProperties = null,bool tracked =true)
        {
            IQueryable<T> query;
            if (tracked == true)
            {
                query=dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();
            }
             
            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
