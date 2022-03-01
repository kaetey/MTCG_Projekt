using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_GamePlay
{
    class Deck
    {
        private List<Card> deck = new List<Card>();

        public Deck() { }

        public List<Card> GetDeckList()
        {
            return this.deck;
        }

        public Card GetCard(int index)
        {
            return this.deck[index];
        }

        public void ChooseDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                //choose deck algorithm
                //use addCard();
            }
        }

        public void AddCard(Card newCard)
        {
            this.deck.Add(newCard);
        }

        public void DeleteCard(Card card)
        {
            this.deck.Remove(card);
        }


    }
}
