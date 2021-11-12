using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class MonsterCard : Card
    {
        private Type type { get; set; }

        public MonsterCard(string name, int damage, int element, int type) : base(name, damage, element){
            this.type = (Type)type;
        }

        public void attack(Card enemyCard)
        {
            if (enemyCard is SpellCard) this.attackSpellCard();
            else if (enemyCard is MonsterCard) this.atttackMonsterCard();
        }

        public void attackSpellCard()
        {
            switch (this.elementType)
            {
                case Element.Fire:
                    //damage enemyCard
                    break;
                case Element.Water:
                    break;
                case Element.Normal:
                    break;
            }
        }

        public void atttackMonsterCard()
        {
            //normal damage?
        }
    }
}
