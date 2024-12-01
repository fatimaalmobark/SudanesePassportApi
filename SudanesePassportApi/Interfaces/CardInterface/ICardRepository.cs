using SudanesePassportApi.Models.SudaneseCard;

namespace SudanesePassportApi.Interfaces.CardInterface;

public interface ICardRepository
{
    public Task<Card> GetCardByIdAsync(int id);
    public Task<IEnumerable<Card>> GetCardsAsync();
    public Task<Card> CreateNewCardAsync(Card createCard);
    public Task<Card> UpdateCardAsync(Card updatedCard);
    public Task DeleteCardAsync(int id);
}
