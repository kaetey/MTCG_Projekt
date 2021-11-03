using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Card
    {
        protected string name { get; set; }
        protected int damage { get; set; }
        protected Element elementType { get; set; }
        protected Type type { get; set; }

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
