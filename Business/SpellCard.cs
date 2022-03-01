using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCG_GamePlay
{
    class SpellCard : Card
    {
        public SpellCard(string name, int damage, int element) : base(name, damage, element){}

        /*public int attack(Card enemyCard)
        {
            switch (this.elementType)
            {
                case Element.Fire:
                    switch (enemyCard.elementType){
                        case Element.Water:
                            damage = damage / 2;
                            break;
                        case Element.Normal:
                            damage = damage * 2;
                            break;
                    }
                    break;
                case Element.Water:
                    switch (enemyCard.elementType)
                    {
                        case Element.Fire:
                            damage = damage * 2;
                            break;
                        case Element.Normal:
                            damage = damage / 2;
                            break;
                    }
                    break;
                case Element.Normal:
                    switch (enemyCard.elementType)
                    {
                        case Element.Water:
                            damage = damage * 2;
                            break;
                        case Element.Fire:
                            damage = damage / 2;
                            break;
                    }
                    break;
            }

            return damage;
        }*/
    }
}
