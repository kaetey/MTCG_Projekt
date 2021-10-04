using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    enum Element { Fire, Water, Normal }
    enum Type { Goblin, Dragon, Wizard, Ork, Knight, Kraken, Elf, Troll }

    class Card
    {
        private string name;
        private int damage;
        private Element elementType;
        private Type type;

        public string Name { get { return name; } set { } }
        public int Damage { get { return damage; } set { } }
        public Element ElementType { get { return elementType; } set { } }
        public Type Type { get { return type; } set { } }

        public Card(){}
        public Card(string name, int damage , int element, int type)
        {
            this.name = name;
            this.damage = damage;
            this.elementType = (Element)element;
            this.type = (Type)type;
        }
    }
}
