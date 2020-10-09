using System.Collections.Generic;
using System.Linq;
using Monopoly_Simulation.Common;

namespace Monopoly_Simulation.Model
{
    public class CardDeck
    {
        private List<Card> _cardSource;
        private Stack<Card> _deck = new Stack<Card>();

        public CardDeck(List<Card> cardSource)
        {
            _cardSource = cardSource;
        }

        public Card Draw()
        {
            if (!_deck.Any())
            {
                Fill();
            }

            return _deck.Pop();
        }

        private void Fill()
        {
            _cardSource.Shuffle();
            foreach (var card in _cardSource)
            {
                _deck.Push(card);
            }
        }
    }
}