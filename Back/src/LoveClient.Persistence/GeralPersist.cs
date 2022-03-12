using System.Linq;
using System.Threading.Tasks;
using LoveClient.Domain;
using LoveClient.Persistence.Contextos;
using LoveClient.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace LoveClient.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly LoveClientContext _context;
        public GeralPersist(LoveClientContext context)
        {
            this._context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}