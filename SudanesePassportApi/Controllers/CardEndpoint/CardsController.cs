using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SudanesePassportApi.Interfaces.CardInterface;
using SudanesePassportApi.Models.SudaneseCard;

namespace SudanesePassportApi.Controllers.CardEndpoint;

[Route("api/[controller]")]
[ApiController]
public class CardsController : ControllerBase
{
    private readonly ICardRepository _repository;

    public CardsController(ICardRepository repository)
    {
        _repository = repository;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Card>> GetCardById(int id)
    {
        var card = await _repository.GetCardByIdAsync(id);
        if (card == null)
        {
            return NotFound("The Card With this id not found");
        }
        return Ok(card);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Card>>> GetAllCards()
    {
        var cards = await _repository.GetCardsAsync();
        if (cards == null)
        {
            return NotFound("No Card found.");
        }
        return Ok(cards);
    }
    [HttpPost]
    public async Task<ActionResult<Card>> CreateNewCard(Card newCard)
    {
        var card = new Card
        {
            Name = newCard.Name,
            NationalId = newCard.NationalId
        };
        await _repository.CreateNewCardAsync(card);
        return CreatedAtAction(nameof(GetCardById), new { id = card.Id }, card);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Card>> UpdateTheCardById(Card updatedCard , int id)
    {
        if (id != updatedCard.Id)
        {
            return NotFound();
        }
        var update = new Card
        {
            Name = updatedCard.Name,
            NationalId = updatedCard.NationalId
        };
        await _repository.UpdateCardAsync(update);
        return Ok(update);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCardById(int id)
    {
        var delete = await _repository.GetCardByIdAsync(id);
        if (delete != null)
        {
            await _repository.DeleteCardAsync(id);
            return NoContent();
        }
        return NotFound("no card was Deleted");
    }
}
