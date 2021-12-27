using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /*interface ICard
    {
        
    }*/

    class Card //: ICard
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public Element ElementType  { get; set; }

        public Card(){}
        public Card(string name, int damage , int element)
        {
            this.Name = name;
            this.Damage = damage;
            this.ElementType = (Element)element;
        }

    }

    
}
