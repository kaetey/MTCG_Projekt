using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Stack erbt von IPackages?

namespace MTCG_GamePlay
{   
    class Stack
    {
        private List<Card> stack = new List<Card>();

        public List<Card> GetStack()
        { return stack; }
        public void SetStack(List<Card> value)
        { }

        public void addCard(Card newCard)
        {

        }

        public void deleteCard()
        {

        }

        public void tradeCard()
        {

        }
    }
}
