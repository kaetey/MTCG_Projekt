using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class GamePlay
    {
        public void Battle()
        {
            Deck player1Deck = new Deck();
            player1Deck.ChooseDeck();
            Deck player2Deck = new Deck();
            player2Deck.ChooseDeck();
            Battle battle = new Battle();
            battle.BattleCards(player1Deck, player2Deck);
        }

        public void Trade()
        {

        }
    }
}
