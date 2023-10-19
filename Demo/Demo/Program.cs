using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        public static Profit[] profit =new Profit[]{new Profit("a",1),new Profit("b",2),new Profit("c",1),new Profit("d",5),new Profit("e",4),new Profit("f",3),new Profit("g",1)};
        public static int findProfit(string name)
        {
            foreach(var item in profit)
            {
                if (item.Name == name)
                    return item.Value;
            }
            return 0;
        }
        public static void printDatabase(Object[] database)
        {
            int row = 1;
             foreach( List<Product> Tid in database){
               
               Console.Write(row++ +"   ");
               foreach(var product in Tid)
               {
                   Console.Write(" "+product.name+"("+product.quantity+") ");
               }
               Console.WriteLine();

            }
        }
        public static int[] findProductInDatabase(string name, Object[] database)
        {
            int[] rows=new int[]{};
            int row=0;
            foreach(List<Product> products in database)
            {
                foreach(var item in products)
                {
                    if (item.name == name)
                        rows = rows.Concat(new int[] { row }).ToArray();
                }
                row++;

            }
            return rows;
        }
        public static int twu(string name,Object[]database)
        {
            int[] rows = findProductInDatabase(name, database);
            int total=0;
            foreach(var i in rows)
                total+=tu(i,database);
            return total;

        }
        public static int u(string[] products, int row, Object[] database)
        {
            int value = 0 ;
            if (row != -1)
            {
                int count = 0;
                List<Product> Tid = (List<Product>)database[row];
                for (int i = 0; i < products.Length; i++)
                {
                    foreach (var product in Tid)
                    {
                        if (products[i] == product.name)
                        {
                            int p = findProfit(products[i]);
                            value += product.quantity * p;
                            count++;
                        }
                    }
                }
                if(count==products.Length)
                    return value;
                return 0;
            }
            else
            {
                int final=0;
                for(int i=0;i<database.Length;i++)
                {
                    value = 0;
                    int count = 0;
                    List<Product> Tid = (List<Product>)database[i];
                    for (int j = 0; j < products.Length; j++)
                    {
                        foreach (var product in Tid)
                        {
                            if (products[j] == product.name)
                            {
                                int p = findProfit(products[j]);
                                value += product.quantity * p;
                                count++;
                            }
                        }
                    }
                    if (count == products.Length)
                        final += value;
                }
                return final;
            }
        }
        
        public static int tu(int row, Object[] database)
        {
            int total = 0;
            List<Product> Tid = (List<Product>)database[row];
            
            foreach(var item in Tid)
            {
                string[] products=new string[]{item.name};

                total += u(products, row, database);
            }
            return total;
        }
        public static string[] filterByMinUtil(ref List<Profit> listTWU,int minUntil)
        {
            string[] productList=new string[]{};
            foreach(var item in listTWU)
            {
                if(item.value<minUntil)
                    productList = productList.Concat(new string[] { item.name }).ToArray();
            }
            listTWU.RemoveAll(item=>item.value<minUntil);
            listTWU=listTWU.OrderBy(x => x.value).ToList();
            return productList;
        }
        public static int getTWUByName(List<Profit> listTWU, string name)
        {
            Profit p = listTWU.SingleOrDefault(t => t.name == name);
            return p.value;
        }
        public static void Swap( List<Product> list, int A,int B)
        {
            Product temp = list[A];
            list[A] = list[B];
            list[B] = temp;
        }
        public static void orderDatabaseByListTWU(List<Profit> listTWU, Object[] database)
        {
            foreach(List<Product> products in database)
            {
                int N = products.Count;
                for (int i = 0; i < N - 1; i++)
                {
                    for (int j = i + 1; j < N; j++)
                    {
                        if (getTWUByName(listTWU, products[i].name) > getTWUByName(listTWU, products[j].name))
                            Swap(products, i, j);
                    }
                }
            }
        }
        public static void removeProductsByStringArray(Object[] database, string[] blackList)
        {
            foreach (List<Product> products in database)
            {
                foreach(var item in blackList)
                {
                    products.RemoveAll(t => t.name == item);
                }
            }

        }
        public static int ru(Object[]database, string[]st, int row)
        {
            string[] tx=new string[]{};
            List<Product> products = (List<Product>)database[row];
            int count = 0;
            foreach(var t in st)
            {
                for(int i=0;i<products.Count;i++)
                {
                    if (t == products[i].name && i != products.Count - 1)
                    {
                        count++;
                    }
                    else if(count==st.Length)
                        tx = tx.Concat(new string[] { products[i].name }).ToArray();
                }
            }
            return u(tx, row, database);
        }
        static void Main(string[] args)
        {
            string[] blackList = new string[] { };
            List<Profit> listTWU = new List<Profit>();
            int minUntil = 30;
            List<Product> Tid1 = new List<Product> { new Product("b", 1), new Product("c", 2), new Product("d", 1), new Product("g", 1) };
            List<Product> Tid2 = new List<Product> { new Product("a", 4), new Product("b", 1), new Product("c", 3), new Product("d", 1), new Product("e", 2) };
            List<Product> Tid3 = new List<Product> { new Product("a", 4), new Product("c", 2), new Product("d", 1) };
            List<Product> Tid4 = new List<Product> { new Product("c", 2), new Product("e", 1), new Product("f", 1) };
            List<Product> Tid5 = new List<Product> { new Product("a", 5), new Product("b", 2), new Product("d", 1), new Product("e", 2) };
            List<Product> Tid6 = new List<Product> { new Product("a", 3), new Product("b", 4), new Product("c", 1), new Product("f", 2) };
            List<Product> Tid7 = new List<Product> { new Product("d", 1), new Product("g", 5) };
            Object[] database = new Object[] { Tid1, Tid2, Tid3, Tid4, Tid5, Tid6, Tid7 };
            printDatabase(database);
            foreach(var product in profit)
            {
                Profit TWU=new Profit(product.Name,twu(product.Name,database));
                listTWU.Add(TWU);
            }
            Profit.printListProfit(listTWU);
            Console.WriteLine("TWU:");
            blackList=filterByMinUtil(ref listTWU, minUntil);
            removeProductsByStringArray(database, blackList);
            Profit.printListProfit(listTWU);
            orderDatabaseByListTWU(listTWU, database);
            printDatabase(database);
            Console.WriteLine("tu(1)= " + tu(0, database));
            Console.WriteLine("tu(2)= " + tu(1, database));
            Console.WriteLine("tu(3): " + tu(2, database));
            Console.WriteLine("tu(4): " + tu(3, database));
            Console.WriteLine("tu(5): " + tu(4, database));
            Console.WriteLine("tu(6): " + tu(5, database));
            Console.WriteLine("tu(7): " + tu(6, database)); 
            Console.WriteLine("ru(eb,T2)="+ ru(database, new string[] { "e","b" }, 1));
            Console.ReadLine();
        }

    }
}
