using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torts
{ 
    internal class ElementsofMenu
    {

        public ElementsofMenu(int meh, string discription, int price, Action action)
        {
            this.meh = meh;
            this.Discription = discription;
            this.Price = price;
            this.Action = action;

        }

        public int meh { get; set; }
        public string Discription { get; set; }
        public int Price { get; set; }
        public Action Action { get; set; }


    }
}
