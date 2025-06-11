using Card;
using Card.Animation.Interfaces;
using Card.Interfaces;
using Command.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Command
{
    public class MoveCardCommand : ICommand
    {
        private readonly ICardStackPresenter _from;
        private readonly ICardStackPresenter _to;
        private readonly ICardView _view;
        private readonly ICardAnimator _anim;

        public MoveCardCommand(ICardStackPresenter from, ICardStackPresenter to,
            ICardView view, ICardAnimator anim)
        {
            _from = from;
            _to = to;
            _view = view;
            _anim = anim;
        }

        public async UniTask Execute()
        {
            var model = _from.Pop(_view);
            
            Vector3 target = _to is CardStackPresenter presenter ? presenter.StackRoot.position + Vector3.up * (presenter.Count) * 0.3f : Vector3.zero;
            
            await _anim.AnimateMove(_view, target);
            await _to.Push(model, _view);
        }

        public async UniTask Undo()
        {
            var model = _to.Pop(_view);
            Vector3 backTarget = _from is CardStackPresenter p ? p.StackRoot.position + Vector3.up * (p.Count) * 0.3f
                : Vector3.zero;
            await _anim.AnimateMove(_view, backTarget);
            await _from.Push(model, _view);
        }
    }
}