using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Sushi sushi1 = new SushiMaki();
            sushi1 = new  TobikoSushi(sushi1); 
            Console.WriteLine("Название: {0}", sushi1.Name);
            Console.WriteLine("Цена: {0}", sushi1.GetCost());

            Sushi sushi2 = new SushiNigiri();
            sushi2 = new SalmonSushi(sushi2);
            Console.WriteLine("Название: {0}", sushi2.Name);
            Console.WriteLine("Цена: {0}", sushi2.GetCost());

            Sushi sushi3 = new SushiMaki();
            sushi3 = new SalmonSushi(sushi3);
            sushi3 = new TobikoSushi(sushi3);
            Console.WriteLine("Название: {0}", sushi3.Name);
            Console.WriteLine("Цена: {0}", sushi3.GetCost());

            Console.ReadLine();
        }
    }

    abstract class Sushi
    {
        public Sushi(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class SushiMaki : Sushi
    {
        public SushiMaki() : base("Суши маки")
        { }
        public override int GetCost()
        {
            return 10;
        }
    }
    class SushiNigiri: Sushi
    {
        public SushiNigiri()
            : base("Суши нигири")
        { }
        public override int GetCost()
        {
            return 8;
        }
    }

    abstract class SushiDecorator : Sushi
    {
        protected Sushi sushi;
        public SushiDecorator(string n, Sushi sushi) : base(n)
        {
            this.sushi = sushi;
        }
    }

    class SalmonSushi : SushiDecorator
    {
        public SalmonSushi(Sushi sh)
            : base(sh.Name + " с лососем,", sh)
        { }

        public override int GetCost()
        {
            return sushi.GetCost() + 3;
        }
    }

    class TobikoSushi : SushiDecorator
    {
        public TobikoSushi(Sushi s)
            : base(s.Name + " с икрой летучей рыбы,", s)
        { }

        public override int GetCost()
        {
            return sushi.GetCost() + 5;
        }
    }
}
