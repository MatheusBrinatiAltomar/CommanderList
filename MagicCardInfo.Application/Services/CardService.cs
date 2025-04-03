using MagicCardInfo.Domain.Models;
using MagicCardInfo.Domain.Repositories;
using MagicCardInfo.Domain.Services;

namespace MagicCardInfo.Application.Services;

public class CardService
{
    private readonly IScryfallService _scryfallService;
    private readonly ICardRepository _cardRepository;

    public CardService(IScryfallService scryfallService, ICardRepository cardRepository)
    {
        _scryfallService = scryfallService;
        _cardRepository = cardRepository;
    }

    public async Task<IEnumerable<Card>> GetCardsAsync(string keyword, int pageNumber, int pageSize)
    {
        return await _cardRepository.GetCardsAsync(keyword, pageNumber, pageSize);
    }

    public async Task AddOrUpdateCardsAsync()
    {
        List<Card> cards = await _scryfallService.GetCardsAsync();
        await _cardRepository.UpsertCardsAsync(cards);
    }
}
