using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Cook c = new Cook();
            CookFacade cook = new CookFacade(c);
            cook.CookFriedPotato();
            cook.CookVegSalad();
            Console.Read();
        }

        class Cook
        {
            public void Peel(String s)
            {
                Console.WriteLine(s + " was peelled");
            }
            public void Wash(String s)
            {
                Console.WriteLine(s + " was washed");
            }
            public void Slice(String s)
            {
                Console.WriteLine(s + " was slised");
            }
            public void AddDressing(String s)
            {
                Console.WriteLine("Dressing was added to " + s);
            }
            public void Fry(String s)
            {
                Console.WriteLine(s + " was fried");
            }
            public void ServeDish(String s)
            {
                Console.WriteLine(s + " was served");
            }

        }
        class CookFacade
        {
            private Cook cook;
            public CookFacade(Cook cook)
            {
                this.cook = cook;
            }
            public void CookVegSalad()
            {
                cook.Wash("Vagetables");
                cook.Slice("Vegetables");
                cook.AddDressing("Veg Salad");
                cook.ServeDish("Veg Salad");
            }
            public void CookFriedPotato()
            {
                cook.Peel("Potato");
                cook.Slice("Potato");
                cook.Fry("Potato");
                cook.ServeDish("Frided potato");
            }
        }
    }
}
