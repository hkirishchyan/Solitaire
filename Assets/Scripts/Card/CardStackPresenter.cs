using System.Collections.Generic;
using System.Threading.Tasks;
using Card.Domain.Interfaces;
using Card.Interfaces;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Card
{
    public class CardStackPresenter : ICardStackPresenter
    {
        private readonly ICardStack _domainStack;
        readonly float _offsetY = 0.3f;

        public int Count => _domainStack.Count;
        public Transform StackRoot { get; }

        public CardStackPresenter(ICardStack domainStack, Transform stackRoot)
        {
            _domainStack = domainStack;
            StackRoot = stackRoot;
        }

        public async UniTask Push(CardModel card, ICardView view)
        {
            _domainStack.Push(card);
            view.Transform.SetParent(StackRoot);
            var target = StackRoot.position + Vector3.up * (Count - 1) * _offsetY;
            await view.Transform.DOMove(target, 0.5f).SetEase(Ease.OutQuad).ToUniTask();
        }

        public CardModel Pop(ICardView view)
        {
            var card = _domainStack.Pop();
            return card;
        }
    }
}