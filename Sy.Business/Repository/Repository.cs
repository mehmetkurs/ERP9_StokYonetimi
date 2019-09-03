using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sy.Core.Abstracts;
using Sy.DataAccess;


namespace Sy.Business.Repository
{
    public class Repository<Tentity, TKey> : IRepository<Tentity, TKey>
         where Tentity : class, IEntity<TKey>
    {

        private readonly StokDbContext _context;
        private readonly DbSet<Tentity> _table;

        public Repository()
        {
            _context = new StokDbContext();
            _table = _context.Set<Tentity>();
        }
        public TKey Add(Tentity entity)
        {
            _table.Add(entity);
            this.Save();
            return entity.Id;
        }

        public int Delete(Tentity entity)
        {
            throw new NotImplementedException();
        }

        public Tentity GetById(TKey id)
        {
            return _table.Find(id);
        }

        public IQueryable<Tentity> Query(Expression<Func<Tentity, bool>> predicate = null)
        {
            return predicate == null ? _table : _table.Where(predicate);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public int Update(Tentity entity)
        {
            _table.AddOrUpdate(entity);
            return this.Save();
        }
    }
}
