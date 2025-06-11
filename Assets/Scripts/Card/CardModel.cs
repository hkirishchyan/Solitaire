using Card.Enums;

namespace Card
{
    public class CardModel
    {
        public CardSuit Suit { get; }
        public int Rank { get; }

        public CardModel(CardSuit suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}