using System.Threading.Tasks;
using LoveClient.Domain;

namespace LoveClient.Persistence.Contratos
{
    public interface IEventoPersist
    {
        //EVENTOS
        Task<Evento[]> GetAllEventosByTituloAsync(string titulo, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync (int eventoId, bool includePalestrantes = false);
    }
}