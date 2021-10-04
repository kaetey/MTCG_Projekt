using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Card
    {
        private string name { get; set; }
        private int damage { get; set; }
        private Element elementType { get; set; }
        private Type type { get; set; }

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
