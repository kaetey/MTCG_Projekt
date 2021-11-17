using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class GamePlay
    {
        public void battle()
        {
            Deck player1Deck = new Deck();
            player1Deck.chooseDeck();
            Deck player2Deck = new Deck();
            player2Deck.chooseDeck();
            Battle battle = new Battle();
            battle.battleCards(player1Deck, player2Deck);
        }

        public void trade()
        {

        }
    }
}
