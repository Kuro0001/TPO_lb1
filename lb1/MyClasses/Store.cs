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
        public bool laid_out;
        public Item(string name, bool laid_out)
        {
            this.name = name;
            this.laid_out = laid_out;
        }
    }

    class Store
    {
        List<Item> list_items;
        public Store()
        {
            list_items = new List<Item>();
        }
        
        public void AddItem(string name)
        {
            list_items.Add(new Item(name, false));
        }

        public int ClearStore()
        {
            for (int i = 0; i < list_items.Count; i++)
            {
                list_items[i] = new Item(list_items[i].name, false);
            }
            return list_items.Count;
        }

        public bool PutItemOnCounter(Item item)
        {
            try
            {
                list_items[list_items.IndexOf(item)] = new Item(item.name, true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int CalculateCountOnCounter()
        {
            int result = 0;
            foreach(Item i in list_items)
            {
                if (i.laid_out) result++;
            }
            return result;
        }

        public int CalculateCountNotOnCounter()
        {
            int result = list_items.Count - CalculateCountOnCounter();
            return result;
        }

        public string GetListAsText()
        {
            string text = "";
            foreach (Item i in list_items)
            {
                text += i.name + " " + i.laid_out + '\n';
            }
            return text; ;
        }

        public List<Item> Items
        {
            get { return list_items; }
            set { list_items = value; }
        }
    }
}
