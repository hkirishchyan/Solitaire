namespace Card.Domain.Interfaces
{
    public interface ICardStack
    {
        int Count { get; }

        void Push(CardModel card);

        CardModel Pop();

        CardModel Peek();
    }
}