using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace Inventofree.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private IDbSet<T> _entities;

        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities as DbSet<T>;
            }
        }

        public virtual IQueryable<T> Table => Entities;

        public IQueryable<T> TableUntracked { get; set; }
        public bool? AutoCommitEnabled { get; set; }

        public Repository(DbContext context, IDbSet<T> entities)
        {
            _context = context;
            _entities = entities;
        }

        public T Create()
        {
            return Entities.Create();
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public T Attach(T entity)
        {
            return Entities.Attach(entity);
        }

        public bool Insert(T entity)
        {
            if (entity == null)
                return false;
            try
            {
                Entities.Add(entity);
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        public bool Update(T entity)
        {

            if (entity == null) return false;

            try
            {
                this.Entities.AddOrUpdate(entity);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(T entity)
        {

            if (entity == null)
                return false;
            try
            {
                Entities.Remove(entity);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Save(T entity)
        {

            if (entity == null)
                return false;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public IQueryable<T> Expand(IQueryable<T> query, string path)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Expand<TProperty>(IQueryable<T> query, Expression<Func<T, TProperty>> path)
        {
            throw new NotImplementedException();
        }

        public bool IsModified(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
