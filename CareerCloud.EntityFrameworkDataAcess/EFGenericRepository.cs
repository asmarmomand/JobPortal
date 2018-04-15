using CareerCloud.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;


namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository<T> where T : class
    {
        private readonly CareerCloudContext _context;
        public EFGenericRepository(bool createProxy = true)
        {
            _context = new CareerCloudContext(createProxy);
           
        }

        public void Add(params T[] items)
        {
            foreach(T item in items) 
            {
                _context.Entry(item).State = EntityState.Added;
            }
            _context.SaveChanges();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> Query = _context.Set<T>();
            foreach(var navprop in navigationProperties)
            {
                Query = Query.Include<T, object>(navprop);
            }
            return Query.ToList<T>();
        }


        public IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> Query = _context.Set<T>();
            foreach (var navprop in navigationProperties)
            {
                Query = Query.Include<T, object>(navprop);
            }
            return Query.Where(where).ToList<T>();
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> Query = _context.Set<T>();
            foreach(Expression <Func<T,object>> navprop in navigationProperties)
            {
                Query = Query.Include<T, object>(navprop);
            }
            return Query.FirstOrDefault(where);
        }

        public void Remove(params T[] items)
        {
            foreach(T item in items)
            {
                _context.Entry(item).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach(T item in items)
            {
                _context.Entry(item).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
}
