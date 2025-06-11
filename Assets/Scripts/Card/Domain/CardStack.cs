using System;
using System.Collections.Generic;
using Card.Domain.Interfaces;

namespace Card.Domain
{
    public class CardStack : ICardStack
    {
        private readonly List<CardModel> _cards = new();
        public int Count => _cards.Count;

        public void Push(CardModel card)
        {
            if (card == null) 
                throw new ArgumentNullException(nameof(card));
            
            _cards.Add(card);
        }

        public CardModel Pop()
        {
            if (_cards.Count == 0) 
                throw new InvalidOperationException("Stack is empty");
            
            var cardModel = _cards[^1];
            _cards.RemoveAt(_cards.Count - 1);
            return cardModel;
        }

        public CardModel Peek()
        {
            if (_cards.Count == 0)
                throw new InvalidOperationException("Stack is empty");

            return _cards[^1];
        }
    }
}