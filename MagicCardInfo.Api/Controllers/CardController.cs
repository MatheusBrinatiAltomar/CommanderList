using MagicCardInfo.Application.Services;
using MagicCardInfo.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagicCardInfo.API.Controllers
{
    [Route("api/cards")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly CardService _cardService;

        public CardController(CardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Card>>> GetCards(string keyword = "", int pageNumber = 1, [FromQuery] int pageSize = 20)
        {
            IEnumerable<Card> cards = await _cardService.GetCardsAsync(keyword, pageNumber, pageSize);

            return Ok(cards);
        }
    }
}
