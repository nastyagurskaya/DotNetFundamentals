using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Boat auto = new Boat(4, new MotorMove());
            auto.Move();
            auto.Movable = new PaddleMove();
            auto.Move();

            Console.ReadLine();
        }
    }
    interface IMovable
    {
        void Move();
    }

    class MotorMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Moving with motor");
        }
    }

    class PaddleMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Moving with paddles");
        }
    }
    class Boat
    {
        protected int passengers; 

        public Boat(int num, IMovable mov)
        {
            this.passengers = num;
            Movable = mov;
        }
        public IMovable Movable { private get; set; }
        public void Move()
        {
            Movable.Move();
        }
    }
}