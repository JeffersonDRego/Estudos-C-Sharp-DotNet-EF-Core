using System.Linq;
using System.Threading.Tasks;
using LoveClient.Domain;
using Microsoft.EntityFrameworkCore;
using LoveClient.Persistence.Contratos;
using LoveClient.Persistence.Contextos;

namespace LoveClient.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        private readonly LoveClientContext _context;
        public EventoPersist(LoveClientContext context)
        {
            this._context = context;
            // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes) 
            {
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTituloAsync(string titulo, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes) 
            {
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
            }

            query = query
                .AsNoTracking()
                .OrderBy(e => e.Id)
                .Where(e => e.Titulo.ToLower().Contains(titulo.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrantes) 
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query
                .AsNoTracking()
                .OrderBy(e => e.Id)
                .Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

    }
}