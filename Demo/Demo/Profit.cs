using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Profit
    {
        public string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int value;

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public Profit(string name,int value)
        {
            this.name = name;
            this.value = value;
        }
        public static void printListProfit(List<Profit> list)
        {
            foreach(var item in list)
                Console.WriteLine(item.Name+": "+item.Value);
        }
        
    }
}
