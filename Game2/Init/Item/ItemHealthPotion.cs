using System;
using System.Collections.Generic;
using System.Text;

namespace Game2
{
    public class ItemHealthPotion
    {
        public Item HealingBottle = new Item(1, "HealingBottle",'H');
        public int _id
        {
            get { return HealingBottle.id; }
            set { HealingBottle.id = value; }
        }
        public string _name
        {
            get { return HealingBottle.name; }
            set { HealingBottle.name = value; }
        }
        public int Buff()
        {
            return 50;
        }
    }
}
