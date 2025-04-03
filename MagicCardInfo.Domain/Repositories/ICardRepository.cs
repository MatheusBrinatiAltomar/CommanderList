using MagicCardInfo.Domain.Models;

namespace MagicCardInfo.Domain.Repositories
{
    public interface ICardRepository
    {
        Task UpsertCardsAsync(IEnumerable<Card> cards);
        Task<IList<Card>> GetCardsAsync(string keyword, int pageNumber, int pageSize);
    }
}