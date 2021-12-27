using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Battle
    {
        private int Rounds;

        public Battle() {
            this.Rounds = 0;
        }

        public void BattleCards(Deck deck1, Deck deck2)
        {
            while(this.Rounds <= 100 && deck1.GetDeckList().Count != 0 && deck2.GetDeckList().Count != 0)
            {
                ICard card1 = this.PickRandomCard(deck1, deck1.GetDeckList().Count);
                ICard card2 = this.PickRandomCard(deck2, deck2.GetDeckList().Count);

                BattleResult result = this.Attack(card1, card2);

                if(result == BattleResult.Win)  this.MoveCard();
                else if(result == BattleResult.Lose)  this.MoveCard();

                this.Rounds++;
            }
        }

        public Card PickRandomCard(Deck deck, int deckSize)
        {
            Random rnd = new Random();
            int rndIndex = rnd.Next(deckSize);
            return deck.GetCard(rndIndex);
        }

        public BattleResult Attack(Card card1, Card card2)
        {
            //return this.CompareDamage(card1, card2);
            if ((card1 is MonsterCard && card2 is MonsterCard))   // Battletype 1: Monster vs Monster
                result = this.monsterVsMonster((MonsterCard)card1, (MonsterCard)card2);
            else if (card1 is MonsterCard && card2 is SpellCard) //Battletype 2: Monster vs Spell
                result = this.monsterVsSpell((MonsterCard)card1, (SpellCard)card2);
            else if(card1 is SpellCard && card2 is MonsterCard)
                result = this.monsterVsSpell((MonsterCard)card2, (SpellCard)card1);
            else if (card1 is SpellCard && card2 is SpellCard)   //Battletype 2: Monster vs Spell
                result = this.spellVsSpell((SpellCard)card1, (SpellCard)card2);
        }

        /*public BattleResult CompareDamage(MonsterCard mcard1, MonsterCard mcard2)
        {
            BattleResult result = BattleResult.Draw;
            return result;
        }

        public BattleResult CompareDamage(MonsterCard mcard, SpellCard scard)
        {
            BattleResult result = BattleResult.Draw;
            return result;
        }

        public BattleResult CompareDamage(SpellCard scard1, SpellCard scard2)
        {
            BattleResult result = BattleResult.Draw;
            return result;
        }*/

        public BattleResult monsterVsMonster(MonsterCard mcard1, MonsterCard mcard2)
        {
            BattleResult result = BattleResult.Draw;
            switch (mcard1.Type)
            {
                case Type.Goblin:
                    if (mcard2.Type == Type.Dragon) result = BattleResult.Win_Card2;
                    else
                    {
                        if (mcard2.Damage > mcard1.Damage) result = BattleResult.Win_Card2;
                        else if (mcard2.Damage == mcard1.Damage) result = BattleResult.Draw;
                        else result = BattleResult.Win_Card1;
                    }
                    break;
                case Type.Dragon:
                    if (mcard2.Type == Type.Goblin) result = BattleResult.Win_Card1;
                    else if (mcard2.Type == Type.Elf && mcard2.ElementType == Element.Fire) result = BattleResult.Win_Card2;
                    else
                    {
                        if (mcard2.Damage > mcard1.Damage) result = BattleResult.Win_Card2;
                        else if (mcard2.Damage == mcard1.Damage) result = BattleResult.Draw;
                        else result = BattleResult.Win_Card1;
                    }
                    break;
                case Type.Wizard:
                    if (mcard2.Type == Type.Ork) result = BattleResult.Win_Card1;
                    else
                    {
                        if (mcard2.Damage > mcard1.Damage) result = BattleResult.Win_Card2;
                        else if (mcard2.Damage == mcard1.Damage) result = BattleResult.Draw;
                        else result = BattleResult.Win_Card1;
                    }
                    break;
                case Type.Ork:
                    if (mcard2.Type == Type.Wizard) result = BattleResult.Win_Card2;
                    else
                    {
                        if (mcard2.Damage > mcard1.Damage) result = BattleResult.Win_Card2;
                        else if (mcard2.Damage == mcard1.Damage) result = BattleResult.Draw;
                        else result = BattleResult.Win_Card1;
                    }
                    break;
                case Type.Knight:
                    if (mcard2.Damage > mcard1.Damage) result = BattleResult.Win_Card2;
                    else if (mcard2.Damage == mcard1.Damage) result = BattleResult.Draw;
                    else result = BattleResult.Win_Card1;
                    break;
                case Type.Kraken:
                    if (mcard2.Damage > mcard1.Damage) result = BattleResult.Win_Card2;
                    else if (mcard2.Damage == mcard1.Damage) result = BattleResult.Draw;
                    else result = BattleResult.Win_Card1;
                    break;
                case Type.Elf:
                    if (mcard2.Type == Type.Dragon && mcard1.ElementType == Element.Fire) result = BattleResult.Win;
                    else
                    {
                        if (mcard2.Damage > mcard1.Damage) result = BattleResult.Win_Card2;
                        else if (mcard2.Damage == mcard1.Damage) result = BattleResult.Draw;
                        else result = BattleResult.Win_Card1;
                    }
                    break;
                case Type.Troll:
                    if (mcard2.Damage > mcard1.Damage) result = BattleResult.Win_Card2;
                    else if (mcard2.Damage == mcard1.Damage) result = BattleResult.Draw;
                    else result = BattleResult.Win_Card1;
                    break;
            }
            return result;
        }

        public BattleResult monsterVsSpell(MonsterCard mcard, SpellCard scard)
        {
            BattleResult result = BattleResult.Draw;   // result of spellcard
            if (mcard.Type == Type.Kraken) result = BattleResult.Win_Card1;
            else
            {
                switch (scard.ElementType)
                {
                    case Element.Fire:
                        if (mcard.ElementType == Element.Fire)
                        {
                            if (mcard.Damage > scard.Damage) result = BattleResult.Win_Card1;
                            else if (mcard.Damage == scard.Damage) result = BattleResult.Draw;
                            else result = BattleResult.Win_Card2;
                        }
                        else if (mcard.ElementType == Element.Water)
                        {
                            if ((mcard.Damage * 2) > (scard.Damage / 2)) result = BattleResult.Win_Card1;
                            else if ((mcard.Damage * 2) == (scard.Damage / 2)) result = BattleResult.Draw;
                            else result = BattleResult.Win_Card2;
                        }
                        else if (mcard.ElementType == Element.Normal)
                        {
                            if ((mcard.Damage / 2) > (scard.Damage * 2)) result = BattleResult.Win_Card1;
                            else if ((mcard.Damage / 2) == (scard.Damage * 2)) result = BattleResult.Draw;
                            else result = BattleResult.Win_Card2;
                        }
                        break;
                    case Element.Water:
                        if (mcard.Type == Type.Knight) result = BattleResult.Win_Card2;
                        else if (mcard.ElementType == Element.Fire)
                        {
                            if ((mcard.Damage / 2) > (scard.Damage * 2)) result = BattleResult.Win_Card1;
                            else if ((mcard.Damage / 2) == (scard.Damage * 2)) result = BattleResult.Draw;
                            else result = BattleResult.Win_Card2;
                        }
                        else if (mcard.ElementType == Element.Water)
                        {
                            if (mcard.Damage > scard.Damage) result = BattleResult.Win_Card1;
                            else if (mcard.Damage == scard.Damage) result = BattleResult.Draw;
                            else result = BattleResult.Win_Card2;
                        }
                        else if (mcard.ElementType == Element.Normal)
                        {
                            if ((mcard.Damage * 2) > (scard.Damage / 2)) result = BattleResult.Win_Card1;
                            else if ((mcard.Damage * 2) == (scard.Damage / 2)) result = BattleResult.Draw;
                            else result = BattleResult.Win_Card2;
                        }
                        break;
                    case Element.Normal:
                        if (mcard.ElementType == Element.Fire)
                        {
                            if ((mcard.Damage * 2) > (scard.Damage / 2)) result = BattleResult.Win_Card1;
                            else if ((mcard.Damage * 2) == (scard.Damage / 2)) result = BattleResult.Draw;
                            else result = BattleResult.Win_Card2;
                        }
                        else if (mcard.ElementType == Element.Water)
                        {
                            if ((mcard.Damage / 2) > (scard.Damage * 2)) result = BattleResult.Win_Card1;
                            else if ((mcard.Damage / 2) == (scard.Damage * 2)) result = BattleResult.Draw;
                            else result = BattleResult.Win_Card2;
                        }
                        else if (mcard.ElementType == Element.Normal)
                        {
                            if (mcard.Damage > scard.Damage) result = BattleResult.Win_Card1;
                            else if (mcard.Damage == scard.Damage) result = BattleResult.Draw;
                            else result = BattleResult.Win_Card2;
                        }
                        break;
                }
            }
            return result;
        }

        public BattleResult spellVsSpell(SpellCard scard1, SpellCard scard2)
        {
            BattleResult result = BattleResult.Draw;    //result of scard1
            switch (scard1.ElementType)
            {
                case Element.Fire:
                    if (scard2.ElementType == Element.Fire) 
                    {
                        if (scard2.Damage > scard1.Damage) result = BattleResult.Win_Card2;
                        else if (scard2.Damage == scard1.Damage) result = BattleResult.Draw;
                        else result = BattleResult.Win_Card1;
                    } 
                    else if (scard2.ElementType == Element.Water)
                    {
                        if ((scard2.Damage * 2) > (scard1.Damage / 2)) result = BattleResult.Win_Card2;
                        else if ((scard2.Damage * 2) == (scard1.Damage / 2)) result = BattleResult.Draw;
                        else result = BattleResult.Win_Card1;
                    }
                    else if (scard2.ElementType == Element.Normal)
                    {
                        if ((scard2.Damage / 2) > (scard1.Damage * 2)) result = BattleResult.Win_Card2;
                        else if ((scard2.Damage / 2) == (scard1.Damage * 2)) result = BattleResult.Draw;
                        else result = BattleResult.Win_Card1;
                    }
                    break;
                case Element.Water:
                    if (scard2.ElementType == Element.Fire)
                    {
                        if ((scard2.Damage / 2) > (scard1.Damage * 2)) result = BattleResult.Win_Card2;
                        else if ((scard2.Damage / 2) == (scard1.Damage * 2)) result = BattleResult.Draw;
                        else result = BattleResult.Win_Card1;
                    }
                    else if (scard2.ElementType == Element.Water)
                    {
                        if (scard2.Damage > scard1.Damage) result = BattleResult.Win_Card2;
                        else if (scard2.Damage == scard1.Damage) result = BattleResult.Draw;
                        else result = BattleResult.Win_Card1;
                    }
                    else if (scard2.ElementType == Element.Normal)
                    {
                        if ((scard2.Damage * 2) > (scard1.Damage / 2)) result = BattleResult.Win_Card2;
                        else if ((scard2.Damage * 2) == (scard1.Damage / 2)) result = BattleResult.Draw;
                        else result = BattleResult.Win_Card1;
                    }
                    break;
                case Element.Normal:
                    if (scard2.ElementType == Element.Fire)
                    {
                        if ((scard2.Damage * 2) > (scard1.Damage / 2)) result = BattleResult.Win_Card2;
                        else if ((scard2.Damage * 2) == (scard1.Damage / 2)) result = BattleResult.Draw;
                        else result = BattleResult.Win_Card1;
                    }
                    else if (scard2.ElementType == Element.Water)
                    {
                        if ((scard2.Damage / 2) > (scard1.Damage * 2)) result = BattleResult.Win_Card2;
                        else if ((scard2.Damage / 2) == (scard1.Damage * 2)) result = BattleResult.Draw;
                        else result = BattleResult.Win_Card1;
                    }
                    else if (scard2.ElementType == Element.Normal)
                    {
                        if (scard2.Damage > scard1.Damage) result = BattleResult.Win_Card2;
                        else if (scard2.Damage == scard1.Damage) result = BattleResult.Draw;
                        else result = BattleResult.Win_Card1;
                    }
                    break;
            }
            return result;
        }

        public void MoveCard()
        {

        }
    }
}
