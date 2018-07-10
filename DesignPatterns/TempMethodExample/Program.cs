using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempMethodExample
{
    class Program
    {
        static void Main(string[] args)
        {
            WoodHouse wh = new WoodHouse();
            ConcreteHouse ch = new ConcreteHouse();

            wh.Build();
            ch.Build(); 
            Console.Read();
        }
    }
    abstract class Building
    {
        public void Build()
        {
            CreateFoundation();
            CreateWals();
            CreateRoof();
            AddFurniture();
        }
        public abstract void CreateFoundation();
        public abstract void CreateWals();
        public abstract void CreateRoof();
        public virtual void AddFurniture()
        {
            Console.WriteLine("Furniture was added");
        }
    }

    class WoodHouse : Building
    {
        public override void CreateFoundation()
        {
            Console.WriteLine("The groundwork for wood house was laid");
        }
        public override void CreateWals()
        {
            Console.WriteLine("Wood walls were put");
        }

        public override void CreateRoof()
        {
            Console.WriteLine("Wood roof was made");
        }

    }

    class ConcreteHouse : Building
    {
        public override void CreateFoundation()
        {
            Console.WriteLine("The groundwork for concrete house was laid");
        }
        public override void CreateWals()
        {
            Console.WriteLine("Concrete walls were put");
        }

        public override void CreateRoof()
        {
            Console.WriteLine("Tiling roof was made");
        }

    }
}