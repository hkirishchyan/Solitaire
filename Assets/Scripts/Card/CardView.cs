using System;
using System.Collections.Generic;
using Card.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Card
{
    public class CardView : MonoBehaviour, ICardView
    {
        [SerializeField] private Canvas _visualCanvas;
        [SerializeField] private List<CardVisualPack> _visualPacks;

        public Transform Transform => transform;
        public Canvas VisualCanvas => _visualCanvas;
        public Action OnCardClicked { get; set; }

        public void Initialize(CardModel model)
        {
            name = $"Card_{model.Suit}_{model.Rank}";

            foreach (var visualPack in _visualPacks)
            {
                visualPack.SuitText.text = model.Suit.ToString();
                visualPack.RankText.text = model.Rank.ToString();
            }
        }

        private void OnMouseDown()
        {
            OnCardClicked?.Invoke();
        }
    }

    [Serializable]
    public class CardVisualPack
    {
        [SerializeField] private TextMeshProUGUI _suitText;
        [SerializeField] private TextMeshProUGUI _rankText;

        public TextMeshProUGUI SuitText => _suitText;
        public TextMeshProUGUI RankText => _rankText;
    }
}