using Microsoft.EntityFrameworkCore;
using SudanesePassportApi.Data;
using SudanesePassportApi.Models.SudaneseCard;

namespace SudanesePassportApi.Interfaces.CardInterface;

public class CardRepository : ICardRepository
{
    private readonly DataContext _context;

    public CardRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<Card> GetCardByIdAsync(int id)
    {
        var GetById = await _context.Cards.FindAsync(id);
        return GetById!;
    }

    public async Task<IEnumerable<Card>> GetCardsAsync()
    {
        return await _context.Cards.ToListAsync();
    }
    public async Task<Card> CreateNewCardAsync(Card createCard)
    {
        _context.Cards.Add(createCard);
        await _context.SaveChangesAsync();
        return createCard;
    }
    public async Task<Card> UpdateCardAsync(Card updatedCard)
    {
         _context.Cards.Entry(updatedCard).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return updatedCard;
    }
    public async Task DeleteCardAsync(int id)
    {
        var delete = await _context.Cards.FindAsync(id);
        if (delete != null)
        {
            _context.Cards.Remove(delete);
            await _context.SaveChangesAsync();
        }
    }
}
