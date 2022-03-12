using System.Threading.Tasks;
using LoveClient.Domain;

namespace LoveClient.Application.Contratos
{
    public interface IEventoService
    {
         Task<Evento> AddEventos(Evento model);
         Task<Evento> UpdateEvento(int eventoId, Evento model);
         Task<bool> DeleteEvento(int eventoId);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosByTituloAsync(string titulo, bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync (int eventoId, bool includePalestrantes = false);
         
    }
}