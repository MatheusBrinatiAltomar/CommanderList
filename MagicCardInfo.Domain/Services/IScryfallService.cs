using MagicCardInfo.Domain.Models;

namespace MagicCardInfo.Domain.Services
{
    public interface IScryfallService
    {
        Task<List<Card>> GetCardsAsync();
    }
}
