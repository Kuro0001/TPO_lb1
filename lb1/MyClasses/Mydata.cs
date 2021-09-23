using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1.MyClasses
{
    public struct Item
    {
        public string name;
        public bool condition;
        public Item(string name, bool condition)
        {
            this.name = name;
            this.condition = condition;
        }
    }

    class Mydata
    {
        List<Item> list_items;
        public Mydata()
        {
            list_items = new List<Item>();
        }
        
        public void AddItem()
        {
            Random rand = new Random();
            list_items.Add(new Item("name" + (list_items.Count+1), Convert.ToBoolean(rand.Next(-1, 1))));
        }

        public int ClearList()
        {
            list_items.Clear();
            return list_items.Count;
        }

        public bool ChangeCondition(Item item)
        {
            try
            {
                list_items[list_items.IndexOf(item)] = new Item(item.name, !item.condition);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int CalculateCountTrue()
        {
            int result = 0;
            foreach(Item i in list_items)
            {
                if (i.condition) result++;
            }
            return result;
        }

        public int CalculateCountFalse()
        {
            int result = list_items.Count - CalculateCountTrue();
            return result;
        }

        public string GetText()
        {
            string text = "";
            foreach (Item i in list_items)
            {
                text += i.name + " " + i.condition + '\n';
            }
            return text;
        }

        public List<Item> Data
        {
            get { return list_items; }
            set { list_items = value; }
        }
    }
}
