using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VouViajar.Excursoes.Application.Contracts.Infrastructure;
using VouViajar.Excursoes.Infrastructure.Persistence;

namespace VouViajar.Excursoes.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ExcursaoDbContext _context;
        private readonly DbSet<T> dbSet;

        public BaseRepository(ExcursaoDbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public BaseRepository()
        {
        }

        public IEnumerable<T> Obter(Expression<Func<T, bool>> parametros)
        {
            return dbSet.AsNoTracking().Where(parametros).ToList();
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