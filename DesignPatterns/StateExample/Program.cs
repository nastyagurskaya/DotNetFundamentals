using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Water water = new Water(new LiquidWaterState());
            water.Heat();
            water.Frost();
            water.Frost();

            Console.Read();
        }
    }
    class Water
    {
        public IWaterState State { get; set; }

        public Water(IWaterState ws)
        {
            State = ws;
        }

        public void Heat()
        {
            State.Heat(this);
        }
        public void Frost()
        {
            State.Frost(this);
        }
    }

    interface IWaterState
    {
        void Heat(Water water);
        void Frost(Water water);
    }

    class SolidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Turn ice into water");
            water.State = new LiquidWaterState();
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Confinue ice freezing");
        }
    }
    class LiquidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Turn water into steam");
            water.State = new GasWaterState();
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Turn water into ice");
            water.State = new SolidWaterState();
        }
    }
    class GasWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Raise steam temperature");
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Turn steam into water");
            water.State = new LiquidWaterState();
        }
    }
}
