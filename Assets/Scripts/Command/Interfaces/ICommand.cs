using Cysharp.Threading.Tasks;

namespace Command.Interfaces
{
    public interface ICommand
    {
        UniTask Execute();
        UniTask Undo();
    }
}