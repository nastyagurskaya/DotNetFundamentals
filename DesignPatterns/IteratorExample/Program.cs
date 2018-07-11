using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop sh = new Shop();
            Reader reader = new Reader();
            reader.ViewProducts(sh);

            Console.Read();
        }
    }

    class Reader
    {
        public void ViewProducts(Shop shop)
        {
            IProdIterator iterator = shop.CreateNumerator();
            while (iterator.HasNext())
            {
                Product p = iterator.Next();
                Console.WriteLine(p.Name);
            }
        }
    }

    interface IProdIterator
    {
        bool HasNext();
        Product Next();
    }
    interface IProdNumerable
    {
        IProdIterator CreateNumerator();
        int Count { get; }
        Product this[int index] { get; }
    }
    class Product
    {
        public string Name { get; set; }
    }

    class Shop : IProdNumerable
    {
        private Product[] prods;
        public Shop()
        {
            prods = new Product[]
            {
                new Product {Name="Bread"},
                new Product {Name="Milk"},
                new Product {Name="Tomato"}
            };
        }
        public int Count
        {
            get { return prods.Length; }
        }

        public Product this[int index]
        {
            get { return prods[index]; }
        }
        public IProdIterator CreateNumerator()
        {
            return new ProdNumerator(this);
        }
    }
    class ProdNumerator : IProdIterator
    {
        IProdNumerable aggregate;
        int index = 0;
        public ProdNumerator(IProdNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public Product Next()
        {
            return aggregate[index++];
        }
    }
}
