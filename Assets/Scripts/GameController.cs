using Card;
using Card.Enums;
using Card.Interfaces;
using Command;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Card.Animation;
using Card.Animation.Interfaces;
using Card.Domain;
using Card.Domain.Interfaces;
using UnityEngine.UI;
using Utilities;

public class GameController : MonoBehaviour
{
    [Header("UI & Prefabs")] 
    [SerializeField] private Button _undoButton;
    [SerializeField] private Button _redoButton;

    [SerializeField] private Transform _stackARoot;
    [SerializeField] private Transform _stackBRoot;
    
    [SerializeField] private CardView _cardPrefab;
    [SerializeField] private int _initialCount = 5;

    private ICardStack _stackA;
    private ICardStack _stackB;
    
    private ICardStackPresenter _presA;
    private ICardStackPresenter _presB;
    
    private ICardAnimator _anim;
    private CommandManager _cmdMgr;

    private void Awake()
    {
        _stackA = new CardStack();
        _stackB = new CardStack();
        
        _presA = new CardStackPresenter(_stackA, _stackARoot);
        _presB = new CardStackPresenter(_stackB, _stackBRoot);
        
        _anim = new TweenCardAnimator();
        _cmdMgr = new CommandManager();

        _undoButton.onClick.AddListener(Undo);
        _redoButton.onClick.AddListener(Redo);
    }

    private async void Redo()
    {
        await _cmdMgr.Redo();
    }

    private async void Undo()
    {
        await _cmdMgr.Undo();
    }

    private async void Start()
    {
        await Deal(_presA);
        await Deal(_presB);
    }

    private async UniTask Deal(ICardStackPresenter pres)
    {
        for (int i = 0; i < _initialCount; i++)
        {
            var model = new CardModel(Helpers.GetRandomEnumValue<CardSuit>(), Random.Range(1, 11));
            var view = Instantiate(_cardPrefab);
            view.Initialize(model);
            view.OnCardClicked = () => OnCardClicked(view);
            view.VisualCanvas.sortingOrder = i;
            await pres.Push(model, view);
        }
    }

    private void OnCardClicked(CardView view) => _ = HandleClick(view);

    private async UniTask HandleClick(CardView view)
    {
        var from = view.transform.parent == _stackARoot ? _presA : _presB;
        var to = from == _presA ? _presB : _presA;

        var cmd = new MoveCardCommand(from, to, view, _anim);
        await _cmdMgr.Execute(cmd);
    }
}