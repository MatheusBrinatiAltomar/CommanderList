using MagicCardInfo.Domain.Models;
using MagicCardInfo.Domain.Repositories;
using MagicCardInfo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicCardInfo.Infrastructure.Persistance
{
    public class CardRepositry : ICardRepository
    {
        private readonly ApplicationDbContext _context;

        public CardRepositry(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task UpsertCardsAsync(IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                if (cards == null)
                {
                    return;
                }
                var existingCard = await _context.Cards.FindAsync(card.Id);
                if (existingCard == null)
                    _context.Cards.Add(card);
                else
                    _context.Entry(existingCard).CurrentValues.SetValues(card);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Card>> GetCardsAsync(string keyword, int pageNumber, int pageSize)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.Cards
                    .OrderBy(c => c.Name)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }

            string lowerKeyword = $"%{keyword.ToLower()}%";

            return await _context.Cards
                .Where(c => EF.Functions.Like(c.Name.ToLower(), lowerKeyword) 
                        || EF.Functions.Like(c.OracleText.ToLower(), lowerKeyword))
                .OrderBy(c => c.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            }
    }
}