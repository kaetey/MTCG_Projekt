using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class MonsterCard : Card
    {
        public Type Type { get; set; }

        public MonsterCard(string name, int damage, int element, int type) : base(name, damage, element){
            this.Type = (Type)type;
        }

        /*public bool attack(Card enemyCard)
        {
            bool win = false;
            if (enemyCard is SpellCard) win = this.attackSpellCard((SpellCard)enemyCard);
            else if (enemyCard is MonsterCard) win = this.atttackMonsterCard((MonsterCard)enemyCard);
            return win;
        }

        public bool attackSpellCard(SpellCard enemyCard)
        {
            switch (enemyCard.elementType)
            {
                case Element.Fire:

                    break;
                case Element.Water:
                    break;
                case Element.Normal:
                    break;

                //beachte Knights vs WaterSpells
            }
            return false;
        }

        public bool atttackMonsterCard(MonsterCard enemyCard)
        {
            bool win;
            switch (this.type)
            {
                case Type.Goblin:
                    if (enemyCard.type == Type.Dragon) win = false;
                    else win = (enemyCard.damage > this.damage) ? false : true;
                    break;
                case Type.Dragon:
                    break;
                case Type.Wizard:
                    break;
                case Type.Ork:
                    break;
                case Type.Knight:
                    break;
                case Type.Kraken:
                    break;
                case Type.Elf:
                    break;
                case Type.Troll:
                    break;
            }
            return win;
        }*/
    }
}
