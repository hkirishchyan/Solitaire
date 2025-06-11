using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Card.Interfaces
{
    public interface ICardStackPresenter
    {
        int Count { get; }
        UniTask Push(CardModel card, ICardView view);
        CardModel Pop(ICardView view);
    }
}