using Card.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Card.Animation.Interfaces
{
    public interface ICardAnimator
    {
        UniTask AnimateMove(ICardView view, Vector3 to);
    }
}