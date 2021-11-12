using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class Card
    {
        public string name { get; set; }
        public int damage { get; set; }
        public Element elementType { get; set; }

        public Card(){}
        public Card(string name, int damage , int element)
        {
            this.name = name;
            this.damage = damage;
            this.elementType = (Element)element;
        }

    }
}
