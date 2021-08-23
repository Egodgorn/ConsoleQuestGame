using System;
using System.Collections.Generic;
using System.Text;

namespace Game2
{
    public struct Item 
    {
        public Item(int Id,string Name,char Icon)
        {
            id = Id;
            name = Name;
            icon = Icon;
        }
        public int id;
        public string name;
        public char icon;
    }
}
