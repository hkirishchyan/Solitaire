using System;
using UnityEngine;
using UnityEngine.UI;

namespace Card.Interfaces
{
    public interface ICardView
    {
        Transform Transform { get; }
        Canvas VisualCanvas { get; }
        
        Action OnCardClicked { get; }
        void Initialize(CardModel model);
    }
}