using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Deck
    {
        private List<Card> deck = new List<Card>();

        public Deck() { }

        public List<Card> getDeckList()
        {
            return this.deck;
        }

        public Card getCard(int index)
        {
            return this.deck[index];
        }

        public void chooseDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                //choose deck algorithm
                //use addCard();
            }
        }

        public void addCard(Card newCard)
        {

        }

        public void deleteCard()
        {

        }


    }
}
