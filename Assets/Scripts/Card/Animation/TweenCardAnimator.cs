using Card.Animation.Interfaces;
using Card.Interfaces;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Card.Animation
{
    public class TweenCardAnimator : ICardAnimator
    {
        readonly float _duration = 0.5f;

        public async UniTask AnimateMove(ICardView view, Vector3 to)
        {
            await view.Transform.DOMove(to, _duration).SetEase(Ease.OutQuad).ToUniTask();
        }
    }
}