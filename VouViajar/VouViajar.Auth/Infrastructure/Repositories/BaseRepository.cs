using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VouViajar.Auth.Application.Contracts.Infrastructure;

namespace VouViajar.Auth.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public BaseRepository()
        {
        }

        public IEnumerable<T> Obter(Expression<Func<T, bool>> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public T ObterPorId(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return dbSet.ToList();
        }

        public T Inserir(T entity)
        {
            dbSet.Add(entity);
            return _context.SaveChanges() == 1 ? entity : null;
        }

        public T Alterar(T entity)
        {
            return Salvar(entity);
        }

        public void Excluir(T entity)
        {
            dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public T Salvar(T entity)
        {
            dbSet.Update(entity);
            return _context.SaveChanges() == 1 ? entity : null;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
