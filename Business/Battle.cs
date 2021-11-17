using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Battle
    {
        private int rounds;

        public Battle() {
            this.rounds = 0;
        }

        public void battleCards(Deck deck1, Deck deck2)
        {
            Card card1 = this.pickRandomCard(deck1, deck1.getDeckList().Count);
            Card card2 = this.pickRandomCard(deck2, deck2.getDeckList().Count);

            while(this.rounds <= 100 && deck1.getDeckList().Count != 0 && deck2.getDeckList().Count != 0)
            {
                BattleResult result = this.attack(card1, card2);

                if(result == BattleResult.Win)  this.moveCard();
                else if(result == BattleResult.Lose)  this.moveCard();

                this.rounds++;
            }
        }

        public Card pickRandomCard(Deck deck, int deckSize)
        {
            Random rnd = new Random();
            int rndIndex = rnd.Next(deckSize);
            return deck.getCard(rndIndex);
        }

        public BattleResult attack(Card card1, Card card2)
        {
            BattleResult result = BattleResult.Draw;
            if ((card1 is MonsterCard && card2 is MonsterCard))   // Battletype 1: Monster vs Monster
                result = this.monsterVsMonster((MonsterCard)card1, (MonsterCard)card2);
            else if (card1 is MonsterCard && card2 is SpellCard) //Battletype 2: Monster vs Spell
                result = this.monsterVsSpell((MonsterCard)card1, (SpellCard)card2);
            else if(card1 is SpellCard && card2 is MonsterCard)
                result = this.monsterVsSpell((MonsterCard)card2, (SpellCard)card1);
            else if (card1 is SpellCard && card2 is SpellCard)   //Battletype 2: Monster vs Spell
                result = this.spellVsSpell((SpellCard)card1, (SpellCard)card2);
            return result;
        }

        public BattleResult monsterVsMonster(MonsterCard mcard1, MonsterCard mcard2)
        {
            BattleResult result = BattleResult.Draw;    //result of mcard1
            switch (mcard1.type)
            {
                case Type.Goblin:
                    if (mcard2.type == Type.Dragon) result = BattleResult.Lose;
                    else
                    {
                        if (mcard2.damage > mcard1.damage) result = BattleResult.Lose;
                        else if (mcard2.damage == mcard1.damage) result = BattleResult.Draw;
                        else result = BattleResult.Win;
                    }
                    break;
                case Type.Dragon:
                    if (mcard2.type == Type.Goblin) result = BattleResult.Win;
                    else if (mcard2.type == Type.Elf && mcard2.elementType == Element.Fire) result = BattleResult.Lose;
                    else
                    {
                        if (mcard2.damage > mcard1.damage) result = BattleResult.Lose;
                        else if (mcard2.damage == mcard1.damage) result = BattleResult.Draw;
                        else result = BattleResult.Win;
                    }
                    break;
                case Type.Wizard:
                    if (mcard2.type == Type.Ork) result = BattleResult.Win;
                    else
                    {
                        if (mcard2.damage > mcard1.damage) result = BattleResult.Lose;
                        else if (mcard2.damage == mcard1.damage) result = BattleResult.Draw;
                        else result = BattleResult.Win;
                    }
                    break;
                case Type.Ork:
                    if (mcard2.type == Type.Wizard) result = BattleResult.Lose;
                    else
                    {
                        if (mcard2.damage > mcard1.damage) result = BattleResult.Lose;
                        else if (mcard2.damage == mcard1.damage) result = BattleResult.Draw;
                        else result = BattleResult.Win;
                    }
                    break;
                case Type.Knight:
                    if (mcard2.damage > mcard1.damage) result = BattleResult.Lose;
                    else if (mcard2.damage == mcard1.damage) result = BattleResult.Draw;
                    else result = BattleResult.Win;
                    break;
                case Type.Kraken:
                    if (mcard2.damage > mcard1.damage) result = BattleResult.Lose;
                    else if (mcard2.damage == mcard1.damage) result = BattleResult.Draw;
                    else result = BattleResult.Win;
                    break;
                case Type.Elf:
                    if (mcard2.type == Type.Dragon && mcard1.elementType == Element.Fire) result = BattleResult.Win;
                    else
                    {
                        if (mcard2.damage > mcard1.damage) result = BattleResult.Lose;
                        else if (mcard2.damage == mcard1.damage) result = BattleResult.Draw;
                        else result = BattleResult.Win;
                    }
                    break;
                case Type.Troll:
                    if (mcard2.damage > mcard1.damage) result = BattleResult.Lose;
                    else if (mcard2.damage == mcard1.damage) result = BattleResult.Draw;
                    else result = BattleResult.Win;
                    break;
            }
            return result;
        }

        public BattleResult monsterVsSpell(MonsterCard mcard, SpellCard scard)
        {
            BattleResult result = BattleResult.Draw;   // result of spellcard
            if (mcard.type == Type.Kraken) result = BattleResult.Lose;
            else
            {
                switch (scard.elementType)
                {
                    case Element.Fire:
                        if (mcard.elementType == Element.Fire)
                        {
                            if (mcard.damage > scard.damage) result = BattleResult.Lose;
                            else if (mcard.damage == scard.damage) result = BattleResult.Draw;
                            else result = BattleResult.Win;
                        }
                        else if (mcard.elementType == Element.Water)
                        {
                            if ((mcard.damage * 2) > (scard.damage / 2)) result = BattleResult.Lose;
                            else if ((mcard.damage * 2) == (scard.damage / 2)) result = BattleResult.Draw;
                            else result = BattleResult.Win;
                        }
                        else if (mcard.elementType == Element.Normal)
                        {
                            if ((mcard.damage / 2) > (scard.damage * 2)) result = BattleResult.Lose;
                            else if ((mcard.damage / 2) == (scard.damage * 2)) result = BattleResult.Draw;
                            else result = BattleResult.Win;
                        }
                        break;
                    case Element.Water:
                        if (mcard.type == Type.Knight) result = BattleResult.Lose;
                        else if (mcard.elementType == Element.Fire)
                        {
                            if ((mcard.damage / 2) > (scard.damage * 2)) result = BattleResult.Lose;
                            else if ((mcard.damage / 2) == (scard.damage * 2)) result = BattleResult.Draw;
                            else result = BattleResult.Win;
                        }
                        else if (mcard.elementType == Element.Water)
                        {
                            if (mcard.damage > scard.damage) result = BattleResult.Lose;
                            else if (mcard.damage == scard.damage) result = BattleResult.Draw;
                            else result = BattleResult.Win;
                        }
                        else if (mcard.elementType == Element.Normal)
                        {
                            if ((mcard.damage * 2) > (scard.damage / 2)) result = BattleResult.Lose;
                            else if ((mcard.damage * 2) == (scard.damage / 2)) result = BattleResult.Draw;
                            else result = BattleResult.Win;
                        }
                        break;
                    case Element.Normal:
                        if (mcard.elementType == Element.Fire)
                        {
                            if ((mcard.damage * 2) > (scard.damage / 2)) result = BattleResult.Lose;
                            else if ((mcard.damage * 2) == (scard.damage / 2)) result = BattleResult.Draw;
                            else result = BattleResult.Win;
                        }
                        else if (mcard.elementType == Element.Water)
                        {
                            if ((mcard.damage / 2) > (scard.damage * 2)) result = BattleResult.Lose;
                            else if ((mcard.damage / 2) == (scard.damage * 2)) result = BattleResult.Draw;
                            else result = BattleResult.Win;
                        }
                        else if (mcard.elementType == Element.Normal)
                        {
                            if (mcard.damage > scard.damage) result = BattleResult.Lose;
                            else if (mcard.damage == scard.damage) result = BattleResult.Draw;
                            else result = BattleResult.Win;
                        }
                        break;
                }
            }
            return result;
        }

        public BattleResult spellVsSpell(SpellCard scard1, SpellCard scard2)
        {
            BattleResult result = BattleResult.Draw;    //result of scard1
            switch (scard1.elementType)
            {
                case Element.Fire:
                    if (scard2.elementType == Element.Fire) 
                    {
                        if (scard2.damage > scard1.damage) result = BattleResult.Lose;
                        else if (scard2.damage == scard1.damage) result = BattleResult.Draw;
                        else result = BattleResult.Win;
                    } 
                    else if (scard2.elementType == Element.Water)
                    {
                        if ((scard2.damage * 2) > (scard1.damage / 2)) result = BattleResult.Lose;
                        else if ((scard2.damage * 2) == (scard1.damage / 2)) result = BattleResult.Draw;
                        else result = BattleResult.Win;
                    }
                    else if (scard2.elementType == Element.Normal)
                    {
                        if ((scard2.damage / 2) > (scard1.damage * 2)) result = BattleResult.Lose;
                        else if ((scard2.damage / 2) == (scard1.damage * 2)) result = BattleResult.Draw;
                        else result = BattleResult.Win;
                    }
                    break;
                case Element.Water:
                    if (scard2.elementType == Element.Fire)
                    {
                        if ((scard2.damage / 2) > (scard1.damage * 2)) result = BattleResult.Lose;
                        else if ((scard2.damage / 2) == (scard1.damage * 2)) result = BattleResult.Draw;
                        else result = BattleResult.Win;
                    }
                    else if (scard2.elementType == Element.Water)
                    {
                        if (scard2.damage > scard1.damage) result = BattleResult.Lose;
                        else if (scard2.damage == scard1.damage) result = BattleResult.Draw;
                        else result = BattleResult.Win;
                    }
                    else if (scard2.elementType == Element.Normal)
                    {
                        if ((scard2.damage * 2) > (scard1.damage / 2)) result = BattleResult.Lose;
                        else if ((scard2.damage * 2) == (scard1.damage / 2)) result = BattleResult.Draw;
                        else result = BattleResult.Win;
                    }
                    break;
                case Element.Normal:
                    if (scard2.elementType == Element.Fire)
                    {
                        if ((scard2.damage * 2) > (scard1.damage / 2)) result = BattleResult.Lose;
                        else if ((scard2.damage * 2) == (scard1.damage / 2)) result = BattleResult.Draw;
                        else result = BattleResult.Win;
                    }
                    else if (scard2.elementType == Element.Water)
                    {
                        if ((scard2.damage / 2) > (scard1.damage * 2)) result = BattleResult.Lose;
                        else if ((scard2.damage / 2) == (scard1.damage * 2)) result = BattleResult.Draw;
                        else result = BattleResult.Win;
                    }
                    else if (scard2.elementType == Element.Normal)
                    {
                        if (scard2.damage > scard1.damage) result = BattleResult.Lose;
                        else if (scard2.damage == scard1.damage) result = BattleResult.Draw;
                        else result = BattleResult.Win;
                    }
                    break;
            }
            return result;
        }

        public void moveCard()
        {

        }
    }
}
