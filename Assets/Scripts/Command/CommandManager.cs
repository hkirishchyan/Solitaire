using System.Collections.Generic;
using Command.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Command
{
    public class CommandManager
    {
        readonly Stack<ICommand> _undo = new();
        readonly Stack<ICommand> _redo = new();

        public async UniTask Execute(ICommand cmd)
        {
            await cmd.Execute();
            _undo.Push(cmd);
            _redo.Clear();
        }

        public async UniTask Undo()
        {
            if (_undo.Count == 0) return;
            var cmd = _undo.Pop();
            await cmd.Undo();
            _redo.Push(cmd);
        }

        public async UniTask Redo()
        {
            if (_redo.Count == 0) return;
            var cmd = _redo.Pop();
            await cmd.Execute();
            _undo.Push(cmd);
        }
    }
}
